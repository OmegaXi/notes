
Option Explicit
Sub generate_order()
'
' generate_order Macro
'

'
    
    Dim import_i As Integer
    Dim import_tabs As Variant
    import_tabs = Array("客户下单时间", "客户参考号1", "客户参考号2", "客户手机号", "客户姓名", "下订单人", "发运类型", "卸货预约时间", "路线点备注", "客户付款方式", "客户付款额", "收货方", "收货联系电话", "收货地地址", "客户订单类型", "批号", "规格", "货号", "货物描述", "INSTALMENT_FORM_FAX_SERIAL", "TNG_CARD", "TNG_SIM", "件数", "包装单位", "客户", "装货地", "卸货地", "分公司", "供应商")
    Call add_tab(import_tabs, Worksheets("Import File"))
    import_i = 2
    Call generate_from_H_Input(import_i, Worksheets("Import File"))
    Call generate_from_Std_CoDel_Input(import_i, Worksheets("Import File"))
    Call generate_from_C_Input(import_i, Worksheets("Import File"))
End Sub
Private Sub generate_from_H_Input(import_i As Integer, sheet As Worksheet)
    Dim table
    Set table = Worksheets("H Input").UsedRange
    Dim height As Integer, width As Integer
    height = table.Rows.Count
    width = table.Rows.Count
    Dim i As Integer
    For i = 1 To height
        If (IsNumeric(table.Rows(i).Cells(1)) And (table.Rows(i).Cells(1) <> "")) Then
            If (i <> 1 And table.Rows(i).Cells(1) = table.Rows(i - 1).Cells(1)) Then
                Dim j As Integer
                For j = 1 To table.Columns.Count
                    If (table.Rows(i).Cells(j) = "") Then
                        table.Rows(i).Cells(j) = table.Rows(i - 1).Cells(j)
                    End If
                Next j
            End If
            Call deal_row_data_from_H_Input(import_i, table.Rows(i), sheet)
           import_i = import_i + 1
        End If
    Next i
End Sub
Private Sub generate_from_Std_CoDel_Input(import_i As Integer, sheet As Worksheet)
    Dim table
    Set table = Worksheets("Std CoDel Input").UsedRange
    Dim height As Integer, width As Integer
    height = table.Rows.Count
    width = table.Rows.Count
    Dim i As Integer
    For i = 1 To height
        If (IsNumeric(table.Rows(i).Cells(1)) And (table.Rows(i).Cells(1) <> "")) Then
            
            If (i <> 1 And table.Rows(i).Cells(1) = table.Rows(i - 1).Cells(1)) Then
                Dim j As Integer
                For j = 1 To table.Columns.Count
                    If (table.Rows(i).Cells(j) = "") Then
                        table.Rows(i).Cells(j) = table.Rows(i - 1).Cells(j)
                    End If
                Next j
            End If
            Call deal_row_data_from_Std_CoDel_Input(import_i, table.Rows(i), sheet)
           import_i = import_i + 1
        End If
    Next i
End Sub
Private Sub generate_from_C_Input(import_i As Integer, sheet As Worksheet)
    Dim table
    Set table = Worksheets("C Input").UsedRange
    Dim height As Integer, width As Integer
    height = table.Rows.Count
    width = table.Rows.Count
    Dim i As Integer
    For i = 1 To height
        If table.Rows(i).Cells(4) Like "*PQX*" Or table.Rows(i).Cells(4) Like "*PQV*" Or table.Rows(i).Cells(4) Like "*OTG*" Then
           Call deal_row_data_from_C_Input(import_i, table.Rows(i), sheet)
           import_i = import_i + 1
        End If
    Next i
