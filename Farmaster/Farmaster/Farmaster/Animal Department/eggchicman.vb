Public Class eggchicman

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsSymbol(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim t As Integer = TextBox1.Text
        Dim x As Integer = 0
        With ComboBox1
            If t > 0 Then
                .Items.Clear()

                While x < t
                    .Items.Add(x)
                    x += 1


                End While
                .Items.Add(x)
            Else
                .Items.Add(x)
            End If


            .SelectedIndex = 0
        End With
    End Sub
    Private Sub filllot()
        Dim pattID, tempid, temp1 As Integer


        Temp1 = Val(Temp1) + 1

        Try
genesis:
            pattID = Temp1
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 id From eggtable Where ID='" & pattID & "' ORDER BY ID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                tempid = pattID
            Else
                Temp1 += 1
                GoTo genesis

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Dim a, b, c As String

        a = DateTime.Now.Day.ToString

        b = DateTime.Now.Month.ToString

        c = DateTime.Now.Year.ToString

        TextBox3.Text = "LTNo" & tempid & "" & Trim(a) & "" & Trim(b) & "" & Trim(c) & ""
      
    End Sub


    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class
