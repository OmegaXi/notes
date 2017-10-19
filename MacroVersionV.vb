Sub generate()
'
' generate_order Macro
'

'
    Dim import_tabs As Variant
    import_tabs = Array("客户下单时间", "客户参考号1", "客户参考号2", "客户手机号", "客户姓名", "下订单人", "发运类型", "卸货预约时间", "路线点备注", "客户付款方式", "客户付款额", "收货方", "收货联系电话", "收货地地址", "客户订单类型", "批号", "规格", "货号", "货物描述", "INSTALMENT_FORM_FAX_SERIAL", "TNG_CARD", "TNG_SIM", "件数", "包装单位", "客户", "装货地", "卸货地", "分公司", "供应商")
    Call add_tab(import_tabs, Worksheets("Import File"))
    '取出列的长度
    Call generate_from_H_Input(Worksheets("Import File"))
    Call generate_from_Std_CoDel_Input(Worksheets("Import File"))
    Call generate_from_C_Input(Worksheets("Import File"))
End Sub
Private Sub generate_from_H_Input(sheet As Worksheet)
    Dim i, j, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk, ll, mm, nn, oo, pp, qq, rr, ss, tt, uu, vv, ww, xx, yy, zz, aaa As Integer
    Dim table
    Set table = Worksheets("H Input").UsedRange
    'match
    For i = 1 To 28 Step 1
        j = 1
        Do While table.Cells(1, j) <> ""
            Text = table.Cells(1, j).Value
            Select Case Text
            Case "PROCESS_DATE" 'A
            aa = j
            Case "ORDER_ID" 'B
            bb = j
            Case "MOBILE_NO" 'D
            dd = j
            Case "CUST_NAME" 'E
            ee = j
            Case "STAFF_ID" 'F
            ff = j
            Case "DELIVERY_TYPE" 'G
            gg = j
            Case "DELIVERY_MODE" 'O
            hh = j
            Case "DELIVERY_DATE" 'H
            ii = j
            Case "DELIVERY_TIME_SLOT" 'I
            jj = j
            Case "PAYMENT_AMT" 'J
            kk = j
            Case "PAYMENT_METHOD" 'K
            ll = j
            Case "CONTACT_NAME" 'L
            mm = j
            Case "CONTACT_NUM_1" 'M
            nn = j
            Case "DELIVERY_ADDRESS" 'N
            pp = j
            Case "ITEM_CODE" 'R
            qq = j
            Case "ITEM_DESC" 'S
            rr = j
            Case "ITEM_SERIAL" 'P
            ss = j
            Case "INSTALMENT_FORM_FAX_SERIAL" 'T
            tt = j
            Case "COURIER" 'AC
            ww = j
            End Select
        j = j + 1
        Loop
    Next
    
    'getlength
    j = 2
    Do While table.Cells(j, "A") <> ""
    j = j + 1
    Loop
    
    i = 2
    Do While i < j
    Worksheets("Import File").Cells(i, "A").Value = get_date(table.Cells(i, aa))
    Worksheets("Import File").Cells(i, "B").Value = table.Cells(i, bb).Value
    'Worksheets("Import File").Cells(i, "C").Value = table.Cells(i, cc).Value
    Worksheets("Import File").Cells(i, "D").Value = table.Cells(i, dd).Value
    Worksheets("Import File").Cells(i, "E").Value = table.Cells(i, ee).Value
    Worksheets("Import File").Cells(i, "F").Value = table.Cells(i, ff).Value
    Worksheets("Import File").Cells(i, "G").Value = table.Cells(i, gg).Value
    Worksheets("Import File").Cells(i, "O").Value = "H"
    Worksheets("Import File").Cells(i, "H").Value = get_date(table.Cells(i, ii))
    Worksheets("Import File").Cells(i, "I").Value = table.Cells(i, jj).Value
    Worksheets("Import File").Cells(i, "I").Replace What:="*M", Replacement:="" 'clear pre
    Worksheets("Import File").Cells(i, "I").Replace What:="*E", Replacement:="" 'clear pre
    Worksheets("Import File").Cells(i, "K").Value = table.Cells(i, kk).Value
    Worksheets("Import File").Cells(i, "J").Value = table.Cells(i, ll).Value
    Worksheets("Import File").Cells(i, "L").Value = table.Cells(i, mm).Value
    Worksheets("Import File").Cells(i, "M").Value = table.Cells(i, nn).Value
    Worksheets("Import File").Cells(i, "N").Value = table.Cells(i, pp).Value
    Worksheets("Import File").Cells(i, "R").Value = table.Cells(i, qq).Value
    Worksheets("Import File").Cells(i, "S").Value = table.Cells(i, rr).Value
    Worksheets("Import File").Cells(i, "P").Value = table.Cells(i, ss).Value
    Worksheets("Import File").Cells(i, "T").Value = table.Cells(i, tt).Value
    Worksheets("Import File").Cells(i, "W").Value = 1
    Worksheets("Import File").Cells(i, "X").Value = "件"
    Worksheets("Import File").Cells(i, "Y").Value = "CSL"
    Worksheets("Import File").Cells(i, "Z").Value = "CSLWH"
    Worksheets("Import File").Cells(i, "AA").Value = "香港，中国"
    Worksheets("Import File").Cells(i, "AB").Value = "HKG/CSL"
    Worksheets("Import File").Cells(i, "AC").Value = "OOCL"
    Worksheets("Import File").Cells(i, "AC").Value = table.Cells(i, ww).Value
    i = i + 1
    Loop
