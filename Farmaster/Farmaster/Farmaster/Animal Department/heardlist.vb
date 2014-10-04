Public Class heardlist

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles herdlistgrid.CellContentClick
        herdlistgrid.CurrentRow.Selected = True
        With ToolTip1
            .SetToolTip(herdlistgrid, "Double Click to Update the entry")



            .ShowAlways = True
        End With
    End Sub

    Private Sub herd()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select ID,Tagid,Animal_name,Breed,Sex,Parent,DOB,DOR,Current_condition,Registered_by from ANIMALHQ where current_condition='healthy' or current_condition='Sick'"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            herdlistgrid.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub heardlist_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call herd()
        herdlistgrid.ReadOnly = True
        herdlistgrid.CurrentRow.Selected = True
        With ToolTip1
            .SetToolTip(herdlistgrid, "Updating Condition")
            .Show("Double click any cell to update current condition", Me, 5000)



            .ShowAlways = True
        End With
        

    End Sub

    Private Sub herdlistgrid_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles herdlistgrid.CellContentDoubleClick
        herdlistgrid.CurrentRow.Selected = True
        Dim tagno, cc, C_C As String

        herdlistgrid.CurrentRow.Selected = True
        If herdlistgrid.CurrentRow.Cells("TagID").Value.ToString <> vbNullString Then
            GoTo 4
        Else
            MsgBox("you have clicked on an empty row this is not allowed", MsgBoxStyle.Critical, "Error")
            Exit Sub

        End If

4:
        tagno = herdlistgrid.CurrentRow.Cells("TagID").Value.ToString
        
        cc = herdlistgrid.CurrentRow.Cells("current_condition").Value.ToString
        cc = cc.ToUpper

1:
        C_C = InputBox("What is the current condition? Healthy or Sick ?", "Current condition update")
        C_C = C_C.ToUpper



        If (C_C Like "SICK") Or C_C Like "HEALTHY" Then

            Try
                Dim cm As New OleDb.OleDbCommand
                Call connect()
                cm.Connection = cnn
                cm.Connection = cnn
                cm.Connection.Open()
                cm.CommandText = "UPDATE AnimalHQ SET Current_Condition = '" & Trim(C_C) & "' wHERE (TagID = '" & Trim(tagno) & "')"
                cm.ExecuteNonQuery()


                MsgBox("Entry Updates Successfuly", MsgBoxStyle.Information, "Updated")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox("The value you offered was rejected, use the selected replies", MsgBoxStyle.Exclamation, "Update Error")
            GoTo 2
        End If
        Call herd()

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
