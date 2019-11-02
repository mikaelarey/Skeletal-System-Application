Public Class Form2

    ' ========================================================================================================================================
    ' Moveable Borderless Form
    ' ========================================================================================================================================

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


    ' ========================================================================================================================================
    ' From events
    ' ========================================================================================================================================

    ' Form Load

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Front_sub_menu_panel.Height = 0
        'Back_sub_menu_panel.Height = 0
        RichTextBox1.Text = Skeletal_System()
    End Sub

    ' Control Box buttons

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


    ' ========================================================================================================================================
    ' Animated toggles
    ' ========================================================================================================================================

    ' Active panel
    ' true if front otherwise false
    Dim active_panel As Boolean = True

    ' Animated menu toggle front
    Dim front_panel_height As Integer = 150
    Dim front_sub_panel_expanded As Boolean = True
    Private Sub Front_label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Front_label.Click, Front_panel.Click
        ' sub panel 150
        front_timer()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If front_sub_panel_expanded = False Then
            If Front_sub_menu_panel.Height >= front_panel_height Then
                Timer1.Enabled = False
                Front_sub_menu_panel.Height = front_panel_height
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

    ' Animated menu toggle (back)
    Dim back_panel_height As Integer = 150
    Dim back_sub_panel_expanded As Boolean = True
    Private Sub Back_label_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back_label.Click, Back_panel.Click
        ' sub panel 150
        back_timer()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If back_sub_panel_expanded = False Then
            If Back_sub_menu_panel.Height >= back_panel_height Then
                Timer2.Enabled = False
                Back_sub_menu_panel.Height = back_panel_height
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


    ' ========================================================================================================================================
    ' Developer credetials
    ' ========================================================================================================================================

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        MessageBox.Show("Website: reybandal-dev.ga" + vbNewLine + "Gmail Account: reybandal027@gmail.com" + vbNewLine + "Facebook Account: yer ojlaloc" + vbNewLine + "Mobile number: 09153450629", "Developer details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    ' ========================================================================================================================================
    ' Descriptions
    ' ========================================================================================================================================

    Private Function Skeletal_System() As String
        Return vbTab + "The skeletal system includes all of the bones and joints in the body. Each bone is a complex living organ that is made up of many cells, protein fibers, and minerals. The skeleton acts as a scaffold by providing support and protection for the soft tissues that make up the rest of the body. The skeletal system also provides attachment points for muscles to allow movements at the joints. New blood cells are produced by the red bone marrow inside of our bones. Bones act as the body’s warehouse for calcium, iron, and energy in the form of fat. Finally, the skeleton grows throughout childhood and provides a framework for the rest of the body to grow along with it."
    End Function


    ' ========================================================================================================================================
    ' Hover Effects
    ' ========================================================================================================================================

    ' Front 1
    Private Sub Front1_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front1_label.MouseHover
        Front1_label.ForeColor = Color.Yellow
        Front1_label.Font = New Font(Front1_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_front1
        PictureBox3.Image = My.Resources.Front_head
        front_toggled()
    End Sub

    Private Sub Front1_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front1_label.MouseLeave
        Front1_label.ForeColor = Color.White
        Front1_label.Font = New Font(Front1_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Front 2
    Private Sub Front2_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front2_label.MouseHover
        Front2_label.ForeColor = Color.Yellow
        Front2_label.Font = New Font(Front2_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_front2
        PictureBox3.Image = My.Resources.Front_body
        front_toggled()
    End Sub

    Private Sub Front2_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front2_label.MouseLeave
        Front2_label.ForeColor = Color.White
        Front2_label.Font = New Font(Front2_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Front 3
    Private Sub Front3_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front3_label.MouseHover
        Front3_label.ForeColor = Color.Yellow
        Front3_label.Font = New Font(Front3_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_front3
        PictureBox3.Image = My.Resources.Front_pelvis
        front_toggled()
    End Sub

    Private Sub Front3_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front3_label.MouseLeave
        Front3_label.ForeColor = Color.White
        Front3_label.Font = New Font(Front3_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Front 4
    Private Sub Front4_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front4_label.MouseHover
        Front4_label.ForeColor = Color.Yellow
        Front4_label.Font = New Font(Front4_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_front4
        PictureBox3.Image = My.Resources.Front_hand
        front_toggled()
    End Sub

    Private Sub Front4_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front4_label.MouseLeave
        Front4_label.ForeColor = Color.White
        Front4_label.Font = New Font(Front4_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Front 5
    Private Sub Front5_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front5_label.MouseHover
        Front5_label.ForeColor = Color.Yellow
        Front5_label.Font = New Font(Front5_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_front5
        PictureBox3.Image = My.Resources.Front_leg
        front_toggled()
    End Sub

    Private Sub Front5_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Front5_label.MouseLeave
        Front5_label.ForeColor = Color.White
        Front5_label.Font = New Font(Front5_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub


    ' Back 1
    Private Sub Back1_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back1_label.MouseHover
        Back1_label.ForeColor = Color.Yellow
        Back1_label.Font = New Font(Back1_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_back1
        PictureBox3.Image = My.Resources.back_head
        back_toggled()
    End Sub

    Private Sub Back1_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back1_label.MouseLeave
        Back1_label.ForeColor = Color.White
        Back1_label.Font = New Font(Back1_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Back 2
    Private Sub Back2_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back2_label.MouseHover
        Back2_label.ForeColor = Color.Yellow
        Back2_label.Font = New Font(Back2_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_back2
        PictureBox3.Image = My.Resources.back_body
        back_toggled()
    End Sub

    Private Sub Back2_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back2_label.MouseLeave
        Back2_label.ForeColor = Color.White
        Back2_label.Font = New Font(Back2_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Back 3
    Private Sub Back3_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back3_label.MouseHover
        Back3_label.ForeColor = Color.Yellow
        Back3_label.Font = New Font(Back3_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_back3
        PictureBox3.Image = My.Resources.back_pelvis
        back_toggled()
    End Sub

    Private Sub Back3_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back3_label.MouseLeave
        Back3_label.ForeColor = Color.White
        Back3_label.Font = New Font(Back3_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Back 4
    Private Sub Back4_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back4_label.MouseHover
        Back4_label.ForeColor = Color.Yellow
        Back4_label.Font = New Font(Back4_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_back4
        PictureBox3.Image = My.Resources.back_hand
        back_toggled()
    End Sub

    Private Sub Back4_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back4_label.MouseLeave
        Back4_label.ForeColor = Color.White
        Back4_label.Font = New Font(Back4_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub

    ' Back 5
    Private Sub Back5_label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back5_label.MouseHover
        Back5_label.ForeColor = Color.Yellow
        Back5_label.Font = New Font(Back5_label.Font, FontStyle.Underline)
        PictureBox2.Image = My.Resources.skeletal_back5
        PictureBox3.Image = My.Resources.back_leg
        back_toggled()
    End Sub

    Private Sub Back5_label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back5_label.MouseLeave
        Back5_label.ForeColor = Color.White
        Back5_label.Font = New Font(Back5_label.Font, FontStyle.Regular)
        set_default_iamge()
    End Sub


    ' ========================================================================================================================================
    ' Custom Functions
    ' ========================================================================================================================================

    ' Default image
    Dim default_image As Integer = 0

    Private Sub set_default_iamge()
        ' Default image for picturebox3
        If default_image = 0 Then
            PictureBox3.Image = My.Resources.timthumb
        End If

        ' Front or back
        If active_panel = True Then
            PictureBox2.Image = My.Resources.skeletal_front
        Else
            PictureBox2.Image = My.Resources.skeletal_back
        End If
    End Sub

    Private Sub front_toggled()
        Front_label.ForeColor = Color.Yellow
        Front_panel.BackColor = Color.FromArgb(64, 64, 64)
        Back_label.ForeColor = Color.White
        Back_panel.BackColor = Color.FromArgb(80, 80, 80)
        Label14.Text = "Front view"
        'Timer1.Enabled = True
        active_panel = True
    End Sub

    Private Sub front_timer()
        front_toggled()
        Timer1.Enabled = True
        PictureBox2.Image = My.Resources.skeletal_front
    End Sub

    Private Sub back_toggled()
        Front_label.ForeColor = Color.White
        Front_panel.BackColor = Color.FromArgb(80, 80, 80)
        Back_label.ForeColor = Color.Yellow
        Back_panel.BackColor = Color.FromArgb(64, 64, 64)
        Label14.Text = "Posterior view"
        'Timer2.Enabled = True
        active_panel = False
    End Sub

    Private Sub back_timer()
        back_toggled()
        Timer2.Enabled = True
        PictureBox2.Image = My.Resources.skeletal_back
    End Sub

End Class