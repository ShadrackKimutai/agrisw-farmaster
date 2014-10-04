Imports System.Data.OleDb
Public Class iTEMS

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SplitContainer1.Panel2Collapsed = False

        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub TextBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsSymbol(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub iTEMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call GRIDS()
    End Sub
    Private Sub GRIDS()
        Call GRID1()
        Call GRID2()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub GRID1()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from ITEMHQ where Category='iMPLEMENT'"
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
    Private Sub GRID2()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select * from ITEMHQ where Category='Chemical'"
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.ReadOnly = False

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click, Button4.Click
        SplitContainer1.Panel2Collapsed = False

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cd As New OleDbCommand
        Call connect()
        cnn.Open()
        cd.Connection = cnn
    
        Try


            cd.CommandText = "delete from itemhq where item_name='" & Trim(TextBox3.Text) & "'"
            cd.ExecuteNonQuery()
            MsgBox("Item '" & Trim(TextBox3.Text) & "' has been successfuly removed")
            'ComboBox1.Refresh()
        Catch ex As Exception
            MsgBox("There is no entry similar to the one provided", MsgBoxStyle.Exclamation)


        End Try
        procurement.ToolStripButton4.PerformClick()
    End Sub

    Private Sub TextBox1_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox2.ReadOnly = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.ReadOnly = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" And TextBox1.Text <> "" And TextBox2.Text <> "" Then
            TextBox1.Text = TextBox1.Text.ToUpper
            TextBox2.Text = TextBox2.Text.ToUpper

            Dim y As String
            Dim cd As New OleDbCommand
            Call connect()
            cnn.Open()
            cd.Connection = cnn
            cd.CommandText = "Select * from Itemhq where Item_name='" & Trim(TextBox2.Text) & "'"
            y = cd.ExecuteScalar
            If y = vbNullString Then
                Try


                    cd.CommandText = "Insert into itemhq(category,Item_type,Item_name) Values('" & Trim(ComboBox1.Text.ToCharArray) & "','" & Trim(TextBox1.Text) & "','" & Trim(TextBox2.Text) & "')"
                    cd.ExecuteNonQuery()
                    MsgBox("Item successfuly added")
                    'ComboBox1.Refresh()
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
            Else
                MsgBox("It seems the Item you are trying to add is already existent. Quiting...", MsgBoxStyle.Exclamation)

            End If
        End If
        procurement.ToolStripButton4.PerformClick()

    End Sub
End Class
