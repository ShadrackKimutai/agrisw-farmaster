Imports System.Data.oledb

Public Class animallreg
    Dim fx As Integer
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub combo1()


        Dim con As OleDbConnection = New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=NemesisFarmaster")

        Dim strSQL As String = "SELECT breedname FROM breed"
        Dim dat As New OleDb.OleDbDataAdapter(strSQL, con)
        Dim ds As New DataSet
        dat.Fill(ds, "breed")
        With ComboBox1
            .DataSource = ds.Tables("breed")
            .DisplayMember = "breedname"
            .ValueMember = "breedname"
            '.SelectedIndex = 0
        End With
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub animallreg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call combo1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        DateTimePicker1.Focus()
        DateTimePicker2.Visible = True
        Label2.Visible = True
        fx = 2


    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Focus()
        fx = 1
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        fx = 3
        DateTimePicker1.Focus()
        DateTimePicker2.Visible = False

    End Sub

    Private Sub Continuous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Continuous.CheckedChanged
        fx = 10
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsNumber(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rp As New dairyperf
        Dim rs As New animalhqrep
        Dim con As New OleDb.OleDbConnection
        Dim sconn As New OleDb.OleDbConnection
        Try
            conn.Close()
            Call connect()
            '  fx = 1
        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "An Error Occured")
        End Try
        conn.Open()
        Dim daSrch As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
        'Dim ds As DataSet = New DataSet
        Dim dt As DataTable = New DataTable
        Dim dsSrch As DataSet = New DataSet
        'Dim drSrch As DataRow
        Select Case fx
            Case 1
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where Animal_Name like'%" & TextBox1.Text & "%' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rs.SetDataSource(dt)
                    Reportcentral.CrystalReportViewer1.ReportSource = rs
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                conn.Close()
            Case 2
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where dor >'" & DateTimePicker1.Value & "' and dor< '" & DateTimePicker2.Value & "'", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rs.SetDataSource(dt)
                    Reportcentral.CrystalReportViewer1.ReportSource = rs
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                conn.Close()

            Case 3
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from animalhq Where breed like'%" & ComboBox1.Text & "%' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rs.SetDataSource(dt)
                    Reportcentral.CrystalReportViewer1.ReportSource = rs
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                conn.Close()
            Case 10
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select * from dairyhq ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Reportcentral.CrystalReportViewer1.ReportSource = rp
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                conn.Close()
        End Select
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        DateTimePicker1.Focus()
        DateTimePicker2.Visible = True
        Label2.Visible = True

    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        DateTimePicker1.Focus()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        fx = 3

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub
End Class
