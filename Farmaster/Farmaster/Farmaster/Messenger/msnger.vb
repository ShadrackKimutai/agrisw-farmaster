Imports System.Math
Imports Microsoft.VisualBasic.VBMath

Public Class Msnger
    Dim a As Integer = 60
    Dim batchkey As Double

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim x As Integer = a - TextBox1.TextLength
        Label3.Text = x

        RichTextBox1.ReadOnly = False
        RichTextBox1.BackColor = Color.White



    End Sub
    Private Sub bch()
        Dim k As String


        k = DateTime.Now.Millisecond.ToString
        '  batchkey = VBMath.Rnd() 'as double

        'batchkey = batchkey * 100000
        'batchkey = Math.Truncate(batchkey)


        'MsgBox(k) 'batchkey)

    End Sub



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.MaxLength = 60

        Call gonno()

    End Sub
    Private Sub gonno()
        Dim conn As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=Farmaster;Persist Security Info=True;User ID=sa;Password=swiftshady")

        Dim strSQL As String = "SELECT distinct dept FROM depart"
        Dim da As New SqlClient.SqlDataAdapter(strSQL, conn)
        Dim ds As New DataSet
        da.Fill(ds, "depart")

        With ComboBox1
            .DataSource = ds.Tables("depart")
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .SelectedIndex = 0
            '********************************************************

        End With
        Call incl()
    End Sub
    Private Sub incl()
        With ComboBox1
            '.Items.Insert(0, "All")
        End With

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.ReadOnly = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ca As New OleDb.OleDbCommand
        TextBox1.Text = "" & Trim(TextBox1.Text) & " Sent at " & Trim(DateTime.Now.Hour.ToString) & ":" & Trim(DateTime.Now.Minute.ToString) & ""
        Call connect()
        cnn.Open()
        ca.Connection = cnn
        Try
            ca.CommandText = " select * from messager where header='" & Trim(TextBox1.Text) & "'"

            Dim checkexist As String = ca.ExecuteScalar()
            If checkexist = vbNullString Then
            Else
                MsgBox("The Header you typed already exists. Please change the header", MsgBoxStyle.Exclamation)
                TextBox1.Focus()
                Exit Sub

            End If
        Catch ex As Exception

        End Try
        Try
            ca.CommandText = "Insert into messager(Destination,header,message,sender,dept,flag,sent_on) Values('" & Trim(ComboBox1.Text) & "','" & Trim(TextBox1.Text) & "','" & Trim(RichTextBox1.Text) & "','" & Trim(logged) & "','" & Trim(dept) & "','1',getdate())"
            ca.ExecuteNonQuery()
            MsgBox("Message sent", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FontColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        Me.RichTextBox1.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub FontTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontTypeToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        Me.RichTextBox1.Font = FontDialog1.Font
    End Sub
End Class
