Imports NUnit.Framework
Imports NSubstitute
Imports ioc
<TestFixture()> _
Public Class modem_Tests

    Private testMODEM As New modem_bo

    <Test()> _
    Sub setModInput_ifLIUselected_returnsOK()
        Dim response As String

        'oggetto pizzaBox che sostituisce il vero pizzabox
        Dim pizzaMock = Substitute.For(Of IPizzaTCP)()
        'oggetto modem_manager che si appoggia sul pizzabox sostituto
        Dim testModemManager As New modem_manager(pizzaMock)

        'istruisco il comportamento del sostituto
        pizzaMock.SendCommand("MODINPUT=LIU" & vbCrLf).Returns("OK")

        'imposto il valore al modem
        testMODEM.ModInput = ModulatorInput.liu_input

        'lo scrivo al servizio
        response = testModemManager.SetModInput(testMODEM)

        Assert.IsTrue(response.StartsWith("SI"), "ERRORE")

    End Sub

    
End Class
