Module Migration
    Sub Main()
        Dim start As Single
        start = Timer

        'enter your excel files paths here
        Dim inscrit As String = "C:\Users\asus\Desktop\2CPI\PRJP\Données_client\INSCRIT_00_04.xlsx"
        Dim note As String = "C:\Users\asus\Desktop\2CPI\PRJP\Données_client\NOTE_00_04.xlsx"
        Dim matiere As String = "C:\Users\asus\Desktop\2CPI\PRJP\Données_client\MATIERE_00_04.xlsx"
        Dim rattrap As String = "C:\Users\asus\Desktop\2CPI\PRJP\Données_client\RATRAP_00_04.xlsx"

        'enter the full path where access database will be created here
        Dim dbPath As String = "C:\Users\asus\Desktop\2CPI\PRJP\Database.accdb"

        'enter the database password here
        Dim dbPassword As String = "123"

        ''access database 
        Dim dbConnString As String
        Dim db As Object

        'Create new database
        db = CreateObject("Access.Application")
        db.NewCurrentDatabase(dbPath)
        db.quit()
        dbConnString = "provider=microsoft.ace.oledb.12.0;data source=" & dbPath & ""
        Dim connAccess As New System.Data.OleDb.OleDbConnection(dbConnString)
        Dim cmdAccess As New System.Data.OleDb.OleDbCommand()
        cmdAccess.Connection = connAccess
        connAccess.Open()
        ' ''Creating tables in the access database
        cmdAccess.CommandText = "create table ETUDIANT " _
                              & "(MATRICULE char(15),Matric_ins char(20),NomEtud char(20), Prenoms char(50),NomEtudA char(20),PrenomsA char(50),DateNais char(15),LieuNaisA char(40), " _
                              & "LieuNais char(40),WilayaNaisA char(40),Adresse char(200),Ville char(50),Wilaya char(40),CodPost char(12),Sexe short,Fils_de char(50),Et_de char(50),primary key(MATRICULE));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table PROMO(ANNEE char,OPTIIN char, ANETIN char,NbInscrits int,NbDoublant int,NbRattrap int, primary key(ANNEE,OPTIIN, ANETIN));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table ETUDE (MATRICULE char(15),ANNEE char,OPTIIN char,ANETIN char(5),CycIN char(5),NumGrp char(10),NumScn char(10)," _
                                & "Moyenne decimal(4,2),RangIN char(20),MentIN char(10),ElimIN char(15),RatIN char(10),ADM char(5), primary key(MATRICULE,ANNEE,OPTIIN,ANETIN));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table  ETUDNOTE(MATRICULE char(15),ANNEE char,OPTIN char,ANETIN char(5),ComaMa char(10),CycNO char(5),NoJuNo char(10),NoSyNo char(10)," _
                                & "NoRaNo char(15),ElimNo char(20),RatrNo char(10), primary key(MATRICULE,ANNEE,OPTIN,ANETIN,ComaMa));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table RATTRAP (MATRICULE char(15),ANNEE char,OPTIRA char,ANETRA char(5),CycRA char(5),MoyeRa char(10),MentRa char(10)," _
                                & "ElimRa char(15),primary key(MATRICULE,ANNEE,OPTIRA,ANETRA));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table MATIERE (COMAMA char(20),OPTIMA char,ANETMA char(25),LibeMA char(50),CoefMA char(20),primary key(COMAMA,ANETMA,OPTIMA));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table MOYMAT (ANNEE char,OPTIMA char,ANETMA char(5),COMAMA char,MoyenneMA char,primary key(ANNEE,OPTIMA,ANETMA,COMAMA));"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table inscrits (NomEtud char(100),Prenoms char(100),NomEtudA char(100),PrenomsA char(100),MATRIC_INS char(50),ANSCIN char,MATRIN char(15)," _
                                & " DATENAIS char(15),LIEUNAISA char(40),WILNAISA char(40),LIEUNAIS char(40),ADRESSE char(200),VILLE char,WILAYA char(40),CODPOST char(12)," _
                                & "ANETIN char(5),CYCLIN char(5),OPTIIN char(5),NumG char(10),NumS char(10),MOYEIN decimal(4,2),RANGIN char(20),MENTIN char(10),ELIMIN char(15),RATRIN char(10)," _
                                & " SEXE short,FILS_DE char,ET_DE char,ADM char(10));"

        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "create table matieres (ANSCMA char(15), ANETMA char(20),OPTIMA char(20), COMAMA char(20), CYCLMA char(20),  LIBEMA char(50), TYPEMA char,COEFMA char(20),MOYMAT decimal(4,2))"
        cmdAccess.ExecuteNonQuery()

        ''Excel files

        Dim connString As String = "provider=microsoft.ace.oledb.12.0;data source=" & inscrit & " ;extended properties=""excel 12.0;hdr=yes"""

        Dim conn As New System.Data.OleDb.OleDbConnection(connString)
        Dim cmd As New System.Data.OleDb.OleDbCommand()
        conn.Open()
        cmd.Connection = conn
        cmd.CommandText = "INSERT INTO [MS Access;Database=" & dbPath & "].[inscrits] (NomEtud,Prenoms,NomEtudA,PrenomsA,MATRIC_INS,ANSCIN,MATRIN,DATENAIS,LIEUNAISA,WILNAISA," _
                           & " LIEUNAIS,ADRESSE,VILLE,WILAYA,CODPOST,ANETIN,CYCLIN,OPTIIN,NumG,NumS,MOYEIN,RANGIN,MENTIN,ELIMIN,RATRIN,SEXE,FILS_DE,ET_DE,ADM) SELECT NomEtud,Prenoms," _
                           & "NomEtudA, PrenomsA, MATRIC_INS, ANSCIN, MATRIN, DATENAIS, LIEUNAISA, WILNAISA, " _
                           & "LIEUNAIS,ADRESSE,VILLE,WILAYA,CODPOST,ANETIN,CYCLIN,OPTIIN,NG,NS,MOYEIN,RANGIN,MENTIN,ELIMIN,RATRIN,SEXE,FILS_DE,ET_DE,ADM FROM [INSCRIT$]" _
                           & " WHERE MATRIN IS NOT NULL AND ANSCIN IS NOT NULL AND OPTIIN IS NOT NULL AND ANETIN IS NOT NULL"
        cmd.ExecuteNonQuery()
        conn.Close()

        connString = "provider=microsoft.ace.oledb.12.0;data source=" & matiere & " ;extended properties=""excel 12.0;hdr=yes"""
        conn = New System.Data.OleDb.OleDbConnection(connString)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandText = "INSERT INTO [MS Access;Database=" & dbPath & "].[matieres] (ANSCMA, ANETMA, OPTIMA, COMAMA, CYCLMA, LIBEMA, TYPEMA,COEFMA,MOYMAT)" _
                           & "  SELECT ANSCMA, ANETMA, OPTIMA, COMAMA,CYCLMA, LIBEMA, TYPEMA,COEFMA,MOYMAT FROM [MATIERE$]" _
                           & " WHERE ANSCMA IS NOT NULL AND ANETMA IS NOT NULL AND OPTIMA IS NOT NULL AND COMAMA IS NOT NULL"
        cmd.ExecuteNonQuery()
        conn.Close()

        connString = "provider=microsoft.ace.oledb.12.0;data source=" & note & ";extended properties=""excel 12.0;hdr=yes"""
        conn = New System.Data.OleDb.OleDbConnection(connString)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandText = "INSERT INTO [MS Access;Database=" & dbPath & "].[ETUDNOTE] (MATRICULE,ANNEE,OPTIN,ANETIN, ComaMa, CycNO, NoJuNo, NoSyNo,NoRaNo ,ElimNo ,RatrNo)" _
                           & "  SELECT MATRNO ,ANSCNO,OPTINO,ANETNO,COMANO, max(CYCLNO) as 'CYCLNO', max(NOJUNO) as 'NOJUNO' ,max(NOSYNO) as 'NOSYNO', max(NORANO) as 'NORANO'," _
                           & "max(ELIMNO) as 'ELIMNO' ,max(RATRNO) as 'RATRNO'  FROM [NOTE$] WHERE MATRNO IS NOT NULL AND ANSCNO IS NOT NULL AND ANETNO IS NOT NULL AND OPTINO IS NOT NULL And COMANO IS NOT NULL" _
                           & " GROUP BY MATRNO,ANSCNO,OPTINO,ANETNO,COMANO"
        cmd.ExecuteNonQuery()
        conn.Close()

        connString = "provider=microsoft.ace.oledb.12.0;data source=" & rattrap & ";extended properties=""excel 12.0;hdr=yes"""
        conn = New System.Data.OleDb.OleDbConnection(connString)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandText = "INSERT INTO [MS Access;Database=" & dbPath & "].[RATTRAP] (MATRICULE,ANNEE,OPTIRA,ANETRA,CycRA,MoyeRa,MentRa,ElimRa)" _
                           & "  SELECT MATRRA,ANSCRA,OPTIRA,ANETRA,max(CYCLRA) as 'CYCLRA',max(MOYERA) as 'MOYERA',max(MENTRA) as 'MENTRA',max(ELIMRA) as 'ELIMRA'" _
                           & "  FROM [RATRAP$] WHERE MATRRA Is Not NULL And ANSCRA IS NOT NULL And OPTIRA IS NOT NULL And ANETRA IS NOT NULL " _
                           & " GROUP BY MATRRA,ANSCRA,OPTIRA,ANETRA"
        cmd.ExecuteNonQuery()
        conn.Close()

        cmdAccess.CommandText = "INSERT INTO ETUDIANT" _
                                & "(MATRICULE ,Matric_ins ,NomEtud , Prenoms ,NomEtudA ,PrenomsA ,DateNais,LieuNaisA , " _
                                & "Lieunais ,WilayaNaisA,Adresse ,Ville ,Wilaya ,CodPost ,Sexe ,Fils_de ,Et_de) SELECT MATRIN,max(MATRIC_INS) as 'MATRIC_INS'," _
                                & " max(NomEtud) as 'NomEtud',max(Prenoms) as 'Prenoms',max(NomEtudA) as 'NomEtudA' ,max(PrenomsA) as 'PrenomsA',max(DATENAIS) as 'DATENAIS'," _
                                & " max(LIEUNAISA) as 'LIEUNAISA',max(LIEUNAIS) as 'LIEUNAIS' ,max(WILNAISA) as 'WILNAISA',max(ADRESSE) as 'ADRESSE',max(VILLE) as 'VILLE', " _
                                & "max(WILAYA) as 'WILAYA',max(CODPOST) as 'CODPOST' ,max(SEXE) as 'SEXE',max(FILS_DE) as 'FILS_DE',max(ET_DE) as 'ET_DE' FROM inscrits GROUP BY MATRIN order by MATRIN;"
        cmdAccess.ExecuteNonQuery()
        cmdAccess.CommandText = "INSERT INTO PROMO (ANNEE ,OPTIIN , ANETIN ) SELECT ANSCIN ,OPTIIN ,ANETIN " _
                                & "FROM inscrits GROUP BY ANSCIN, OPTIIN,ANETIN ORDER BY ANSCIN;"
        cmdAccess.ExecuteNonQuery()
        cmdAccess.CommandText = "INSERT INTO ETUDE (MATRICULE,ANNEE,OPTIIN ,ANETIN,CycIN ,NumGrp ,NumScn,Moyenne,RangIN ,MentIN,ElimIN,RatIN ,ADM)" _
                                 & " SELECT MATRIN, ANSCIN,OPTIIN,ANETIN,max(CYCLIN) as 'CYCLIN',max(NumG) as 'NumG' , max(NumS) as 'NumS', max(MOYEIN) as 'MOYEIN',  " _
                                 & "max(RANGIN) as 'RANGIN',max(MENTIN) as 'MENTIN' , max(ELIMIN) as 'ELIMIN',max(RATRIN) as 'RATRIN' ,max(ADM) as 'ADM'  " _
                                 & "from inscrits GROUP BY MATRIN, ANSCIN,OPTIIN,ANETIN;"
        cmdAccess.ExecuteNonQuery()
        cmdAccess.CommandText = "INSERT INTO MATIERE (COMAMA,OPTIMA,ANETMA,LibeMA ,CoefMA)" _
                                 & " SELECT COMAMA,OPTIMA, ANETMA,max(LIBEMA) as 'LIBEMA',max(COEFMA) as 'COEFMA' " _
                                 & "FROM matieres GROUP BY COMAMA,OPTIMA,ANETMA;"
        cmdAccess.ExecuteNonQuery()
        cmdAccess.CommandText = "INSERT INTO MOYMAT (ANNEE,OPTIMA ,ANETMA,COMAMA ,MoyenneMA)" _
                                 & " SELECT ANSCMA, OPTIMA, ANETMA, COMAMA,max(MOYMAT) as 'MOYMAT' " _
                                 & "FROM matieres GROUP BY ANSCMA, OPTIMA, ANETMA, COMAMA ;"
        cmdAccess.ExecuteNonQuery()

        cmdAccess.CommandText = "drop table inscrits; "
        cmdAccess.ExecuteNonQuery()
        cmdAccess.CommandText = "drop table matieres; "
        cmdAccess.ExecuteNonQuery()
        connAccess.Close()

        ''set database password
        db = CreateObject("Access.Application")
        db.OpenCurrentDatabase(dbPath, True)
        db.CurrentProject.Connection.Execute("ALTER DATABASE PASSWORD " & dbPassword & " NULL")
        db.CloseCurrentDatabase()
        db.Quit()
        MsgBox("Successfully done !" & vbCrLf & "Excecution time : " & Timer - start & " seconds")
    End Sub

End Module