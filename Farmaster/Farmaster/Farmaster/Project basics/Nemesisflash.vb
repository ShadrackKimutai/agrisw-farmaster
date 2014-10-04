Public NotInheritable Class Nemesisflash

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub Nemesisflash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            '  ApplicationTitle.Text = "Nemesis Farmaster"
        Else
            'If the application title is missing, use the application name, without the extension
            '' ApplicationTitle.Text = "Nemesis Farmaster" 'System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
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
        Label1.Text = "developed by shadrack kimutai " 'as partial fulfilment of the requirements nessesary to be awarded Bsc Computer science in Kabarak University"
        Call fea()
        'System.Threading.Thread.Sleep(5000)

       


        'System.Threading.Thread.Sleep(1000)

    End Sub

    Private Sub ApplicationTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
    Public Sub fea()

        Dim i, s As Integer
        Dim a(0 To 100) As Integer
        With Me.ProgressBar1()

            .Minimum = 0

            .Maximum = 100
        End With
1:      For i = 0 To i = 100
            s = 1
            'ProgressBar1.Value = i
            ProgressBar1.PerformStep()

            System.Threading.Thread.Sleep(10)
        Next i
        If s = 0 Then
            GoTo 1
        End If
    End Sub
End Class
