Public Class Form2

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseDown, Label1.MouseDown, Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseUp, Label1.MouseUp, Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseMove, Label1.MouseMove, Panel1.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()
            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Do you really want to close this application?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Button3.BackgroundImage = My.Resources.icons8_normal_screen_filled_32
        Else
            Me.WindowState = FormWindowState.Normal
            Button3.BackgroundImage = My.Resources.icons8_full_screen_32
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Dim front_sub_panel_expanded As Boolean = True
    Private Sub Front_label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Front_label.Click, Front_panel.Click
        ' sub panel 150
        Front_label.ForeColor = Color.Yellow
        Front_panel.BackColor = Color.FromArgb(64, 64, 64)
        Back_label.ForeColor = Color.White
        Back_panel.BackColor = Color.FromArgb(80, 80, 80)
        PictureBox2.Image = My.Resources.skeletal_front
        Label14.Text = "Front view"
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If front_sub_panel_expanded = False Then
            If Front_sub_menu_panel.Height >= 150 Then
                Timer1.Enabled = False
                Front_sub_menu_panel.Height = 150
                front_sub_panel_expanded = True
            Else
                Front_sub_menu_panel.Height += 10
            End If
        Else
            If Front_sub_menu_panel.Height <= 0 Then
                Timer1.Enabled = False
                Front_sub_menu_panel.Height = 0
                front_sub_panel_expanded = False
            Else
                Front_sub_menu_panel.Height -= 10
            End If
        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Front_sub_menu_panel.Height = 0
        'Back_sub_menu_panel.Height = 0
        RichTextBox1.Text = Skeletal_System()
    End Sub

    Dim back_sub_panel_expanded As Boolean = True
    Private Sub Back_label_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back_label.Click, Back_panel.Click
        ' sub panel 150
        Front_label.ForeColor = Color.White
        Front_panel.BackColor = Color.FromArgb(80, 80, 80)
        Back_label.ForeColor = Color.Yellow
        Back_panel.BackColor = Color.FromArgb(64, 64, 64)
        PictureBox2.Image = My.Resources.skeletal_back
        Label14.Text = "Posterior view"
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If back_sub_panel_expanded = False Then
            If Back_sub_menu_panel.Height >= 150 Then
                Timer2.Enabled = False
                Back_sub_menu_panel.Height = 150
                back_sub_panel_expanded = True
            Else
                Back_sub_menu_panel.Height += 10
            End If
        Else
            If Back_sub_menu_panel.Height <= 0 Then
                Timer2.Enabled = False
                Back_sub_menu_panel.Height = 0
                back_sub_panel_expanded = False
            Else
                Back_sub_menu_panel.Height -= 10
            End If
        End If
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        MessageBox.Show("Website: reybandal-dev.ga" + vbNewLine + "Gmail Account: reybandal027@gmail.com" + vbNewLine + "Facebook Account: yer ojlaloc" + vbNewLine + "Mobile number: 09153450629", "Developer details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Descriptions
    Private Function Skeletal_System() As String
        Return vbTab + "The skeletal system includes all of the bones and joints in the body. Each bone is a complex living organ that is made up of many cells, protein fibers, and minerals. The skeleton acts as a scaffold by providing support and protection for the soft tissues that make up the rest of the body. The skeletal system also provides attachment points for muscles to allow movements at the joints. New blood cells are produced by the red bone marrow inside of our bones. Bones act as the body’s warehouse for calcium, iron, and energy in the form of fat. Finally, the skeleton grows throughout childhood and provides a framework for the rest of the body to grow along with it."
    End Function
End Class