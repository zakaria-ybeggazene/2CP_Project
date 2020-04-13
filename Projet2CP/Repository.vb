Public Class Repository
    Private Shared _connection As New System.Data.OleDb.OleDbConnection()


    Public Shared Sub initialiser(ByVal password As String)
        'initialiser la connexion avec la bdd
        Dim dbConnString As String
        Dim path As String = My.Computer.FileSystem.CurrentDirectory & "\db.accdb"
        dbConnString = "provider=microsoft.ace.oledb.12.0;data source=" & path & ";Jet OLEDB:Database Password=" & Util.GetHash(password).Substring(0, 14) & ";"


        'MsgBox(My.Computer.FileSystem.CurrentDirectory)
        _connection.ConnectionString = dbConnString
        _connection.Open()

        'initialiser la liste des matieres
        Dim matieres As List(Of Matiere) = New List(Of Matiere)()

        Dim sqlCommand As String

        sqlCommand = "SELECT COMAMA,OPTIMA,ANETMA,LibeMA ,CoefMA FROM MATIERE;"

        Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
        Dim dr As System.Data.OleDb.OleDbDataReader

        dr = cmd.ExecuteReader()

        Dim m As Matiere
        Do While dr.Read
            m = New Matiere With {.CodMat = dr.Item("COMAMA"),
                                  .Coef = dr.Item("CoefMA"),
                                  .LibeMat = dr.Item("LibeMA"),
                                  .NiveauM = Util.GetNiveau(dr.Item("OPTIMA"), dr.Item("ANETMA"))}
            matieres.Add(m)
        Loop

        Matiere.initialiserMatieres(matieres)

        dr.Close()

    End Sub

    Public Shared Sub disposer()
        'fermer la connection base de donnée
        _connection.Close()
    End Sub

    Public Shared Function recherche_etudiants(ByVal matricule As String, ByVal nom As String, ByVal prenom As String, ByVal nomA As String, ByVal prenomA As String, ByVal dateNais As String, ByVal sexe As String, ByVal annee As String, ByVal wilayaNaissance As String, ByVal lieuNaissance As String) As List(Of Etudiant)
        Dim etudiants As List(Of Etudiant) = New List(Of Etudiant)()

        Dim contientAnnee As Boolean = True
        If annee = "" Then
            contientAnnee = False
        End If


        Dim sqlCommand As String

        If Not contientAnnee Or matricule <> "" Then

            sqlCommand = "SELECT MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais,LieuNaisA , " _
                                    & "Lieunais ,WilayaNaisA,Adresse ,Ville ,Wilaya ,CodPost ,Sexe ,Fils_de ,Et_de " _
                                    & "FROM ETUDIANT "

        Else
            sqlCommand = "SELECT ETUDIANT.MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais,LieuNaisA , " _
                                           & "Lieunais ,WilayaNaisA,Adresse ,Ville ,Wilaya ,CodPost ,Sexe ,Fils_de ,Et_de, ETUDE.ANNEE " _
                                           & "FROM ETUDIANT INNER JOIN ETUDE ON ETUDE.MATRICULE = ETUDIANT.MATRICULE "
        End If

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
            etudiant = New Etudiant With {.Adresse = dr.Item("Adresse").ToString(), .CodePostal = dr.Item("CodPost").ToString.Trim, .DateNais = dr.Item("DateNais").ToString.Trim, .LieuNais = dr.Item("LieuNais").ToString.Trim, .LieuNaisA = dr.Item("LieuNaisA").ToString.Trim, .Matricule = dr.Item("MATRICULE").Trim, .Nom = dr.Item("NomEtud").ToString, .NomA = dr.Item("NomEtudA").ToString.Trim, .NomMere = dr.Item("Et_de").ToString.Trim, .Prenom = dr.Item("Prenoms").ToString.Trim, .PrenomA = dr.Item("PrenomsA").ToString.Trim, .PrenomPere = dr.Item("Fils_de").ToString().Trim, .Ville = dr.Item("Ville").ToString().Trim, .Wilaya = dr.Item("Wilaya").ToString().Trim, .WilayaNaisA = dr.Item("WilayaNaisA").ToString().Trim}
            If Not etudiants.Contains(etudiant) Then
                etudiants.Add(etudiant)
            End If
        Loop

        dr.Close()

        Return etudiants
    End Function

    Public Shared Function paracours_etudiant(ByVal etudiant As Etudiant) As Etudiant
        Dim parcours As List(Of AnneeEtude) = New List(Of AnneeEtude)()

        Dim sqlCommand As String

        sqlCommand = "SELECT MATRICULE, ETUDE.ANNEE, ETUDE.OPTIIN, ETUDE.ANETIN, ETUDE.CycIN , NumGrp , NumScn, Moyenne, RangIN , MentIN, ElimIN, RatIN, ADM, NbInscrits " _
                    & "FROM ETUDE INNER JOIN PROMO ON PROMO.ANNEE = ETUDE.ANNEE AND PROMO.OPTIIN = ETUDE.OPTIIN AND PROMO.ANETIN = ETUDE.ANETIN " _
                    & "WHERE MATRICULE = '" & etudiant.Matricule & "' ORDER BY ETUDE.ANETIN ASC;"


        Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
        Dim dr As System.Data.OleDb.OleDbDataReader

        dr = cmd.ExecuteReader()

        Dim anneEtude As AnneeEtude
        Dim ratrapage As List(Of Integer) = New List(Of Integer)
        Do While dr.Read()
            ratrapage.Add(dr.Item("RatIN"))
            anneEtude = New AnneeEtude With {.Adm = Util.dbNullToString(dr.Item("ADM")),
                                             .Annee = Util.dbNullToString(dr.Item("ANNEE")).Trim(),
                                             .Groupe = Util.dbNullToInteger(dr.Item("NumGrp")),
                                             .Mention = Util.dbNullToString(dr.Item("MentIN")),
                                             .MoyenneJ = Util.dbNullToDouble(dr.Item("Moyenne")),
                                             .Niveau = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIIN")).Trim(), Util.dbNullToString(dr.Item("ANETIN")).Trim()),
                                             .Section = Util.dbNullToString(dr.Item("NumScn")),
                                             .Rang = Util.dbNullToInteger(dr.Item("RangIN")),
                                             .NbrEtudiants = Util.dbNullToInteger(dr.Item("NbInscrits"))}

            parcours.Add(anneEtude)
        Loop
        dr.Close()

        Dim notes As Dictionary(Of Matiere, Note) = New Dictionary(Of Matiere, Note)()
        Dim i As Integer = 0
        For Each a As AnneeEtude In parcours
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
                notes.Add(Matiere.getMatiere(dr.Item("ComaMa"), a.Niveau), n)
            Loop
            dr.Close()

            If ratrapage(i) > 0 Then
                sqlCommand = "SELECT MoyeRa,MentRa,ElimRa " _
                            & "FROM RATTRAP " _
                            & "WHERE MATRICULE = '" & etudiant.Matricule & "' AND ANNEE = '" & a.Annee & "' AND OPTIRA = '" & Util.GetOption(a.Niveau) & "' AND ANETRA = '" & Util.GetAnneEt(a.Niveau) & "';"

                cmd.CommandText = sqlCommand
                MessageBox.Show(sqlCommand)
                dr = cmd.ExecuteReader

                If (dr.Read()) Then
                    Util.dbNullToDouble(dr.Item("MoyeRa"))
                    Util.dbNullToInteger(dr.Item("MentRa"))
                    Util.dbNullToInteger(dr.Item("ElimRa"))
                    a.Rattrap = New AnneeEtude.Rattrapage With {.MoyenneR = Util.dbNullToDouble(dr.Item("MoyeRa")),
                                                            .MentionR = Util.dbNullToInteger(dr.Item("MentRa")),
                                                            .Elim = Util.dbNullToInteger(dr.Item("ElimRa"))}
                    MessageBox.Show(i)
                End If


                dr.Close()
            End If

            i += 1
        Next

        etudiant.Parcours = parcours

        Return etudiant
    End Function

    Public Shared Function recherche_promo(ByVal niveau As String, ByVal annee As Integer) As List(Of Promotion)
        Dim etudiants As List(Of Etudiant) = New List(Of Etudiant)()
        etudiants.Add(New Etudiant With {.Adresse = "Moscou", .CodePostal = 1500, .DateNais = New Date(), .LieuNais = "Bejaia", .LieuNaisA = "Bejaia arabe", .Matricule = "18/0225", .Nom = "Mohamed", .NomA = "Mohamed Arabe", .NomMere = "Nom mere", .Prenom = "prenom", .PrenomA = "prenom arabe", .PrenomPere = "prenom pere", .Ville = "alger", .Wilaya = "alger", .WilayaNaisA = "Baghdad", .WilayaNaisCode = 12})

        etudiants.Add(New Etudiant With {.Adresse = "Moscou", .CodePostal = 1500, .DateNais = New Date(), .LieuNais = "Bejaia", .LieuNaisA = "Bejaia arabe", .Matricule = "18/0226", .Nom = "Mohamed", .NomA = "Mohamed Arabe", .NomMere = "Nom mere", .Prenom = "prenom", .PrenomA = "prenom arabe", .PrenomPere = "prenom pere", .Ville = "alger", .Wilaya = "alger", .WilayaNaisA = "Baghdad", .WilayaNaisCode = 13})

        etudiants.Add(New Etudiant With {.Adresse = "Moscou", .CodePostal = 1500, .DateNais = New Date(), .LieuNais = "Bejaia", .LieuNaisA = "Bejaia arabe", .Matricule = "18/0227", .Nom = "Mohamed", .NomA = "Mohamed Arabe", .NomMere = "Nom mere", .Prenom = "prenom", .PrenomA = "prenom arabe", .PrenomPere = "prenom pere", .Ville = "alger", .Wilaya = "alger", .WilayaNaisA = "Baghdad", .WilayaNaisCode = 14})

        etudiants.Add(New Etudiant With {.Adresse = "Moscou", .CodePostal = 1500, .DateNais = New Date(), .LieuNais = "Bejaia", .LieuNaisA = "Bejaia arabe", .Matricule = "18/0228", .Nom = "Mohamed", .NomA = "Mohamed Arabe", .NomMere = "Nom mere", .Prenom = "prenom", .PrenomA = "prenom arabe", .PrenomPere = "prenom pere", .Ville = "alger", .Wilaya = "alger", .WilayaNaisA = "Baghdad", .WilayaNaisCode = 15})

        Dim moyenneMatiere As Dictionary(Of Matiere, Decimal) = New Dictionary(Of Matiere, Decimal)
        Dim mat As Matiere = New Matiere With {.CodMat = "Algo", .Coef = 5, .LibeMat = "ALGORITHMIQUE", .NiveauM = Projet2CP.Niveau.TRC1}
        Dim note As Decimal = 12
        moyenneMatiere.Add(mat, note)
        mat = New Matiere With {.CodMat = "Archi", .Coef = 5, .LibeMat = "Architecture", .NiveauM = Projet2CP.Niveau.TRC1}
        note = 15.55
        moyenneMatiere.Add(mat, note)
        mat = New Matiere With {.CodMat = "Sys", .Coef = 5, .LibeMat = "Systeme", .NiveauM = Projet2CP.Niveau.TRC1}
        note = 13.12
        moyenneMatiere.Add(mat, note)

        Dim promo As Promotion = New Promotion With {.Annee = 2000, .ListeEtudiants = etudiants, .ListeMatiere = moyenneMatiere, .NiveauP = Projet2CP.Niveau.TRC1, .NbDoublants = 1, .NbInscrits = 4, .NbRattrap = 0}
        Dim promos As List(Of Promotion) = New List(Of Promotion)(promo)
        Return promos
    End Function

End Class
