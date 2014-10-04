Imports System.Windows.Forms

Public Class Change_Password

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If String.Compare(TextBox2.Text, TextBox3.Text) = 0 Then
            Dim cd As New OleDb.OleDbCommand
            Call connect()
            cnn.Open()
            cd.Connection = cnn
            Try
                cd.CommandText = "select * from privstaffhq where national_id='" & Trim(TextBox1.Text) & "'"
                Dim clow As String = cd.ExecuteScalar
                If clow = vbNullString Then


                    MsgBox("invalid attempt! your credentials are non existent ")
                    Me.Close()
                End If
            Catch ex As Exception

            End Try
            Try
                cd.CommandText = "Update Privstaffhq set Passcode='" & Trim(TextBox3.Text) & "' where National_Id ='" & Trim(TextBox1.Text) & "'"
                cd.ExecuteNonQuery()
                MsgBox("password updated successfully", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

        End If
        'Farmaster.frmaster.Close()
        Farmaster.Login.Show()
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Change_Password_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Farmaster.Login.Close()

    End Sub
End Class
