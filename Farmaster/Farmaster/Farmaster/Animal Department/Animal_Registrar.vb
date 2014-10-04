Imports System.Data.OleDb

Public Class Animal_Registrar
    Dim partempstr As String
    Dim condition As String
    Dim source As String
    Dim tempid As Integer
    Dim breedstring As String



    Private Sub AnimalHQBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub SexComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SexComboBox.SelectedIndexChanged

    End Sub

    Private Sub combos()
        With SexComboBox
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .SelectedIndex = 0

        End With
        Dim cn As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim str As String = "SELECT breedname FROM Breed"
        Dim dat As New OleDbDataAdapter(str, cn)
        Dim ds As New DataSet
        dat.Fill(ds, "Breed")
        With BreedComboBox
            .DataSource = ds.Tables("Breed")
            .DisplayMember = "Breedname"
            .ValueMember = "Breedname"
            '.SelectedIndex = 0
        End With


        With ToolStripComboBox1
            .Items.Clear()
            .Items.Add("BREED")
            .Items.Add("SEX")
            .Items.Add("NAME")
            .Items.Add("REGISTRER")
            .Items.Add("HEALTH")
            .SelectedIndex = 0

        End With

        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")

        Dim strg As String = "SELECT tagid FROM animalhq where  current_condition='healthy' or current_condition='sick' "
        Dim datad As New OleDbDataAdapter(strg, con)
        Dim dset As New DataSet
        datad.Fill(dset, "animalhq")
        With ComboBox1
            .DataSource = dset.Tables("animalhq")
            .DisplayMember = "tagid"
            .ValueMember = "tagid"
            '
        End With
        
        With causecmb
            .Items.Add("DEAD")
            .Items.Add("SOLD")
            .Items.Add("GIVEN OUT")
            .SelectedIndex = 0
        End With
        Call fillgrid()
    End Sub
    Private Sub fillgrid()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select Tagid,Animal_name,Breed,Sex,Parent,Dob,Dor,Age,Current_condition from ANIMALHQ "
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
    Private Sub breed()
        Dim cnn1 As New OleDb.OleDbConnection
        Dim adpt As OleDb.OleDbDataAdapter
        Dim strg As String
        Dim dst1 As New DataSet
        Dim connectionstring As String
        connectionstring = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn1 = New OleDb.OleDbConnection(connectionstring)
        strg = "Select Tagid,Animal_name,Breed,Sex,Parent,DOB,DOR,Current_condition,REGISTERED_BY from ANIMALHQ where breed like ='%" & breedstring & "'%"
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
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'r = InputBox("Enter the name of the new breed ", "New Breed Registration", "(enter breed name)")
        minipad.Text = "New Breed Registration"
        minipad.Label1.Text = "Enter the name of the new breed"
        minipad.TextBox1.Text = "(enter breed name)"
        minipadid = 1
        minipad.TopMost = True
        minipad.Show()




    End Sub

    Private Sub Animal_Registrar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call combos()
        Call nextid()
        Call tagidgen()
        'Call breed()


        DOBDateTimePicker.MaxDate = Today
        DORDateTimePicker.MinDate = Today
    End Sub

    Private Sub Animal_NameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Animal_NameTextBox.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub Animal_NameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animal_NameTextBox.TextChanged

    End Sub

    Private Sub BreedComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BreedComboBox.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (RadioButton1.Checked = False And RadioButton2.Checked = False) Then
            MsgBox("Select a radio button", MsgBoxStyle.Exclamation)


        Else

            If RadioButton1.Checked = True Then
                source = 0
                parenttextbox.DropDownStyle = ComboBoxStyle.DropDownList
                parenttextbox.FlatStyle = FlatStyle.Flat
                
                Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
                'Dim strol As String = "Select Animal_Name From AnimalHQ Where Sex Like '%FEMALE%' and (Datediff(yy,DOB,getDate())>2) and "
                Dim strol As String = "Select  Animal_Name FROM animalHQ  wHERe (age > 712) AND (NOT (Animal_Name IN (SELECT parent FROm animalhQ   WHERE age < 356))) AND (Sex = 'female') and Not( current_condition='DEAD')"
                Dim da As New OleDbDataAdapter(strol, con)
                Dim ds As New DataSet
                da.Fill(ds, "AnimalHQ")
                With parenttextbox
                    .DataSource = ds.Tables("AnimalHQ")
                    .DisplayMember = "Animal_Name"
                    .ValueMember = "Animal_NAme"
                    '.SelectedIndex = 0
                End With
                Dim X As String
                X = DateTime.Now.Year
                X = X - 1
                DOBDateTimePicker.MinDate = Today
                '   MsgBox((1 / 1 / X))

            Else
                '
                source = 1
                parenttextbox.DropDownStyle = ComboBoxStyle.DropDownList
                parenttextbox.FlatStyle = FlatStyle.Flat
                Dim m As String

                m = InputBox("Enter the source of the animal", "Externaly  Animal Registration")
                m.ToUpper()
                If Char.IsSymbol(m) Or Char.IsNumber(m) Or Char.IsPunctuation(m) Or m = "" Then
                    MsgBox("The entry you offered was rejected! Please check the entries before retrying", MsgBoxStyle.Exclamation, "Error")
                Else
                    With parenttextbox


                        .Items.Clear()
                        .Items.Add(m.ToUpper)
                        .SelectedIndex = 0
                    End With
                    ' = m.ToUpper

                End If
                'extBox1.Text = "(enter breed name)"

            End If
        End If

        parenttextbox.Enabled = True

    End Sub
    Private Sub tagidgen()
        'select top 1 tagid from animalhq ORDER BY TagID DESC
        Dim pattID, Prodid As String
        Dim Temp1 As Integer
        Dim k As String = DateTime.Now.Year.ToString
        Temp1 = Val(Temp1) + 1
        Prodid = "CN"
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
            newpermcmd.CommandText = "Select top 1 tagid From AnimalHQ Where TagID='" & pattID.ToCharArray & "' ORDER BY TagID DESC"
            checkexist = newpermcmd.ExecuteScalar
            If checkexist = vbNullString Then
                TagIDTextBox.Text = pattID
            Else
                Temp1 += 1
                GoTo start

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
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
            newpermcmd.CommandText = "Select top 1 id From AnimalHQ Where ID='" & pattID & "' ORDER BY ID DESC"
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

    Private Sub btnrgst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrgst.Click
        Animal_NameTextBox.Text = Animal_NameTextBox.Text.ToUpper
        If Animal_NameTextBox.Text = "" Then
            MsgBox("Animal Name cannot be null", MsgBoxStyle.Exclamation)
            Animal_NameTextBox.Focus()
            Exit Sub


        End If
        If parenttextbox.Text = "" Then
            MsgBox("Parent Name cannot be null. Fill this by use of eigther or the radio boxes provided in the parentage section", MsgBoxStyle.Exclamation)
            'ParentTextBox.Focus()

            Exit Sub


        End If
        parenttextbox.Text = parenttextbox.Text.ToUpper
        If DOBDateTimePicker.Value > DORDateTimePicker.Value Then
            MsgBox("date of birth cannot be more recent than the date of registration ", MsgBoxStyle.Exclamation)
        End If


        Try
            Dim cm As New OleDbCommand
            Call connect()

            cm.Connection = cnn
            cm.Connection.Open()
            cm.CommandText = "insert into animalhq(id, TagID, Animal_Name, Breed, Sex, Parent, DOB, DOR, Registered_by, Current_Condition,  Source) VALUES   ('" & Trim(tempid) & "','" & Trim(TagIDTextBox.Text) & "','" & Trim(Animal_NameTextBox.Text) & "','" & Trim(BreedComboBox.Text) & "','" & Trim(SexComboBox.Text) & "','" & Trim(parenttextbox.Text) & "','" & Trim(DOBDateTimePicker.Value.Date.ToShortDateString) & "','" & Trim(DORDateTimePicker.Value.Date.ToShortDateString) & "','" & Trim(logged) & "','" & Trim(condition) & "','" & Trim(source) & "')"
            cm.ExecuteNonQuery()
            'Dim cm As New SqlCommand
            'cm.Connection = con

            'cm.Connection.Open() '" & Trim(txtVenNo.Text) & "','" & Trim(txtVenName.Text) & "','" & txtVenPost.text & "','" & txtVenTel.Text & "','" & txtVenMail.Text & "','" & txtVenCity.Text & "', '" & Trim(DateTimePicker1.Text) & "','" & Trim(txtVenTAmt.Text) & "','" & txtVenTOrd.text & "'

            'cm.CommandText = "Insert into Vendor(VendorNo,VendorName,PostAddress,TelPhone,Email,City) values('" & Trim(txtVenNo.Text) & "','" & Trim(txtVenName.Text) & "','" & txtVenPost.Text & "','" & txtVenTel.Text & "','" & txtVenMail.Text & "','" & txtVenCity.Text & "')"
            'cm.ExecuteNonQuery()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    MsgBox("Could not Insert Vendor Details", MsgBoxStyle.Critical, "Insertion Error")
            '    Exit Sub


        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("there seems to have been a problem. it seems the Animal you are trying to enter is already registered, recheck the entry", MsgBoxStyle.Exclamation, "Breed input")

            
            Exit Sub

        End Try
        anidept.ToolStripButton2.PerformClick()

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        condition = "HEALTHY"
        btnrgst.Enabled = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        condition = "SICK"
        btnrgst.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        anidept.ToolStripButton2.PerformClick()
        'MsgBox(DORDateTimePicker.Value.Date.ToShortDateString)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.CurrentRow.Selected = True
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        DataGridView1.CurrentRow.Selected = True
    End Sub

    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
       
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        
        Try
