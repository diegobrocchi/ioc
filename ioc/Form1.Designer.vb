<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbLiu = New System.Windows.Forms.RadioButton
        Me.rbExt = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.rbMerda = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbMerda)
        Me.GroupBox1.Controls.Add(Me.rbExt)
        Me.GroupBox1.Controls.Add(Me.rbLiu)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(102, 106)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modem Input"
        '
        'rbLiu
        '
        Me.rbLiu.AutoSize = True
        Me.rbLiu.Location = New System.Drawing.Point(6, 19)
        Me.rbLiu.Name = "rbLiu"
        Me.rbLiu.Size = New System.Drawing.Size(68, 17)
        Me.rbLiu.TabIndex = 0
        Me.rbLiu.TabStop = True
        Me.rbLiu.Text = "LIU input"
        Me.rbLiu.UseVisualStyleBackColor = True
        '
        'rbExt
        '
        Me.rbExt.AutoSize = True
        Me.rbExt.Location = New System.Drawing.Point(6, 43)
        Me.rbExt.Name = "rbExt"
        Me.rbExt.Size = New System.Drawing.Size(72, 17)
        Me.rbExt.TabIndex = 1
        Me.rbExt.TabStop = True
        Me.rbExt.Text = "EXT input"
        Me.rbExt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Label2"
        '
        'rbMerda
        '
        Me.rbMerda.AutoSize = True
        Me.rbMerda.Location = New System.Drawing.Point(6, 66)
        Me.rbMerda.Name = "rbMerda"
        Me.rbMerda.Size = New System.Drawing.Size(64, 17)
        Me.rbMerda.TabIndex = 2
        Me.rbMerda.TabStop = True
        Me.rbMerda.Text = "MERDA"
        Me.rbMerda.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 165)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbExt As System.Windows.Forms.RadioButton
    Friend WithEvents rbLiu As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbMerda As System.Windows.Forms.RadioButton

End Class
