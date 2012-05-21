Public Class modem_bo
    Private _ModInput As ModulatorInput = ModulatorInput.undefined
    Public Property ModInput() As ModulatorInput
        Get
            Return _ModInput
        End Get
        Set(ByVal value As ModulatorInput)
            _ModInput = value
        End Set
    End Property
End Class
