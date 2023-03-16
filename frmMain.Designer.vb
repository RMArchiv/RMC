<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim ListViewItem1 As ListViewItem = New ListViewItem(New String() {"test", "test2"}, -1)
        lvGames = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        picBack = New PictureBox()
        lblTitle = New Label()
        CType(picBack, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lvGames
        ' 
        lvGames.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2})
        lvGames.FullRowSelect = True
        lvGames.Items.AddRange(New ListViewItem() {ListViewItem1})
        lvGames.Location = New Point(12, 12)
        lvGames.MultiSelect = False
        lvGames.Name = "lvGames"
        lvGames.Size = New Size(249, 627)
        lvGames.TabIndex = 0
        lvGames.UseCompatibleStateImageBehavior = False
        lvGames.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Titel"
        ColumnHeader1.Width = 120
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Untertitel"
        ColumnHeader2.Width = 120
        ' 
        ' picBack
        ' 
        picBack.Location = New Point(267, 12)
        picBack.Name = "picBack"
        picBack.Size = New Size(843, 144)
        picBack.SizeMode = PictureBoxSizeMode.AutoSize
        picBack.TabIndex = 1
        picBack.TabStop = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTitle.Location = New Point(282, 26)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(100, 21)
        lblTitle.TabIndex = 2
        lblTitle.Text = "GameName"' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1122, 651)
        Controls.Add(lblTitle)
        Controls.Add(picBack)
        Controls.Add(lvGames)
        Name = "frmMain"
        Text = "frmMain"
        CType(picBack, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lvGames As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents picBack As PictureBox
    Friend WithEvents lblTitle As Label
End Class