End Sub
Private Sub generate_from_Std_CoDel_Input(sheet As Worksheet)
Dim i, j, k, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk, ll, mm, nn As Integer
    Dim table
    Set table = Worksheets("Std CoDel Input").UsedRange
    'match
    For i = 1 To 21 Step 1
        j = 1
        Do While table.Cells(1, j) <> ""
            Text = table.Cells(1, j).Value
            Select Case Text
            Case "Order type"
            aa = j
            Case "REFER SB Order"
            bb = j
            Case "POS SM"
            cc = j
            Case "MOBILE_NO"
            dd = j
            Case "Contact No."
            ee = j
            Case "Customer Name"
            ff = j
            Case "D. Address"
            gg = j
            Case "DELIVERY_DATE"
            hh = j
            Case "PAYMENT_METHOD"
            ii = j
            Case "Bank-in Cash $"
            jj = j
            Case "DELIVERY_TIME_SLOT"
            kk = j
            Case "ITEM_CODE"
            ll = j
            Case "ITEM_DESC"
            mm = j
            Case "IMEI"
            nn = j
            End Select
        j = j + 1
        Loop
    Next
    
    'getlength
    j = 1
    Do While table.Cells(j + 1, "B") <> ""
    j = j + 1
    Loop
    
    'getlengthofimportfile
    k = 2
    Do While Worksheets("Import File").Cells(k, "B") <> ""
    k = k + 1
    Loop
    
    i = 2
    Do While i <= j
    Worksheets("Import File").Cells(k + i - 2, "O").Value = table.Cells(i, aa).Value
    Worksheets("Import File").Cells(k + i - 2, "B").Value = table.Cells(i, bb).Value
    Worksheets("Import File").Cells(k + i - 2, "C").Value = table.Cells(i, cc).Value
    Worksheets("Import File").Cells(k + i - 2, "M").Value = table.Cells(i, dd).Value
    Worksheets("Import File").Cells(k + i - 2, "D").Value = table.Cells(i, ee).Value
    Worksheets("Import File").Cells(k + i - 2, "E").Value = table.Cells(i, ff).Value
    Worksheets("Import File").Cells(k + i - 2, "G").Value = "NORMAL"
    Worksheets("Import File").Cells(k + i - 2, "N").Value = table.Cells(i, gg).Value
    Worksheets("Import File").Cells(k + i - 2, "H").Value = table.Cells(i, hh).Value
    Worksheets("Import File").Cells(k + i - 2, "J").Value = table.Cells(i, ii).Value
    Worksheets("Import File").Cells(k + i - 2, "K").Value = table.Cells(i, jj).Value
    Worksheets("Import File").Cells(k + i - 2, "I").Value = table.Cells(i, kk).Value
    Worksheets("Import File").Cells(k + i - 2, "R").Value = table.Cells(i, ll).Value
    Worksheets("Import File").Cells(k + i - 2, "S").Value = table.Cells(i, mm).Value
    Worksheets("Import File").Cells(k + i - 2, "P").Value = table.Cells(i, nn).Value
    Worksheets("Import File").Cells(k + i - 2, "W").Value = 1
    Worksheets("Import File").Cells(k + i - 2, "X").Value = "件"
    Worksheets("Import File").Cells(k + i - 2, "Y").Value = "CSL"
    Worksheets("Import File").Cells(k + i - 2, "Z").Value = "CSLWH"
    Worksheets("Import File").Cells(k + i - 2, "AA").Value = "香港，中国"
    Worksheets("Import File").Cells(k + i - 2, "AB").Value = "HKG/CSL"
    Worksheets("Import File").Cells(k + i - 2, "AC").Value = "OOCL"
    i = i + 1
    Loop
