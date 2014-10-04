Imports System.Data.oledb

Public Class Login
    Inherits System.Windows.Forms.Form
    Dim form1 As New frmaster
    Dim drw As DataRow

    Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Long) As IntPtr
    Private Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
    Private Declare Function GetMenuItemCount Lib "user32" (ByVal hMenu As IntPtr) As Integer
    Private Declare Function DrawMenuBar Lib "user32" (ByVal hwnd As IntPtr) As Boolean
    '
    Private Const MF_BYPOSITION = &H400
    Private Const MF_REMOVE = &H1000
    Private Const MF_DISABLED = &H2

    Dim string1, string2 As String
    Public Sub DisCloseButton(ByVal hwnd As IntPtr)
        Dim hMenu As IntPtr
        Dim menuItemCount As Integer
        hMenu = GetSystemMenu(hwnd, False)
        menuItemCount = GetMenuItemCount(hMenu)
        Call RemoveMenu(hMenu, menuItemCount - 1, _
        MF_DISABLED Or MF_BYPOSITION)
        Call RemoveMenu(hMenu, menuItemCount - 2, _
        MF_DISABLED Or MF_BYPOSITION)
        Call DrawMenuBar(hwnd)
    End Sub

    Public Sub recall()
        frmaster.Show()
        frmaster.Enabled = False
    End Sub


    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmaster.Show()

        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
        loginallowed = False

        Call disablebtn()
        Me.TopMost = True
        Call filldepts()

    End Sub
    Private Sub disablebtn()
        DisCloseButton(Me.Handle)

    End Sub


    Private Sub Btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        If PasswordTextBox.Text = "1234" Or String.Compare(PasswordTextBox.Text, UsernameTextBox.Text) = 0 Then
            Dim cm As New OleDbCommand
            Call connect()
            cnn.Open()

            cm.Connection = cnn
            Dim frt As String
            Try
                cm.CommandText = "Select Passcode from privstaffhq where username='" & Trim(UsernameTextBox.Text) & "'"
               frt =cm.ExecuteScalar
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            cnn.Close()
            If frt = "1234" Or String.Compare(frt, UsernameTextBox.Text) = 0 Then
                MsgBox("The Password You are using is eigther default system password or unreasonably simple . Please change it then try again", MsgBoxStyle.Critical)
                Change_Password.Show()
                Change_Password.TopMost = True
                Me.Hide()
                frmaster.Hide()
                Exit Sub

            Else
                MsgBox("The Account you are trying to change its password seems like it isnt yours", MsgBoxStyle.Exclamation)

            End If

        End If

        Call toup()

        Dim userid As String
        Dim password As String
        Dim department As String


        Try

            userid = UsernameTextBox.Text
            password = PasswordTextBox.Text
            department = departmentComboBox.Text
            cnn.ConnectionString = "Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster"
            cnn.Open()
            cmd = cnn.CreateCommand
            cmd.CommandText = "SELECT Username, Passcode,department  from privstaffHQ where status Like 'ON DUTY'"
            da.SelectCommand = cmd
            da.Fill(ds, "privstaffhq")

            Dim x As String
            x = UsernameTextBox.Text
            dt = ds.Tables("privstaffhq")
            Try
                Dim aredit As DataRow() = ds.Tables("privstaffhq").Select("UserName='" & x & "'")
                UBound(aredit, 1)
                drw = aredit(0)
                string1 = drw("Passcode")
                string2 = drw("Department")


                If RTrim(LTrim(string1)) = PasswordTextBox.Text Then


                    If RTrim(LTrim(string2)) = departmentComboBox.Text Then
                        loginallowed = True
                    Else
                        MsgBox("You do not belong to That Department!", MsgBoxStyle.Exclamation, "Login Error")
                        departmentComboBox.Refresh()
                        departmentComboBox.Focus()
                    End If


                Else
                    MsgBox("Wrong password!", MsgBoxStyle.Exclamation, "Login Error")
                    PasswordTextBox.Clear()
                    PasswordTextBox.Focus()
                End If

                logged = UsernameTextBox.Text
                dept = departmentComboBox.Text
                'if 

                cnn.Close()
            Catch ex As Exception
                MsgBox("Wrong User Name!", MsgBoxStyle.Exclamation, "Login Error")
                UsernameTextBox.Clear()
                UsernameTextBox.Focus()
                cnn.Close()
                Exit Sub
                MsgBox("on error" & ex.Source & ":" & ex.Message, MessageBoxIcon.Warning, "btndatadapter")
            End Try
        Catch ex As Exception
            MsgBox("OnError :" & ex.Message)
        End Try
        Dim t As String
        t = DateTime.Now.Hour.ToString

        If (loginallowed = True) Then
            If frmaster.ShowInTaskbar = False Then Call recall()

            'If ((t < 4) Or (t > 22)) And dept <> "SA" Or dept <> "MANAGEMENT" Then


            '    MsgBox("You cant login, wait till office hours! Only the administrator can log you in  ", MsgBoxStyle.Exclamation, "Login Error")
            '    loginallowed = False

            'Else

            logged = logged.ToUpper
            frmaster.Refresh()
            Me.Hide()

            frmaster.Enabled = True

            frmaster.loggedinas.Text = logged.ToUpper
            frmaster.depment.Text = dept.ToUpper

            Call defineme()
            frmaster.Timer1.Enabled = True

            'End If

        End If



    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        frmaster.Close()

        Me.Close()
    End Sub

    Private Sub UsernameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True

        End If
    End Sub

    Private Sub UsernameTextBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.MouseLeave

    End Sub
    Private Sub toup()
        UsernameTextBox.Text.ToUpper()
    End Sub


    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged

    End Sub
    Private Sub filldepts()
        Dim con As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Password=swiftshady;User ID=sa;Initial Catalog=Farmaster")
        Dim strol As String = "Select distinct dept From depart "
        Dim da As New OleDbDataAdapter(strol, con)
        Dim ds As New DataSet
        da.Fill(ds, "Depart")
        With departmentComboBox
            .DataSource = ds.Tables("Depart")
            .DisplayMember = "dept"
            .ValueMember = "Dept"
            '.SelectedIndex = 0
        End With



    End Sub
    Private Sub departmentComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles departmentComboBox.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loginallowed = True

        'cent = True
        frmaster.Refresh()
        Me.Hide()

        frmaster.Enabled = True
    End Sub

    Private Sub UsernameLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameLabel.Click

    End Sub
End Class

