Public Class Form1
    Dim time As Integer = 0
    Dim fish As Integer = 9
    Dim s As New Random
    Dim X1move As Integer = 1
    Dim Y1move As Integer = 1
    Dim X2move As Integer = 1
    Dim Y2move As Integer = 1
    Dim X3move As Integer = 1
    Dim Y3move As Integer = 1
    Dim X4move As Integer = 1
    Dim Y4move As Integer = 1
    Dim X5move As Integer = 1
    Dim Y5move As Integer = 1
    Dim X6move As Integer = 1
    Dim Y6move As Integer = 1
    Dim X7move As Integer = 1
    Dim Y7move As Integer = 1
    Dim X8move As Integer = 1
    Dim Y8move As Integer = 1
    Dim X9move As Integer = 1
    Dim Y9move As Integer = 1
    Dim difficulty
    Dim mode
    Dim mV As Integer = 0         '玩家游速(鍵盤模式)
    Dim V As Integer = 1      '其他魚游速
    Dim temp_x, temp_y As Integer
    Dim round As Integer = 1
    Dim best As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.bgm, AudioPlayMode.BackgroundLoop)
        '在選擇難易度及操作方式之前,計時器及其他魚不能移動
        Timer1.Stop()
        Timer2.Stop()

        difficulty = MsgBox("請選擇遊戲難易度,此難易度決定魚的游速~" & vbCrLf & "是->簡單(正常游速)" & vbCrLf & "否->中等(2倍游速)" & vbCrLf & "取消->困難(3倍游速)", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information, "難度選擇")
        If difficulty = MsgBoxResult.Yes Then
            mV = 2
            V = 2
        End If
        If difficulty = MsgBoxResult.No Then
            mV = 3
            V = 3
        End If
        If difficulty = MsgBoxResult.Cancel Then
            mV = 4
            V = 4
        End If

        mode = MsgBox("請選擇要用鍵盤還是滑鼠進行遊戲" & vbCrLf & "是->鍵盤(上下左右移動)" & vbCrLf & "否->滑鼠(滑鼠按住魚移動)", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "操作模式")
        If mode = MsgBoxResult.Yes Then
            PictureBox1.Enabled = False
        End If
        If mode = MsgBoxResult.No Then
            PictureBox1.Enabled = True
            mV = 0           '在滑鼠模式下不能用鍵盤移動(但可轉頭)
            If difficulty = MsgBoxResult.Yes Then
                V = 2
            End If
            If difficulty = MsgBoxResult.No Then
                V = 3
            End If
            If difficulty = MsgBoxResult.Cancel Then
                V = 4
            End If
        End If

        '遊戲正式開始
        Timer1.Start()
        Timer2.Start()

        PictureBox1.Image = My.Resources.a
        PictureBox2.Image = My.Resources.b
        PictureBox3.Image = My.Resources.c
        PictureBox4.Image = My.Resources.d
        PictureBox5.Image = My.Resources.e
        PictureBox6.Image = My.Resources.f
        PictureBox7.Image = My.Resources.g
        PictureBox8.Image = My.Resources.h
        PictureBox9.Image = My.Resources.i
        PictureBox10.Image = My.Resources.j
        PictureBox11.Image = My.Resources.trash
        PictureBox12.Image = My.Resources.trash
        PictureBox13.Image = My.Resources.trash
        PictureBox14.Image = My.Resources.trash
        PictureBox15.Image = My.Resources.trash
        PictureBox16.Image = My.Resources.trash
        PictureBox17.Image = My.Resources.trash

        PictureBox18.Image = My.Resources.grass
        PictureBox19.Image = My.Resources.grass
        PictureBox20.Image = My.Resources.grass
        PictureBox21.Image = My.Resources.grass
        PictureBox22.Image = My.Resources.grass

        Label2.Enabled = False
        Label7.Enabled = False
        Label12.Visible = False

        PictureBox1.Location = New Point(Me.ClientSize.Width / 2, Me.ClientSize.Height / 2)
        PictureBox2.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox3.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox4.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox5.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox6.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox7.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox8.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox9.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox10.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox11.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox12.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox13.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox14.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox15.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox16.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox17.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))

        PictureBox18.Location = New Point(Me.ClientSize.Width / 6, Me.ClientSize.Height - 147)
        PictureBox19.Location = New Point(2 * (Me.ClientSize.Width / 6), Me.ClientSize.Height - 147)
        PictureBox20.Location = New Point(3 * (Me.ClientSize.Width / 6), Me.ClientSize.Height - 147)
        PictureBox21.Location = New Point(4 * (Me.ClientSize.Width / 6), Me.ClientSize.Height - 147)
        PictureBox22.Location = New Point(5 * (Me.ClientSize.Width / 6), Me.ClientSize.Height - 147)
    End Sub

    '鍵盤
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case 38 '上 
                If Label1.Enabled = True Then
                    If PictureBox1.Location.Y >= 0 Then
                        PictureBox1.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y - 10 * mV)
                    End If
                Else  '若遊戲暫停則玩家不能移動
                    PictureBox1.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y)
                End If
            Case 40 '下 
                If Label1.Enabled = True Then
                    If PictureBox1.Location.Y <= Me.ClientSize.Height - PictureBox1.Height Then
                        PictureBox1.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y + 10 * mV)
                    End If
                Else   '若遊戲暫停則玩家不能移動
                    PictureBox1.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y)
                End If
            Case 37 '左
                If Label1.Enabled = True Then
                    If PictureBox1.Location.X >= 0 Then
                        PictureBox1.Location = New Point(PictureBox1.Location.X - 10 * mV, PictureBox1.Location.Y)
                    End If
                    PictureBox1.Image = My.Resources.a  '按下鍵盤"左"鍵,魚的頭朝向左邊
                Else   '若遊戲暫停則玩家不能移動
                    PictureBox1.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y)
                End If
            Case 39 '右
                If Label1.Enabled = True Then
                    If PictureBox1.Location.X < Me.ClientSize.Width - PictureBox1.Width Then
                        PictureBox1.Location = New Point(PictureBox1.Location.X + 10 * mV, PictureBox1.Location.Y)
                    End If
                    PictureBox1.Image = My.Resources.a2  '按下鍵盤"右"鍵,魚的頭朝向右邊
                Else   '若遊戲暫停則玩家不能移動
                    PictureBox1.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y)
                End If
        End Select
    End Sub

    '滑鼠
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        temp_x = e.X
        temp_y = e.Y
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = MouseButtons.Left Then
            sender.Left += e.X - temp_x
            sender.Top += e.Y - temp_y
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        temp_x = 0
        temp_y = 0
    End Sub

    '其他魚撞到牆壁後會反彈
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i As Integer = 1 To V
            PictureBox2.Left = PictureBox2.Left + X1move
            If PictureBox2.Left >= Me.ClientSize.Width - PictureBox2.Size.Width Or PictureBox2.Left <= 0 Then
                X1move = If(PictureBox2.Left <= 0, 2, -2)
                PictureBox2.Image = My.Resources.b2
            End If
            PictureBox2.Top = PictureBox2.Top + Y1move
            If PictureBox2.Top >= Me.ClientSize.Height - PictureBox2.Size.Height Or PictureBox2.Top <= 0 Then
                Y1move = If(PictureBox2.Top <= 0, 1, -1)
                PictureBox2.Image = My.Resources.b
            End If
        Next

        For i As Integer = 1 To V
            PictureBox3.Left = PictureBox3.Left + X2move
            If PictureBox3.Left >= Me.ClientSize.Width - PictureBox3.Size.Width Or PictureBox3.Left <= 0 Then
                X2move = If(PictureBox3.Left <= 0, 1, -1)
                PictureBox3.Image = My.Resources.c2
            End If
            PictureBox3.Top = PictureBox3.Top + Y2move
            If PictureBox3.Top >= Me.ClientSize.Height - PictureBox3.Size.Height Or PictureBox3.Top <= 0 Then
                Y2move = If(PictureBox3.Top <= 0, 1, -1)
                PictureBox3.Image = My.Resources.c
            End If
        Next

        For i As Integer = 1 To V
            PictureBox4.Left = PictureBox4.Left + X3move
            If PictureBox4.Left >= Me.ClientSize.Width - PictureBox4.Size.Width Or PictureBox4.Left <= 0 Then
                X3move = If(PictureBox4.Left <= 0, 2, -2)
                PictureBox4.Image = My.Resources.d2
            End If
            PictureBox4.Top = PictureBox4.Top + Y3move
            If PictureBox4.Top >= Me.ClientSize.Height - PictureBox4.Size.Height Or PictureBox4.Top <= 0 Then
                Y3move = If(PictureBox4.Top <= 0, 1, -1)
                PictureBox4.Image = My.Resources.d
            End If
        Next

        For i As Integer = 1 To V
            PictureBox5.Left = PictureBox5.Left + X4move
            If PictureBox5.Left >= Me.ClientSize.Width - PictureBox5.Size.Width Or PictureBox5.Left <= 0 Then
                X4move = If(PictureBox5.Left <= 0, 1, -1)
                PictureBox5.Image = My.Resources.e
            End If
            PictureBox5.Top = PictureBox5.Top + Y4move
            If PictureBox5.Top >= Me.ClientSize.Height - PictureBox5.Size.Height Or PictureBox5.Top <= 0 Then
                Y4move = If(PictureBox5.Top <= 0, 1, -1)
                PictureBox5.Image = My.Resources.e2
            End If
        Next

        For i As Integer = 1 To V
            PictureBox6.Left = PictureBox6.Left + X5move
            If PictureBox6.Left >= Me.ClientSize.Width - PictureBox6.Size.Width Or PictureBox6.Left <= 0 Then
                X5move = If(PictureBox6.Left <= 0, 2, -2)
                PictureBox6.Image = My.Resources.f
            End If
            PictureBox6.Top = PictureBox6.Top + Y5move
            If PictureBox6.Top >= Me.ClientSize.Height - PictureBox6.Size.Height Or PictureBox6.Top <= 0 Then
                Y5move = If(PictureBox6.Top <= 0, 1, -1)
                PictureBox6.Image = My.Resources.f2
            End If
        Next

        For i As Integer = 1 To V
            PictureBox7.Left = PictureBox7.Left + X6move
            If PictureBox7.Left >= Me.ClientSize.Width - PictureBox7.Size.Width Or PictureBox7.Left <= 0 Then
                X6move = If(PictureBox7.Left <= 0, 2, -2)
                PictureBox7.Image = My.Resources.g
            End If
            PictureBox7.Top = PictureBox7.Top + Y6move
            If PictureBox7.Top >= Me.ClientSize.Height - PictureBox7.Size.Height Or PictureBox7.Top <= 0 Then
                Y6move = If(PictureBox7.Top <= 0, 1, -1)
                PictureBox7.Image = My.Resources.g2
            End If
        Next

        For i As Integer = 1 To V
            PictureBox8.Left = PictureBox8.Left + X7move
            If PictureBox8.Left >= Me.ClientSize.Width - PictureBox8.Size.Width Or PictureBox8.Left <= 0 Then
                X7move = If(PictureBox8.Left <= 0, 2, -2)
                PictureBox8.Image = My.Resources.h
            End If
            PictureBox8.Top = PictureBox8.Top + Y7move
            If PictureBox8.Top >= Me.ClientSize.Height - PictureBox8.Size.Height Or PictureBox8.Top <= 0 Then
                Y7move = If(PictureBox8.Top <= 0, 1, -1)
                PictureBox8.Image = My.Resources.h2
            End If
        Next

        For i As Integer = 1 To V
            PictureBox9.Left = PictureBox9.Left + X8move
            If PictureBox9.Left >= Me.ClientSize.Width - PictureBox9.Size.Width Or PictureBox9.Left <= 0 Then
                X8move = If(PictureBox9.Left <= 0, 2, -2)
                PictureBox9.Image = My.Resources.i
            End If
            PictureBox9.Top = PictureBox9.Top + Y8move
            If PictureBox9.Top >= Me.ClientSize.Height - PictureBox9.Size.Height Or PictureBox9.Top <= 0 Then
                Y8move = If(PictureBox9.Top <= 0, 2, -2)
                PictureBox9.Image = My.Resources.i2
            End If
        Next

        For i As Integer = 1 To V
            PictureBox10.Left = PictureBox10.Left + X9move
            If PictureBox10.Left >= Me.ClientSize.Width - PictureBox10.Size.Width Or PictureBox10.Left <= 0 Then
                X9move = If(PictureBox10.Left <= 0, 2, -2)
                PictureBox10.Image = My.Resources.j
            End If
            PictureBox10.Top = PictureBox10.Top + Y9move
            If PictureBox10.Top >= Me.ClientSize.Height - PictureBox10.Size.Height Or PictureBox10.Top <= 0 Then
                Y9move = If(PictureBox10.Top <= 0, 2, -2)
                PictureBox10.Image = My.Resources.j2
            End If
        Next

        '吃魚判定.吃垃圾判定
        If (PictureBox1.Left <= PictureBox2.Left + PictureBox2.Width) And (PictureBox1.Left >= PictureBox2.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox2.Top + PictureBox2.Height) And (PictureBox1.Top >= PictureBox2.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox2.Width Then
                PictureBox2.Visible = False
            End If
            If PictureBox1.Width <= PictureBox2.Width And PictureBox2.Visible = True Then
                If time > 3 Then     '前3秒無敵
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox3.Left + PictureBox3.Width) And (PictureBox1.Left >= PictureBox3.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox3.Top + PictureBox3.Height) And (PictureBox1.Top >= PictureBox3.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox3.Width Then
                PictureBox3.Visible = False
            End If
            If PictureBox1.Width <= PictureBox3.Width And PictureBox3.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox4.Left + PictureBox4.Width) And (PictureBox1.Left >= PictureBox4.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox4.Top + PictureBox4.Height) And (PictureBox1.Top >= PictureBox4.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox4.Width Then
                PictureBox4.Visible = False
            End If
            If PictureBox1.Width <= PictureBox4.Width And PictureBox4.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox5.Left + PictureBox5.Width) And (PictureBox1.Left >= PictureBox5.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox5.Top + PictureBox5.Height) And (PictureBox1.Top >= PictureBox5.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox5.Width Then
                PictureBox5.Visible = False
            End If
            If PictureBox1.Width <= PictureBox5.Width And PictureBox5.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox6.Left + PictureBox6.Width) And (PictureBox1.Left >= PictureBox6.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox6.Top + PictureBox6.Height) And (PictureBox1.Top >= PictureBox6.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox6.Width Then
                PictureBox6.Visible = False
            End If
            If PictureBox1.Width <= PictureBox6.Width And PictureBox6.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox7.Left + PictureBox7.Width) And (PictureBox1.Left >= PictureBox7.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox7.Top + PictureBox7.Height) And (PictureBox1.Top >= PictureBox7.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox7.Width Then
                PictureBox7.Visible = False
            End If
            If PictureBox1.Width <= PictureBox7.Width And PictureBox7.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox8.Left + PictureBox8.Width) And (PictureBox1.Left >= PictureBox8.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox8.Top + PictureBox8.Height) And (PictureBox1.Top >= PictureBox8.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox8.Width Then
                PictureBox8.Visible = False
            End If
            If PictureBox1.Width <= PictureBox8.Width And PictureBox8.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox9.Left + PictureBox9.Width) And (PictureBox1.Left >= PictureBox9.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox9.Top + PictureBox9.Height) And (PictureBox1.Top >= PictureBox9.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox9.Width Then
                PictureBox9.Visible = False
            End If
            If PictureBox1.Width <= PictureBox9.Width And PictureBox9.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox10.Left + PictureBox10.Width) And (PictureBox1.Left >= PictureBox10.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox10.Top + PictureBox10.Height) And (PictureBox1.Top >= PictureBox10.Top - PictureBox1.Height) Then
            If PictureBox1.Width > PictureBox10.Width Then
                PictureBox10.Visible = False
            End If
            If PictureBox1.Width <= PictureBox10.Width And PictureBox10.Visible = True Then
                If time > 3 Then
                    PictureBox1.Visible = False
                End If
            End If
        End If

        If (PictureBox1.Left <= PictureBox11.Left + PictureBox11.Width) And (PictureBox1.Left >= PictureBox11.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox11.Top + PictureBox11.Height) And (PictureBox1.Top >= PictureBox11.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox11.Visible = False
            End If
        End If

        If (PictureBox1.Left <= PictureBox12.Left + PictureBox12.Width) And (PictureBox1.Left >= PictureBox12.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox12.Top + PictureBox12.Height) And (PictureBox1.Top >= PictureBox12.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox12.Visible = False
            End If
        End If

        If (PictureBox1.Left <= PictureBox13.Left + PictureBox13.Width) And (PictureBox1.Left >= PictureBox13.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox13.Top + PictureBox13.Height) And (PictureBox1.Top >= PictureBox13.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox13.Visible = False
            End If
        End If

        If (PictureBox1.Left <= PictureBox14.Left + PictureBox14.Width) And (PictureBox1.Left >= PictureBox14.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox14.Top + PictureBox14.Height) And (PictureBox1.Top >= PictureBox14.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox14.Visible = False
            End If
        End If

        If (PictureBox1.Left <= PictureBox15.Left + PictureBox15.Width) And (PictureBox1.Left >= PictureBox15.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox15.Top + PictureBox15.Height) And (PictureBox1.Top >= PictureBox15.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox15.Visible = False
            End If
        End If

        If (PictureBox1.Left <= PictureBox16.Left + PictureBox16.Width) And (PictureBox1.Left >= PictureBox16.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox16.Top + PictureBox16.Height) And (PictureBox1.Top >= PictureBox16.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox16.Visible = False
            End If
        End If

        If (PictureBox1.Left <= PictureBox17.Left + PictureBox17.Width) And (PictureBox1.Left >= PictureBox17.Left - PictureBox1.Width) And (PictureBox1.Top <= PictureBox17.Top + PictureBox17.Height) And (PictureBox1.Top >= PictureBox17.Top - PictureBox1.Height) Then
            If time > 3 Then
                PictureBox17.Visible = False
            End If
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click '暫停
        Timer1.Stop()
        Timer2.Stop()
        Label1.Enabled = False
        Label2.Enabled = True
        PictureBox1.Enabled = False
        Label3.Text = "遊戲暫停"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click '開始
        Timer1.Start()
        Timer2.Start()
        Label2.Enabled = False
        Label1.Enabled = True
        If mode = MsgBoxResult.No Then
            PictureBox1.Enabled = True
        End If
        Label3.Text = ""
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick '計時
        time += 1
        Label4.Text = Format(time, "00")
    End Sub

    Private Sub p1_Tick(sender As Object, e As EventArgs) Handles p1.Tick '處理玩家的事件
        If PictureBox1.Visible = False Or PictureBox1.Size.Width <= 0 Then
            p1.Stop()
            Timer1.Stop()
            Timer2.Stop()
            My.Computer.Audio.Play(My.Resources.bgm2, AudioPlayMode.WaitToComplete)
            MsgBox("GAME OVER!!")
            My.Computer.Audio.Play(My.Resources.bgm, AudioPlayMode.BackgroundLoop)
            Label3.Text = "請重啟遊戲"
            Label1.Enabled = False
            Label7.Enabled = True
        End If
    End Sub

    Private Sub p2_Tick(sender As Object, e As EventArgs) Handles p2.Tick  '處理其他魚1的事件
        If PictureBox2.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox2.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox2.Size.Height) / 3)
            p2.Stop()
        End If
    End Sub

    Private Sub p3_Tick(sender As Object, e As EventArgs) Handles p3.Tick  '處理其他魚2的事件
        If PictureBox3.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox3.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox3.Size.Height) / 3)
            p3.Stop()
        End If
    End Sub

    Private Sub p4_Tick(sender As Object, e As EventArgs) Handles p4.Tick  '處理其他魚3的事件
        If PictureBox4.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox4.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox4.Size.Height) / 3)
            p4.Stop()
        End If
    End Sub

    Private Sub p5_Tick(sender As Object, e As EventArgs) Handles p5.Tick  '處理其他魚4的事件
        If PictureBox5.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox5.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox5.Size.Height) / 3)
            p5.Stop()
        End If
    End Sub

    Private Sub p6_Tick(sender As Object, e As EventArgs) Handles p6.Tick  '處理其他魚5的事件
        If PictureBox6.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox6.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox6.Size.Height) / 3)
            p6.Stop()
        End If
    End Sub

    Private Sub p7_Tick(sender As Object, e As EventArgs) Handles p7.Tick  '處理其他魚6的事件
        If PictureBox7.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox7.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox7.Size.Height) / 3)
            p7.Stop()
        End If
    End Sub

    Private Sub p8_Tick(sender As Object, e As EventArgs) Handles p8.Tick  '處理其他魚7的事件
        If PictureBox8.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox8.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox8.Size.Height) / 3)
            p8.Stop()
        End If
    End Sub

    Private Sub p9_Tick(sender As Object, e As EventArgs) Handles p9.Tick  '處理其他魚8的事件
        If PictureBox9.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox9.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox9.Size.Height) / 3)
            p9.Stop()
        End If
    End Sub
    Private Sub p10_Tick(sender As Object, e As EventArgs) Handles p10.Tick  '處理其他魚9的事件
        If PictureBox10.Visible = False Then
            fish -= 1
            Label5.Text = Format(fish, "0")
            PictureBox1.Size = New Size(PictureBox1.Size.Width + (PictureBox10.Size.Width) / 3, PictureBox1.Size.Height + (PictureBox10.Size.Height) / 3)
            p10.Stop()
        End If
    End Sub

    '處理垃圾1~7的事件
    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        If PictureBox11.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t1.Stop()
        End If
        If PictureBox11.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t1.Stop()
        End If
    End Sub

    Private Sub t2_Tick(sender As Object, e As EventArgs) Handles t2.Tick
        If PictureBox12.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox12.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox12.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t2.Stop()
        End If
        If PictureBox12.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t2.Stop()
        End If
    End Sub

    Private Sub t3_Tick(sender As Object, e As EventArgs) Handles t3.Tick
        If PictureBox13.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox13.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox13.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t3.Stop()
        End If
        If PictureBox13.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t3.Stop()
        End If
    End Sub

    Private Sub t4_Tick(sender As Object, e As EventArgs) Handles t4.Tick
        If PictureBox14.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox14.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox14.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t4.Stop()
        End If
        If PictureBox14.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t4.Stop()
        End If
    End Sub

    Private Sub t5_Tick(sender As Object, e As EventArgs) Handles t5.Tick
        If PictureBox15.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox15.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox15.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t5.Stop()
        End If
        If PictureBox15.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t5.Stop()
        End If
    End Sub

    Private Sub t6_Tick(sender As Object, e As EventArgs) Handles t6.Tick
        If PictureBox16.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox16.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox16.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t6.Stop()
        End If
        If PictureBox16.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t6.Stop()
        End If
    End Sub

    Private Sub t7_Tick(sender As Object, e As EventArgs) Handles t7.Tick
        If PictureBox17.Visible = False And PictureBox1.Size.Width <= 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox17.Size.Width) / 5, PictureBox1.Size.Height - (PictureBox17.Size.Height) / 5)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t7.Stop()
        End If
        If PictureBox14.Visible = False And PictureBox1.Size.Width > 100 Then
            PictureBox1.Size = New Size(PictureBox1.Size.Width - (PictureBox11.Size.Width) / 2, PictureBox1.Size.Height - (PictureBox11.Size.Height) / 2)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            t7.Stop()
        End If
    End Sub

    Private Sub GameClear_Tick(sender As Object, e As EventArgs) Handles GameClear.Tick   '過關
        If PictureBox2.Visible = False And PictureBox3.Visible = False And PictureBox4.Visible = False And
           PictureBox5.Visible = False And PictureBox6.Visible = False And PictureBox7.Visible = False And
           PictureBox8.Visible = False And PictureBox9.Visible = False And PictureBox10.Visible = False Then
            GameClear.Stop()
            Timer1.Stop()
            Timer2.Stop()
            My.Computer.Audio.Play(My.Resources.bgm3, AudioPlayMode.WaitToComplete)
            MsgBox("恭喜通關!!")
            My.Computer.Audio.Play(My.Resources.bgm, AudioPlayMode.BackgroundLoop)
            Label3.Text = "請重啟遊戲"
            Label1.Enabled = False
            Label7.Enabled = True
            If time < best Or best = 0 Then   '最佳成績判斷
                best = time
                Label11.Text = Format(best, "00")
            End If

        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click  '重玩
        Dim s As New Random

        difficulty = MsgBox("請選擇遊戲難易度,此難易度決定魚的游速~" & vbCrLf & "是->簡單(正常游速)" & vbCrLf & "否->中等(2倍游速)" & vbCrLf & "取消->困難(3倍游速)", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information, "難度選擇")
        If difficulty = MsgBoxResult.Yes Then
            mV = 2
            V = 2
        End If
        If difficulty = MsgBoxResult.No Then
            mV = 4
            V = 4
        End If
        If difficulty = MsgBoxResult.Cancel Then
            mV = 6
            V = 6
        End If

        mode = MsgBox("請選擇要用鍵盤還是滑鼠進行遊戲" & vbCrLf & "是->鍵盤(上下左右移動)" & vbCrLf & "否->滑鼠(滑鼠按住魚移動)", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "操作模式")
        If mode = MsgBoxResult.Yes Then
            PictureBox1.Enabled = False
        End If
        If mode = MsgBoxResult.No Then
            PictureBox1.Enabled = True
            mV = 0
            If difficulty = MsgBoxResult.Yes Then
                V = 2
            End If
            If difficulty = MsgBoxResult.No Then
                V = 4
            End If
            If difficulty = MsgBoxResult.Cancel Then
                V = 6
            End If
        End If

        fish = 9
        Label5.Text = Format(fish, "0")

        time = 0
        Label4.Text = Format(time, "00")
        Label3.Text = ""

        round += 1
        Label9.Text = Format(round, "0")

        Timer1.Start()
        Timer2.Start()
        p1.Start()
        p2.Start()
        p3.Start()
        p4.Start()
        p5.Start()
        p6.Start()
        p7.Start()
        p8.Start()
        p9.Start()
        p10.Start()
        t1.Start()
        t2.Start()
        t3.Start()
        t4.Start()
        t5.Start()
        t6.Start()
        t7.Start()

        GameClear.Start()

        PictureBox1.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = True
        PictureBox9.Visible = True
        PictureBox10.Visible = True
        PictureBox11.Visible = True
        PictureBox12.Visible = True
        PictureBox13.Visible = True
        PictureBox14.Visible = True
        PictureBox15.Visible = True
        PictureBox16.Visible = True
        PictureBox17.Visible = True

        PictureBox1.Image = My.Resources.a
        PictureBox2.Image = My.Resources.b
        PictureBox3.Image = My.Resources.c
        PictureBox4.Image = My.Resources.d
        PictureBox5.Image = My.Resources.e
        PictureBox6.Image = My.Resources.f
        PictureBox7.Image = My.Resources.g
        PictureBox8.Image = My.Resources.h
        PictureBox9.Image = My.Resources.i
        PictureBox10.Image = My.Resources.j

        Label1.Enabled = True
        Label2.Enabled = False
        Label7.Enabled = False

        PictureBox1.Size = New Size(50, 50)
        PictureBox1.Location = New Point(Me.ClientSize.Width / 2, Me.ClientSize.Height / 2)
        PictureBox2.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox3.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox4.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox5.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox6.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox7.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox8.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox9.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox10.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox11.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox12.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox13.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox14.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox15.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox16.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))
        PictureBox17.Location = New Point(s.Next(Me.ClientSize.Width - 100), s.Next(Me.ClientSize.Height - 100))

    End Sub

    '秘密功能
    Private Sub PictureBox21_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox21.DoubleClick
        Timer1.Stop()
        Timer2.Stop()
        MsgBox("秘密功能啟動!?")
        If Label1.Enabled = True Then
            Timer1.Start()
            Timer2.Start()
        End If
        Label12.Visible = True
        PictureBox21.Enabled = False  '再次雙擊不會彈出MsgBox
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        PictureBox1.Size = New Size(PictureBox1.Size.Width + 10, PictureBox1.Size.Height + 10)
    End Sub
End Class
