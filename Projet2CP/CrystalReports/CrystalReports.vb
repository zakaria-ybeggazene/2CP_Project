Imports System.Data

Public Class CrystalReports
    Public Shared Function Attestation(ByVal etudiant As EtudiantParcours) As AttestationReport

        Dim ds As New DataSet
        Dim etudiantTable As New EtudiantDS.EtudiantDataTable
        Dim parcoursTable As New EtudiantDS.ParcoursDataTable
        Dim row As DataRow

        row = etudiantTable.NewEtudiantRow()
        row("Matricule") = etudiant.Matricule
        row("NomPrenom") = etudiant.Nom.Trim & " " & etudiant.Prenom.Trim
        Dim _dateNais As String = etudiant.DateNais
        If _dateNais <> "" Then
            If CType(_dateNais.Trim.Substring(6), Integer) > 60 Then
                _dateNais = _dateNais.Trim.Insert(6, "19")
            Else
                _dateNais = _dateNais.Trim.Insert(6, "20")
            End If
        End If
        row("DateNais") = _dateNais
        row("LieuNais") = etudiant.LieuNais
        etudiantTable.Rows.Add(row)
        ds.Tables.Add(etudiantTable)

        row = Nothing
        For Each annee As AnneeEtude In etudiant.Parcours
            row = parcoursTable.NewParcoursRow()
            row("Annee") = Util.GetAnneeUniv(annee.Annee)
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
            row("Decision") = Util.GetDecisionRN(annee.Decision)
            row("Matricule") = etudiant.Matricule
            parcoursTable.Rows.Add(row)
        Next
        ds.Tables.Add(parcoursTable)

        Dim attestationReport As New AttestationReport
        attestationReport.SetDataSource(ds)
        Return attestationReport
    End Function

    Public Shared Function ReleveNotes(ByVal etudiant As EtudiantParcours, ByVal niveau As Niveau)
        Dim ds As New DataSet
        Dim etudiantTable As New EtudiantDS.EtudiantDataTable
        Dim parcoursTable As New EtudiantDS.ParcoursDataTable
        Dim notesTable As New EtudiantDS.NotesDataTable

        Dim row As DataRow

        row = etudiantTable.NewEtudiantRow()
        row("Matricule") = etudiant.Matricule
        row("NomPrenom") = etudiant.Nom.Trim & " " & etudiant.Prenom.Trim
        Dim _dateNais As String = etudiant.DateNais
        If _dateNais <> "" Then
            If CType(_dateNais.Trim.Substring(6), Integer) > 60 Then
                _dateNais = _dateNais.Trim.Insert(6, "19")
            Else
                _dateNais = _dateNais.Trim.Insert(6, "20")
            End If
        End If
        row("DateNais") = _dateNais
        row("LieuNais") = etudiant.LieuNais
        etudiantTable.Rows.Add(row)
        ds.Tables.Add(etudiantTable)

        row = Nothing

        Dim annee As AnneeEtude = etudiant.Parcours.Find(Function(p) p.Niveau = niveau)
        row = parcoursTable.NewParcoursRow()
        row("Matricule") = etudiant.Matricule
        row("Annee") = Util.GetAnneeUniv(annee.Annee)
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
        If annee.Rattrap Is Nothing Then
            row("MoyenneJ") = String.Format("{0:00.00}", annee.MoyenneJ)
        Else
            row("MoyenneJ") = String.Format("{0:00.00}", annee.MoyenneJ) & "    Moyenne de septembre : " & String.Format("{0:00.00}", annee.Rattrap.MoyenneR)
        End If
        row("Rang") = annee.Rang & " sur " & annee.NbrEtudiants
        row("Decision") = Util.GetDecisionRN(annee.Decision)
        parcoursTable.Rows.Add(row)
        ds.Tables.Add(parcoursTable)

        row = Nothing

        Dim notes As Dictionary(Of Matiere, Note) = annee.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes
            row = notesTable.NewNotesRow()
            row("Annee") = Util.GetAnneeUniv(annee.Annee)
            row("Matiere") = matNotPair.Key.CodMat
            row("Libelle") = matNotPair.Key.LibeMat
            row("Coefficient") = matNotPair.Key.Coef
            row("Noju") = String.Format("{0:00.00}", matNotPair.Value.Noju)
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                row("Nora") = String.Format("{0:00.00}", matNotPair.Value.Nora)
            End If
            notesTable.Rows.Add(row)
        Next
        ds.Tables.Add(notesTable)

        Dim releveNotesAttestation As New ReleveNotesReport
        releveNotesAttestation.SetDataSource(ds)
        Return releveNotesAttestation
    End Function

    Public Shared Function ReleveNotesGlobal(ByVal etudiant As EtudiantParcours) As ReleveGlobalReport
        Dim ds As New DataSet
        Dim etudiantTable As New ReleveGlobDS.EtudiantDataTable
        Dim trc1Table As New ReleveGlobDS.TRC1DataTable
        Dim trc2Table As New ReleveGlobDS.TRC2DataTable
        Dim cs1Table As New ReleveGlobDS.CS1DataTable
        Dim cs2Table As New ReleveGlobDS.CS2DataTable
        Dim cs3Table As New ReleveGlobDS.CS3DataTable

        Dim row As DataRow

        row = etudiantTable.NewEtudiantRow()
        row("Matricule") = etudiant.Matricule
        row("NomPrenom") = etudiant.Nom.Trim & " " & etudiant.Prenom.Trim
        Dim _dateNais As String = etudiant.DateNais
        If _dateNais <> "" Then
            If CType(_dateNais.Trim.Substring(6), Integer) > 60 Then
                _dateNais = _dateNais.Trim.Insert(6, "19")
            Else
                _dateNais = _dateNais.Trim.Insert(6, "20")
            End If
        End If
        row("DateNais") = _dateNais
        row("LieuNais") = etudiant.LieuNais
        etudiantTable.Rows.Add(row)
        ds.Tables.Add(etudiantTable)

        row = Nothing

        Dim trc1 As AnneeEtude = etudiant.Parcours.FindLast(Function(p) p.Niveau = Niveau.TRC1)
        Dim notes1 As Dictionary(Of Matiere, Note) = trc1.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes1
            row = trc1Table.NewTRC1Row()
            row("Matricule") = etudiant.Matricule
            row("Annee") = Util.GetAnneeUniv(trc1.Annee)
            row("MoyenneJ") = String.Format("{0:00.00}", trc1.MoyenneJ)
            If Not trc1.Rattrap Is Nothing Then
                row("MoyenneR") = String.Format("{0:00.00}", trc1.Rattrap.MoyenneR)
            End If
            row("Rang") = trc1.Rang & " sur " & trc1.NbrEtudiants
            row("Decision") = Util.GetDecisionRN(trc1.Decision)
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = String.Format("{0:00.00}", matNotPair.Value.Noju)
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                row("Ratt") = String.Format("{0:00.00}", matNotPair.Value.Nora)
            End If
            trc1Table.Rows.Add(row)
        Next

        ds.Tables.Add(trc1Table)

        row = Nothing

        Dim trc2 As AnneeEtude = etudiant.Parcours.FindLast(Function(p) p.Niveau = Niveau.TRC2)
        Dim notes2 As Dictionary(Of Matiere, Note) = trc2.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes2
            row = trc2Table.NewTRC2Row()
            row("Matricule") = etudiant.Matricule
            row("Annee") = Util.GetAnneeUniv(trc2.Annee)
            row("MoyenneJ") = String.Format("{0:00.00}", trc2.MoyenneJ)
            If Not trc2.Rattrap Is Nothing Then
                row("MoyenneR") = String.Format("{0:00.00}", trc2.Rattrap.MoyenneR)
            End If
            row("Rang") = trc2.Rang & " sur " & trc2.NbrEtudiants
            row("Decision") = Util.GetDecisionRN(trc2.Decision)
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = String.Format("{0:00.00}", matNotPair.Value.Noju)
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                row("Ratt") = String.Format("{0:00.00}", matNotPair.Value.Nora)
            End If
            trc2Table.Rows.Add(row)
        Next

        ds.Tables.Add(trc2Table)

        row = Nothing

        Dim cs1 As AnneeEtude = etudiant.Parcours.FindLast(Function(p) p.Niveau = Niveau.SI1 Or p.Niveau = Niveau.SIQ1)
        Dim notes3 As Dictionary(Of Matiere, Note) = cs1.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes3
            row = cs1Table.NewCS1Row()
            row("Matricule") = etudiant.Matricule
            row("Annee") = Util.GetAnneeUniv(cs1.Annee)
            If cs1.Niveau = Niveau.SI1 Then
                row("Option") = "Systèmes d'Information"
            ElseIf cs1.Niveau = Niveau.SIQ1 Then
                row("Option") = "Systèmes Informatiques"
            End If
            row("MoyenneJ") = String.Format("{0:00.00}", cs1.MoyenneJ)
            If Not cs1.Rattrap Is Nothing Then
                row("MoyenneR") = String.Format("{0:00.00}", cs1.Rattrap.MoyenneR)
            End If
            row("Rang") = cs1.Rang & " sur " & cs1.NbrEtudiants
            row("Decision") = Util.GetDecisionRN(cs1.Decision)
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = String.Format("{0:00.00}", matNotPair.Value.Noju)
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                row("Ratt") = String.Format("{0:00.00}", matNotPair.Value.Nora)
            End If
            cs1Table.Rows.Add(row)
        Next

        ds.Tables.Add(cs1Table)

        row = Nothing

        Dim cs2 As AnneeEtude = etudiant.Parcours.FindLast(Function(p) p.Niveau = Niveau.SI2 Or p.Niveau = Niveau.SIQ2)
        Dim notes4 As Dictionary(Of Matiere, Note) = cs2.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes4
            row = cs2Table.NewCS2Row()
            row("Matricule") = etudiant.Matricule
            row("Annee") = Util.GetAnneeUniv(cs2.Annee)
            If cs2.Niveau = Niveau.SI2 Then
                row("Option") = "Systèmes d'Information"
            ElseIf cs2.Niveau = Niveau.SIQ2 Then
                row("Option") = "Systèmes Informatiques"
            End If
            row("MoyenneJ") = String.Format("{0:00.00}", cs2.MoyenneJ)
            If Not cs2.Rattrap Is Nothing Then
                row("MoyenneR") = String.Format("{0:00.00}", cs2.Rattrap.MoyenneR)
            End If
            row("Rang") = cs2.Rang & " sur " & cs2.NbrEtudiants
            row("Decision") = Util.GetDecisionRN(cs2.Decision)
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = String.Format("{0:00.00}", matNotPair.Value.Noju)
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                row("Ratt") = String.Format("{0:00.00}", matNotPair.Value.Nora)
            End If
            cs2Table.Rows.Add(row)
        Next

        ds.Tables.Add(cs2Table)

        row = Nothing

        Dim cs3 As AnneeEtude = etudiant.Parcours.FindLast(Function(p) p.Niveau = Niveau.SI3 Or p.Niveau = Niveau.SIQ3)
        row = cs3Table.NewCS3Row()
        row("Matricule") = etudiant.Matricule
        row("Annee") = Util.GetAnneeUniv(cs3.Annee)
        If cs3.Niveau = Niveau.SI3 Then
            row("Option") = "Systèmes d'Information"
        ElseIf cs3.Niveau = Niveau.SIQ3 Then
            row("Option") = "Systèmes Informatiques"
        End If
        row("Note") = String.Format("{0:00.00}", cs3.MoyenneJ)
        row("Mention") = Util.GetMention(cs3.Mention)

        cs3Table.Rows.Add(row)

        ds.Tables.Add(cs3Table)

        Dim releveGlobalReport As New ReleveGlobalReport
        releveGlobalReport.SetDataSource(ds)
        Return releveGlobalReport
    End Function

    Public Shared Function PvDeliberation(ByVal promotion As PromotionAnnee) As PvDelibReport
        Dim ds As New DataSet
        Dim promoTable As New PvDelibDS.PromotionDataTable
        Dim etudiantTable As New PvDelibDS.EtudiantDataTable

        Dim row As DataRow

        row = promoTable.NewPromotionRow()

        Select Case promotion.NiveauP
            Case Niveau.TRC1
                row("Niveau") = "1ère année INGENIEUR - TRC"
            Case Niveau.TRC2
                row("Niveau") = "2ème année INGENIEUR - TRC"
            Case Niveau.SI1
                row("Niveau") = "3ème année INGENIEUR - SI"
            Case Niveau.SIQ1
                row("Niveau") = "3ème année INGENIEUR - SIQ"
            Case Niveau.SI2
                row("Niveau") = "4ème année INGENIEUR - SI"
            Case Niveau.SIQ2
                row("Niveau") = "4ème année INGENIEUR - SIQ"
            Case Else
        End Select
        row("Annee") = Util.GetAnneeUniv(promotion.Annee.ToString)

        Dim i As Integer = 1
        For Each m As Matiere In promotion.ListeMatiere.Keys
            row("CM" & i) = m.CodMat
            row("Co" & i) = "  " & m.Coef
            i += 1
        Next

        promoTable.Rows.Add(row)
        ds.Tables.Add(promoTable)

        row = Nothing

        For Each e As EtudiantAnnee In promotion.ListeEtudiants
            row = etudiantTable.NewEtudiantRow()
            row("Matricule") = e.Matricule
            row("NomPrenom") = e.Nom.Trim & " " & e.Prenom.Trim
            row("Moyenne") = String.Format("{0:00.00}", e.Annee.MoyenneJ)
            row("Mention") = Util.GetMentionPV(e.Annee.Mention)
            row("Rang") = e.Annee.Rang
            If Not e.Annee.Rattrap Is Nothing Then
                row("MoyenneR") = String.Format("{0:00.00}", e.Annee.Rattrap.MoyenneR)
            End If
            row("Decision") = Util.GetDecisionPV(e.Annee.Decision)
            ' row("Ne") = REVENIR POUR AJOUTER LE NOMBRE DE NOTES ELIMINATOIRES
            Dim nbElim As Integer = 0
            For Each m As Matiere In promotion.ListeMatiere.Keys
                Try
                    Dim curCodMat As String = m.CodMat
                    Dim kvp As KeyValuePair(Of Matiere, Note) = e.Annee.Notes.FirstOrDefault(Function(p) p.Key.CodMat = curCodMat)
                    If kvp.Value.Noju >= kvp.Value.Nora Then
                        row("Notes") += String.Format("{0:00.00}", kvp.Value.Noju) & "  "
                    Else
                        row("Notes") += String.Format("{0:00.00}", kvp.Value.Nora) & "  "
                    End If
                    If kvp.Value.Eliminatoire = True Then
                        nbElim += 1
                    End If
                Catch ex As Exception
                    row("Notes") += "       "
                End Try
            Next
            row("Ne") = nbElim
            etudiantTable.Rows.Add(row)
        Next
        ds.Tables.Add(etudiantTable)

        Dim pvDelibRapport As PvDelibReport = New PvDelibReport()
        pvDelibRapport.SetDataSource(ds)
        Return pvDelibRapport
    End Function
End Class
