Imports System.Data.OleDb

Public Class CustReg
    Dim tempid As Integer
    Dim ex As String

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub


    Private Sub CustReg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call nextid()
        Call genncustid()
        Call filla()
    End Sub
    Private Sub nextid()
        Dim pattID As Integer

        Dim Temp1 As Integer
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
            newpermcmd.CommandText = "Select top 1 id From customerHQ Where ID='" & pattID & "' ORDER BY ID DESC"
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
    End Sub
    Private Sub genncustid()
        Dim pattID, Prodid As String
        Dim Temp1 As Integer
        Dim a, b, c, k As String
        With DateTime.Now
            a = .Day.ToString
            b = .Month.ToString
            c = .Year.ToString

        End With
        k = a + b + c

        Temp1 = Val(Temp1) + 1
        Prodid = "CID"
        Try
start:
            pattID = Prodid & Temp1 & k
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select top 1 customer_id From customerHQ Where customer_ID='" & pattID.ToCharArray & "' ORDER BY Customer_ID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                TextBox1.Text = pattID
            Else
                Temp1 += 1
                GoTo start

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Choose a radiobutton to proceed", MsgBoxStyle.Exclamation)
        Else
            GroupBox2.Enabled = True
            Addres.Show()
            'Dim x As String = InputBox("Enter The Box Number and Town The rest will be entered for you (as shown in the example below)", , " 0 ,TOWN")
            'If x <> "" Or x <> " 0 ,TOWN" Or Char.IsSymbol(x) Then



        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
            TextBox1.Text = TextBox1.Text.ToUpper()
            TextBox2.Text = TextBox2.Text.ToUpper()
            TextBox3.Text = TextBox3.Text.ToUpper()
            TextBox4.Text = TextBox4.Text.ToUpper()

            GroupBox3.Enabled = True
            ComboBox1.SelectedIndex = 0
            ComboBox1.Focus()
            TextBox5.Text = logged
        Else
            MsgBox("There is an input that still is not correctly inserted ", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub TextBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Click
        'Addres.Show()
        'Dim x As String = InputBox("Enter The Box Number and Town The rest will be entered for you (as shown in the example below)", , " 0 ,TOWN")
        'If x <> "" Or x <> " 0 ,TOWN" Or Char.IsSymbol(x) Then

        TextBox4.Text = sterm
        'Else
        '    MsgBox("The input you provided seems incorect")
        'End If

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox4.Text = sterm
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button4.Enabled = True
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sharon As String
        If RadioButton1.Checked = True Then
            sharon = "DAIRY"
        Else
            sharon = "PLANTATION"
        End If
        Dim dorris As New OleDb.OleDbCommand
        Call connect()
        cnn.Open()
        dorris.Connection = cnn
        Try
            dorris.CommandText = "Insert into Customerhq(Id, Product, Customer_ID, First_Name, Last_Name, Address, MOP, DOR, Registered_By) values('" & Trim(tempid) & "','" & Trim(sharon) & "','" & Trim(TextBox1.Text) & "','" & Trim(TextBox2.Text) & "','" & Trim(TextBox3.Text) & "','" & Trim(TextBox4.Text) & "','" & Trim(ComboBox1.Text) & "','" & Trim(DateTimePicker1.Value) & "','" & Trim(TextBox5.Text) & "')"
            dorris.ExecuteNonQuery()
            MsgBox("Customer has been registered successfuly")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Accounts.ToolStripButton3.PerformClick()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Accounts.ToolStripButton3.PerformClick()

    End Sub
    Private Sub filla()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "SELECT * from Customerhq"
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
    Private Sub fillb()

        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "SELECT * from plantationorder"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView2.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Call fillc()
    End Sub
    Private Sub fillc()


        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "SELECT * from Milkorder"
        Try
            cnn1.Open()
            adpt = New OleDb.OleDbDataAdapter(strg, cnn1)
            adpt.Fill(dst1)
            cnn1.Close()
            DataGridView3.DataSource = dst1.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MsgBox("Select eigther of the options above")

        Else
            If RadioButton3.Checked = True Then
                Call fillpltord()

                DateTimePicker2.MinDate = Today
                DateTimePicker2.MaxDate = DateTimePicker3.Value


                SplitContainer1.Panel2Collapsed = True

            Else
                Call filldryord()
                SplitContainer1.Panel1Collapsed = True
                DateTimePicker5.MinDate = Today
                DateTimePicker5.MaxDate = DateTimePicker4.Value

            End If
        End If
        GroupBox6.Enabled = True


    End Sub
    Private Sub filldryord()
        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT Customer_ID FROM customerhq where  Product='DAIRY'"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "customerhq")
        With ComboBox4
            .DataSource = dset.Tables("customerhq")
            .DisplayMember = "customer_id"
            .ValueMember = "Customer_id"
            '
        End With
    End Sub
    Private Sub fillpltord()
        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT Customer_ID FROM customerhq where  Product='Plantation'"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "customerhq")
        With ComboBox2
            .DataSource = dset.Tables("customerhq")
            .DisplayMember = "customer_id"
            .ValueMember = "Customer_id"
            '
        End With
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim cm As New OleDb.OleDbCommand
        Dim con As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT distinct Crop FROM landgrade"
        Dim datad As New OleDb.OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "landgrade")
        With ComboBox3
            .DataSource = dset.Tables("landgrade")
            .DisplayMember = "crop"
            .ValueMember = "Crop"
            '
        End With
        Button9.Enabled = True
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker3.MinDate = DateTimePicker2.Value
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If NumericUpDown1.Value > 0 Then
            GroupBox5.Enabled = False
            Button7.Enabled = True
            ComboBox3.Enabled = False
            ComboBox2.Enabled = False

            NumericUpDown1.Enabled = False
        Else
            MsgBox("Invalid Value selected ", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim lydia As New OleDbCommand
        Call connect()
        cnn.Open()
        lydia.Connection = cnn
        Try
            lydia.CommandText = "INSERT INTO PlantationOrder(CustomerId, Crop, [Demand_(Tonnes)], Period_Begining, Period_ending, Demanded_on, Registrar) Values('" & Trim(ComboBox2.Text) & "','" & Trim(ComboBox3.Text) & "','" & Trim(NumericUpDown1.Value.ToString) & "','" & Trim(DateTimePicker2.Value) & "','" & Trim(DateTimePicker3.Value) & "','" & Trim(DateTimePicker2.Value) & "','" & Trim(logged) & "')"
            lydia.ExecuteNonQuery()
            MsgBox("Customer's Order has been registered Successfuly", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Accounts.ToolStripButton3.PerformClick()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            Call filla()
            SplitContainer2.Panel1Collapsed = False
            SplitContainer2.Panel2Collapsed = True
        Else
            Call fillb()
            SplitContainer2.Panel1Collapsed = True
            SplitContainer2.Panel2Collapsed = False
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        
        If NumericUpDown2.Value > 0 Then
            GroupBox5.Enabled = False
            ComboBox4.Enabled = False
            NumericUpDown2.Enabled = False
            Button11.Enabled = True
        Else
            MsgBox("Invalid Order Ammount")
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim methu As New OleDbCommand
        Call connect()
        cnn.Open()
        methu.Connection = cnn
        Try
            methu.CommandText = "INSERT INTO MilkOrder (CustomerID, Demand, STD, STTPD, Registrar)Values('" & Trim(ComboBox4.Text) & "','" & Trim(NumericUpDown2.Value) & "','" & Trim(DateTimePicker5.Value) & "','" & Trim(DateTimePicker4.Value) & "','" & Trim(logged) & "')"
            methu.ExecuteNonQuery()
            MsgBox("Order has Been posted Successfuly", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
        Accounts.ToolStripButton3.PerformClick()
    End Sub

    Private Sub DateTimePicker5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker5.ValueChanged

    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged
        DateTimePicker5.MaxDate = DateTimePicker4.Value
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker2.MaxDate = DateTimePicker3.Value
    End Sub

    Private Sub GroupBox9_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox9.Enter

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Accounts.ToolStripButton3.PerformClick()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Accounts.ToolStripButton3.PerformClick()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Button10.Enabled = True

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub
End Class
