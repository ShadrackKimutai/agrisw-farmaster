Imports system.Data.OleDb
Public Class Depreq
    Dim tempid As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If RadioButton1.Checked = False And RadioButton2.Checked = False Then GoTo exodus
        If RadioButton1.Checked = True Then
            Call impl()
        Else
            Call chem()

        End If
        GroupBox3.Enabled = False

        GroupBox4.Enabled = True
        Exit Sub
exodus:
        MsgBox("You havent Selected eigther of the options. Quiting", MsgBoxStyle.Exclamation)
        Exit Sub
    End Sub
    Private Sub impl()
        Call genny()
        Call fillclass()
    End Sub
    Private Sub chem()
        Call genny()
        Call fillclass()
    End Sub
    Private Sub fillclass()
        Dim elsie As String
        If RadioButton1.Checked = True Then
            elsie = "Implement"
        Else
            elsie = "Chemical"
        End If
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        Dim strol As String = "Select distinct item_type From Itemhq Where Category ='" & Trim(elsie.ToCharArray) & "'"
        Dim da As New OleDbDataAdapter(strol, con)
        Dim ds As New DataSet
        da.Fill(ds, "ItemHQ")
        With ComboBox1
            .DataSource = ds.Tables("ItemHQ")
            .DisplayMember = "Item_type"
            .ValueMember = "Item_type"
            '.SelectedIndex = 0
        End With
    End Sub
    Private Sub genny()

        Dim pattID, Prodid As String
        Dim Temp1 As Integer
        Dim a, b, c, k As String
        With DateTime.Now
            a = .Day.ToString
            b = .Month.ToString
            c = .Year.ToString

        End With
        k = a + b + c
        'MsgBox(k)
        Temp1 = Val(Temp1) + 1

        If RadioButton1.Checked = True Then

            Prodid = "IMPL" & k
        Else

            Prodid = "CHEM" & k
        End If

        Try
start:
            pattID = Prodid & "0" & Temp1
            Dim newpermcmd As New OleDb.OleDbCommand
            Dim checkexist As String
            newpermcmd.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newpermcmd.Connection = cnn
            newpermcmd.CommandText = "Select * From requestHQ Where itemreqID='" & pattID.ToCharArray & "'"
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
        Call id()
    End Sub
    Private Sub id()
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
            newpermcmd.CommandText = "Select top 1 id From requestHQ Where ID='" & pattID & "' ORDER BY ID DESC"
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
        'MsgBox(tempid)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As OleDb.OleDbConnection = New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        'Dim conn As New SqlClient.SqlConnection("Data Source=(local);Initial Catalog=NFMIS;User ID=sa;Password=swiftshady")

        Dim strSQL As String = "SELECT  Item_name from itemhq where item_type Like '" & "%" & ComboBox1.Text & "%'"
        Dim dat As New OleDb.OleDbDataAdapter(strSQL, con)
        Dim ds As New DataSet
        dat.Fill(ds, "itemhq")
        With ComboBox2
            .DataSource = ds.Tables("Itemhq")
            .DisplayMember = "Item_name"
            .ValueMember = "Item_name"
            '.SelectedIndex = 0
        End With


        Call UNS()

    End Sub
    Private Sub UNS()
        ComboBox5.Items.Clear()
        If RadioButton1.Checked = True Then
            With ComboBox5
                .Items.Add("UNITS")
            End With
        Else

            With ComboBox5
                .Items.Add("KILOGRAMS")
                .Items.Add("LITRES")
            End With

        End If
        ComboBox5.SelectedIndex = 0
   
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim x, y, cat As String
        If RadioButton1.Checked = True Then
            cat = "IMPLEMENT"
        Else
            cat = "CHEMICAL"
        End If
        x = InputBox("Enter The Name Of the Item you wish to Add. Items Requiring New categories Will have to be registered through the storage terminal of this application", "New Item Entry")
        x.ToUpper()
        If Char.IsSymbol(x) Or Char.IsNumber(x) Or Char.IsPunctuation(x) Or x = "" Then
            MsgBox("The entry you offered was rejected! Please check the entries before retrying", MsgBoxStyle.Exclamation, "Error")
        Else

            Dim cd As New OleDbCommand
            Call connect()
            cnn.Open()
            cd.Connection = cnn
            cd.CommandText = "Select * from Itemhq where Item_name='" & Trim(x.ToCharArray) & "'"
            y = cd.ExecuteScalar
            If y = vbNullString Then
                Try

               
                    cd.CommandText = "Insert into itemhq(category,Item_type,Item_name) Values('" & Trim(cat.ToCharArray) & "','" & Trim(ComboBox1.Text) & "','" & Trim(x.ToCharArray) & "')"
                    cd.ExecuteNonQuery()
                    MsgBox("Item successfuly added")
                    ComboBox1.Refresh()
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
            Else
                MsgBox("It seems the Item you are trying to add is already existent. Quiting...", MsgBoxStyle.Exclamation)

            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cat As String
        If RadioButton1.Checked = False And RadioButton2.Checked = False And ComboBox1.Text = "" Then GoTo 4
        If RadioButton1.Checked = True Then
            cat = "IMPLEMENT"
        Else
            cat = "CHEMICAL"
        End If

        Dim cm As New OleDbCommand
        Call connect()
        cnn.Open()
        cm.Connection = cnn
        Try


            cm.CommandText = "INSERT INTO requestHQ(Id, ItemreqID, Category, Item_Type, Item_Name, Quantity, Units,doreq,Status,ro,department) Values('" & Trim(tempid) & "','" & Trim(TextBox1.Text) & "','" & Trim(cat) & "','" & Trim(ComboBox1.Text) & "','" & Trim(ComboBox2.Text) & "','" & NumericUpDown1.Value & "','" & Trim(ComboBox5.Text) & "','" & Trim(DateTimePicker1.Value.ToString) & "','1','" & Trim(logged) & "','" & Trim(dept) & "')"
            cm.ExecuteNonQuery()

            MsgBox("The Order has Been posted successfuly", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If ParentForm.Text = "Plantation" Then
            Plantation.ToolStripButton3.PerformClick()
        Else
            anidept.ToolStripButton4.PerformClick()
        End If
        Exit Sub
4:
        MsgBox("Error! Invalid entry attempt", MsgBoxStyle.Critical)


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ParentForm.Text = "Plantation" Then
            Plantation.ToolStripButton3.PerformClick()
        Else
            anidept.ToolStripButton4.PerformClick()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If NumericUpDown1.Value <> 0 Then
            MsgBox("make sure that the Units selected are appropriate", MsgBoxStyle.Information)
            GroupBox3.Enabled = False
            GroupBox4.Enabled = False

            Button4.Enabled = True
        Else
            MsgBox("you havent selected the Appropriate quantity to be ordered", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Depreq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call fillgrid()
    End Sub

    Private Sub fillgrid()


        Dim cnn2 As New OleDb.OleDbConnection
        Dim adept As OleDb.OleDbDataAdapter
        Dim strng As String
        Dim dst2 As New DataSet
        Dim connectionstring1 As String
        connectionstring1 = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn2 = New OleDb.OleDbConnection(connectionstring1)
        strng = "Select Id, ItemreqID, Category, Item_Type, Item_Name, Quantity, Units,doreq,ro from requestHQ where status='1'"
        Try
            cnn2.Open()
            adept = New OleDb.OleDbDataAdapter(strng, cnn2)
            adept.Fill(dst2)
            cnn2.Close()
            DataGridView1.DataSource = dst2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
End Class
