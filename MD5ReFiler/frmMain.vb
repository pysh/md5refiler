Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class frmMain
	Private boolCancel As Boolean = False
	Sub Button1Click(sender As Object, e As EventArgs)
'		Dim myFile As String = Me.textBox1.Text
'		Dim dtFrom As Date = Now
'		Dim myHash As String = GetMD5(myFile)
'		status1.Text = String.Format("Выполнено за {0}", GetDTInterval(dtFrom, Now))
'        textBox2.Text = myHash
'		backgroundWorker1.RunWorkerAsync()
		CalculateMD5()
    End Sub
 
    Function GetMD5(ByVal filePath As String)
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim f As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
 
        f = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        md5.ComputeHash(f)
        f.Close()
 
        Dim hash As Byte() = md5.Hash
        Dim buff As StringBuilder = New StringBuilder
        Dim hashByte As Byte
 
        For Each hashByte In hash
            buff.Append(String.Format("{0:X2}", hashByte))
        Next

        Dim md5string As String
        md5string = buff.ToString()

        Return md5string

    End Function
    
    Function GetDTInterval(ByVal dtFrom As Date, ByVal dtTo As Date) As String
        Dim timeSec As Long, timeMin As Long, timeHour As Long
        timeSec = CLng(DateDiff(DateInterval.Second, dtFrom, dtTo))
        timeHour = timeSec \ 3600
        timeMin = (timeSec Mod 3600) \ 60
        timeSec = (timeSec Mod 3600) Mod 60
        GetDTInterval = String.Format("{0}:{1}:{2}", Format(timeHour, "00"), Format(timeMin, "00"), Format(timeSec, "00"))
    End Function    
    
    #REGION "Drag and Drop"
    Sub ListView1DragDrop(sender As Object, e As DragEventArgs)
		' Accept on files and folders.
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            Dim Items() As Object = CType(e.Data.GetData(DataFormats.FileDrop), System.Object())
            Dim File As Object
            FileListView.BeginUpdate
            For Each File In Items
                ' Let's see if we are dealing with a file or a folder.
                If System.IO.File.Exists(File.ToString) Then
                	' It's a file, so we add it to the listbox.
                	AddFile(File.ToString)
                ElseIf System.IO.Directory.Exists(File.ToString) Then
                    ' It's a folder, so we must search it for files.
                    FindFiles(File.ToString)
                End If
            Next
            FileListView.EndUpdate
            FileListView.Columns.Item(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If    	
    End Sub
    
	Sub ListView1DragEnter(sender As Object, e As DragEventArgs)
        ' Let's allow files to be dropped.
        ' Writetrace("DragEnter")
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If    	
    End Sub
    
	Private Sub AddFile(ByVal FilePath As String)
        Dim lvi as System.Windows.Forms.ListViewItem
        ' Simply add the file to the listbox.
        lvi = Me.FileListView.Items.Add(FilePath)
        ' lvi.StateImageIndex=0
    End Sub    
    
	Private Sub FindFiles(ByVal Directory As String)
        ' Find files in current folder.
        Try
            Dim Files As String() = System.IO.Directory.GetFiles(Directory, "*")
            Dim File As String
            For Each File In Files
                AddFile(File)
            Next
        Catch
        End Try

        ' Find subfolders in current folder and search them for files too.
        Try
            Dim Dirs As String() = System.IO.Directory.GetDirectories(Directory, "*")
            Dim Dir As String
            For Each Dir In Dirs
                FindFiles(Dir)
            Next
        Catch
        End Try
	End Sub
    
    #END REGION
    
'    Private Sub JoinFiles0()
'        Try
'            Dim strFilePath As String = IO.Directory.GetCurrentDirectory()
'            Const strFileMask As String = "E*.001"
'            Dim strOutFile As String = String.Empty
'            Dim files As IEnumerable = From chkFile In Directory.EnumerateFiles(strFilePath, strFileMask, SearchOption.AllDirectories) _
'                Order By (IO.File.GetCreationTime(chkFile)) _
'                From line In IO.File.ReadLines(chkFile, System.Text.Encoding.GetEncoding(1251)) _
'                Where line <> "" _
'                Select New With {.curFile = chkFile, .curLine = line}
'
'            For Each f As Object In files
'                Debug.WriteLine(f.curFile.ToString, f.CurLine.ToString)
'                strOutFile = strOutFile & f.curLine.ToString & vbCrLf
'            Next f
'            If strOutFile <> "" Then
'                Using sw As IO.StreamWriter = New IO.StreamWriter(IO.Path.Combine(cFilePath, "ALL.001"), False, System.Text.Encoding.GetEncoding(1251))
'                    sw.Write(strOutFile)
'                End Using
'            End If
'
'        Catch UAEx As UnauthorizedAccessException
'            MsgBox(UAEx.Message, MsgBoxStyle.Critical, "Ошибка")
'            'Console.WriteLine(UAEx.Message)
'        Catch PathEx As PathTooLongException
'            MsgBox(PathEx.Message, MsgBoxStyle.Critical, "Ошибка")
'            'Console.WriteLine(PathEx.Message)
'        End Try
'    End Sub    
    
    
    Sub BackgroundWorker1DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
'    	FileListView.Invoke(New MethodInvoker(AddressOf CalculateMD5))
    End Sub
    
	Sub BackgroundWorker1RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
'		If (e.Error IsNot Nothing) Then
'			MessageBox.Show(e.Error.Message)
'		ElseIf e.Cancelled Then
'			MessageBox.Show ("Canceled")
'		Else
'			
'		End If
	End Sub
	
	Sub CalculateMD5()
		Dim strFileName As String
		Dim newFileNames As List(Of String)
		Dim strMD5 As String
		Dim lvi As ListViewItem
		boolCancel = False
		If dsDB.ReadXml(IO.Path.ChangeExtension(Application.ExecutablePath, ".db.xml")) Then
			Debug.WriteLine(dsDB.Tables(0).TableName)
			Progress1.Maximum=fileListView.Items.Count
	    	For Each lvi In Me.FileListView.Items
	    		'    		lvi.SubItems.Clear
	    		If boolCancel Then Exit For
	    		For f=1 To lvi.SubItems.Count-1
					lvi.SubItems.RemoveAt(1)
				Next
				strFileName = lvi.Text
	            lvi.EnsureVisible
	            progress1.Value=lvi.Index
	            strMD5 = GetMD5(strFileName)
	            newFileNames = GetFileNameByMD5(strMD5)
	            Me.FileListView.BeginUpdate
	            lvi.SubItems.Add(strMD5)
	            lvi.SubItems.Add(Join(newFileNames.ToArray, "/"))
	            Me.FileListView.EndUpdate
	            MoveFiles(strFileName, newFileNames)
	            Me.FileListView.Refresh
	            If boolCancel Then Exit For
	    	Next
		End If
	End Sub
	
	Function GetFileNameByMD5(strMD5 As String) As List(Of String)
		Dim RetVal As New List(Of String)
		Dim tDef As Data.DataTable = dsDB.Tables("Files")
		Dim filterExp As String = String.Format("CRC='{0}'", strMD5)
		Dim drarray() As DataRow
		Dim i As Integer
		drarray = tDef.Select(filterExp)
		For i = 0 To (drarray.Length - 1)
   			RetVal.Add(drarray(i)("fullName").ToString )
		Next
		Return RetVal
	End Function
	
	Sub MoveFiles(strSourceFileName As String, destFileNames As List(Of String))
		Dim strDestFolderName As String
		Dim strDestFileName As String
		Dim strDestShortFileName As String
		Dim strDestFileExtension As String
		For Each strDestFullFileName In destFileNames
			strDestFolderName = IO.Path.GetDirectoryName(strDestFullFileName)
			strDestFileName = IO.Path.GetFileName(strDestFullFileName)
			strDestShortFileName = IO.Path.GetFileNameWithoutExtension(strDestFullFileName)
			strDestFileExtension = IO.Path.GetExtension(strDestFullFileName)
			' strDestFileNameReplace =  IO.Path.Combine(strDestFolderName,strDestShortFileName & String.Format("{0:yyyyMMdd-hhmmss}", Date.Now) & strDestFileExtension)
			If IO.File.Exists(strDestFullFileName) Then
				My.Application.Log.WriteEntry(string.Format("MoveWithBackup '{0}', '{1}', '{2}'", strSourceFileName, strDestFullFileName, strDestFullFileName & ".bak")) 
				IO.File.Replace(strSourceFileName, strDestFullFileName, strDestFullFileName & ".bak")
			Else
				My.Application.Log.WriteEntry(string.Format("Move '{0}', '{1}'", strSourceFileName, strDestFullFileName))
				IO.File.Move(strSourceFileName, strDestFullFileName)
			End If
		Next
	End Sub
    
    Sub BtnCopyToBufferClick(sender As Object, e As EventArgs)
    	SendToClipboard(Me.FileListView)	
    End Sub
    
    Public Sub SendToClipboard (ByVal ListViewObj As ListView)  
		Dim ListItemObj As ListViewItem ' MSComctlLib.ListItem  
	  	Dim ListSubItemObj As ListViewItem.ListViewSubItem 'MSComctlLib.ListSubItem  
	  	Dim col As DataColumn  
	  	Dim ClipboardText As String  
	  	Dim ClipboardLine As String  
	   	ClipboardText=""
		' копирование заголовков:
		For Each col In ListViewObj.Columns
			ClipboardText = IIf(ClipboardText="","", vbTab) & col.ColumnName
		Next

	  	For Each ListItemObj In ListViewObj.Items
	  		'ClipboardText = ClipboardText & IIf(ClipboardText="","", vbCrLf)
	  		ClipboardLine = "" ' ListItemObj.Text
	    	' содержимое подчиненных элементов
	    	If ListItemObj.Checked Then
	    		For Each ListSubItemObj In ListItemObj.SubItems
	    			ClipboardLine = ClipboardLine + IIf(ClipboardLine="","", vbTab) + ListSubItemObj.Text
	    		Next  
	    		ClipboardText = ClipBoardText + IIf(ClipBoardText="","", vbCrLf) + ClipboardLine
	    	End If
		Next  
		If ClipboardText <> "" Then
			' ClipBoard.Clear()
			Clipboard.SetText(ClipboardText,TextDataFormat.UnicodeText)
			MsgBox("Текст скопирован в буфер")
		Else	
			MsgBox("Нечего копировать")
		End If
    End Sub
    
    Private Sub CreateDirectoryRecursive(strDirectoryName As String)
        Dim pfn As String = IO.Path.GetDirectoryName(strDirectoryName)
        If Not IO.Directory.Exists(pfn) Then CreateDirectoryRecursive(pfn)
        IO.Directory.CreateDirectory(strDirectoryName)
    End Sub
    
    Sub BtnCancelClick(sender As Object, e As EventArgs)
    	
    End Sub
End Class
