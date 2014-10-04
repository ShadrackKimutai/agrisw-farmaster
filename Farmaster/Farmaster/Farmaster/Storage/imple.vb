Imports System.Data.OleDb
Imports System.String
Imports System.IO
Imports System.Data.SqlClient
Public Class implEmt

    Private Sub chem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call imptorage()
        Call impREQS()
        listviewfill()

    End Sub
    Private Sub imptorage()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=NemesisFarmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from STORAGEHQ WHERE CATEGORY LIKE '%IMPLEMENT%' AND QTTY >2"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView2.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub impREQS()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=NemesisFarmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select Department,OrderNo,category,Item_Type,Item_Name,Quantity,Units,DOReq,Urgency,RO from REQUESTHQ WHERE CATEGORY LIKE '%IMPLEMENT%' and status =1"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)


            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView1.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        OrdN = DataGridView1.CurrentRow.Cells("orderNo").Value.ToString
        Cat = DataGridView1.CurrentRow.Cells("category").Value.ToString
        Itype = DataGridView1.CurrentRow.Cells("Item_type").Value.ToString
        Iname = DataGridView1.CurrentRow.Cells("Item_Name").Value.ToString
        qty = DataGridView1.CurrentRow.Cells("Quantity").Value
        units = DataGridView1.CurrentRow.Cells("Units").Value.ToString
        dorg = DataGridView1.CurrentRow.Cells("DOReq").Value.ToString
        'sts = DataGridView1.CurrentRow.Cells("status").Value.ToString
        urg = DataGridView1.CurrentRow.Cells("Urgency").Value.ToString
        ro = DataGridView1.CurrentRow.Cells("Ro").Value.ToString
        d = DataGridView1.CurrentRow.Cells("Department").Value.ToString


        Call connect()
        cnn.Open()
        Dim stocat, stoype, stoiname, stoid, rid, stouni, rofficer As String
        Dim dop As Date
        Dim qtty As Integer
        Dim lstrw As OleDbDataReader
        ' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
        Dim cEmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM storageHq WHERE category Like '%IMPLEMENT%' And Item_Type='" & Itype.ToCharArray & "' and Item_Name='" & Iname.ToCharArray & "'", cnn)
        lstrw = cEmd.ExecuteReader


        While lstrw.Read

            stoid = lstrw("stoid")
            stouni = lstrw("Units")
            stocat = lstrw("Category")
            stoype = lstrw("Item_type")
            stoiname = lstrw("Item_name")
            rid = lstrw("rid")
            dop = lstrw("dop")
            qtty = lstrw("qtty")
            rofficer = lstrw("rofficer")

            stouni = stouni.ToUpper()

        End While

        units = units.ToUpper()
        'MsgBox("" & stoiname & "" & Iname & "")

        If Compare(stoiname, Iname) Then
            check = 1


        Else
            check = 0
        End If
        'MsgBox(check)
        If check = 1 Then

            demp = 1

            floatingpane.OrderNoTextBox.Text = OrdN
            floatingpane.StoIDTextBox.Text = stoid

            floatingpane.Show()
        Else

            Dim mes1 As MsgBoxResult
            mes1 = MsgBox("The requested item is out of stock, do you want to place a request?", MsgBoxStyle.YesNo, "Out of Stock!")
            If mes1 = MsgBoxResult.Yes Then

                storageT.ToolStripButton4.PerformClick()
            Else


            End If

        End If


    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Public Sub listviewfill()

        Try
            conn.Close()
            Call connect()
            conn.Open()
            chemview.View = View.Details
            chemview.Scrollable = True
            chemview.FullRowSelect.ToString()
            chemview.Items.Clear()
            Dim command As New SqlCommand("SELECT   Department,OrderNo,category,Item_Type,Item_Name,Quantity,Units,DOReq,status,RO from requesthq wHERE CATEGORY='IMPLEMENT'", conn)
            Dim dreader As SqlDataReader = command.ExecuteReader()
            Do While dreader.Read()
                Dim INSERTED As New ListViewItem(dreader.Item("Department").ToString)
                INSERTED.SubItems.Add(dreader.Item("OrderNo").ToString)
                INSERTED.SubItems.Add(dreader.Item("Category").ToString)
                INSERTED.SubItems.Add(dreader.Item("Item_Type").ToString)
                INSERTED.SubItems.Add(dreader.Item("Item_name").ToString)
                INSERTED.SubItems.Add(dreader.Item("quantity").ToString)
                INSERTED.SubItems.Add(dreader.Item("Units").ToString)
                INSERTED.SubItems.Add(dreader.Item("DOreq").ToString)
                INSERTED.SubItems.Add(dreader.Item("status").ToString)

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
    End Sub

    Private Sub chemview_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chemview.SelectedIndexChanged

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
End Class