End Sub
 Private Sub deal_row_data_from_H_Input(i As Integer, row As Range, sheet As Worksheet)
    sheet.Range("A" & i).Value = get_date(row.Cells(2))
    sheet.Range("B" & i).Value = row.Cells(3)
    sheet.Range("C" & i).Value = row.Cells(4)
    sheet.Range("D" & i).Value = row.Cells(5)
    sheet.Range("E" & i).Value = row.Cells(6)
    sheet.Range("F" & i).Value = row.Cells(7)
    sheet.Range("G" & i).Value = row.Cells(8)
    sheet.Range("H" & i).Value = get_time(row.Cells(9), row.Cells(10))
    sheet.Range("I" & i).Value = row.Cells(10)
    sheet.Range("J" & i).Value = row.Cells(11)
    sheet.Range("K" & i).Value = row.Cells(12)
    sheet.Range("L" & i).Value = row.Cells(13)
    If row.Cells(15) <> "" Then
        sheet.Range("M" & i).Value = row.Cells(14) & "/" & row.Cells(15)
    Else
         sheet.Range("M" & i).Value = row.Cells(14)
    End If
    sheet.Range("N" & i).Value = row.Cells(16)
    sheet.Range("O" & i).Value = "H"
    sheet.Range("P" & i).Value = row.Cells(20)
    sheet.Range("R" & i).Value = row.Cells(18)
    sheet.Range("S" & i).Value = row.Cells(19)
    sheet.Range("T" & i).Value = row.Cells(22)
    sheet.Range("U" & i).Value = row.Cells(24)
    sheet.Range("V" & i).Value = row.Cells(25)
    sheet.Range("W" & i).Value = 1
    sheet.Range("X" & i).Value = "件"
    sheet.Range("Y" & i).Value = "CSL"
    sheet.Range("Z" & i).Value = "CSLWH"
    sheet.Range("AA" & i).Value = "香港，中国"
    sheet.Range("AB" & i).Value = "HKG/CSL"
    sheet.Range("AC" & i).Value = row.Cells(29)
 End Sub
  Private Sub deal_row_data_from_Std_CoDel_Input(i As Integer, row As Range, sheet As Worksheet)
    sheet.Range("B" & i).Value = row.Cells(4)
    sheet.Range("C" & i).Value = row.Cells(3)
    sheet.Range("D" & i).Value = row.Cells(6)
    sheet.Range("E" & i).Value = row.Cells(7)
    sheet.Range("G" & i).Value = "NORMAL"
sheet.Range("H" & i).Value = get_time(row.Cells(9), row.Cells(12))
    sheet.Range("I" & i).Value = row.Cells(12)
    sheet.Range("J" & i).Value = row.Cells(10)
    sheet.Range("K" & i).Value = row.Cells(11)
    sheet.Range("M" & i).Value = row.Cells(5)
    sheet.Range("N" & i).Value = row.Cells(8)
    sheet.Range("O" & i).Value = row.Cells(2)
    sheet.Range("P" & i).Value = row.Cells(15)
    sheet.Range("R" & i).Value = row.Cells(13)
    sheet.Range("W" & i).Value = 1
    sheet.Range("X" & i).Value = "件"
    sheet.Range("Y" & i).Value = "CSL"
    sheet.Range("Z" & i).Value = "CSLWH"
    sheet.Range("AA" & i).Value = "香港，中国"
    sheet.Range("AB" & i).Value = "HKG/CSL"
    sheet.Range("AC" & i).Value = "OOCL"
 End Sub
 Private Sub deal_row_data_from_C_Input(i As Integer, row As Range, sheet As Worksheet)
    sheet.Range("B" & i).Value = row.Cells(4)
    sheet.Range("L" & i).Value = row.Cells(5)
    sheet.Range("M" & i).Value = row.Cells(6)
    Dim route_comment As String
    Select Case row.Cells(8)
        Case "AM"
            route_comment = "10:00-13:00"
        Case "PM"
            route_comment = "14:00-18:00"
        Case "EVE"
            route_comment = "18:00-22:00"
    End Select
    sheet.Range("G" & i).Value = "NORMAL"
    sheet.Range("H" & i).Value = get_time_without_time(row.Cells(7), route_comment)
    sheet.Range("I" & i).Value = route_comment
    sheet.Range("N" & i).Value = row.Cells(9)
    sheet.Range("O" & i).Value = "C"
    sheet.Range("R" & i).Value = row.Cells(3)
    sheet.Range("W" & i).Value = 1
    sheet.Range("X" & i).Value = "件"
    sheet.Range("Y" & i).Value = "CSL"
    sheet.Range("Z" & i).Value = "CSLWH"
    sheet.Range("AA" & i).Value = "香港，中国"
    sheet.Range("AB" & i).Value = "HKG/CSL"
    sheet.Range("AC" & i).Value = "OOCL"
 End Sub

 Private Sub add_tab(import_tabs As Variant, sheet As Worksheet)
    Dim i As Integer
    For i = 0 To UBound(import_tabs)
        sheet.Cells(1, i + 1) = import_tabs(i)
    Next i
 End Sub

