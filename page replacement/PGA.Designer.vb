<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        txtPages = New TextBox()
        txtFrames = New TextBox()
        btnFIFO = New Button()
        btnLRU = New Button()
        btnOptimal = New Button()
        lstFIFO = New ListBox()
        lblFrames = New Label()
        lblPages = New Label()
        btnGenerate = New Button()
        lstLRU = New ListBox()
        lstOptimal = New ListBox()
        lblFIFO = New Label()
        lblLRU = New Label()
        lblOptimal = New Label()
        rtbProcess = New RichTextBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' txtPages
        ' 
        txtPages.Location = New Point(395, 30)
        txtPages.Name = "txtPages"
        txtPages.Size = New Size(375, 23)
        txtPages.TabIndex = 0
        ' 
        ' txtFrames
        ' 
        txtFrames.Location = New Point(13, 30)
        txtFrames.Name = "txtFrames"
        txtFrames.Size = New Size(376, 23)
        txtFrames.TabIndex = 1
        ' 
        ' btnFIFO
        ' 
        btnFIFO.Location = New Point(13, 59)
        btnFIFO.Name = "btnFIFO"
        btnFIFO.Size = New Size(185, 40)
        btnFIFO.TabIndex = 2
        btnFIFO.Text = "Run FIFO"
        btnFIFO.UseVisualStyleBackColor = True
        ' 
        ' btnLRU
        ' 
        btnLRU.Location = New Point(204, 59)
        btnLRU.Name = "btnLRU"
        btnLRU.Size = New Size(185, 40)
        btnLRU.TabIndex = 3
        btnLRU.Text = "Run LRU"
        btnLRU.UseVisualStyleBackColor = True
        ' 
        ' btnOptimal
        ' 
        btnOptimal.Location = New Point(395, 59)
        btnOptimal.Name = "btnOptimal"
        btnOptimal.Size = New Size(185, 40)
        btnOptimal.TabIndex = 4
        btnOptimal.Text = "Run Optimal"
        btnOptimal.UseVisualStyleBackColor = True
        ' 
        ' lstFIFO
        ' 
        lstFIFO.FormattingEnabled = True
        lstFIFO.ItemHeight = 15
        lstFIFO.Location = New Point(11, 120)
        lstFIFO.Name = "lstFIFO"
        lstFIFO.Size = New Size(250, 199)
        lstFIFO.TabIndex = 5
        ' 
        ' lblFrames
        ' 
        lblFrames.AutoSize = True
        lblFrames.Location = New Point(13, 12)
        lblFrames.Name = "lblFrames"
        lblFrames.Size = New Size(109, 15)
        lblFrames.TabIndex = 6
        lblFrames.Text = "Number of Frames:"
        ' 
        ' lblPages
        ' 
        lblPages.AutoSize = True
        lblPages.Location = New Point(395, 12)
        lblPages.Name = "lblPages"
        lblPages.Size = New Size(70, 15)
        lblPages.TabIndex = 7
        lblPages.Text = "Page String:"
        ' 
        ' btnGenerate
        ' 
        btnGenerate.Location = New Point(586, 59)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(185, 40)
        btnGenerate.TabIndex = 8
        btnGenerate.Text = "Generate Pages"
        btnGenerate.UseVisualStyleBackColor = True
        ' 
        ' lstLRU
        ' 
        lstLRU.FormattingEnabled = True
        lstLRU.ItemHeight = 15
        lstLRU.Location = New Point(266, 120)
        lstLRU.Name = "lstLRU"
        lstLRU.Size = New Size(250, 199)
        lstLRU.TabIndex = 9
        ' 
        ' lstOptimal
        ' 
        lstOptimal.FormattingEnabled = True
        lstOptimal.ItemHeight = 15
        lstOptimal.Location = New Point(521, 120)
        lstOptimal.Name = "lstOptimal"
        lstOptimal.Size = New Size(250, 199)
        lstOptimal.TabIndex = 10
        ' 
        ' lblFIFO
        ' 
        lblFIFO.AutoSize = True
        lblFIFO.Location = New Point(11, 102)
        lblFIFO.Name = "lblFIFO"
        lblFIFO.Size = New Size(95, 15)
        lblFIFO.TabIndex = 11
        lblFIFO.Text = "FIFO Page faults:"
        ' 
        ' lblLRU
        ' 
        lblLRU.AutoSize = True
        lblLRU.Location = New Point(266, 102)
        lblLRU.Name = "lblLRU"
        lblLRU.Size = New Size(92, 15)
        lblLRU.TabIndex = 12
        lblLRU.Text = "LRU Page faults:"
        ' 
        ' lblOptimal
        ' 
        lblOptimal.AutoSize = True
        lblOptimal.Location = New Point(521, 102)
        lblOptimal.Name = "lblOptimal"
        lblOptimal.Size = New Size(114, 15)
        lblOptimal.TabIndex = 13
        lblOptimal.Text = "Optimal Page faults:"
        ' 
        ' rtbProcess
        ' 
        rtbProcess.Location = New Point(10, 344)
        rtbProcess.Name = "rtbProcess"
        rtbProcess.ReadOnly = True
        rtbProcess.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbProcess.Size = New Size(760, 200)
        rtbProcess.TabIndex = 14
        rtbProcess.Text = ""
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(11, 326)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 15)
        Label1.TabIndex = 15
        Label1.Text = "Process:"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(782, 556)
        Controls.Add(Label1)
        Controls.Add(rtbProcess)
        Controls.Add(lblOptimal)
        Controls.Add(lblLRU)
        Controls.Add(lblFIFO)
        Controls.Add(lstOptimal)
        Controls.Add(lstLRU)
        Controls.Add(btnGenerate)
        Controls.Add(lblPages)
        Controls.Add(lblFrames)
        Controls.Add(lstFIFO)
        Controls.Add(btnOptimal)
        Controls.Add(btnLRU)
        Controls.Add(btnFIFO)
        Controls.Add(txtFrames)
        Controls.Add(txtPages)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = """FIFO vs LRU vs Optimal Page Replacement"""
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtPages As TextBox
    Friend WithEvents txtFrames As TextBox
    Friend WithEvents btnFIFO As Button
    Friend WithEvents btnLRU As Button
    Friend WithEvents btnOptimal As Button
    Friend WithEvents lstFIFO As ListBox
    Friend WithEvents lblFrames As Label
    Friend WithEvents lblPages As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents lstLRU As ListBox
    Friend WithEvents lstOptimal As ListBox
    Friend WithEvents lblFIFO As Label
    Friend WithEvents lblLRU As Label
    Friend WithEvents lblOptimal As Label
    Friend WithEvents rtbProcess As RichTextBox
    Friend WithEvents Label1 As Label

End Class
