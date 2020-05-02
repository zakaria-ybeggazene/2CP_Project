Imports System.Data.OleDb

Public Class Repository
    'connection a la base de donnée s'ouvre au debut de l'application
    Private Shared _connection As New System.Data.OleDb.OleDbConnection()

    'booleen indiquant le mode de connexion, admin ou simple utilisateur
    Public Shared admin As Boolean = True
    'le mdp du simple utilisateur appliqué a lui la fonction de hachage, qui represente le mdp de la bdd
    Public Shared userpwd As String

    's'execute lors de la connexion de l'utilisateur
    Public Shared Sub initialiser(ByVal password As String)
        'initialiser la connexion avec la bdd
        Dim dbConnString As String
        'chemin de la bdd qui est : chemin du dossier courant + nom de la bdd
        Dim path As String = My.Computer.FileSystem.CurrentDirectory & "\db.accdb"
        'initialisation du userpwd
        userpwd = Util.GetHash(password).Substring(0, 14)
        dbConnString = "provider=microsoft.ace.oledb.12.0;data source=" & path & ";Jet OLEDB:Database Password=" & userpwd & ";"

        _connection.ConnectionString = dbConnString
        'ouverture de la connexion
        _connection.Open()

        'initialiser la liste des matieres
        'Vu que le nombre de matieres est limité, on prefere charger la liste des matiere a la memoire centrale au debut de l'application
        'ce qui permettra d'eviter des requetes a la bdd si on a besoin d'acceder a des informations d'une certaine matiere
        Dim matieres As List(Of Matiere) = New List(Of Matiere)()

        Dim sqlCommand As String

        sqlCommand = "SELECT COMAMA,OPTIMA,ANETMA,LibeMA ,CoefMA FROM MATIERE;"

        Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
        Dim dr As System.Data.OleDb.OleDbDataReader

        dr = cmd.ExecuteReader()

        Dim m As Matiere
        Do While dr.Read
            m = New Matiere With {.CodMat = Util.dbNullToString(dr.Item("COMAMA")),
                                  .Coef = dr.Item("CoefMA"),
                                  .LibeMat = Util.dbNullToString(dr.Item("LibeMA")),
                                  .NiveauM = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIMA")), Util.dbNullToString(dr.Item("ANETMA")))}
            matieres.Add(m)
        Loop

        'initialiser la liste des matieres dans la classe Matiere
        Matiere.initialiserMatieres(matieres)

        dr.Close()

    End Sub

    Public Shared Sub disposer()
        'fermer la connection base de donnée
        _connection.Close()
    End Sub

    'Recherche les etudiants selon les criteres saisies
    Public Shared Function recherche_etudiants(ByVal matricule As String, ByVal nom As String, ByVal prenom As String, ByVal nomA As String, ByVal prenomA As String, ByVal dateNais As String, ByVal sexe As String, ByVal annee As String, ByVal wilayaNaissance As String, ByVal lieuNaissance As String) As List(Of Etudiant)
        Dim etudiants As List(Of Etudiant) = New List(Of Etudiant)()
        Try
            'verification de l'etat de la connection
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim contientAnnee As Boolean = True
            If annee = "" Then
                contientAnnee = False
            End If


            Dim sqlCommand As String

            'si on a specifié le matricule ou on a pas precisé comme critere l'année ou l'etudiant a etudié on a pas besoin
            'de faire la jointure avec la table etude
            If Not contientAnnee Or matricule <> "" Then

                sqlCommand = "SELECT MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais, LieuNaisA, " _
                                        & "Lieunais, WilayaNaisA, Adresse, Ville, Wilaya, CodPost, Sexe, Fils_de, Et_de, " _
                                        & "ANNEEBAC, SERIEBAC, MOYBAC, WILBAC FROM ETUDIANT "

            Else
                sqlCommand = "SELECT ETUDIANT.MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais,LieuNaisA , " _
                                               & "Lieunais ,WilayaNaisA,Adresse ,Ville ,Wilaya ,CodPost ,Sexe ,Fils_de ,Et_de, ANNEEBAC, " _
                                               & "SERIEBAC, MOYBAC, WILBAC, ETUDE.ANNEE FROM ETUDIANT INNER JOIN ETUDE ON ETUDE.MATRICULE = ETUDIANT.MATRICULE "
            End If

            'Si on a specifié le matricule on ignore les autres critéres
            If matricule <> "" Then
                sqlCommand += "WHERE MATRICULE = '" & matricule & "' "
            Else
                Dim condition As String = ""
                Dim hasCondition As Boolean = False

                If nom <> "" Then
                    condition = "NomEtud LIKE '%" & nom & "%' "
                    hasCondition = True
                End If
                If prenom <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "Prenoms LIKE '%" & prenom & "%' "
                    hasCondition = True
                End If
                If nomA <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "NomEtudA LIKE '%" & nomA & "%' "
                    hasCondition = True
                End If
                If prenomA <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "PrenomsA LIKE '%" & prenomA & "%' "
                    hasCondition = True
                End If
                If wilayaNaissance <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "WilayaNaisA LIKE '%" & wilayaNaissance & "%' "
                    hasCondition = True
                End If
                If lieuNaissance <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "Lieunais LIKE '%" & lieuNaissance & "%' "
                    hasCondition = True
                End If
                If sexe <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "Sexe = " & sexe & " "
                    hasCondition = True
                End If
                If dateNais <> "" Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "DateNais = '" & dateNais & "' "
                    hasCondition = True
                End If
                If contientAnnee Then
                    If hasCondition Then
                        condition += "And "
                    End If
                    condition += "ANNEE = '" & annee & "' "
                    hasCondition = True
                End If
                If hasCondition Then
                    sqlCommand += "WHERE " & condition
                End If
            End If
            sqlCommand += ";"

            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()

            Dim etudiant As Etudiant
            Do While dr.Read()
                etudiant = New Etudiant With {.Adresse = Util.dbNullToString(dr.Item("Adresse")),
                                                  .CodePostal = Util.dbNullToString(dr.Item("CodPost")),
                                                  .DateNais = Util.dbNullToString(dr.Item("DateNais")),
                                                  .LieuNais = Util.dbNullToString(dr.Item("LieuNais")),
                                                  .LieuNaisA = Util.dbNullToString(dr.Item("LieuNaisA")),
                                                  .Matricule = Util.dbNullToString(dr.Item("MATRICULE")),
                                                  .Nom = Util.dbNullToString(dr.Item("NomEtud")),
                                                  .NomA = Util.dbNullToString(dr.Item("NomEtudA")),
                                                  .NomMere = Util.dbNullToString(dr.Item("Et_de")),
                                                  .Prenom = Util.dbNullToString(dr.Item("Prenoms")),
                                                  .PrenomA = Util.dbNullToString(dr.Item("PrenomsA")),
                                                  .PrenomPere = Util.dbNullToString(dr.Item("Fils_de")),
                                                  .Ville = Util.dbNullToString(dr.Item("Ville")),
                                                  .Wilaya = Util.dbNullToString(dr.Item("Wilaya")),
                                                  .Sexe = Util.dbNullToString(dr.Item("Sexe")),
                                                  .WilayaNaisA = Util.dbNullToString(dr.Item("WilayaNaisA")),
                                                  .AnneeBac = Util.dbNullToString(dr.Item("ANNEEBAC")),
                                                  .MoyenneBac = Util.dbNullToDouble(dr.Item("MOYBAC")),
                                                  .SerieBac = Util.dbNullToString(dr.Item("SERIEBAC")),
                                                  .WilayaBac = Util.dbNullToString(dr.Item("WILBAC"))}
                etudiants.Add(etudiant)
            Loop

            dr.Close()
            Return etudiants
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    'Recupere le parcours d'un etudiant donné
    'ceci dit toutes les années etudiées a l'etablissement
    Public Shared Function paracours_etudiant(ByVal etudiant As Etudiant) As EtudiantParcours
        Dim parcours As List(Of AnneeEtude) = New List(Of AnneeEtude)()
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim sqlCommand As String

            sqlCommand = "SELECT MATRICULE, ETUDE.ANNEE, ETUDE.OPTIIN, ETUDE.ANETIN, ETUDE.CycIN , NumGrp , NumScn, Moyenne, RangIN , MentIN, ElimIN, RatIN, DECIIN, NbInscrits " _
                        & "FROM ETUDE INNER JOIN PROMO ON PROMO.ANNEE = ETUDE.ANNEE AND PROMO.OPTIIN = ETUDE.OPTIIN AND PROMO.ANETIN = ETUDE.ANETIN " _
                        & "WHERE MATRICULE = '" & etudiant.Matricule & "' ORDER BY ETUDE.ANETIN ASC;"


            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader
            dr = cmd.ExecuteReader()

            Dim anneEtude As AnneeEtude
            Do While dr.Read()
                anneEtude = New AnneeEtude With {.Decision = Util.dbNullToString(dr.Item("DECIIN")),
                                                 .Annee = Util.dbNullToString(dr.Item("ANNEE")).Trim(),
                                                 .Groupe = Util.dbNullToInteger(dr.Item("NumGrp")),
                                                 .Mention = Util.dbNullToString(dr.Item("MentIN")),
                                                 .MoyenneJ = Util.dbNullToDouble(dr.Item("Moyenne")),
                                                 .Niveau = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIIN")), Util.dbNullToString(dr.Item("ANETIN"))),
                                                 .Section = Util.dbNullToString(dr.Item("NumScn")),
                                                 .Rang = Util.dbNullToInteger(dr.Item("RangIN")),
                                                 .NbrEtudiants = Util.dbNullToInteger(dr.Item("NbInscrits")),
                                                 .RatrIn = Util.dbNullToInteger(dr.Item("RatIn")),
                                                 .AnnetIn = Util.dbNullToInteger(dr.Item("ANETIN"))}
                parcours.Add(anneEtude)
            Loop
            dr.Close()

            Dim notes As Dictionary(Of Matiere, Note)
            For Each a As AnneeEtude In parcours
                notes = New Dictionary(Of Matiere, Note)()
                cmd.CommandText = "SELECT MATRICULE,ANNEE,OPTIN,ANETIN, ComaMa, CycNO, NoJuNo, NoSyNo,NoRaNo ,ElimNo ,RatrNo FROM ETUDNOTE " _
                                & "WHERE MATRICULE = '" & etudiant.Matricule & "' AND ANNEE = '" & a.Annee & "' AND OPTIN = '" & Util.GetOption(a.Niveau) & "' AND ANETIN = '" & Util.GetAnneEt(a.Niveau) & "';"
                dr = cmd.ExecuteReader()
                Dim n As Note
                Do While dr.Read
                    n = New Note With {.Noju = Util.dbNullToDouble(dr.Item("NoJuNo")),
                                          .Nosy = Util.dbNullToDouble(dr.Item("NoSyNo")),
                                          .Nora = Util.dbNullToDouble(dr.Item("NoRaNo")),
                                          .Ratrapage = Util.dbNullToInteger(dr.Item("RatrNo")),
                                          .Eliminatoire = Util.dbNullToString(dr.Item("ElimNo")).Equals("0")}

                    notes.Add(Matiere.getMatiere(Util.dbNullToString(dr.Item("ComaMa")), a.Niveau), n)
                Loop
                dr.Close()

                If a.RatrIn > 0 Then
                    sqlCommand = "SELECT MoyeRa,MentRa,ElimRa " _
                                & "FROM RATTRAP " _
                                & "WHERE MATRICULE = '" & etudiant.Matricule & "' AND ANNEE = '" & a.Annee & "' AND OPTIRA = '" & Util.GetOption(a.Niveau) & "' AND ANETRA = '" & Util.GetAnneEt(a.Niveau) & "';"

                    cmd.CommandText = sqlCommand
                    dr = cmd.ExecuteReader

                    If (dr.Read()) Then
                        Util.dbNullToDouble(dr.Item("MoyeRa"))
                        Util.dbNullToInteger(dr.Item("MentRa"))
                        Util.dbNullToInteger(dr.Item("ElimRa"))
                        a.Rattrap = New AnneeEtude.Rattrapage With {.MoyenneR = Util.dbNullToDouble(dr.Item("MoyeRa")),
                                                                .MentionR = Util.dbNullToInteger(dr.Item("MentRa")),
                                                                .Elim = Util.dbNullToInteger(dr.Item("ElimRa"))}
                    End If


                    dr.Close()
                End If

                a.Notes = notes
            Next

            Dim etudiantP As EtudiantParcours = New EtudiantParcours With {.Adresse = etudiant.Adresse,
                                                  .CodePostal = etudiant.CodePostal,
                                                  .DateNais = etudiant.DateNais,
                                                  .LieuNais = etudiant.LieuNais,
                                                  .LieuNaisA = etudiant.LieuNaisA,
                                                  .Matricule = etudiant.Matricule,
                                                  .Nom = etudiant.Nom,
                                                  .NomA = etudiant.NomA,
                                                  .NomMere = etudiant.NomMere,
                                                  .Prenom = etudiant.Prenom,
                                                  .PrenomA = etudiant.PrenomA,
                                                  .PrenomPere = etudiant.PrenomPere,
                                                  .Ville = etudiant.Ville,
                                                  .Wilaya = etudiant.Wilaya,
                                                  .Sexe = etudiant.Sexe,
                                                  .WilayaNaisA = etudiant.WilayaNaisA}
            parcours.Sort(AddressOf Util.compareAnneEtude)
            etudiantP.Parcours = parcours

            Return etudiantP
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function recherche_promo(ByVal niveau As Niveau, ByVal annee As String) As PromotionAnnee
        Dim promotion As PromotionAnnee
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim sqlCommand As String

            sqlCommand = "SELECT ANNEE, OPTIIN, ANETIN, NbInscrits FROM PROMO " _
                        & "WHERE ANNEE = '" & annee & "' AND OPTIIN = '" & Util.GetOption(niveau) & "' AND ANETIN = '" & Util.GetAnneEt(niveau) & "';"


            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                promotion = New PromotionAnnee With {.Annee = annee, .NiveauP = niveau, .NbInscrits = Util.dbNullToInteger(dr.Item("NbInscrits"))}


                dr.Close()

                sqlCommand = "SELECT ETUDIANT.MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais,LieuNaisA , " _
                                            & "Lieunais ,WilayaNaisA,Adresse ,Ville ,Wilaya ,CodPost ,Sexe ,Fils_de ,Et_de, " _
                                            & "ETUDE.ANNEE, ETUDE.OPTIIN, ETUDE.ANETIN, ETUDE.CycIN , NumGrp , NumScn, Moyenne, RangIN , MentIN, ElimIN, RatIN, DECIIN " _
                                            & "FROM ETUDE INNER JOIN ETUDIANT ON ETUDE.MATRICULE = ETUDIANT.MATRICULE " _
                    & "WHERE ANNEE = '" & annee & "' AND OPTIIN = '" & Util.GetOption(niveau) & "' AND ANETIN = '" & Util.GetAnneEt(niveau) & "' ORDER BY ETUDE.Moyenne DESC;"
                Dim etudiants As List(Of EtudiantAnnee) = New List(Of EtudiantAnnee)()

                cmd.CommandText = sqlCommand
                dr = cmd.ExecuteReader()

                Dim etudiant As EtudiantAnnee
                Dim anneEtude As AnneeEtude
                Do While dr.Read()
                    anneEtude = New AnneeEtude With {.Decision = Util.dbNullToString(dr.Item("DECIIN")),
                                     .Annee = Util.dbNullToString(dr.Item("ANNEE")).Trim(),
                                     .Groupe = Util.dbNullToInteger(dr.Item("NumGrp")),
                                     .Mention = Util.dbNullToString(dr.Item("MentIN")),
                                     .MoyenneJ = Util.dbNullToDouble(dr.Item("Moyenne")),
                                     .Niveau = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIIN")).Trim(), Util.dbNullToString(dr.Item("ANETIN")).Trim()),
                                     .Section = Util.dbNullToString(dr.Item("NumScn")),
                                     .Rang = Util.dbNullToInteger(dr.Item("RangIN")),
                                     .NbrEtudiants = promotion.NbInscrits,
                                     .RatrIn = Util.dbNullToInteger(dr.Item("RatIn"))}

                    etudiant = New EtudiantAnnee With {.Adresse = Util.dbNullToString(dr.Item("Adresse")),
                                                  .CodePostal = Util.dbNullToString(dr.Item("CodPost")),
                                                  .DateNais = Util.dbNullToString(dr.Item("DateNais")),
                                                  .LieuNais = Util.dbNullToString(dr.Item("LieuNais")),
                                                  .LieuNaisA = Util.dbNullToString(dr.Item("LieuNaisA")),
                                                  .Matricule = Util.dbNullToString(dr.Item("MATRICULE")),
                                                  .Nom = Util.dbNullToString(dr.Item("NomEtud")),
                                                  .NomA = Util.dbNullToString(dr.Item("NomEtudA")),
                                                  .NomMere = Util.dbNullToString(dr.Item("Et_de")),
                                                  .Prenom = Util.dbNullToString(dr.Item("Prenoms")),
                                                  .PrenomA = Util.dbNullToString(dr.Item("PrenomsA")),
                                                  .PrenomPere = Util.dbNullToString(dr.Item("Fils_de")),
                                                  .Ville = Util.dbNullToString(dr.Item("Ville")),
                                                  .Wilaya = Util.dbNullToString(dr.Item("Wilaya")),
                                                  .Sexe = Util.dbNullToString(dr.Item("Sexe")),
                                                  .WilayaNaisA = Util.dbNullToString(dr.Item("WilayaNaisA")),
                                                       .Annee = anneEtude}
                    If Not etudiants.Contains(etudiant) Then
                        etudiants.Add(etudiant)
                    End If
                Loop
                dr.Close()

                Dim notes As Dictionary(Of Matiere, Note)
                For Each etudiant In etudiants
                    anneEtude = etudiant.Annee
                    notes = New Dictionary(Of Matiere, Note)()
                    cmd.CommandText = "SELECT MATRICULE,ANNEE,OPTIN,ANETIN, ComaMa, CycNO, NoJuNo, NoSyNo,NoRaNo ,ElimNo ,RatrNo FROM ETUDNOTE " _
                                    & "WHERE MATRICULE = '" & etudiant.Matricule & "' AND ANNEE = '" & anneEtude.Annee & "' AND OPTIN = '" & Util.GetOption(anneEtude.Niveau) & "' AND ANETIN = '" & Util.GetAnneEt(anneEtude.Niveau) & "';"
                    dr = cmd.ExecuteReader()
                    Dim n As Note
                    Do While dr.Read
                        n = New Note With {.Noju = Util.dbNullToDouble(dr.Item("NoJuNo")),
                                              .Nosy = Util.dbNullToDouble(dr.Item("NoSyNo")),
                                              .Nora = Util.dbNullToDouble(dr.Item("NoRaNo")),
                                              .Ratrapage = Util.dbNullToInteger(dr.Item("RatrNo")),
                                              .Eliminatoire = Util.dbNullToString(dr.Item("ElimNo")).Equals("0")}

                        notes.Add(Matiere.getMatiere(Util.dbNullToString(dr.Item("ComaMa")), anneEtude.Niveau), n)
                    Loop
                    dr.Close()

                    If anneEtude.RatrIn > 0 Then
                        sqlCommand = "SELECT MoyeRa,MentRa,ElimRa " _
                                    & "FROM RATTRAP " _
                                    & "WHERE MATRICULE = '" & etudiant.Matricule & "' AND ANNEE = '" & anneEtude.Annee & "' AND OPTIRA = '" & Util.GetOption(anneEtude.Niveau) & "' AND ANETRA = '" & Util.GetAnneEt(anneEtude.Niveau) & "';"

                        cmd.CommandText = sqlCommand
                        dr = cmd.ExecuteReader

                        If (dr.Read()) Then
                            Util.dbNullToDouble(dr.Item("MoyeRa"))
                            Util.dbNullToInteger(dr.Item("MentRa"))
                            Util.dbNullToInteger(dr.Item("ElimRa"))
                            anneEtude.Rattrap = New AnneeEtude.Rattrapage With {.MoyenneR = Util.dbNullToDouble(dr.Item("MoyeRa")),
                                                                    .MentionR = Util.dbNullToInteger(dr.Item("MentRa")),
                                                                    .Elim = Util.dbNullToInteger(dr.Item("ElimRa"))}
                        End If


                        dr.Close()
                    End If

                    anneEtude.Notes = notes
                    etudiant.Annee = anneEtude
                Next

                Dim moyenneMatiere As Dictionary(Of Matiere, Decimal) = New Dictionary(Of Matiere, Decimal)()
                cmd.CommandText = "SELECT COMAMA, MoyenneMA FROM MOYMAT " _
                                & "WHERE ANNEE = '" & annee & "' AND OPTIMA = '" & Util.GetOption(niveau) & "' AND ANETMA = '" & Util.GetAnneEt(niveau) & "';"
                dr = cmd.ExecuteReader()
                Do While dr.Read
                    Dim matiere As Matiere = matiere.getMatiere(Util.dbNullToString(dr.Item("COMAMA")), niveau)

                    moyenneMatiere.Add(matiere, Util.dbNullToDouble(dr.Item("MoyenneMA")))
                Loop
                dr.Close()

                promotion.ListeMatiere = moyenneMatiere
                promotion.ListeEtudiants = etudiants

                Return promotion
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function recherche_promo_parcours(ByVal niveau As Niveau, ByVal annee As String) As PromotionParcours
        Dim promotion As PromotionParcours

        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim sqlCommand As String
            Dim niveauString As String = ""
            If niveau <> Projet2CP.Niveau.CS3 Then
                niveauString = "AND OPTIIN = '" & Util.GetOption(niveau) & "' "
            End If

            sqlCommand = "SELECT ANNEE, OPTIIN, ANETIN, NbInscrits FROM PROMO " _
                        & "WHERE ANNEE = '" & annee & "' " & niveauString & "AND ANETIN = '5';"


            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                promotion = New PromotionParcours With {.Annee = annee, .NiveauP = niveau, .NbInscrits = Util.dbNullToInteger(dr.Item("NbInscrits"))}
                promotion.ListeEtudiants = New List(Of EtudiantParcours)()

                dr.Close()

                sqlCommand = "SELECT ETUDE.MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais, LieuNaisA, " _
                            & "Lieunais, WilayaNaisA, Adresse, Ville, Wilaya, CodPost, Sexe, Fils_de, Et_de, " _
                            & "ANNEEBAC, SERIEBAC, MOYBAC, WILBAC FROM ETUDE INNER JOIN ETUDIANT ON ETUDIANT.MATRICULE = ETUDE.MATRICULE WHERE ANNEE = '" & annee & "' " & niveauString & "AND ANETIN = '5';"
                Dim etudiants As List(Of EtudiantParcours) = New List(Of EtudiantParcours)()
                cmd.CommandText = sqlCommand
                dr = cmd.ExecuteReader()

                Dim etudiantP As EtudiantParcours
                While dr.Read
                    etudiantP = New EtudiantParcours With {.Adresse = Util.dbNullToString(dr.Item("Adresse")),
                              .CodePostal = Util.dbNullToString(dr.Item("CodPost")),
                              .DateNais = Util.dbNullToString(dr.Item("DateNais")),
                              .LieuNais = Util.dbNullToString(dr.Item("LieuNais")),
                              .LieuNaisA = Util.dbNullToString(dr.Item("LieuNaisA")),
                              .Matricule = Util.dbNullToString(dr.Item("MATRICULE")),
                              .Nom = Util.dbNullToString(dr.Item("NomEtud")),
                              .NomA = Util.dbNullToString(dr.Item("NomEtudA")),
                              .NomMere = Util.dbNullToString(dr.Item("Et_de")),
                              .Prenom = Util.dbNullToString(dr.Item("Prenoms")),
                              .PrenomA = Util.dbNullToString(dr.Item("PrenomsA")),
                              .PrenomPere = Util.dbNullToString(dr.Item("Fils_de")),
                              .Ville = Util.dbNullToString(dr.Item("Ville")),
                              .Wilaya = Util.dbNullToString(dr.Item("Wilaya")),
                              .Sexe = Util.dbNullToString(dr.Item("Sexe")),
                              .WilayaNaisA = Util.dbNullToString(dr.Item("WilayaNaisA"))}

                    promotion.ListeEtudiants.Add(etudiantP)
                End While

                dr.Close()

                For Each etudiantP In promotion.ListeEtudiants
                    Dim parcours As List(Of AnneeEtude) = New List(Of AnneeEtude)()

                    sqlCommand = "SELECT MATRICULE, ETUDE.ANNEE, ETUDE.OPTIIN, ETUDE.ANETIN, ETUDE.CycIN , NumGrp , NumScn, Moyenne, RangIN , MentIN, ElimIN, RatIN, DECIIN " _
                                & "FROM ETUDE " _
                                & "WHERE MATRICULE = '" & etudiantP.Matricule & "' ORDER BY ETUDE.ANETIN ASC;"

                    cmd.CommandText = sqlCommand
                    dr = cmd.ExecuteReader()
                    Dim anneEtude As AnneeEtude
                    Do While dr.Read()
                        anneEtude = New AnneeEtude With {.Decision = Util.dbNullToString(dr.Item("DECIIN")),
                                                         .Annee = Util.dbNullToString(dr.Item("ANNEE")).Trim(),
                                                         .Groupe = Util.dbNullToInteger(dr.Item("NumGrp")),
                                                         .Mention = Util.dbNullToString(dr.Item("MentIN")),
                                                         .MoyenneJ = Util.dbNullToDouble(dr.Item("Moyenne")),
                                                         .Niveau = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIIN")).Trim(), Util.dbNullToString(dr.Item("ANETIN")).Trim()),
                                                         .Section = Util.dbNullToString(dr.Item("NumScn")),
                                                         .Rang = Util.dbNullToInteger(dr.Item("RangIN")),
                                                         .NbrEtudiants = promotion.NbInscrits,
                                                         .RatrIn = Util.dbNullToInteger(dr.Item("RatIn"))}
                        'MessageBox.Show(anneEtude.Decision.Length)
                        parcours.Add(anneEtude)
                    Loop
                    dr.Close()
                    etudiantP.Parcours = parcours
                Next

                Return promotion
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function moyennesMatiere(ByVal matiere As Matiere) As List(Of Double)
        Dim resultat As List(Of Double) = New List(Of Double)
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim i As Integer
            For i = 0 To 22
                resultat.Add(0.0)
            Next

            Dim sqlCommand As String

            sqlCommand = "SELECT ANNEE, MoyenneMA FROM MOYMAT " _
                        & "WHERE COMAMA = '" & matiere.CodMat & "' AND OPTIMA = '" & Util.GetOption(matiere.NiveauM) & "' AND ANETMA = '" & Util.GetAnneEt(matiere.NiveauM) & "';"


            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()


            While dr.Read
                i = Util.dbNullToInteger(dr.Item("ANNEE")) - 89
                If i < 0 Then
                    i += 100
                End If
                resultat(i) = Util.dbNullToDouble(dr.Item("MoyenneMA"))

            End While

            Return resultat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function tauxReussiteMatiere(ByVal matiere As Matiere) As List(Of Object)
        Dim resultat As List(Of Object) = New List(Of Object)
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim i As Integer
            For i = 0 To 22
                resultat.Add(New With {.nbrReussite = 0, .nbrEchec = 0})
            Next

            Dim sqlCommand As String

            sqlCommand = "SELECT ANNEE, NoJuNo, NoRaNo FROM ETUDNOTE " _
                        & "WHERE ComaMa = '" & matiere.CodMat & "' AND OPTIN = '" & Util.GetOption(matiere.NiveauM) & "' AND ANETIN = '" & Util.GetAnneEt(matiere.NiveauM) & "';"


            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()

            Dim j As Integer = 0
            While dr.Read
                i = Util.dbNullToInteger(dr.Item("ANNEE")) - 89
                If i < 0 Then
                    i += 100
                End If
                Dim m, r As Double
                m = Util.dbNullToDouble(dr.Item("NoJuNo"))
                r = Util.dbNullToDouble(dr.Item("NoRaNo"))

                If j = 0 Then
                    j = 1
                End If
                If m >= 10 Or r >= 10 Then
                    resultat(i).nbrReussite += 1
                Else
                    resultat(i).nbrEchec += 1
                End If

            End While

            Return resultat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function nombreEtudiantsGeneral() As List(Of Object)
        Dim resultat As List(Of Object) = New List(Of Object)
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim i As Integer
            For i = 0 To 22
                resultat.Add(New With {.nbEtudiants = 0, .nbMasculin = 0, .nbFeminin = 0})
            Next

            Dim sqlCommand As String

            sqlCommand = "SELECT ANNEE, Count(*) AS c, Sum(IIF(Sexe = 1, 1, 0)) AS s FROM ETUDE INNER JOIN ETUDIANT " _
                       & "ON ETUDE.MATRICULE = ETUDIANT.MATRICULE GROUP BY ANNEE;"

            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()

            While dr.Read()
                i = Util.dbNullToInteger(dr.Item("ANNEE")) - 89

                If i < 0 Then
                    i += 100
                End If

                If i >= 0 And i <= 22 Then
                    resultat(i).nbEtudiants = Util.dbNullToInteger(dr.Item("c"))
                    resultat(i).nbMasculin = Util.dbNullToInteger(dr.Item("s"))
                    resultat(i).nbFeminin = resultat(i).nbEtudiants - resultat(i).nbMasculin
                End If
            End While

            Return resultat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function nombreReussiteGeneral(ByVal niv As Niveau) As List(Of Object)
        Dim resultat As List(Of Object) = New List(Of Object)
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim i As Integer
            For i = 0 To 22
                resultat.Add(New With {.nbReussite = 0, .nbEchec = 0})
            Next

            Dim sqlCommand As String

            sqlCommand = "SELECT ANNEE, Count(*) AS c, Sum(IIF(DECIIN = '1' OR DECIIN = '2', 1, 0)) AS d " _
                       & "FROM ETUDE WHERE OPTIIN = '" & Util.GetOption(niv) & "' AND ANETIN = '" & Util.GetAnneEt(niv) & "' GROUP BY ANNEE;"

            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()

            Dim nbEtudiants As Integer
            While dr.Read()
                i = Util.dbNullToInteger(dr.Item("ANNEE")) - 89

                If i < 0 Then
                    i += 100
                End If

                If i >= 0 And i <= 22 Then
                    nbEtudiants = Util.dbNullToInteger(dr.Item("c"))
                    resultat(i).nbReussite = Util.dbNullToInteger(dr.Item("d"))
                    resultat(i).nbEchec = nbEtudiants - resultat(i).nbReussite
                End If
            End While

            Return resultat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function distributionBacheliers(ByVal annee As String) As Dictionary(Of String, Integer)
        Dim resultat As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim sqlCommand As String

            sqlCommand = "SELECT ETUDIANT.SERIEBAC AS s, Count(*) AS c FROM ETUDE INNER JOIN ETUDIANT ON " _
                       & "ETUDE.MATRICULE = ETUDIANT.MATRICULE WHERE ANNEE = '" & annee & "' AND OPTIIN = 'TRC' " _
                       & "AND ANETIN = '1' GROUP BY ETUDIANT.SERIEBAC;"

            Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
            Dim dr As System.Data.OleDb.OleDbDataReader

            dr = cmd.ExecuteReader()

            While dr.Read()
                resultat.Add(Util.dbNullToString(dr.Item("s")), Util.dbNullToInteger(dr.Item("c")))
            End While

            Return resultat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    'ouvrir la base de données Access
    Public Shared db As Object
    Public Shared Sub openDB()
        _connection.Close()
        Try
            db = CreateObject("Access.Application")
            db.OpenCurrentDatabase(My.Computer.FileSystem.CurrentDirectory & "\db.accdb", False, userpwd)
            db.visible = True
        Catch ex As Exception
            MsgBox("la base de données est déja ouverte")
        End Try
    End Sub

    'supprimer la based de données
    Public Shared Sub deleteDB()
        disposer()
        Kill(My.Computer.FileSystem.CurrentDirectory & "\db.accdb")
    End Sub

    'changer le mot de passe de l'utilisateur
    Public Shared Sub setUserPassword(ByVal oldpwd As String, ByVal newpwd As String)
        Dim dbPath As String = My.Computer.FileSystem.CurrentDirectory & "\db.accdb"
        Try
            _connection.Close()
            Dim dbConnString As String = "provider=microsoft.ace.oledb.12.0;data source=" & dbPath & ";Mode=Share Exclusive;Jet OLEDB:Database Password=" & Util.GetHash(oldpwd).Substring(0, 14) & ";"
            Dim connAccess As New System.Data.OleDb.OleDbConnection(dbConnString)
            Dim cmdAccess As New System.Data.OleDb.OleDbCommand()
            cmdAccess.Connection = connAccess
            connAccess.Open()
            cmdAccess.CommandText = "ALTER DATABASE PASSWORD " & Util.GetHash(newpwd).Substring(0, 14) & " " & Util.GetHash(oldpwd).Substring(0, 14) & ""
            cmdAccess.ExecuteNonQuery()
            connAccess.Close()
            initialiser(newpwd)
            MsgBox("Successfully Done", MsgBoxStyle.Information)
        Catch ex As Exception
            _connection.Open()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'changer le mot de passe de l'administrateur
    Public Shared Sub setAdminPassword(ByVal oldpwd As String, ByVal newpwd As String)
        Try
            If _connection.State = System.Data.ConnectionState.Closed Then
                db.quit()
                _connection.Open()
            End If
            Dim cmdAccess As New System.Data.OleDb.OleDbCommand()
            cmdAccess.Connection = _connection
            cmdAccess.CommandText = "SELECT * FROM AUTHENTIC;"
            cmdAccess = New OleDbCommand(cmdAccess.CommandText, _connection)
            Dim oledbReader As OleDbDataReader = cmdAccess.ExecuteReader()
            oledbReader.Read()
            If StrComp(Trim(oledbReader.Item("MotDePasse").ToString), oldpwd) = 0 Then
                oledbReader.Close()
                cmdAccess.CommandText = "INSERT INTO authentic(MotDePasse)" _
                                      & "VALUES ('" & newpwd & "') ;"
                cmdAccess.ExecuteNonQuery()
                MsgBox("Successfully Done", MsgBoxStyle.Information)
            Else
                MsgBox("Wrong Password Try Again", MsgBoxStyle.Critical)
            End If
            oledbReader.Close()
            cmdAccess.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    'se connecter en tant qu'administrateur
    Public Shared Sub adminLogin(ByVal password As String)
        Dim cmdAccess As New System.Data.OleDb.OleDbCommand()
        cmdAccess.Connection = _connection
        cmdAccess.CommandText = "SELECT * FROM AUTHENTIC;"
        cmdAccess = New OleDbCommand(cmdAccess.CommandText, _connection)
        Dim oledbReader As OleDbDataReader = cmdAccess.ExecuteReader()
        oledbReader.Read()
        If StrComp(Trim(oledbReader.Item("MotDePasse").ToString), password) = 0 Then
            admin = True
            MsgBox("Authenticated As Admin")
        Else
            MsgBox("Wrong Password Try Again")
        End If
        oledbReader.Close()
        cmdAccess.Dispose()
    End Sub
    'se deconnecter du mode administrateur
    Public Shared Sub adminLogout()
        admin = False
    End Sub
End Class