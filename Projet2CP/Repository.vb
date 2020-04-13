Public Class Repository
    Private Shared _connection As New System.Data.OleDb.OleDbConnection()


    Public Shared Sub initialiser()
        'initialiser la connexion avec la bdd
        Dim dbConnString As String
        'Dim path As String = "C:/Users/dell/Desktop/db.accdb"
        'dbConnString = "provider=microsoft.ace.oledb.12.0;data source=" & Migration.dbPath
        dbConnString = "provider=microsoft.ace.oledb.12.0;data source=" & Migration.dbPath & "; Jet OLEDB:Database Password=" & Migration.dbPassword & ""
        _connection.ConnectionString = dbConnString
        _connection.Open()

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
        Console.WriteLine(sqlCommand)

        dr = cmd.ExecuteReader()

        Dim etudiant As Etudiant
        Do While dr.Read()
            etudiant = New Etudiant With {.Adresse = dr.Item("Adresse").ToString, .CodePostal = dr.Item("CodPost").ToString, .DateNais = dr.Item("DateNais").ToString, .LieuNais = dr.Item("LieuNais").ToString, .LieuNaisA = dr.Item("LieuNaisA").ToString, .Matricule = dr.Item("MATRICULE"), .Nom = dr.Item("NomEtud").ToString, .NomA = dr.Item("NomEtudA").ToString, .NomMere = dr.Item("Et_de").ToString, .Prenom = dr.Item("Prenoms").ToString, .PrenomA = dr.Item("PrenomsA").ToString, .PrenomPere = dr.Item("Fils_de").ToString(), .Ville = dr.Item("Ville").ToString(), .Wilaya = dr.Item("Wilaya").ToString(), .WilayaNaisA = dr.Item("WilayaNaisA").ToString()}
            If Not etudiants.Contains(etudiant) Then
                etudiants.Add(etudiant)
            End If
        Loop
        Return etudiants
    End Function

    Public Shared Function paracours_etudiant(ByVal etudiant As Etudiant) As Etudiant
        Dim parcours As List(Of AnneeEtude) = New List(Of AnneeEtude)()

        ''annee 1
        Dim anneEtude As AnneeEtude = New AnneeEtude With {.Adm = "j", .Annee = 2000, .Groupe = 10, .Mention = 4, .MoyenneJ = 15.01, .Niveau = Niveau.TRC1, .Section = "C"}
        Dim notes As Dictionary(Of Matiere, Note) = New Dictionary(Of Matiere, Note)()
        Dim mat As Matiere = New Matiere With {.CodMat = "Algo", .Coef = 5, .LibeMat = "ALGORITHMIQUE", .NiveauM = Niveau.TRC1}
        Dim note As Note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        mat = New Matiere With {.CodMat = "Archi", .Coef = 5, .LibeMat = "Architecture", .NiveauM = Niveau.TRC1}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        mat = New Matiere With {.CodMat = "Sys", .Coef = 5, .LibeMat = "Systeme", .NiveauM = Niveau.TRC1}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        anneEtude.Notes = notes
        parcours.Add(anneEtude)

        ''annee 2
        anneEtude = New AnneeEtude With {.Adm = "j", .Annee = 2001, .Groupe = 7, .Mention = 4, .MoyenneJ = 12.01, .Niveau = Niveau.TRC2, .Section = "C"}
        notes = New Dictionary(Of Matiere, Note)()
        mat = New Matiere With {.CodMat = "Algo", .Coef = 5, .LibeMat = "ALGORITHMIQUE", .NiveauM = Niveau.TRC2}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        mat = New Matiere With {.CodMat = "Archi", .Coef = 5, .LibeMat = "Architecture", .NiveauM = Niveau.TRC2}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        mat = New Matiere With {.CodMat = "SFSD", .Coef = 5, .LibeMat = "Structure fichier", .NiveauM = Niveau.TRC2}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        anneEtude.Notes = notes
        parcours.Add(anneEtude)

        ''annee 3
        anneEtude = New AnneeEtude With {.Adm = "j", .Annee = 2002, .Groupe = 7, .Mention = 4, .MoyenneJ = 12.01, .Niveau = Niveau.SI1, .Section = "B"}
        notes = New Dictionary(Of Matiere, Note)()
        mat = New Matiere With {.CodMat = "Sys", .Coef = 5, .LibeMat = "Systeme", .NiveauM = Niveau.SI1}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        mat = New Matiere With {.CodMat = "Archi", .Coef = 5, .LibeMat = "Architecture", .NiveauM = Niveau.SI1}
        note = New Note With {.Eliminatoire = False, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        mat = New Matiere With {.CodMat = "THP", .Coef = 5, .LibeMat = "Theorie de programmation", .NiveauM = Niveau.SI1}
        note = New Note With {.Eliminatoire = True, .Noju = 15, .Nora = 0, .Nosy = 0, .Ratrapage = 0}
        notes.Add(mat, note)
        anneEtude.Notes = notes
        parcours.Add(anneEtude)

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

    ''Fonction utilitaire pour recuperer le niveau a partir du cycle et de l'année
    Private Shared Function GetNiveau(ByVal Cycle As String, ByVal Annee As Integer) As Niveau
        If Cycle = "TRC" Then
            If Annee = 1 Then
                Return Niveau.TRC1
            Else
                Return Niveau.TRC2
            End If
        ElseIf Cycle = "SI" Then
            If Annee = 3 Then
                Return Niveau.SI1
            Else
                Return Niveau.SI2
            End If
        Else
            If Annee = 3 Then
                Return Niveau.SIQ1
            Else
                Return Niveau.SIQ2
            End If
        End If
    End Function

End Class
