Imports System.Data

Public Class CrystalReports
    Public Shared Function Attestation(ByVal etudiant As Etudiant) As AttestationReport

        Dim ds As New DataSet
        Dim etudiantTable As New EtudiantDS.EtudiantDataTable
        Dim parcoursTable As New EtudiantDS.ParcoursDataTable
        Dim row As DataRow

        row = etudiantTable.NewEtudiantRow()
        row("Matricule") = etudiant.Matricule
        row("NomPrenom") = etudiant.Nom.Trim & " " & etudiant.Prenom.Trim
        row("DateNais") = etudiant.DateNais
        row("LieuNais") = etudiant.LieuNais
        etudiantTable.Rows.Add(row)
        ds.Tables.Add(etudiantTable)

        row = Nothing
        For Each annee As AnneeEtude In etudiant.Parcours
            row = parcoursTable.NewParcoursRow()
            If annee.Annee = 99 Then
                row("Annee") = "19" & annee.Annee & " / 2000"
            ElseIf annee.Annee > 60 Then
                row("Annee") = "19" & annee.Annee & " / 19" & annee.Annee + 1
            Else
                row("Annee") = "20" & annee.Annee & " /20" & annee.Annee + 1
            End If
            Select Case annee.Niveau
                Case Niveau.TRC1
                    row("Niveau") = "1ère année Tronc Commun"
                Case Niveau.TRC2
                    row("Niveau") = "2ème année Tronc Commun"
                Case Niveau.SI1
                    row("Niveau") = "3ème année Ingénieur option Systèmes d'Information"
                Case Niveau.SIQ1
                    row("Niveau") = "3ème année Ingénieur option Systèmes Informatiques"
                Case Niveau.SI2
                    row("Niveau") = "4ème année Ingénieur option Systèmes d'Information"
                Case Niveau.SIQ2
                    row("Niveau") = "4ème année Ingénieur option Systèmes Informatiques"
                Case Niveau.SI3
                    row("Niveau") = "5ème année Ingénieur option Systèmes d'Information"
                Case Niveau.SIQ3
                    row("Niveau") = "5ème année Ingénieur option Systèmes Informatiques"
                Case Else
            End Select
            row("Decision") = annee.Adm 'REVENIR ICI APRES AVOIR EU LES PRECISIONS DU CHAMP ADM'
            row("Matricule") = etudiant.Matricule
            parcoursTable.Rows.Add(row)
        Next
        ds.Tables.Add(parcoursTable)

        Dim attestationReport As New AttestationReport
        attestationReport.SetDataSource(ds)
        Return attestationReport
    End Function

    Public Shared Function ReleveNotes(ByVal etudiant As Etudiant, ByVal niveau As Niveau)
        Dim ds As New DataSet
        Dim etudiantTable As New EtudiantDS.EtudiantDataTable
        Dim parcoursTable As New EtudiantDS.ParcoursDataTable
        Dim notesTable As New EtudiantDS.NotesDataTable

        Dim row As DataRow

        row = etudiantTable.NewEtudiantRow()
        row("Matricule") = etudiant.Matricule
        row("NomPrenom") = etudiant.Nom.Trim & " " & etudiant.Prenom.Trim
        etudiantTable.Rows.Add(row)
        ds.Tables.Add(etudiantTable)

        row = Nothing

        Dim annee As AnneeEtude = etudiant.Parcours.Find(Function(p) p.Niveau = niveau)
        row = parcoursTable.NewParcoursRow()
        row("Matricule") = etudiant.Matricule
        If annee.Annee = 99 Then
            row("Annee") = "19" & annee.Annee & " / 2000"
        ElseIf annee.Annee > 60 Then
            row("Annee") = "19" & annee.Annee & " / 19" & annee.Annee + 1
        Else
            row("Annee") = "20" & annee.Annee & " /20" & annee.Annee + 1
        End If
        Select Case annee.Niveau
            Case niveau.TRC1
                row("Niveau") = "1ère année INGENIEUR   Option : TRONC COMMUN"
            Case niveau.TRC2
                row("Niveau") = "2ème année INGENIEUR   Option : TRONC COMMUN"
            Case niveau.SI1
                row("Niveau") = "3ème année INGENIEUR   Option : SYSTÈMES D'INFORMATION"
            Case niveau.SIQ1
                row("Niveau") = "3ème année INGENIEUR   Option : SYSTÈMES INFORMATIQUES"
            Case niveau.SI2
                row("Niveau") = "4ème année INGENIEUR   Option : SYSTÈMES D'INFORMATION"
            Case niveau.SIQ2
                row("Niveau") = "4ème année INGENIEUR   Option : SYSTÈMES INFORMATIQUES"
            Case Else
        End Select
        row("MoyenneJ") = annee.MoyenneJ
        row("Rang") = annee.Rang & " sur " & annee.NbrEtudiants
        row("Decision") = annee.Adm
        parcoursTable.Rows.Add(row)
        ds.Tables.Add(parcoursTable)

        row = Nothing

        Dim notes As Dictionary(Of Matiere, Note) = annee.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes
            If matNotPair.Key.NiveauM = niveau Then
                row = notesTable.NewNotesRow()
                row("Annee") = annee.Annee & "/" & annee.Annee + 1
                row("Matiere") = matNotPair.Key.LibeMat
                row("Libelle") = matNotPair.Key.CodMat
                row("Coefficient") = matNotPair.Key.Coef
                row("Noju") = matNotPair.Value.Noju
                row("Nosy") = matNotPair.Value.Nosy
                row("Nora") = matNotPair.Value.Nora
                notesTable.Rows.Add(row)
            End If
        Next
        ds.Tables.Add(notesTable)

        Dim releveNotesAttestation As New ReleveNotesReport
        releveNotesAttestation.SetDataSource(ds)
        Return releveNotesAttestation
    End Function
End Class
