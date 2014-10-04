Imports System.String
Imports System.IO
Public Class RequestProc

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub RequestProc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call fillchemgrids()

    End Sub

    Private Sub chemlistviewfill()

        Try

            Call connect()
            cnn.Open()
            chemview.View = View.Details
            chemview.Scrollable = False
            chemview.FullRowSelect.ToString()
            chemview.Items.Clear()
            Dim command As New OleDb.OleDbCommand("SELECT   ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO from requesthq where category='Chemical' ORDER BY Status DESC", cnn)
            Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
            Do While dreader.Read()
                '(dreader.Item("Department").ToString)
                Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)
                'INSERTED.SubItems.Add(dreader.Item("status").ToString)

                INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                chemview.Items.Add(INSERTED)

            Loop
            cnn.Close()
            Dim wid As Integer
            For i As Integer = 0 To chemview.Columns.Count - 1
                chemview.Columns(i).Width = -2
                wid += chemview.Columns(i).Width

            Next i

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub fillchemgrids()
        Call pendin()
        Call instorage()
        Call chemlistviewfill()
        ToolStripComboBox1.SelectedIndex = 0

    End Sub
    Private Sub fillimplgrids()
        Call impending()
        Call impinstorage()
        Call implistviewfill()

        ToolStripComboBox2.SelectedIndex = 0
    End Sub
    Private Sub pending()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select id,Department,ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq as Dated_On,RO as Requested_by from RequestHQ WHERE STATUS =1 and Category='Chemical'"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            Datapendchem.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub impending()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select id,Department,ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq as Dated_On,RO as Requested_by from RequestHQ WHERE STATUS =1 and Category='Implement'"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            Impledatagrid.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub impinstorage()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from storageHQ where Category='Implement'"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            stoimpledatagrid.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Datapendchem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datapendchem.CellContentClick

    End Sub
    Private Sub pendin()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select id,Department,itemreqid,category,Item_Type,Item_Name,Quantity,Units,DOReq as Dated_On,RO as Requested_by from RequestHQ WHERE STATUS =1 and Category='Chemical'" ' Department,ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq as Dated_On,Urgency,RO as Requested_by
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            Datapendchem.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub instorage()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from storageHQ where Category='Chemical'"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            Datastochem.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Impledatagrid.CellContentClick

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 1
                Call fillimplgrids()
            Case 2
                MsgBox("2")
            Case 0
                Call fillchemgrids()

        End Select
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles implview.SelectedIndexChanged

    End Sub
    Private Sub chemtype()
        If ToolStripComboBox1.Text = "Class" Then

            Try

                Call connect()
                cnn.Open()
                chemview.View = View.Details
                chemview.Scrollable = True
                chemview.FullRowSelect.ToString()
                chemview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='chemical' and Item_type LIKE '" & "%" & ToolStripTextBox1.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    chemview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To chemview.Columns.Count - 1
                    chemview.Columns(i).Width = -2
                    wid += chemview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Private Sub implnamesearch()
        If ToolStripComboBox2.Text = "Name" Then

            Try

                Call connect()
                cnn.Open()
                implview.View = View.Details
                implview.Scrollable = True
                implview.FullRowSelect.ToString()
                implview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='Implement' and Item_Name LIKE '" & "%" & ToolStripTextBox2.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    implview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To implview.Columns.Count - 1
                    implview.Columns(i).Width = -2
                    wid += implview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub chemnamesearch()
        If ToolStripComboBox1.Text = "Name" Then

            Try

                Call connect()
                cnn.Open()
                chemview.View = View.Details
                chemview.Scrollable = True
                chemview.FullRowSelect.ToString()
                chemview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='chemical' and Item_Name LIKE '" & "%" & ToolStripTextBox1.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    chemview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To chemview.Columns.Count - 1
                    chemview.Columns(i).Width = -2
                    wid += chemview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Private Sub chemreqsearch()
        If ToolStripComboBox1.Text = "Requested By" Then

            Try

                Call connect()
                cnn.Open()
                chemview.View = View.Details
                chemview.Scrollable = True
                chemview.FullRowSelect.ToString()
                chemview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='chemical' and  ro LIKE '" & "%" & ToolStripTextBox1.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    chemview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To chemview.Columns.Count - 1
                    chemview.Columns(i).Width = -2
                    wid += chemview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub impreqsearch()

        If ToolStripComboBox2.Text = "Requested By" Then

            Try

                Call connect()
                cnn.Open()
                implview.View = View.Details
                implview.Scrollable = True
                implview.FullRowSelect.ToString()
                implview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category ='implement' and ro LIKE '" & "%" & ToolStripTextBox2.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    implview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To implview.Columns.Count - 1
                    implview.Columns(i).Width = -2
                    wid += implview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub impltype()
        If ToolStripComboBox2.Text = "Class" Then

            Try

                Call connect()
                cnn.Open()
                implview.View = View.Details
                implview.Scrollable = True
                implview.FullRowSelect.ToString()
                implview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='Implement' and Item_type LIKE '" & "%" & ToolStripTextBox2.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    implview.Items.Add(INSERTED)

                Loop
                cnn.Close()
                Dim wid As Integer
                For i As Integer = 0 To implview.Columns.Count - 1
                    implview.Columns(i).Width = -2
                    wid += implview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub


    Private Sub chemordersearch()
        If ToolStripComboBox1.Text = "Order Number" Then

            Try

                Call connect()
                cnn.Open()
                chemview.View = View.Details
                chemview.Scrollable = True
                chemview.FullRowSelect.ToString()
                chemview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='chemical' and ItemReqid LIKE '" & "%" & ToolStripTextBox1.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    chemview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To chemview.Columns.Count - 1
                    chemview.Columns(i).Width = -2
                    wid += chemview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Private Sub impordersearch()
        If ToolStripComboBox2.Text = "Order Number" Then

            Try

                Call connect()
                cnn.Open()
                implview.View = View.Details
                implview.Scrollable = True
                implview.FullRowSelect.ToString()
                implview.Items.Clear()
                Dim command As New OleDb.OleDbCommand("SELECT ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO From requestHQ where category='Implement' and ItemReqid LIKE '" & "%" & ToolStripTextBox2.Text & "%'", cnn)
                Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
                Do While dreader.Read()
                    Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                    INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                    INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                    INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                    INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                    implview.Items.Add(INSERTED)

                Loop
                conn.Close()
                Dim wid As Integer
                For i As Integer = 0 To implview.Columns.Count - 1
                    implview.Columns(i).Width = -2
                    wid += implview.Columns(i).Width
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Public Sub implistviewfill()

        Try

            Call connect()
            cnn.Open()
            implview.View = View.Details
            implview.Scrollable = False
            implview.FullRowSelect.ToString()
            implview.Items.Clear()
            Dim command As New OleDb.OleDbCommand("SELECT   ItemReqid,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO from requesthq where category='Implement' ORDER BY Status DESC", cnn)
            Dim dreader As OleDb.OleDbDataReader = command.ExecuteReader()
            Do While dreader.Read()

                Dim INSERTED As New ListViewItem(dreader.Item("ItemReqid").ToString)
                INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)


                INSERTED.SubItems.Add(dreader.Item("RO").ToString)


                implview.Items.Add(INSERTED)

            Loop
            conn.Close()
            Dim wid As Integer
            For i As Integer = 0 To implview.Columns.Count - 1
                implview.Columns(i).Width = -2
                wid += implview.Columns(i).Width

            Next i

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chemview_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles implview.SelectedIndexChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.Click

    End Sub

    Private Sub ToolStripTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.TextChanged

    End Sub

    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call chemordersearch()
        Call chemtype()
        Call chemnamesearch()
        Call chemreqsearch()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call impordersearch()
        Call impreqsearch()
        Call implnamesearch()
        Call impltype()
    End Sub

    Private Sub Datapendchem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Datapendchem.DoubleClick
        Dim ordn, cat, itype, iname, qty, units, urg, ro, d As String
        Dim dorg As Date
        ordn = Datapendchem.CurrentRow.Cells("ItemReqid").Value.ToString
        cat = Datapendchem.CurrentRow.Cells("category").Value.ToString
        itype = Datapendchem.CurrentRow.Cells("Item_type").Value.ToString
        iname = Datapendchem.CurrentRow.Cells("Item_Name").Value.ToString
        qty = Datapendchem.CurrentRow.Cells("Quantity").Value
        units = Datapendchem.CurrentRow.Cells("Units").Value.ToString
        dorg = Datapendchem.CurrentRow.Cells("dATED_ON").Value
        'sts = Datapendchem.CurrentRow.Cells("status").Value.ToString
        ' urg = Datapendchem.CurrentRow.Cells("Urgency").Value.ToString
        ro = Datapendchem.CurrentRow.Cells("Requested_by").Value.ToString
        d = Datapendchem.CurrentRow.Cells("Department").Value.ToString

        Call connect()
        cnn.Open()
        Dim stocat, stoype, stoiname, stoid, rid, stouni, rofficer As String
        Dim dop As Date
        Dim qtty As Integer
        Dim lstrw As OleDb.OleDbDataReader
        ' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
        Dim cEmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM storageHq WHERE category Like '%CHEMICAL%' And Type='" & itype.ToCharArray & "' and Name='" & iname.ToCharArray & "'", cnn)
        lstrw = cEmd.ExecuteReader


        While lstrw.Read

            stoid = lstrw("ItemBatchNo")
            stouni = lstrw("Units")
            stocat = lstrw("Category")
            stoype = lstrw("type")
            stoiname = lstrw("name")
            rid = lstrw("CLass")
            dop = lstrw("Supplied_on")
            qtty = lstrw("qtty")
            rofficer = lstrw("received_by")

            stouni = stouni.ToUpper()

        End While
        units = units.ToUpper()
        ' floatingpane.StoIDTextBox.Text = s
        If stoiname = "" Then
            GoTo unavail
        Else

            Dim CHECK
            ' MsgBox("" & stoiname & "" & iname & "")

            If String.Compare(iname.ToCharArray, stoiname.ToCharArray) Then
                CHECK = 1


            Else
                CHECK = 0
            End If
            'MsgBox(CHECK)
            Floatingpane.OrderNoTextBox.Text = ordn
            Floatingpane.StoIDTextBox.Text = stoid

            Floatingpane.TopMost = True
            Floatingpane.Show()

        End If
        Exit Sub

