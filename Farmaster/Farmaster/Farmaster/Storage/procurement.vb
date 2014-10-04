Public Class procurement
    Dim allp As AllpendingR
    Dim reqpr As RequestProc
    Dim res As Restock
    Dim it As iTEMS

    Private ReadOnly Property itl() As iTEMS
        Get
            Me.it = New iTEMS

            SplitContainer1.Panel2.Controls.Add(Me.it)
            Me.it.Dock = DockStyle.Fill
            Return Me.it

        End Get
    End Property
    Private ReadOnly Property apnd() As AllpendingR
        Get
            Me.allp = New AllpendingR

            SplitContainer1.Panel2.Controls.Add(Me.allp)
            Me.allp.Dock = DockStyle.Fill
            Return Me.allp

        End Get
    End Property
    '**************************************************
    Private ReadOnly Property rproc() As RequestProc
        Get
            Me.reqpr = New RequestProc
            SplitContainer1.Panel2.Controls.Add(Me.reqpr)
            Me.reqpr.Dock = DockStyle.Fill
            Return Me.reqpr
        End Get
    End Property
    '**************************************************
    Private ReadOnly Property rtk() As Restock
        Get
            Me.res = New Restock
            SplitContainer1.Panel2.Controls.Add(Me.res)
            Me.res.Dock = DockStyle.Fill
            Return Me.res
        End Get
    End Property

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call reset()
        Me.apnd.Visible = True
    End Sub
    Private Sub reset()
        SplitContainer1.Panel2.Controls.Clear()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call reset()
        Me.rproc.Visible = True
        Dim cd As New OleDb.OleDbCommand
        Call connect()
        cnn.Open()
        cd.Connection = cnn
        Try
            cd.CommandText = "Delete  from storagehq where qtty=0"
            cd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub procurement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With frmaster
            .ToolStripButton5.BackColor = Color.Transparent
            ' .ToolStripButton5.Font.Bold.ToString()
        End With
    End Sub

    Private Sub procurement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With frmaster
            .ToolStripButton5.BackColor = Color.SteelBlue
            .ToolStripButton5.Font.Bold.ToString()
        End With
        Me.ToolStripButton1.PerformClick()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Call reset()
        Me.rtk.Visible = True


    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Call reset()
        Me.itl.Visible = True

    End Sub
End Class