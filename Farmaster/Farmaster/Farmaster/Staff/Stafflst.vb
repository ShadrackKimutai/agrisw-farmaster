Public Class Stafflst

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Stafflst_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call grids()
    End Sub
    Private Sub grids()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "SELECT [ID], [SysID], [First_Name], [Last_Name], [National_ID], [DOE], [POE], [DEPARTMENT], [SUB_DEPARTMENT], [USERNAME],STATUS from PrivStaffHQ WHere status='ON DUTY' OR status='ON LEAVE'"
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
        DataGridView1.CurrentRow.Selected = True

    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        DataGridView1.CurrentRow.Selected = True

        Dim tagno, cc, C_C As String

        DataGridView1.CurrentRow.Selected = True
        If DataGridView1.CurrentRow.Cells("sysid").Value.ToString <> vbNullString Then
            GoTo 4
        Else
            MsgBox("you have clicked on an empty row this is not allowed", MsgBoxStyle.Critical, "Error")
            Exit Sub

        End If

4:
        tagno = DataGridView1.CurrentRow.Cells("sysID").Value.ToString

        cc = DataGridView1.CurrentRow.Cells("status").Value.ToString
        cc = cc.ToUpper

1:
        C_C = InputBox("What is the current condition? ON DUTY or ON LEAVE ?", "Current condition update")
        C_C = C_C.ToUpper



        If (C_C Like "ON DUTY") Or C_C Like "ON LEAVE" Then

            Try
                Dim cm As New OleDb.OleDbCommand
                Call connect()
                cm.Connection = cnn
                cm.Connection = cnn
                cm.Connection.Open()
                cm.CommandText = "UPDATE privstaffHQ SET status = '" & Trim(C_C) & "' wHERE (sysID = '" & Trim(tagno) & "')"
                cm.ExecuteNonQuery()


                MsgBox("Entry Updates Successfuly", MsgBoxStyle.Information, "Updated")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox("The value you offered was rejected, use the selected replies", MsgBoxStyle.Exclamation, "Update Error")
            GoTo 2
        End If
        Call grids()

        Exit Sub

2:

        Dim c As MsgBoxResult = MsgBox("do you still want to try the task", MsgBoxStyle.YesNo, "Retry Task")
        If c = MsgBoxResult.Yes Then
            GoTo 1
        Else
            Exit Sub
        End If



    End Sub
End Class