genesis:

            Dim newp As New OleDb.OleDbCommand
            Dim checkexist As String
            newp.Connection = cnn
            '*******************************
            cnn.Close()
            Call connect()
            cnn.Open()
            newp.Connection = cnn
            newp.CommandText = "Select * From AnimalHQ Where tagID ='" & ComboBox1.Text & "' and Animal_name like '" & andertextbox.Text & "' ORDER BY ID DESC"
            checkexist = newp.ExecuteScalar
            If checkexist = vbNullString Then
                MsgBox("The TAGID and the ANIMAL NAME are NOT matching. Rectify this.", MsgBoxStyle.Exclamation, "Entry Mismatch")
                andertextbox.Clear()
                andertextbox.Focus()
                    Else
                GroupBox7.Enabled = True

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub andertextbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles andertextbox.KeyPress
        If Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True


        End If
    End Sub

    Private Sub andertextbox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles andertextbox.MouseHover
        
    End Sub

    Private Sub andertextbox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles andertextbox.TextChanged
        GroupBox7.Enabled = False

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub causecmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles causecmb.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If causecmb.Text <> "" And TextBox1.Text <> "" Then


            '        RichTextBox1.AppendText("TagNo_________" & Trim(ComboBox1.Text) & _
            '" Name:_______" & Trim(andertextbox.Text) & "")
            RichTextBox1.Text = ("1. Tag Number______________________" & Trim(ComboBox1.Text) & "      2.  Animal__________________________" & Trim(andertextbox.Text.ToUpper) & "         3.  Reason_________________________" & Trim(causecmb.Text) & "                 " & Trim(TextBox1.Text.ToUpper) & "")

            GroupBox8.Enabled = True

        Else
            MsgBox("You cant proceed till you fill all required parameters", MsgBoxStyle.Exclamation, "Input Error")

        End If

    End Sub
    Private Sub filldanimalhq()

        Dim stw As String = ComboBox1.Text
        Dim dob, dor, dodr As Date
        Dim ID, TagID, Animal, Breed, Sex, Parent, Reg, C_c, age, Source As String
        'ID, TagID, Animal_Name, Breed, Sex, Parent, DOB, DOR, Registered_by, Current_Condition, age, Source
        'ID, TagID, Animal_Name, Breed, Sex, Parent, DOB, DOR, DODR, DeRegistered_by, reason, Cause, age
        Call connect()
        cnn.Open()
        Dim lstrw As OleDbDataReader
        ' cmd.CommandText = ("SELECT * FROM AnimalHq WHERE TagNo='" & stw.ToCharArray & "'")
        Dim comd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM AnimalHq WHERE TagID='" & stw.ToCharArray & "'", cnn)
        lstrw = comd.ExecuteReader
        While lstrw.Read
            ID = lstrw("ID")
            TagID = lstrw("Tagid")
            Animal = lstrw("Animal_Name")


            Breed = lstrw("Breed")


            dob = lstrw("DOB")
            dor = lstrw("DOR")

            Parent = lstrw("parent")
            Reg = lstrw("Registered_by")
            'StatusTextBox.Clear()
            C_c = lstrw("current_condition")
            age = lstrw("Age")
            Source = lstrw("Source")

            Sex = lstrw("Sex")

        End While
        dodr = DateTime.Today.ToShortDateString
        Dim cause As String = causecmb.Text
        cause = cause.ToUpper
        MsgBox(cause)
        Try
            Dim c01 As New OleDbCommand
            Call connect()
            'cnn.Close()
            'cnn.Open()
            c01.Connection = cnn
            c01.Connection.Open()
            c01.CommandText = "Insert into danimalhq(ID, TagID, Animal_Name, Breed, Sex, Parent, DOB, DOR, DODR, DeRegistered_by, reason, Cause, age) Values('" & Trim(ID.ToUpper) & "','" & Trim(TagID.ToUpper) & "','" & Trim(Animal.ToUpper) & "','" & Trim(Breed.ToUpper) & "','" & Trim(Sex.ToUpper) & "','" & Trim(Parent.ToUpper) & "','" & dob & "',' " & dor & "',' " & dodr & "',' " & Trim(logged.ToUpper) & "','" & Trim(cause) & "','" & Trim(TextBox1.Text.ToUpper) & "', '" & Trim(age) & "')"
            'Insert into Vendor(VendorNo,VendorName,PostAddress,TelPhone,Email,City) values('" & Trim(txtVenNo.Text) & "','" & Trim(txtVenName.Text) & "','" & txtVenPost.Text & "','" & txtVenTel.Text & "','" & txtVenMail.Text & "','" & txtVenCity.Text & "')"
              c01.ExecuteNonQuery()
            MsgBox("The animal has been deregistered", MsgBoxStyle.Information, "Animal has been Deregistered")

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
        anidept.ToolStripButton2.PerformClick()
        TabControl1.TabIndex = 2
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim c0m As New OleDbCommand
            Call connect()

            c0m.Connection = cnn
            c0m.Connection.Open()
            c0m.CommandText = "UPDATE AnimalHQ SET Current_Condition = '" & Trim(causecmb.Text.ToUpper) & "' wHERE (TagID = '" & Trim(ComboBox1.Text) & "')"
            c0m.ExecuteNonQuery()
            Call filldanimalhq()
            

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("there seems to have been a problem. it seems the Animal you are trying to enter is already registered, recheck the entry", MsgBoxStyle.Exclamation, "Breed input")


            Exit Sub

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        anidept.ToolStripButton2.PerformClick()
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        GroupBox10.Enabled = True
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub derr()
        Dim cnn2 As New OleDb.OleDbConnection
        Dim adept As OleDb.OleDbDataAdapter
        Dim strng As String
        Dim dst2 As New DataSet
        Dim connectionstring1 As String
        connectionstring1 = "Provider=SQLOLEDB;Data Source=(local);Persist Security Info=True;Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
        cnn2 = New OleDb.OleDbConnection(connectionstring1)
        strng = "Select Tagid,Animal_name,Breed,Sex,Age,Dor,Dodr,Reason,Cause,Deregistered_by from dANIMALHQ "
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

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        Call derr()

    End Sub

    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabIndexChanged
        If TabControl1.TabIndex = 1 Then
            Call derr()
            GroupBox11.Text = "Deregistered Animal"
        Else
            Call fillgrid()
            GroupBox11.Text = "Registered Animal"

        End If
    End Sub

    Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
        Call fillgrid()



    End Sub

    Private Sub Button4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseHover

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class
