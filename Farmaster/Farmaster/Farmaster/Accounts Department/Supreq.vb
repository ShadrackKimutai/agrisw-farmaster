Public Class Supreq

    Dim s, t, r, itm, q, o, p, itmbat As String

    Private Sub orderGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles orderGrid.CellContentClick
        orderGrid.CurrentRow.Selected = True

    End Sub

    Private Sub Supreq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call fillorder()
    End Sub
    Private Sub fillorder()
        Dim cnn2 As New OleDb.OleDbConnection
        Dim adept As OleDb.OleDbDataAdapter
        Dim strng As String
        Dim dst2 As New DataSet
        Dim connectionstring1 As String
        connectionstring1 = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn2 = New OleDb.OleDbConnection(connectionstring1)
        strng = "Select    Id, ItemOrderID, Category, Item_Type, Item_Name, Quantity, Units, Ordate, Ordered_by  from orderhq"

        Try
            cnn2.Open()
            adept = New OleDb.OleDbDataAdapter(strng, cnn2)
            adept.Fill(dst2)
            cnn2.Close()
            orderGrid.DataSource = dst2.Tables(0)
            grid.DataSource = dst2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub orderGrid_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles orderGrid.CellContentDoubleClick
        itm = orderGrid.CurrentRow.Cells("ItemOrderID").Value.ToString
        Dim rp As New supplyletter
        'Dim cnn As New OleDb.OleDbConnection

        Try
            'cnn.Close()
            Call connect()

        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "An Error Occured")
        End Try
        cnn.Open()
        Dim daSrch As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
        'Dim ds As DataSet = New DataSet
        Dim dt As DataTable = New DataTable
        Dim dsSrch As DataSet = New DataSet

        Try
            daSrch.SelectCommand = New OleDb.OleDbCommand("select *  FROM orderhq Where itemorderID like'%" & Trim(itm.ToCharArray) & "%' ", cnn)
            dsSrch.Clear()
            daSrch.Fill(dt)
            rp.SetDataSource(dt)
            semireportviewer.ReportSource = rp
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        cnn.Close()

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Try
                If semireportviewer.ReportSource = vbNullString Then

                Else
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            MsgBox("Select the items from tab page 1 to initiate the document", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 0
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellContentClick
        grid.CurrentRow.Selected = True

    End Sub

    Private Sub grid_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellContentDoubleClick

        s = grid.CurrentRow.Cells("item_name").Value.ToString
        t = grid.CurrentRow.Cells("quantity").Value.ToString
        r = grid.CurrentRow.Cells("units").Value.ToString
        q = grid.CurrentRow.Cells("category").Value.ToString
        o = grid.CurrentRow.Cells("item_type").Value.ToString
        itmbat = grid.CurrentRow.Cells("itemorderid").Value.ToString

        TextBox1.Text = s
        TextBox2.Text = t
        TextBox3.Text = r
        TextBox4.Text = r
        TextBox6.Text = s

        NumericUpDown1.Value = 0

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub genny()
        Dim pattID, Prodid As String
        Dim Temp1 As Integer
        Dim a, b, c, k As String
        With DateTime.Now
            a = .Day.ToString
            b = .Month.ToString
            c = .Year.ToString

        End With
        k = a + b + c

        Temp1 = Val(Temp1) + 1
        Prodid = "CID"
        Try
start:
            pattID = Prodid & Temp1 & k
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 itembatchno From storageHQ Where itembatchno='" & pattID.ToCharArray & "' ORDER BY itembatchno DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                p = pattID
            Else
                Temp1 += 1
                GoTo start

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call genny()
        'ItemBatchNo, Category, Type, Name, Qtty, Units, Supplied_On, Class, Received_By
        Dim cd As New OleDb.OleDbCommand
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        'MsgBox(t)
        'MsgBox(r)
        'MsgBox(itm)
        'MsgBox(q)
        'MsgBox(o)
        'MsgBox(p)
        'MsgBox(itmbat)
        'MsgBox(s)
        Try
            cd.CommandText = "insert into storagehq(ItemBatchNo,Category, Type, Name, Qtty, Units, Supplied_On, Class, Received_By) values('" & Trim(p) & "','" & Trim(q) & "','" & Trim(o) & "','" & Trim(s) & "','" & Trim(NumericUpDown1.Value.ToString) & "','" & Trim(r) & "','" & Trim(Today) & "','Z','" & Trim(logged) & "')"
            cd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            cd.CommandText = "delete from orderhq where itemorderid='" & Trim(itmbat) & "'"
            cd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub
End Class
