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
            If annee.Annee = 99 Then
                row("Annee") = "1999 / 2000"
            ElseIf annee.Annee > 60 Then
                row("Annee") = "19" & annee.Annee & " / 19" & annee.Annee + 1
            ElseIf annee.Annee >= 0 And annee.Annee < 9 Then
                row("Annee") = "20" & annee.Annee & " /200" & annee.Annee + 1
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
            Select Case annee.Adm
                Case "J"c
                    row("Decision") = "Admis"
                Case "S"
                    row("Decision") = "Admis"
                Case "R"c
                    row("Decision") = "Redouble"
                Case "M"c
                    row("Decision") = "Maladie"
                Case "X"c
                    row("Decision") = "Exclu"
                Case Else
                    row("Decision") = ""
            End Select
            row("Matricule") = etudiant.Matricule
            parcoursTable.Rows.Add(row)
        Next
        ds.Tables.Add(parcoursTable)

        Dim attestationReport As New AttestationReport
        attestationReport.SetDataSource(ds)
        Return attestationReport
    End Function

    Public Shared Function ReleveNotes(ByVal etudiant As Etudiant, ByVal niveau As Niveau) As ReleveNotesReport
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
        If annee.Annee = 99 Then
            row("Annee") = "1999 / 2000"
        ElseIf annee.Annee > 60 Then
            row("Annee") = "19" & annee.Annee & " / 19" & annee.Annee + 1
        ElseIf annee.Annee >= 0 And annee.Annee < 9 Then
            row("Annee") = "20" & annee.Annee & " /200" & annee.Annee + 1
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
        If annee.Rattrap Is Nothing Then
            row("MoyenneJ") = annee.MoyenneJ
        Else
            row("MoyenneJ") = annee.MoyenneJ & "    Moyenne de septembre : " & annee.Rattrap.MoyenneR
        End If
        row("Rang") = annee.Rang & " sur " & annee.NbrEtudiants
        Select Case annee.Adm
            Case "J"c
                row("Decision") = "Admis"
            Case "S"c
                row("Decision") = "Admis"
            Case "R"c
                row("Decision") = "Redouble"
            Case "M"c
                row("Decision") = "Maladie"
            Case "X"c
                row("Decision") = "Exclu"
            Case Else
                row("Decision") = ""
        End Select
        parcoursTable.Rows.Add(row)
        ds.Tables.Add(parcoursTable)

        row = Nothing

        Dim notes As Dictionary(Of Matiere, Note) = annee.Notes
        For Each matNotPair As KeyValuePair(Of Matiere, Note) In notes
            row = notesTable.NewNotesRow()
            If annee.Annee = 99 Then
                row("Annee") = "1999 / 2000"
            ElseIf annee.Annee > 60 Then
                row("Annee") = "19" & annee.Annee & " / 19" & annee.Annee + 1
            ElseIf annee.Annee >= 0 And annee.Annee < 9 Then
                row("Annee") = "20" & annee.Annee & " /200" & annee.Annee + 1
            Else
                row("Annee") = "20" & annee.Annee & " /20" & annee.Annee + 1
            End If
            row("Matiere") = matNotPair.Key.CodMat
            row("Libelle") = matNotPair.Key.LibeMat
            row("Coefficient") = matNotPair.Key.Coef
            row("Noju") = matNotPair.Value.Noju
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                Dim s As String = matNotPair.Value.Nora
                If s.Trim.Length = 2 Then
                    s = s.Trim & ",00"
                End If
                row("Nora") = s
            End If
            notesTable.Rows.Add(row)
        Next
        ds.Tables.Add(notesTable)

        Dim releveNotesAttestation As New ReleveNotesReport
        releveNotesAttestation.SetDataSource(ds)
        Return releveNotesAttestation
    End Function

    Public Shared Function ReleveNotesGlobal(ByVal etudiant As Etudiant) As ReleveGlobalReport
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
            If trc1.Annee = 99 Then
                row("Annee") = "1999 / 2000"
            ElseIf trc1.Annee > 60 Then
                row("Annee") = "19" & trc1.Annee & " / 19" & trc1.Annee + 1
            ElseIf trc1.Annee >= 0 And trc1.Annee < 9 Then
                row("Annee") = "20" & trc1.Annee & " /200" & trc1.Annee + 1
            Else
                row("Annee") = "20" & trc1.Annee & " /20" & trc1.Annee + 1
            End If
            row("MoyenneJ") = trc1.MoyenneJ
            If Not trc1.Rattrap Is Nothing Then
                row("MoyenneR") = trc1.Rattrap.MoyenneR
            End If
            row("Rang") = trc1.Rang & " sur " & trc1.NbrEtudiants
            Select Case trc1.Adm
                Case "J"c
                    row("Decision") = "Admis"
                Case "S"c
                    row("Decision") = "Admis"
                Case "R"c
                    row("Decision") = "Redouble"
                Case "M"c
                    row("Decision") = "Maladie"
                Case "X"c
                    row("Decision") = "Exclu"
                Case Else
                    row("Decision") = ""
            End Select
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = matNotPair.Value.Noju
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                Dim s As String = matNotPair.Value.Nora
                If s.Trim.Length = 2 Then
                    s = s.Trim & ",00"
                End If
                row("Ratt") = s
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
            If trc2.Annee = 99 Then
                row("Annee") = "1999 / 2000"
            ElseIf trc2.Annee > 60 Then
                row("Annee") = "19" & trc2.Annee & " / 19" & trc2.Annee + 1
            ElseIf trc2.Annee >= 0 And trc2.Annee < 9 Then
                row("Annee") = "20" & trc2.Annee & " /200" & trc2.Annee + 1
            Else
                row("Annee") = "20" & trc2.Annee & " /20" & trc2.Annee + 1
            End If
            row("MoyenneJ") = trc2.MoyenneJ
            If Not trc2.Rattrap Is Nothing Then
                row("MoyenneR") = trc2.Rattrap.MoyenneR
            End If
            row("Rang") = trc2.Rang & " sur " & trc2.NbrEtudiants
            Select Case trc2.Adm
                Case "J"c
                    row("Decision") = "Admis"
                Case "S"c
                    row("Decision") = "Admis"
                Case "R"c
                    row("Decision") = "Redouble"
                Case "M"c
                    row("Decision") = "Maladie"
                Case "X"c
                    row("Decision") = "Exclu"
                Case Else
                    row("Decision") = ""
            End Select
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = matNotPair.Value.Noju
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                Dim s As String = matNotPair.Value.Nora
                If s.Trim.Length = 2 Then
                    s = s.Trim & ",00"
                End If
                row("Ratt") = s
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
            If cs1.Annee = 99 Then
                row("Annee") = "1999 / 2000"
            ElseIf cs1.Annee > 60 Then
                row("Annee") = "19" & cs1.Annee & " / 19" & cs1.Annee + 1
            ElseIf cs1.Annee >= 0 And cs1.Annee < 9 Then
                row("Annee") = "20" & cs1.Annee & " /200" & cs1.Annee + 1
            Else
                row("Annee") = "20" & cs1.Annee & " /20" & cs1.Annee + 1
            End If
            If cs1.Niveau = Niveau.SI1 Then
                row("Option") = "Systèmes d'Information"
            ElseIf cs1.Niveau = Niveau.SIQ1 Then
                row("Option") = "Systèmes Informatiques"
            End If
            row("MoyenneJ") = cs1.MoyenneJ
            If Not cs1.Rattrap Is Nothing Then
                row("MoyenneR") = cs1.Rattrap.MoyenneR
            End If
            row("Rang") = cs1.Rang & " sur " & cs1.NbrEtudiants
            Select Case cs1.Adm
                Case "J"c
                    row("Decision") = "Admis"
                Case "S"c
                    row("Decision") = "Admis"
                Case "R"c
                    row("Decision") = "Redouble"
                Case "M"c
                    row("Decision") = "Maladie"
                Case "X"c
                    row("Decision") = "Exclu"
                Case Else
                    row("Decision") = ""
            End Select
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = matNotPair.Value.Noju
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                Dim s As String = matNotPair.Value.Nora
                If s.Trim.Length = 2 Then
                    s = s.Trim & ",00"
                End If
                row("Ratt") = s
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
            If cs2.Annee = 99 Then
                row("Annee") = "1999 / 2000"
            ElseIf cs2.Annee > 60 Then
                row("Annee") = "19" & cs2.Annee & " / 19" & cs2.Annee + 1
            ElseIf cs2.Annee >= 0 And cs2.Annee < 9 Then
                row("Annee") = "20" & cs2.Annee & " /200" & cs2.Annee + 1
            Else
                row("Annee") = "20" & cs2.Annee & " /20" & cs2.Annee + 1
            End If
            If cs2.Niveau = Niveau.SI2 Then
                row("Option") = "Systèmes d'Information"
            ElseIf cs2.Niveau = Niveau.SIQ2 Then
                row("Option") = "Systèmes Informatiques"
            End If
            row("MoyenneJ") = cs2.MoyenneJ
            If Not cs2.Rattrap Is Nothing Then
                row("MoyenneR") = cs2.Rattrap.MoyenneR
            End If
            row("Rang") = cs2.Rang & " sur " & cs2.NbrEtudiants
            Select Case cs2.Adm
                Case "J"c
                    row("Decision") = "Admis"
                Case "S"c
                    row("Decision") = "Admis"
                Case "R"c
                    row("Decision") = "Redouble"
                Case "M"c
                    row("Decision") = "Maladie"
                Case "X"c
                    row("Decision") = "Exclu"
                Case Else
                    row("Decision") = ""
            End Select
            row("Matiere") = matNotPair.Key.LibeMat
            row("Coef") = matNotPair.Key.Coef
            row("Note") = matNotPair.Value.Noju
            If matNotPair.Value.Nora > matNotPair.Value.Noju Then
                Dim s As String = matNotPair.Value.Nora
                If s.Trim.Length = 2 Then
                    s = s.Trim & ",00"
                End If
                row("Ratt") = s
            End If
            cs2Table.Rows.Add(row)
        Next

        ds.Tables.Add(cs2Table)

        row = Nothing

        Dim cs3 As AnneeEtude = etudiant.Parcours.FindLast(Function(p) p.Niveau = Niveau.SI3 Or p.Niveau = Niveau.SIQ3)
        row = cs3Table.NewCS3Row()
        row("Matricule") = etudiant.Matricule
        If cs3.Annee = 99 Then
            row("Annee") = "1999 / 2000"
        ElseIf cs3.Annee > 60 Then
            row("Annee") = "19" & cs3.Annee & " / 19" & cs3.Annee + 1
        ElseIf cs3.Annee >= 0 And cs3.Annee < 9 Then
            row("Annee") = "20" & cs3.Annee & " /200" & cs3.Annee + 1
        Else
            row("Annee") = "20" & cs3.Annee & " /20" & cs3.Annee + 1
        End If
        If cs3.Niveau = Niveau.SI3 Then
            row("Option") = "Systèmes d'Information"
        ElseIf cs3.Niveau = Niveau.SIQ3 Then
            row("Option") = "Systèmes Informatiques"
        End If
        row("Note") = cs3.MoyenneJ
        row("Mention") = cs3.Mention 'COME BACK HERE

        ds.Tables.Add(cs3Table)

        Dim releveGlobalReport As New ReleveGlobalReport
        releveGlobalReport.SetDataSource(ds)
        Return releveGlobalReport
    End Function
End Class
