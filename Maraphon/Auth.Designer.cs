namespace Maraphon
{
    partial class Auth
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
            this.Auth_panel = new System.Windows.Forms.TableLayoutPanel();
            this.Auth_Label = new System.Windows.Forms.Label();
            this.Info_Auth_Label = new System.Windows.Forms.Label();
            this.Cancel = new Maraphon.Drawer();
            this.Auth_but = new Maraphon.Drawer();
            this.Email_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Email_TextBox = new System.Windows.Forms.TextBox();
            this.Pass_TextBox = new System.Windows.Forms.TextBox();
            this.Headers = new System.Windows.Forms.PictureBox();
            this.Back = new Maraphon.Drawer();
            this.Timer_label = new System.Windows.Forms.Label();
            this.Auth_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).BeginInit();
            this.SuspendLayout();
            // 
            // Auth_panel
            // 
            this.Auth_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_panel.ColumnCount = 4;
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.96399F));
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.89751F));
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.22438F));
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.19114F));
            this.Auth_panel.Controls.Add(this.Auth_Label, 0, 0);
            this.Auth_panel.Controls.Add(this.Info_Auth_Label, 0, 1);
            this.Auth_panel.Controls.Add(this.Cancel, 2, 4);
            this.Auth_panel.Controls.Add(this.Auth_but, 1, 4);
            this.Auth_panel.Controls.Add(this.Email_label, 0, 2);
            this.Auth_panel.Controls.Add(this.Password_label, 0, 3);
            this.Auth_panel.Controls.Add(this.Email_TextBox, 1, 2);
            this.Auth_panel.Controls.Add(this.Pass_TextBox, 1, 3);
            this.Auth_panel.Location = new System.Drawing.Point(12, 111);
            this.Auth_panel.Name = "Auth_panel";
            this.Auth_panel.RowCount = 5;
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Auth_panel.Size = new System.Drawing.Size(785, 314);
            this.Auth_panel.TabIndex = 0;
            this.Auth_panel.Click += new System.EventHandler(this.Auth_panel_Click);
            // 
            // Auth_Label
            // 
            this.Auth_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_Label.AutoSize = true;
            this.Auth_panel.SetColumnSpan(this.Auth_Label, 4);
            this.Auth_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Auth_Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Auth_Label.Location = new System.Drawing.Point(3, 0);
            this.Auth_Label.Name = "Auth_Label";
            this.Auth_Label.Size = new System.Drawing.Size(779, 62);
            this.Auth_Label.TabIndex = 7;
            this.Auth_Label.Text = "Форма авторизации";
            this.Auth_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Auth_Label.Click += new System.EventHandler(this.Auth_Label_Click);
            // 
            // Info_Auth_Label
            // 
            this.Info_Auth_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_Auth_Label.AutoSize = true;
            this.Auth_panel.SetColumnSpan(this.Info_Auth_Label, 4);
            this.Info_Auth_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info_Auth_Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Info_Auth_Label.Location = new System.Drawing.Point(3, 62);
            this.Info_Auth_Label.Name = "Info_Auth_Label";
            this.Info_Auth_Label.Size = new System.Drawing.Size(779, 62);
            this.Info_Auth_Label.TabIndex = 0;
            this.Info_Auth_Label.Text = "Пожалуйста, авторизуйтесь в системе, используя ваш адрес электронной почты\r\nи пар" +
    "оль.\r\n\r\n";
            this.Info_Auth_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Info_Auth_Label.Click += new System.EventHandler(this.Info_Auth_Label_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.BorderColor = System.Drawing.Color.Gray;
            this.Cancel.BorderRadius = 7;
            this.Cancel.BorderSize = 1;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Cancel.Location = new System.Drawing.Point(393, 251);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(115, 50);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.TextColor = System.Drawing.SystemColors.ControlText;
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Auth_but
            // 
            this.Auth_but.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_but.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Auth_but.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Auth_but.BorderColor = System.Drawing.Color.Gray;
            this.Auth_but.BorderRadius = 7;
            this.Auth_but.BorderSize = 1;
            this.Auth_but.FlatAppearance.BorderSize = 0;
            this.Auth_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Auth_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Auth_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Auth_but.Location = new System.Drawing.Point(272, 251);
            this.Auth_but.Name = "Auth_but";
            this.Auth_but.Size = new System.Drawing.Size(115, 50);
            this.Auth_but.TabIndex = 3;
            this.Auth_but.Text = "Login";
            this.Auth_but.TextColor = System.Drawing.SystemColors.ControlText;
            this.Auth_but.UseVisualStyleBackColor = false;
            this.Auth_but.Click += new System.EventHandler(this.Auth_but_Click);
            // 
            // Email_label
            // 
            this.Email_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Email_label.AutoSize = true;
            this.Email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Email_label.Location = new System.Drawing.Point(184, 142);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(71, 25);
            this.Email_label.TabIndex = 8;
            this.Email_label.Text = "Email:";
            // 
            // Password_label
            // 
            this.Password_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Password_label.AutoSize = true;
            this.Password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Password_label.Location = new System.Drawing.Point(143, 204);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(112, 25);
            this.Password_label.TabIndex = 8;
            this.Password_label.Text = "Password:";
            // 
            // Email_TextBox
            // 
            this.Email_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_panel.SetColumnSpan(this.Email_TextBox, 2);
            this.Email_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email_TextBox.Location = new System.Drawing.Point(261, 140);
            this.Email_TextBox.Name = "Email_TextBox";
            this.Email_TextBox.Size = new System.Drawing.Size(354, 29);
            this.Email_TextBox.TabIndex = 1;
            this.Email_TextBox.Enter += new System.EventHandler(this.Email_TextBox_Enter);
            this.Email_TextBox.Leave += new System.EventHandler(this.Email_TextBox_Leave);
            // 
            // Pass_TextBox
            // 
            this.Pass_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_panel.SetColumnSpan(this.Pass_TextBox, 2);
            this.Pass_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass_TextBox.Location = new System.Drawing.Point(261, 202);
            this.Pass_TextBox.Name = "Pass_TextBox";
            this.Pass_TextBox.PasswordChar = '*';
            this.Pass_TextBox.Size = new System.Drawing.Size(354, 29);
            this.Pass_TextBox.TabIndex = 2;
            this.Pass_TextBox.Enter += new System.EventHandler(this.Pass_textBox_Enter);
            this.Pass_TextBox.Leave += new System.EventHandler(this.Pass_textBox_Leave);
            // 
            // Headers
            // 
            this.Headers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Headers.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Headers.Location = new System.Drawing.Point(0, 0);
            this.Headers.Name = "Headers";
            this.Headers.Size = new System.Drawing.Size(811, 62);
            this.Headers.TabIndex = 3;
            this.Headers.TabStop = false;
            this.Headers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Headers_MouseDown);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Back.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Back.BorderColor = System.Drawing.SystemColors.Control;
            this.Back.BorderRadius = 7;
            this.Back.BorderSize = 1;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(93, 42);
            this.Back.TabIndex = 5;
            this.Back.Text = "Назад";
            this.Back.TextColor = System.Drawing.SystemColors.ControlText;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Timer_label
            // 
            this.Timer_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Timer_label.BackColor = System.Drawing.Color.DimGray;
            this.Timer_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer_label.ForeColor = System.Drawing.Color.Transparent;
            this.Timer_label.Location = new System.Drawing.Point(0, 482);
            this.Timer_label.Name = "Timer_label";
            this.Timer_label.Size = new System.Drawing.Size(810, 29);
            this.Timer_label.TabIndex = 23;
            this.Timer_label.Text = "18 дней 8 часов и 17 минут до старта марафона!";
            this.Timer_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.Timer_label);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Headers);
            this.Controls.Add(this.Auth_panel);
            this.MinimumSize = new System.Drawing.Size(825, 550);
            this.Name = "Auth";
            this.Text = "Auth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Auth_FormClosing);
            this.Load += new System.EventHandler(this.Auth_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Auth_MouseDown);
            this.Auth_panel.ResumeLayout(false);
            this.Auth_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Auth_panel;
        private System.Windows.Forms.PictureBox Headers;
        private Drawer Back;
        private Drawer Auth_but;
        private Drawer Cancel;
        private System.Windows.Forms.Label Auth_Label;
        private System.Windows.Forms.Label Info_Auth_Label;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Email_TextBox;
        private System.Windows.Forms.TextBox Pass_TextBox;
        private System.Windows.Forms.Label Timer_label;
    }
}