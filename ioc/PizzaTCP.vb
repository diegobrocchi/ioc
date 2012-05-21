Imports System.Net
Imports System.Net.Sockets
Imports System.IO
'Imports System.IO.Ports
Imports System.Threading
Imports System.Text

Public Class PizzaTCP
    Implements IPizzaTCP

    Private _IPAddress As String
    Private _IPPort As Integer
    Private _isHDWConnected As Boolean = False


    Public Property IPAddress() As String
        Get
            Return _IPAddress
        End Get
        Set(ByVal value As String)
            _IPAddress = value
        End Set
    End Property
    Public Property IPPort() As Integer
        Get
            Return _IPPort
        End Get
        Set(ByVal value As Integer)
            _IPPort = value
        End Set
    End Property
    Sub New(ByVal IP_Address As String, ByVal IP_Port As Integer)
        Dim ipa As IPAddress
        If (System.Net.IPAddress.TryParse(IP_Address, ipa)) Then
            IPAddress = IP_Address
            IPPort = IP_Port
        Else
            Throw New Exception("Indirizzo IP non valido")
        End If
    End Sub
    Public ReadOnly Property isHDWConnected() As Boolean
        Get
            Return _isHDWConnected
        End Get
    End Property

    Private Shared Function TestConnection(ByVal ipAddress As String, ByVal Port As Integer, ByVal waitMilliseconds As Integer) As Boolean
        Using tcpClient As New TcpClient()
            Dim result As IAsyncResult = tcpClient.BeginConnect(ipAddress, Port, Nothing, Nothing)
            Dim timeoutHandler As WaitHandle = result.AsyncWaitHandle
            Try
                If Not result.AsyncWaitHandle.WaitOne(waitMilliseconds, False) Then
                    tcpClient.Close()
                    Return False
                End If

                tcpClient.EndConnect(result)
            Catch ex As Exception
                Return False
            Finally
                timeoutHandler.Close()
            End Try
            Return True
        End Using
    End Function

    Public Function SendCommand(ByVal command As String) As String Implements IPizzaTCP.SendCommand

        Dim sCommand As String
        Dim tcpClient As New System.Net.Sockets.TcpClient
        Dim outStream As Byte()
        Dim serverStream As NetworkStream
        Dim inStream(8191) As Byte
        Dim myDeviceResponse As String
        Dim iNumOfBytesCurrentRead As Integer = 0
        Dim bEndOfData As Boolean = False
        Dim sCompleteMessage As New StringBuilder
        Dim sReadData As String = String.Empty

        If Not isHDWConnected Then
            _isHDWConnected = TestConnection(IPAddress, IPPort, 500)
        End If

        
        If isHDWConnected Then
            tcpClient.Connect(IPAddress, IPPort)
            serverStream = tcpClient.GetStream()
            tcpClient.ReceiveBufferSize = 8192

            'imposto il timeout di lettura
            tcpClient.ReceiveTimeout = 5000
            'accodo al comando il vbCrLf
            If command.Contains(vbCrLf) Then
                sCommand = command
            Else
                sCommand = command & vbCrLf
            End If

            Try
                outStream = System.Text.Encoding.ASCII.GetBytes(sCommand)
                serverStream.Write(outStream, 0, outStream.Length)
                serverStream.Flush()
                iNumOfBytesCurrentRead = 0
                'leggo fino al carattere vbLf (0x10) che è l'ultimo della risposta
                While Not bEndOfData
                    iNumOfBytesCurrentRead = serverStream.Read(inStream, 0, inStream.Length)
                    If iNumOfBytesCurrentRead > 0 Then
                        sCompleteMessage.Append(Encoding.ASCII.GetString(inStream, 0, iNumOfBytesCurrentRead))
                    End If
                    If inStream(iNumOfBytesCurrentRead - 1) = Encoding.ASCII.GetBytes(vbLf)(0) Then
                        bEndOfData = True
                    End If
                End While
                'ho letto tutto
                sReadData = sCompleteMessage.ToString
                If sReadData.IndexOf(vbCrLf) > 0 Then
                    sReadData = sReadData.Substring(0, sReadData.IndexOf(vbCrLf))
                End If
                'preparo la risposta
                myDeviceResponse = sReadData
                  'esco con la risposta
                Return myDeviceResponse

            Catch ex As IOException
                myDeviceResponse = "Timeout"
                 Return myDeviceResponse

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical)
                Return myDeviceResponse
            Finally
                sCommand = "BYE" & vbCrLf
                outStream = System.Text.Encoding.ASCII.GetBytes(sCommand)
                If tcpClient.Connected Then
                    serverStream.Write(outStream, 0, outStream.Length)
                    serverStream.Flush()
                    tcpClient.Close()
                End If
            End Try

        Else
            myDeviceResponse = "Impossibile connettersi al dispositivo."
             Return myDeviceResponse
        End If

    End Function
End Class