unavail:
        MsgBox("The chemical that you requested is Out of stock. Farmaster recomends that you restock it ASAP", MsgBoxStyle.Information, "Out of Stock")
        procurement.ToolStripButton3.PerformClick()
    End Sub

    Private Sub Impledatagrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Impledatagrid.DoubleClick
        Dim ordn, cat, itype, iname, qty, units, urg, ro, d As String
        Dim dorg As Date
        ordn = Impledatagrid.CurrentRow.Cells("ItemReqid").Value.ToString
        cat = Impledatagrid.CurrentRow.Cells("category").Value.ToString
        itype = Impledatagrid.CurrentRow.Cells("Item_type").Value.ToString
        iname = Impledatagrid.CurrentRow.Cells("Item_Name").Value.ToString
        qty = Impledatagrid.CurrentRow.Cells("Quantity").Value
        units = Impledatagrid.CurrentRow.Cells("Units").Value.ToString
        dorg = Impledatagrid.CurrentRow.Cells("dATED_ON").Value
        'sts = Impledatagrid.CurrentRow.Cells("status").Value.ToString
        'urg = Impledatagrid.CurrentRow.Cells("Urgency").Value.ToString
        ro = Impledatagrid.CurrentRow.Cells("Requested_by").Value.ToString
        d = Impledatagrid.CurrentRow.Cells("Department").Value.ToString

        Call connect()
        cnn.Open()
        Dim stocat, stoype, stoiname, stoid, rid, stouni, rofficer As String
        Dim dop As Date
        Dim qtty As Integer
        Dim lstrw As OleDb.OleDbDataReader
        ' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
        Dim cEmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM storageHq WHERE category Like '%Implement%' And Type='" & itype.ToCharArray & "' and Name='" & iname.ToCharArray & "'", cnn)
        lstrw = cEmd.ExecuteReader


        While lstrw.Read

            stoid = lstrw("ItemBatchNo")
            stouni = lstrw("Units")
            stocat = lstrw("Category")
            stoype = lstrw("type")
            stoiname = lstrw("name")
            rid = lstrw("CLass")
            dop = lstrw("Supplied_on")
            qtty = lstrw("qtty")
            rofficer = lstrw("received_by")

            stouni = stouni.ToUpper()

        End While
        units = units.ToUpper()
        ' floatingpane.StoIDTextBox.Text = s
        If stoiname = "" Then
            GoTo unavail
        Else

            Dim CHECK
            ' MsgBox("" & stoiname & "" & iname & "")

            If String.Compare(iname.ToCharArray, stoiname.ToCharArray) Then
                CHECK = 1


            Else
                CHECK = 0
            End If
            'MsgBox(CHECK)
            Floatingpane.OrderNoTextBox.Text = ordn
            Floatingpane.StoIDTextBox.Text = stoid

            Floatingpane.TopMost = True
            Floatingpane.Show()

        End If
        Exit Sub
unavail:
        MsgBox("The Implement you requested is out of stock. Farmaster recomends restocking", MsgBoxStyle.Exclamation)
        procurement.ToolStripButton3.PerformClick()

    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class
