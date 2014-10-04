
Public Class frmaster

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        anidept.MdiParent = Me
        anidept.ShowInTaskbar = False
        anidept.WindowState = FormWindowState.Maximized
        anidept.Show()




    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        With Plantation
            .MdiParent = Me
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub ToolStripSplitButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.Click
        With farmasterReports
            .MdiParent = Me
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Show()
        End With

    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        With Accounts
            .MdiParent = Me
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Show()
        End With

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        With procurement
            .MdiParent = Me
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub ToolStripButton1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.MouseHover

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        'Farmasterabout.Show()
        With Staff
            .MdiParent = Me
            .ShowInTaskbar = False
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim x As String = DateTime.Now.Hour.ToString
        Dim m As String = DateTime.Now.Minute.ToString
        Dim s As String = DateTime.Now.Second.ToString
        Dim y As String
        Dim D As String = DateTime.Now.Day
        Dim MM As String = DateTime.Now.Month.ToString
        Dim yy As String = DateTime.Now.Year.ToString
        Dim ref As String





        If m < 10 Then
            m = "0" & m
        End If
        If s < 10 Then
            s = "0" & s
        End If


        If x > 12 Then
            y = "P.M."
            x -= 12

        Else
            y = "A.M."

        End If
        ToolStripStatusLabel1.Text = (DateTime.Now.DayOfWeek.ToString() & "  " & D & " : " & MM & " : " & yy)
        ToolStripStatusLabel3.Text = (x & " :" & m & " : " & s & " " & y.ToCharArray)

        ref = DateTime.Now.Second

        If ref Mod 267 = 0 Then
            Call mess()

        End If

    End Sub
    Private Sub mess()
        Dim conn As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=Farmaster;Persist Security Info=True;User ID=sa;Password=swiftshady")

        Dim strSQL As String = "SELECT  Header FROM messager where destination = '" & Trim(dept) & "'"
        Dim da As New SqlClient.SqlDataAdapter(strSQL, conn)
        Dim ds As New DataSet
        da.Fill(ds, "messager")
        With ListBox1
            .DataSource = ds.Tables("messager")
            .DisplayMember = "header"
            .ValueMember = "header"

            '.SelectedIndex = 0

        End With


    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Msnger.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick

        msgg = ListBox1.Text

        msgReceive.Show()


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class