End Sub
Private Sub generate_from_C_Input(sheet As Worksheet)
Dim i, j, k, aa, bb, cc, dd, ee, ff, gg, hh, ii As Integer
    Dim table
    Set table = Worksheets("C Input").UsedRange
    'match
    For i = 1 To 14 Step 1
        j = 1
        Do While table.Cells(1, j) <> ""
            Text = table.Cells(1, j).Value
            Select Case Text
            Case "SM No"
            aa = j
            Case "Sub-Dealer Code"
            bb = j
            Case "Contact Number"
            cc = j
            Case "Shipment Date"
            dd = j
            Case "Time Slot"
            ee = j
            Case "Courier"
            ff = j
            Case "Item Desc"
            gg = j
            Case "Item Code"
            hh = j
            Case "Item QTY"
            ii = j
            End Select
        j = j + 1
        Loop
    Next
    
    'getlength
    j = 1
    Do While table.Cells(j + 1, "B") <> ""
    j = j + 1
    Loop
    
    'getlengthofimportfile
    k = 2
    Do While Worksheets("Import File").Cells(k, "B") <> ""
    k = k + 1
    Loop
    
    i = 2
    Do While i <= j
    Worksheets("Import File").Cells(k + i - 2, "B").Value = table.Cells(i, aa).Value
    Worksheets("Import File").Cells(k + i - 2, "L").Value = table.Cells(i, bb).Value
    Worksheets("Import File").Cells(k + i - 2, "M").Value = table.Cells(i, cc).Value
    Worksheets("Import File").Cells(k + i - 2, "H").Value = table.Cells(i, dd).Value
    Select Case table.Cells(i, ee).Value
        Case "AM"
            Worksheets("Import File").Cells(k + i - 2, "I").Value = "10:00-13:00"
        Case "PM"
            Worksheets("Import File").Cells(k + i - 2, "I").Value = "14:00-18:00"
        Case "EVE"
            Worksheets("Import File").Cells(k + i - 2, "I").Value = "18:00-22:00"
    End Select
    Worksheets("Import File").Cells(k + i - 2, "S").Value = table.Cells(i, gg).Value
    Worksheets("Import File").Cells(k + i - 2, "R").Value = table.Cells(i, hh).Value
    Worksheets("Import File").Cells(k + i - 2, "W").Value = table.Cells(i, ii).Value
    Worksheets("Import File").Cells(k + i - 2, "X").Value = "件"
    Worksheets("Import File").Cells(k + i - 2, "Y").Value = "CSL"
    Worksheets("Import File").Cells(k + i - 2, "Z").Value = "CSLWH"
    Worksheets("Import File").Cells(k + i - 2, "AA").Value = "香港，中国"
    Worksheets("Import File").Cells(k + i - 2, "AB").Value = "HKG/CSL"
    Worksheets("Import File").Cells(k + i - 2, "AC").Value = "OOCL"
    Worksheets("Import File").Cells(k + i - 2, "AC").Value = table.Cells(i, ff).Value
    Worksheets("Import File").Cells(k + i - 2, "G").Value = "NORMAL"
    Worksheets("Import File").Cells(k + i - 2, "O").Value = "C"
    i = i + 1
    Loop
End Sub
 Private Sub deal_row_data_from_H_Input(i As Integer, row As Range, sheet As Worksheet)
 End Sub
  Private Sub deal_row_data_from_Std_CoDel_Input(i As Integer, row As Range, sheet As Worksheet)
 End Sub
 Private Sub deal_row_data_from_C_Input(i As Integer, row As Range, sheet As Worksheet)
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
    Dim dates, month, year As Variant
    If date_ <> "" Then
        days = Split(date_, "/")(0)
        month = Split(date_, "/")(1)
        year = Split(date_, "/")(2)
        get_date = month & "/" & days & "/" & year
    Else
        get_date = ""
    End If
End Function

Sub Macro1()
'
' Macro1 Macro
'
'
    Range("A1:AB210").Select
    ActiveWindow.SmallScroll Down:=-54
    Selection.ClearContents
End Sub