Private Function get_time(date_ As String, time_ As String) As String
    Dim dates As Variant, times As Variant, month_ As String, dates1 As Variant
    dates = Split(date_, "-")
    dates1 = Split(date_, "/")
    times = Split(time_, "-")
    If (UBound(dates) = 2) Then
        Select Case dates(1)
            Case "JAN"
                month_ = "01"
            Case "FEB"
                month_ = "02"
            Case "MAR"
                month_ = "03"
            Case "APR"
                month_ = "04"
            Case "MAY"
                month_ = "05"
            Case "JUN"
                month_ = "06"
            Case "JUL"
                month_ = "07"
            Case "AUG"
                month_ = "08"
            Case "SEP"
                month_ = "09"
            Case "OCT"
                month_ = "10"
            Case "NOV"
                month_ = "11"
            Case "DEC"
                month_ = "12"
        End Select
        If (UBound(times) = 1) Then
            get_time = dates(2) & " " & month_ & " " & dates(0) & " " & times(1)
        Else
            get_time = ""
        End If
    ElseIf (UBound(dates1) = 2) Then
        If (Len(dates1(0)) = 1) Then
            dates1(0) = "0" & dates1(0)
        End If
        If (Len(dates1(1)) = 1) Then
            dates1(1) = "0" & dates1(1)
        End If
        If (UBound(times) = 1) Then
            get_time = dates1(2) & " " & dates1(0) & " " & dates1(1) & " " & times(1)
        Else
            get_time = ""
        End If
    Else
        get_time = ""
    End If
End Function
Private Function get_time_without_time(date_ As String, time_ As String) As String
    Dim times() As String
    times = Split(time_, "-")
    If (UBound(times) = 1) Then
        get_time_without_time = Mid(date_, 1, 4) & " " & Mid(date_, 5, 2) & " " & Mid(date_, 7, 2) & " " & times(1)
    Else
        get_time_without_time = ""
    End If
End Function
Private Function get_date(date_ As String) As String
    Dim dates As Variant, month_ As String, dates1 As Variant
    dates1 = Split(date_, "/")
    dates = Split(date_, "-")
    If (UBound(dates) = 2) Then
        Select Case dates(1)
            Case "JAN"
                month_ = "01"
            Case "FEB"
                month_ = "02"
            Case "MAR"
                month_ = "03"
            Case "APR"
                month_ = "04"
            Case "MAY"
                month_ = "05"
            Case "JUN"
                month_ = "06"
            Case "JUL"
                month_ = "07"
            Case "AUG"
                month_ = "08"
            Case "SEP"
                month_ = "09"
            Case "OCT"
                month_ = "10"
            Case "NOV"
                month_ = "11"
            Case "DEC"
                month_ = "12"
        End Select
        get_date = dates(2) & " " & month_ & " " & dates(0)
    ElseIf (UBound(dates1) = 2) Then
        If (Len(dates1(0)) = 1) Then
            dates1(0) = "0" & dates1(0)
        End If
        If (Len(dates1(1)) = 1) Then
            dates1(1) = "0" & dates1(1)
        End If
        get_date = dates1(2) & " " & dates1(0) & " " & dates1(1)
    Else
        get_date = ""
    End If
End Function
