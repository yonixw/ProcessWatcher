Imports System.Management
Imports System.Security.Cryptography
Imports System.IO
Imports System.Diagnostics.Process

Public Class frmMain

    Dim _watchedProcess As Process = Nothing
    Dim _id As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Log("Init at: " & TimeOfDay.ToLongTimeString)

        Log("Command: " & Command())

        Dim Parms() As String = Command.Split("~")

        '-: When a exption accur ? exit?
        '-: md5
        '-: Interval
        '-: Path
        '-: Arguemnts (must be last for avoiding problems with parms)

        If Parms.Length <> 5 Then
            Log("Error: Wrong number of parameters, Expected:")
            Log("1- Exit on violation?")
            Log("2- MD5")
            Log("3- Interval between checks.")
            Log("4- Path to file.")
            Log("5- Arguments.")
            Log("Got: " & Parms.Length)
        Else
            If File.Exists(Parms(3)) Then
                If calcMD5(Parms(3)) = Parms(1) Then
                    If CInt(Parms(2)) > 0 Then
                        'Everything is ok!

                        Log("Set interval: " & 500 * Parms(2) & " mili seconds.")
                        tmr1.Interval = 500 * Parms(2) ' 0.5 Second * Time

                        Log("Process: " & Parms(3).Split("\").Last)
                        _watchedProcess = Process.Start(Parms(3), Parms(4))
                        _id = _watchedProcess.Id

                        Dim t As New Threading.Thread(AddressOf WaitForExit)
                        t.Start()


                        Log("Starting Timer....")
                        tmr1.Enabled = True

                    Else
                        Log("Error: Invalid Timer Interval.")
                    End If
                Else
                    Log("Error: MD5 doesn't match")
                End If
            Else
                Log("Error: Didn't find file.")
            End If
        End If

    End Sub

    Private Sub niMain_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niMain.MouseDoubleClick

        Me.Visible = Not Me.Visible




    End Sub


    'Icon ico = Icon.ExtractAssociatedIcon(theProcess.MainModule.FileName);


    Sub KillAllProcessesSpawnedBy(ByVal parentProcessId As UInt32, Optional ByVal isLog As Boolean = True)
        Try
            ' NOTE: Process Ids are reused!
            Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(
                "SELECT * " &
                "FROM Win32_Process " &
                "WHERE ParentProcessId=" & parentProcessId)
            Dim collection As ManagementObjectCollection = searcher.Get()
            If (collection.Count > 0) Then

                For Each item In collection

                    Dim childProcessId As UInt32 = CType(item("ProcessId"), UInt32)

                    If childProcessId <> Process.GetCurrentProcess().Id Then
                        KillAllProcessesSpawnedBy(childProcessId)

                        Dim childProcess As Process = Process.GetProcessById(childProcessId)

                        Try
                            childProcess.Kill()
                        Catch ex As Exception
                            If isLog Then
                                Log("Error in killing a specific child:")
                                Log(ex.Message)
                            End If
                        End Try
                    End If
                Next
            End If
        Catch ex As Exception
            If isLog Then
                Log("Error in killing child function:")
                Log(ex.Message)
            End If
        End Try

    End Sub

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim _res As MsgBoxResult = MsgBox("Do you want to close the process and exit?", vbYesNoCancel + vbQuestion, "Well...")
        If _res = MsgBoxResult.Yes Then
            If _watchedProcess IsNot Nothing Then
                KillAllProcessesSpawnedBy(_id)
                _watchedProcess.Kill()
            End If

            'Now exit:
            ExitProgram()
        End If
    End Sub

    Sub Log(ByVal txt As String, Optional ByVal ShowDate As Boolean = True, Optional ByVal newLine As Boolean = True)
        rtb.Text &= "[" & TimeOfDay.ToLongTimeString & "] " & txt
        If newLine Then
            rtb.Text &= vbNewLine
        End If
    End Sub

    Function calcMD5(ByVal path As String) As String
        Using md As MD5 = System.Security.Cryptography.MD5.Create()
            Using stream = File.OpenRead(path)
                Return HexStr(md.ComputeHash(stream))
            End Using
        End Using
    End Function

    Function HexStr(ByVal target() As Byte) As String
        Dim _str As String = ""
        For Each bit As Byte In target
            _str &= Hex(bit)
        Next
        Return _str
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dlgOpen.ShowDialog()
        If dlgOpen.FileName <> "" Then
            Log("MD5: " & calcMD5(dlgOpen.FileName))
        End If
    End Sub

    Private Sub tmr1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr1.Tick
        Log("Killing child process...")
        KillAllProcessesSpawnedBy(_watchedProcess.Id)
    End Sub


    Sub WaitForExit()
        _watchedProcess.WaitForExit()
        KillAllProcessesSpawnedBy(_id, False)

        ExitProgram()

    End Sub

    Sub ExitProgram()

        niMain.Visible = False
        End
    End Sub

End Class
