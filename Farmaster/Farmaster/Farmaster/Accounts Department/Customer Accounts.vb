Public Class Customer_Accounts
    Dim Tx As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rp As New SOA
        'Dim rs As New animalhqrep
        Dim con As New OleDb.OleDbConnection
        Dim sconn As New OleDb.OleDbConnection
        Try
            cnn.Close()
            Call connect()

        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "An Error Occured")
        End Try
        cnn.Open()
        Dim daSrch As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
        'Dim ds As DataSet = New DataSet
        Dim dt As DataTable = New DataTable
        Dim dsSrch As DataSet = New DataSet

        Select Case Tx

            Case 1
                'Try
                '    daSrch.SelectCommand = New OleDb.OleDbCommand("select *  FROM cropsales Where CustomerID like'%" & ComboBox1.Text & "%' ", cnn)
                '    dsSrch.Clear()
                '    daSrch.Fill(dt)
                '    rp.SetDataSource(dt)
                '    Me.accviewer.ReportSource = rp
                'Catch ex As Exception

                '    MsgBox(ex.Message)
                'End Try
                'cnn.Close()
            Case 2
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select *  FROM farmastermilksales Where CustomerID like'%" & ComboBox1.Text & "%' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.accviewer.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
        End Select

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Please choose eigther of the available options", MsgBoxStyle.Information)
        Else
            If RadioButton1.Checked = True Then
                GroupBox2.Enabled = False
                GroupBox3.Enabled = True

                Tx = 1
            Else
                GroupBox2.Enabled = True
                GroupBox3.Enabled = False
                Tx = 2

                Call filldry()
            End If
        End If
    End Sub
    Private Sub fillplt()
        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT distinct CustomerID FROM cropsales"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "cropsales")
        With ComboBox2
            .DataSource = dset.Tables("cropsales")
            .DisplayMember = "customerid"
            .ValueMember = "Customerid"
            '
        End With
    End Sub
    Private Sub filldry()
        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT  distinct CustomerID FROM FarmasterMilkSales"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "FarmasterMilkSales")
        With ComboBox1
            .DataSource = dset.Tables("FarmasterMilkSales")
            .DisplayMember = "customerid"
            .ValueMember = "Customerid"
            '
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim rp As New SOAP
        'Dim rs As New animalhqrep
        Dim con As New OleDb.OleDbConnection
        Dim sconn As New OleDb.OleDbConnection
        Try
            cnn.Close()
            Call connect()

        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "An Error Occured")
        End Try
        cnn.Open()
        Dim daSrch As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
        'Dim ds As DataSet = New DataSet
        Dim dt As DataTable = New DataTable
        Dim dsSrch As DataSet = New DataSet

        Select Case Tx

            Case 1
                Try
                    daSrch.SelectCommand = New OleDb.OleDbCommand("select *  FROM cropsales Where CustomerID like'%" & ComboBox2.Text & "%' ", cnn)
                    dsSrch.Clear()
                    daSrch.Fill(dt)
                    rp.SetDataSource(dt)
                    Me.accviewer.ReportSource = rp
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
                cnn.Close()
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        
    End Sub
End Class
