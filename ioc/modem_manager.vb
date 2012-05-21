Public Class modem_manager
    Implements IModem

    Private _pizzaTcp As IPizzaTCP

    Sub New(ByVal IPAddress As String, ByVal IPPort As Integer)
        Me.New(New PizzaTCP(IPAddress, IPPort))
    End Sub


    Sub New(ByVal pizzaTcp As IPizzaTCP)
        _pizzaTcp = pizzaTcp
    End Sub

    Public Function SetModInput(ByRef myModem As modem_bo) As String Implements IModem.SetModInput

        Dim sCommand As String
        Dim myDeviceResponse As String


        Try

            ''composizione del comando
            Select Case myModem.ModInput
                Case ModulatorInput.liu_input
                    sCommand = "MODINPUT=LIU" & vbCrLf
                Case ModulatorInput.external_input
                    sCommand = "MODINPUT=EXT" & vbCrLf
                Case Else
                    Throw New Exception("MODEM_HDW-SetModInput: valore non definito")
            End Select

            myDeviceResponse = _pizzaTcp.SendCommand(sCommand)
            If myDeviceResponse.StartsWith("OK") Then
                myDeviceResponse = "SI"
            End If

            Return myDeviceResponse

        Catch ex As Exception
            Throw New Exception("MODEM_HDW-SetModInput: " & ex.Message)
        End Try

    End Function
End Class
