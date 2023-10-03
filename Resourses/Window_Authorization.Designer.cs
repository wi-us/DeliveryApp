namespace DeliveryApp.Resourses
{
    partial class Window_Authorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label_Login = new Label();
            Label_Password = new Label();
            TextBox_Login = new TextBox();
            TextBox_Password = new TextBox();
            Button_CheckAuthData = new Button();
            SuspendLayout();
            // 
            // Label_Login
            // 
            Label_Login.AutoSize = true;
            Label_Login.Location = new Point(22, 27);
            Label_Login.Name = "Label_Login";
            Label_Login.Size = new Size(84, 15);
            Label_Login.TabIndex = 0;
            Label_Login.Text = "Пользователь";
            // 
            // Label_Password
            // 
            Label_Password.AutoSize = true;
            Label_Password.Location = new Point(22, 53);
            Label_Password.Name = "Label_Password";
            Label_Password.Size = new Size(49, 15);
            Label_Password.TabIndex = 1;
            Label_Password.Text = "Пароль";
            // 
            // TextBox_Login
            // 
            TextBox_Login.Location = new Point(118, 24);
            TextBox_Login.Name = "TextBox_Login";
            TextBox_Login.Size = new Size(100, 23);
            TextBox_Login.TabIndex = 2;
            // 
            // TextBox_Password
            // 
            TextBox_Password.Location = new Point(118, 53);
            TextBox_Password.Name = "TextBox_Password";
            TextBox_Password.Size = new Size(100, 23);
            TextBox_Password.TabIndex = 3;
            // 
            // Button_CheckAuthData
            // 
            Button_CheckAuthData.Location = new Point(86, 103);
            Button_CheckAuthData.Name = "Button_CheckAuthData";
            Button_CheckAuthData.Size = new Size(75, 23);
            Button_CheckAuthData.TabIndex = 4;
            Button_CheckAuthData.Text = "Вход";
            Button_CheckAuthData.UseVisualStyleBackColor = true;
            Button_CheckAuthData.Click += Button_CheckAuthData_Click;
            // 
            // Window_Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(246, 140);
            Controls.Add(Button_CheckAuthData);
            Controls.Add(TextBox_Password);
            Controls.Add(TextBox_Login);
            Controls.Add(Label_Password);
            Controls.Add(Label_Login);
            Name = "Window_Authorization";
            Text = "Window_Authorization";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_Login;
        private Label Label_Password;
        private TextBox TextBox_Login;
        private TextBox TextBox_Password;
        private Button Button_CheckAuthData;
    }
}