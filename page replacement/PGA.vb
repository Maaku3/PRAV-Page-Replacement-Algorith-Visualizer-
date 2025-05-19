' This program shows how three page replacement strategies work: FIFO, LRU, and Optimal.
' It's designed with a GUI so that users can see the process of each method and how many page faults occur.

Public Class Form1
    ' Array to store the page reference string
    Dim pageReference() As Integer

    ' Button to generate a random sequence of page requests
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim rand As New Random()
        pageReference = New Integer(19) {} ' Make an array with 20 elements

        ' Fill the array with random numbers between 0 and 9
        For i = 0 To pageReference.Length - 1
            pageReference(i) = rand.Next(0, 10)
        Next

        ' Display the sequence in a textbox
        txtPages.Text = String.Join(" ", pageReference)
        rtbProcess.Clear()
        rtbProcess.AppendText("Generated Pages: " & txtPages.Text & vbCrLf)
    End Sub

    ' FIFO button click - runs FIFO algorithm
    Private Sub btnFIFO_Click(sender As Object, e As EventArgs) Handles btnFIFO.Click
        If Not ValidateInputs() Then Exit Sub

        Dim frames As Integer = Integer.Parse(txtFrames.Text)
        Dim faults As Integer = RunFIFO(pageReference, frames, lstFIFO, rtbProcess)
        lblFIFO.Text = "FIFO Page Faults: " & faults
    End Sub

    ' LRU button click - runs LRU algorithm
    Private Sub btnLRU_Click(sender As Object, e As EventArgs) Handles btnLRU.Click
        If Not ValidateInputs() Then Exit Sub

        Dim frames As Integer = Integer.Parse(txtFrames.Text)
        Dim faults As Integer = RunLRU(pageReference, frames, lstLRU, rtbProcess)
        lblLRU.Text = "LRU Page Faults: " & faults
    End Sub

    ' Optimal button click - runs Optimal algorithm
    Private Sub btnOptimal_Click(sender As Object, e As EventArgs) Handles btnOptimal.Click
        If Not ValidateInputs() Then Exit Sub

        Dim frames As Integer = Integer.Parse(txtFrames.Text)
        Dim faults As Integer = RunOptimal(pageReference, frames, lstOptimal, rtbProcess)
        lblOptimal.Text = "Optimal Page Faults: " & faults
    End Sub

    ' allows manual typing of page reference string
    Private Function ValidateInputs() As Boolean
        If txtFrames.Text = "" Then
            MessageBox.Show("Enter the number of frames.")
            Return False
        End If

        If txtPages.Text = "" Then
            MessageBox.Show("Enter or generate the page sequence.")
            Return False
        End If

        Dim temp As Integer
        If Not Integer.TryParse(txtFrames.Text, temp) Then
            MessageBox.Show("Number of frames must be a number.")
            Return False
        End If

        ' Try parsing the typed/entered page string
        Try
            pageReference = txtPages.Text.Split({" ", ",", ";"}, StringSplitOptions.RemoveEmptyEntries).Select(Function(s) Integer.Parse(s.Trim())).ToArray()
        Catch ex As Exception
            MessageBox.Show("Invalid page string. Please enter space-separated integers (e.g., 0 1 2 3).")
            Return False
        End Try

        Return True
    End Function

    ' FIFO: Replaces the oldest page in memory when full
    Private Function RunFIFO(pages As Integer(), frames As Integer, lst As ListBox, rtb As RichTextBox) As Integer
        lst.Items.Clear()
        rtb.Clear()
        rtb.AppendText("FIFO" & vbCrLf)

        Dim queue As New Queue(Of Integer)()
        Dim pageFaults As Integer = 0

        For Each page In pages
            rtb.AppendText("Checking page: " & page & vbCrLf)

            If Not queue.Contains(page) Then
                If queue.Count = frames Then
                    Dim removed = queue.Dequeue()
                    rtb.AppendText("Removed oldest page: " & removed & vbCrLf)
                End If
                queue.Enqueue(page)
                pageFaults += 1
                lst.Items.Add("Page " & page & ": (Miss) -> " & String.Join(" ", queue))
                rtb.AppendText("(Miss) Added to frame: " & page & vbCrLf)
            Else
                lst.Items.Add("Page " & page & ": (Hit) -> " & String.Join(" ", queue))
                rtb.AppendText("(Hit) Already in memory." & vbCrLf)
            End If

            rtb.AppendText("Frame now: " & String.Join(" ", queue) & vbCrLf & vbCrLf)
        Next

        rtb.AppendText("Total FIFO Page Faults: " & pageFaults & vbCrLf)
        Return pageFaults
    End Function

    ' LRU: Removes the least recently used page when full
    Private Function RunLRU(pages As Integer(), frames As Integer, lst As ListBox, rtb As RichTextBox) As Integer
        lst.Items.Clear()
        rtb.Clear()
        rtb.AppendText("LRU" & vbCrLf)

        Dim cache As New List(Of Integer)()
        Dim pageFaults As Integer = 0

        For Each page In pages
            rtb.AppendText("Checking page: " & page & vbCrLf)

            If cache.Contains(page) Then
                cache.Remove(page)
                cache.Add(page)
                lst.Items.Add("Page " & page & ": (Hit) -> " & String.Join(" ", cache))
                rtb.AppendText("(Hit) Moved to most recent" & vbCrLf)
            Else
                If cache.Count = frames Then
                    Dim removed = cache(0)
                    cache.RemoveAt(0)
                    rtb.AppendText("Removed least recent: " & removed & vbCrLf)
                End If
                cache.Add(page)
                pageFaults += 1
                lst.Items.Add("Page " & page & ": (Miss) -> " & String.Join(" ", cache))
                rtb.AppendText("(Miss) Added to memory" & vbCrLf)
            End If

            rtb.AppendText("Frame now: " & String.Join(" ", cache) & vbCrLf & vbCrLf)
        Next

        rtb.AppendText("Total LRU Page Faults: " & pageFaults & vbCrLf)
        Return pageFaults
    End Function

    ' Optimal: Removes the page that won't be used for the longest time
    Private Function RunOptimal(pages As Integer(), frames As Integer, lst As ListBox, rtb As RichTextBox) As Integer
        lst.Items.Clear()
        rtb.Clear()
        rtb.AppendText("Optimal" & vbCrLf)

        Dim memory As New List(Of Integer)()
        Dim pageFaults As Integer = 0

        For i As Integer = 0 To pages.Length - 1
            Dim page = pages(i)
            rtb.AppendText("Checking page: " & page & vbCrLf)

            If Not memory.Contains(page) Then
                If memory.Count < frames Then
                    memory.Add(page)
                    rtb.AppendText("Added to free space: " & page & vbCrLf)
                Else
                    Dim farthestIndex As Integer = -1
                    Dim toRemove As Integer = -1

                    ' Look into future use of each page to decide which to replace
                    For Each mPage In memory
                        Dim index = Array.IndexOf(pages, mPage, i + 1)
                        If index = -1 Then
                            toRemove = mPage
                            Exit For ' Best option: not used again
                        ElseIf index > farthestIndex Then
                            farthestIndex = index
                            toRemove = mPage
                        End If
                    Next

                    memory.Remove(toRemove)
                    memory.Add(page)
                    rtb.AppendText("Removed: " & toRemove & " Added: " & page & vbCrLf)
                End If
                pageFaults += 1
                lst.Items.Add("Page " & page & ": (Miss) -> " & String.Join(" ", memory))
                rtb.AppendText("(Miss) Added to memory" & vbCrLf)
            Else
                lst.Items.Add("Page " & page & ": (Hit) -> " & String.Join(" ", memory))
                rtb.AppendText("(Hit) Page is already present" & vbCrLf)
            End If

            rtb.AppendText("Frame now: " & String.Join(" ", memory) & vbCrLf & vbCrLf)
        Next

        rtb.AppendText("Total Optimal Page Faults: " & pageFaults & vbCrLf)
        Return pageFaults
    End Function
End Class
