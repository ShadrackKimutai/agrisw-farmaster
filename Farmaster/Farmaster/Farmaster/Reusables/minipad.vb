Imports System.Data.OleDb
Public Class minipad

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cm As New OleDbCommand
        TextBox1.Text = TextBox1.Text.ToUpper()

        If TextBox1.Text = "" Then
            MsgBox("Your input has been rejected because its eigther empty or a non valid entry was detected! Please rectify this.", MsgBoxStyle.Exclamation)
            TextBox1.Clear()
            TextBox1.Focus()
            Exit Sub


        Else
            Try

                Select Case minipadid
                    Case 1
                        GoTo 1
                        Exit Try
                    Case 2
                        GoTo 2


                        'Case Else

                        MsgBox("error", MsgBoxStyle.Critical)

                End Select


                'Call mefader()


            Catch ex As Exception
                MsgBox(ex.Message)

                ' MsgBox("It seems there has bee an error in the attempts to enter the value you offered. Counter check if it already exists", MsgBoxStyle.Exclamation)
                Call mefader()
            End Try

        End If

1:
        Try


            Call connect()

            cm.Connection = cnn
            cm.Connection.Open()
            cm.CommandText = "insert into breed(breedname) values('" & Trim(TextBox1.Text) & "')"
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


            MsgBox("Breed added.", MsgBoxStyle.Information)

            anidept.ToolStripButton2.PerformClick()
            Call mefader()
        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox("there seems to have been a problem. it seems the breed you are trying to enter is already registered, recheck the entry", MsgBoxStyle.Exclamation, "Breed input")

            TextBox1.Focus()
            Exit Sub

        End Try

2:

        minipadparent = TextBox1.Text
        anidept.ToolStripButton2.PerformClick()

        'Try
        '    Call connect()

        '    cm.Connection = cnn
        '    cm.Connection.Open()
        '    cm.CommandText = "insert into breed(breedname) values('" & Trim(TextBox1.Text) & "')"
        '    cm.ExecuteNonQuery()
        'Catch ex As Exception

        'End Try



        'SELECT MIN (AGE) from animalhq WHERE PARENT LIKE


        Call mefader()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsNumber(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call mefader()
    End Sub
    Private Sub mefader()
        Dim a As Double = 1

        Do
            While a > 0.01
                Me.Opacity = (a - 0.02)
                a = a - 0.01
                System.Threading.Thread.Sleep(7)

            End While
            Exit Do
        Loop
        Me.Close()

    End Sub

    Private Sub minipad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If minipadid = 2 Then
            ComboBox1.Visible = True
            TextBox1.Visible = False
            Call fillpar()
        Else
            ComboBox1.Visible = False
        End If
    End Sub
    Private Sub fillpar()
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        'Dim strol As String = "Select Animal_Name From AnimalHQ Where Sex Like '%FEMALE%' and (Datediff(yy,DOB,getDate())>2) and "
        Dim strol As String = "Select  Animal_Name FROM animalHQ  wHERe (age > 712) AND (NOT (Animal_Name IN (SELECT parent FROm animalhQ   WHERE age < 356))) AND (Sex = 'female')"
        Dim da As New OleDbDataAdapter(strol, con)
        Dim ds As New DataSet
        da.Fill(ds, "AnimalHQ")
        With ComboBox1
            .DataSource = ds.Tables("AnimalHQ")
            .DisplayMember = "Animal_Name"
            .ValueMember = "Animal_NAme"
            '.SelectedIndex = 0
        End With


    End Sub
End Class