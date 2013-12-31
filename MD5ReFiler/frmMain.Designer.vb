<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    	Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
    	Me.status1 = New System.Windows.Forms.ToolStripStatusLabel()
    	Me.Progress1 = New System.Windows.Forms.ToolStripProgressBar()
    	Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
    	Me.panel1 = New System.Windows.Forms.Panel()
    	Me.btnCancel = New System.Windows.Forms.Button()
    	Me.btnCopyToBuffer = New System.Windows.Forms.Button()
    	Me.button1 = New System.Windows.Forms.Button()
    	Me.FileListView = New System.Windows.Forms.ListView()
    	Me.colFileName = New System.Windows.Forms.ColumnHeader()
    	Me.colMD5 = New System.Windows.Forms.ColumnHeader()
    	Me.colNewFileName = New System.Windows.Forms.ColumnHeader()
    	Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
    	Me.dsDB = New System.Data.DataSet()
    	Me.statusStrip1.SuspendLayout
    	Me.panel1.SuspendLayout
    	CType(Me.dsDB,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.SuspendLayout
    	'
    	'statusStrip1
    	'
    	Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status1, Me.Progress1})
    	Me.statusStrip1.Location = New System.Drawing.Point(0, 397)
    	Me.statusStrip1.Name = "statusStrip1"
    	Me.statusStrip1.Size = New System.Drawing.Size(1043, 22)
    	Me.statusStrip1.TabIndex = 3
    	Me.statusStrip1.Text = "statusStrip1"
    	'
    	'status1
    	'
    	Me.status1.Name = "status1"
    	Me.status1.Size = New System.Drawing.Size(0, 17)
    	'
    	'Progress1
    	'
    	Me.Progress1.Name = "Progress1"
    	Me.Progress1.Size = New System.Drawing.Size(200, 16)
    	'
    	'toolStrip1
    	'
    	Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
    	Me.toolStrip1.Name = "toolStrip1"
    	Me.toolStrip1.Size = New System.Drawing.Size(1043, 25)
    	Me.toolStrip1.TabIndex = 4
    	Me.toolStrip1.Text = "toolStrip1"
    	'
    	'panel1
    	'
    	Me.panel1.Controls.Add(Me.btnCancel)
    	Me.panel1.Controls.Add(Me.btnCopyToBuffer)
    	Me.panel1.Controls.Add(Me.button1)
    	Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    	Me.panel1.Location = New System.Drawing.Point(0, 347)
    	Me.panel1.Name = "panel1"
    	Me.panel1.Size = New System.Drawing.Size(1043, 50)
    	Me.panel1.TabIndex = 5
    	'
    	'btnCancel
    	'
    	Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnCancel.Location = New System.Drawing.Point(807, 15)
    	Me.btnCancel.Name = "btnCancel"
    	Me.btnCancel.Size = New System.Drawing.Size(109, 23)
    	Me.btnCancel.TabIndex = 3
    	Me.btnCancel.Text = "Отмена"
    	Me.btnCancel.UseVisualStyleBackColor = true
    	AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
    	'
    	'btnCopyToBuffer
    	'
    	Me.btnCopyToBuffer.Location = New System.Drawing.Point(12, 15)
    	Me.btnCopyToBuffer.Name = "btnCopyToBuffer"
    	Me.btnCopyToBuffer.Size = New System.Drawing.Size(75, 23)
    	Me.btnCopyToBuffer.TabIndex = 2
    	Me.btnCopyToBuffer.Text = "button2"
    	Me.btnCopyToBuffer.UseVisualStyleBackColor = true
    	AddHandler Me.btnCopyToBuffer.Click, AddressOf Me.BtnCopyToBufferClick
    	'
    	'button1
    	'
    	Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.button1.Location = New System.Drawing.Point(922, 15)
    	Me.button1.Name = "button1"
    	Me.button1.Size = New System.Drawing.Size(109, 23)
    	Me.button1.TabIndex = 1
    	Me.button1.Text = "Рассчитать MD5"
    	Me.button1.UseVisualStyleBackColor = true
    	AddHandler Me.button1.Click, AddressOf Me.Button1Click
    	'
    	'FileListView
    	'
    	Me.FileListView.AllowDrop = true
    	Me.FileListView.CheckBoxes = true
    	Me.FileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFileName, Me.colMD5, Me.colNewFileName})
    	Me.FileListView.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.FileListView.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
    	Me.FileListView.Location = New System.Drawing.Point(0, 25)
    	Me.FileListView.Name = "FileListView"
    	Me.FileListView.Size = New System.Drawing.Size(1043, 322)
    	Me.FileListView.TabIndex = 6
    	Me.FileListView.UseCompatibleStateImageBehavior = false
    	Me.FileListView.View = System.Windows.Forms.View.Details
    	AddHandler Me.FileListView.DragDrop, AddressOf Me.ListView1DragDrop
    	AddHandler Me.FileListView.DragEnter, AddressOf Me.ListView1DragEnter
    	'
    	'colFileName
    	'
    	Me.colFileName.Text = "Имя файла"
    	Me.colFileName.Width = 490
    	'
    	'colMD5
    	'
    	Me.colMD5.Text = "MD5"
    	Me.colMD5.Width = 255
    	'
    	'colNewFileName
    	'
    	Me.colNewFileName.Text = "Новое имя файла"
    	Me.colNewFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    	Me.colNewFileName.Width = 245
    	'
    	'backgroundWorker1
    	'
    	AddHandler Me.backgroundWorker1.DoWork, AddressOf Me.BackgroundWorker1DoWork
    	AddHandler Me.backgroundWorker1.RunWorkerCompleted, AddressOf Me.BackgroundWorker1RunWorkerCompleted
    	'
    	'dsDB
    	'
    	Me.dsDB.DataSetName = "NewDataSet"
    	'
    	'frmMain
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.ClientSize = New System.Drawing.Size(1043, 419)
    	Me.Controls.Add(Me.FileListView)
    	Me.Controls.Add(Me.panel1)
    	Me.Controls.Add(Me.toolStrip1)
    	Me.Controls.Add(Me.statusStrip1)
    	Me.Name = "frmMain"
    	Me.Text = "Form1"
    	Me.statusStrip1.ResumeLayout(false)
    	Me.statusStrip1.PerformLayout
    	Me.panel1.ResumeLayout(false)
    	CType(Me.dsDB,System.ComponentModel.ISupportInitialize).EndInit
    	Me.ResumeLayout(false)
    	Me.PerformLayout
    End Sub
    Private btnCancel As System.Windows.Forms.Button
    Private btnCopyToBuffer As System.Windows.Forms.Button
    Private dsDB As System.Data.DataSet
    Private colNewFileName As System.Windows.Forms.ColumnHeader
    Private colMD5 As System.Windows.Forms.ColumnHeader
    Private Progress1 As System.Windows.Forms.ToolStripProgressBar
    Private backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private colFileName As System.Windows.Forms.ColumnHeader
    Private FileListView As System.Windows.Forms.ListView
    Private panel1 As System.Windows.Forms.Panel
    Private toolStrip1 As System.Windows.Forms.ToolStrip
    Private status1 As System.Windows.Forms.ToolStripStatusLabel
    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private button1 As System.Windows.Forms.Button

End Class
