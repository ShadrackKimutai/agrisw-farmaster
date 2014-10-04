Public Class msgReceive

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Msnger.Show()


        Me.Close()
    End Sub

    Private Sub msgReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox3.Text = msgg
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim d, o As String
        Dim cd As New OleDb.OleDbCommand
        Dim lstrw As OleDb.OleDbDataReader
        Call connect()
        cnn.Open()

        cd.Connection = cnn
        cd.CommandText = "Select * from messager where header='" & Trim(TextBox3.Text) & "'"
        lstrw = cd.ExecuteReader
        While lstrw.Read

            TextBox1.Text = lstrw("Sender")
            TextBox2.Text = lstrw("Dept")
            RichTextBox1.Text = lstrw("message")
        End While
    End Sub
End Class