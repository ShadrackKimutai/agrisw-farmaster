Public NotInheritable Class Nemesisflash

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub Nemesisflash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ' ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ' ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
        Company.Text = My.Application.Info.CompanyName
        Call infinid()
    End Sub
    Private Sub infinid()
        Dim i As Integer
gen:
        ProgressBar1.PerformStep()
        Label1.Text = " calling subroutines " & i & "%"
        'System.Threading.Thread.Sleep(30)

        i = i + 1
        If i < 20 Then GoTo gen
        'System.Threading.Thread.Sleep(50)
ex:
        While i < 30
            ProgressBar1.PerformStep()
            Label1.Text = " Loading subroutines " & i & "%"
            'System.Threading.Thread.Sleep(30)
            i += 1
        End While
        ' System.Threading.Thread.Sleep(50)
        While i < 50
            ProgressBar1.PerformStep()
            Label1.Text = " Checking Connection " & i & "%"
            'System.Threading.Thread.Sleep(30)
            i += 1
        End While
        'System.Threading.Thread.Sleep(50)
        While i < 80
            ProgressBar1.PerformStep()
            Label1.Text = " Optimizing  Data" & i & "%"
            'System.Threading.Thread.Sleep(30)
            i += 1
        End While


        System.Threading.Thread.Sleep(150)
exim:
        ProgressBar1.PerformStep()
        Label1.Text = " Launching Farmaster  " & i & "%"
        'System.Threading.Thread.Sleep(30)
        i += 1
        If i < 100 Then GoTo exim
        'System.Threading.Thread.Sleep(50)




    End Sub
    Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub

    Private Sub Company_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Company.Click

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub
End Class
