Imports System.Data.OleDb

Public Class Repository
    Private Shared _connection As New System.Data.OleDb.OleDbConnection()

    Private Shared admin As Boolean = False
    Public Shared Sub initialiser(ByVal password As String)
        'initialiser la connexion avec la bdd
        Dim dbConnString As String
        Dim path As String = My.Computer.FileSystem.CurrentDirectory & "\db.accdb"
        dbConnString = "provider=microsoft.ace.oledb.12.0;data source=" & path & ";Jet OLEDB:Database Password=" & Util.GetHash(password).Substring(0, 14) & ";"
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
            m = New Matiere With {.CodMat = Util.dbNullToString(dr.Item("COMAMA")),
                                  .Coef = dr.Item("CoefMA"),
                                  .LibeMat = Util.dbNullToString(dr.Item("LibeMA")),
                                  .NiveauM = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIMA")), Util.dbNullToString(dr.Item("ANETMA")))}
            matieres.Add(m)
        Loop

        Matiere.initialiserMatieres(matieres)

        dr.Close()

    End Sub

    Public Shared Sub disposer()
        'fermer la connection base de donnée
        _connection.Close()
    End Sub
    ''
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
                                              .WilayaNaisA = Util.dbNullToString(dr.Item("WilayaNaisA"))}
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
        Do While dr.Read()
            anneEtude = New AnneeEtude With {.Adm = Util.dbNullToString(dr.Item("ADM")),
                                             .Annee = Util.dbNullToString(dr.Item("ANNEE")).Trim(),
                                             .Groupe = Util.dbNullToInteger(dr.Item("NumGrp")),
                                             .Mention = Util.dbNullToString(dr.Item("MentIN")),
                                             .MoyenneJ = Util.dbNullToDouble(dr.Item("Moyenne")),
                                             .Niveau = Util.GetNiveau(Util.dbNullToString(dr.Item("OPTIIN")).Trim(), Util.dbNullToString(dr.Item("ANETIN")).Trim()),
                                             .Section = Util.dbNullToString(dr.Item("NumScn")),
                                             .Rang = Util.dbNullToInteger(dr.Item("RangIN")),
                                             .NbrEtudiants = Util.dbNullToInteger(dr.Item("NbInscrits")),
                                             .RatrIn = Util.dbNullToInteger(dr.Item("RatIn"))}

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
                                              .WilayaNaisA = etudiant.WilayaNaisA}
        etudiantP.Parcours = parcours

        Return etudiantP
    End Function


    Public Shared Function recherche_promo(ByVal niveau As Niveau, ByVal annee As String) As Promotion
        Dim promotion As Promotion

        Dim sqlCommand As String

        sqlCommand = "SELECT ANNEE, OPTIIN, ANETIN, NbInscrits FROM PROMO " _
                    & "WHERE ANNEE LIKE '%" & annee & "%' AND OPTIIN LIKE '%" & Util.GetOption(niveau) & "%' AND ANETIN LIKE '%" & Util.GetAnneEt(niveau) & "%';"


        Dim cmd As New System.Data.OleDb.OleDbCommand(sqlCommand, _connection)
        Dim dr As System.Data.OleDb.OleDbDataReader

        dr = cmd.ExecuteReader()
        If dr.Read() Then
            promotion = New Promotion With {.Annee = annee, .NiveauP = niveau, .NbInscrits = Util.dbNullToInteger(dr.Item("NbInscrits"))}


            dr.Close()

            sqlCommand = "SELECT ETUDIANT.MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais,LieuNaisA , " _
                                        & "Lieunais ,WilayaNaisA,Adresse ,Ville ,Wilaya ,CodPost ,Sexe ,Fils_de ,Et_de, " _
                                        & "ETUDE.ANNEE, ETUDE.OPTIIN, ETUDE.ANETIN, ETUDE.CycIN , NumGrp , NumScn, Moyenne, RangIN , MentIN, ElimIN, RatIN, ADM " _
                                        & "FROM ETUDE INNER JOIN ETUDIANT ON ETUDE.MATRICULE = ETUDIANT.MATRICULE " _
                & "WHERE ANNEE LIKE '%" & annee & "%' AND OPTIIN LIKE '%" & Util.GetOption(niveau) & "%' AND ANETIN LIKE '%" & Util.GetAnneEt(niveau) & "%';"
            Dim etudiants As List(Of EtudiantAnnee) = New List(Of EtudiantAnnee)()

            cmd.CommandText = sqlCommand
            dr = cmd.ExecuteReader()

            Dim etudiant As EtudiantAnnee
            Dim anneEtude As AnneeEtude
            Do While dr.Read()
                anneEtude = New AnneeEtude With {.Adm = Util.dbNullToString(dr.Item("ADM")),
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
                            & "WHERE ANNEE LIKE '%" & annee & "%' AND OPTIMA LIKE '%" & Util.GetOption(niveau) & "%' AND ANETMA LIKE '%" & Util.GetAnneEt(niveau) & "%';"
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
    End Function

    Public Shared Sub setAdminPassword(ByVal password As String)
        Dim cmdAccess As New System.Data.OleDb.OleDbCommand()
        cmdAccess.Connection = _connection
        cmdAccess.CommandText = "INSERT INTO authentic(MotDePasse)" _
                              & "VALUES ('" & password & "') ;"
        cmdAccess.ExecuteNonQuery()
        MsgBox("done")
    End Sub

    Public Shared Function adminLogin(ByVal password As String)
        Dim check As Boolean = False
        Dim cmdAccess As New System.Data.OleDb.OleDbCommand()
        cmdAccess.Connection = _connection
        cmdAccess.CommandText = "select * from AUTHENTIC;"
        cmdAccess = New OleDbCommand(cmdAccess.CommandText, _connection)
        Dim oledbReader As OleDbDataReader = cmdAccess.ExecuteReader()
        oledbReader.Read()
        MsgBox(Trim(oledbReader.Item("MotDePasse").ToString))
        If StrComp(Trim(oledbReader.Item("MotDePasse").ToString), password) = 0 Then
            check = True
            MsgBox("authenticated")
        Else
            MsgBox("wrong password try again")
        End If
        oledbReader.Close()
        cmdAccess.Dispose()
        Return check
    End Function
End Class