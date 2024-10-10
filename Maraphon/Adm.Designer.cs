namespace Maraphon
{
    partial class Adm
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
            this.Headers = new System.Windows.Forms.PictureBox();
            this.FAQ_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Info_Text_label = new System.Windows.Forms.Label();
            this.users_But = new Maraphon.Drawer();
            this.volunteers_But = new Maraphon.Drawer();
            this.invent_But = new Maraphon.Drawer();
            this.organiz_But = new Maraphon.Drawer();
            this.Timer_label = new System.Windows.Forms.Label();
            this.Logout = new Maraphon.Drawer();
            this.Back = new Maraphon.Drawer();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).BeginInit();
            this.FAQ_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Headers
            // 
            this.Headers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Headers.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Headers.Location = new System.Drawing.Point(0, 0);
            this.Headers.Name = "Headers";
            this.Headers.Size = new System.Drawing.Size(811, 62);
            this.Headers.TabIndex = 7;
            this.Headers.TabStop = false;
            // 
            // FAQ_Panel
            // 
            this.FAQ_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FAQ_Panel.ColumnCount = 2;
            this.FAQ_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FAQ_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FAQ_Panel.Controls.Add(this.Info_Text_label, 0, 0);
            this.FAQ_Panel.Controls.Add(this.users_But, 0, 1);
            this.FAQ_Panel.Controls.Add(this.volunteers_But, 1, 1);
            this.FAQ_Panel.Controls.Add(this.invent_But, 1, 2);
            this.FAQ_Panel.Controls.Add(this.organiz_But, 0, 2);
            this.FAQ_Panel.Location = new System.Drawing.Point(152, 112);
            this.FAQ_Panel.Name = "FAQ_Panel";
            this.FAQ_Panel.RowCount = 3;
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.FAQ_Panel.Size = new System.Drawing.Size(519, 244);
            this.FAQ_Panel.TabIndex = 8;
            // 
            // Info_Text_label
            // 
            this.Info_Text_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_Text_label.AutoSize = true;
            this.FAQ_Panel.SetColumnSpan(this.Info_Text_label, 2);
            this.Info_Text_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info_Text_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Info_Text_label.Location = new System.Drawing.Point(3, 0);
            this.Info_Text_label.Name = "Info_Text_label";
            this.Info_Text_label.Size = new System.Drawing.Size(513, 56);
            this.Info_Text_label.TabIndex = 4;
            this.Info_Text_label.Text = "Administartor menu";
            this.Info_Text_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // users_But
            // 
            this.users_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.users_But.BackColor = System.Drawing.SystemColors.ControlLight;
            this.users_But.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.users_But.BorderColor = System.Drawing.Color.Gray;
            this.users_But.BorderRadius = 10;
            this.users_But.BorderSize = 1;
            this.users_But.FlatAppearance.BorderSize = 0;
            this.users_But.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.users_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users_But.ForeColor = System.Drawing.SystemColors.ControlText;
            this.users_But.Location = new System.Drawing.Point(7, 63);
            this.users_But.Margin = new System.Windows.Forms.Padding(7);
            this.users_But.Name = "users_But";
            this.users_But.Size = new System.Drawing.Size(245, 79);
            this.users_But.TabIndex = 1;
            this.users_But.Text = "Пользователи";
            this.users_But.TextColor = System.Drawing.SystemColors.ControlText;
            this.users_But.UseVisualStyleBackColor = false;
            this.users_But.Click += new System.EventHandler(this.users_But_Click);
            // 
            // volunteers_But
            // 
            this.volunteers_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.volunteers_But.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volunteers_But.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.volunteers_But.BorderColor = System.Drawing.Color.Gray;
            this.volunteers_But.BorderRadius = 10;
            this.volunteers_But.BorderSize = 1;
            this.volunteers_But.FlatAppearance.BorderSize = 0;
            this.volunteers_But.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volunteers_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.volunteers_But.ForeColor = System.Drawing.SystemColors.ControlText;
            this.volunteers_But.Location = new System.Drawing.Point(266, 63);
            this.volunteers_But.Margin = new System.Windows.Forms.Padding(7);
            this.volunteers_But.Name = "volunteers_But";
            this.volunteers_But.Size = new System.Drawing.Size(246, 79);
            this.volunteers_But.TabIndex = 1;
            this.volunteers_But.Text = "Волонтеры";
            this.volunteers_But.TextColor = System.Drawing.SystemColors.ControlText;
            this.volunteers_But.UseVisualStyleBackColor = false;
            this.volunteers_But.Click += new System.EventHandler(this.volunteers_But_Click);
            // 
            // invent_But
            // 
            this.invent_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invent_But.BackColor = System.Drawing.SystemColors.ControlLight;
            this.invent_But.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.invent_But.BorderColor = System.Drawing.Color.Gray;
            this.invent_But.BorderRadius = 10;
            this.invent_But.BorderSize = 1;
            this.invent_But.FlatAppearance.BorderSize = 0;
            this.invent_But.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invent_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.invent_But.ForeColor = System.Drawing.SystemColors.ControlText;
            this.invent_But.Location = new System.Drawing.Point(266, 156);
            this.invent_But.Margin = new System.Windows.Forms.Padding(7);
            this.invent_But.Name = "invent_But";
            this.invent_But.Size = new System.Drawing.Size(246, 81);
            this.invent_But.TabIndex = 1;
            this.invent_But.Text = "Инвентарь";
            this.invent_But.TextColor = System.Drawing.SystemColors.ControlText;
            this.invent_But.UseVisualStyleBackColor = false;
            this.invent_But.Click += new System.EventHandler(this.invent_But_Click);
            // 
            // organiz_But
            // 
            this.organiz_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.organiz_But.BackColor = System.Drawing.SystemColors.ControlLight;
            this.organiz_But.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.organiz_But.BorderColor = System.Drawing.Color.Gray;
            this.organiz_But.BorderRadius = 10;
            this.organiz_But.BorderSize = 1;
            this.organiz_But.FlatAppearance.BorderSize = 0;
            this.organiz_But.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.organiz_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organiz_But.ForeColor = System.Drawing.SystemColors.ControlText;
            this.organiz_But.Location = new System.Drawing.Point(7, 156);
            this.organiz_But.Margin = new System.Windows.Forms.Padding(7);
            this.organiz_But.Name = "organiz_But";
            this.organiz_But.Size = new System.Drawing.Size(245, 81);
            this.organiz_But.TabIndex = 1;
            this.organiz_But.Text = "Благотворительные организации";
            this.organiz_But.TextColor = System.Drawing.SystemColors.ControlText;
            this.organiz_But.UseVisualStyleBackColor = false;
            this.organiz_But.Click += new System.EventHandler(this.organiz_But_Click);
            // 
            // Timer_label
            // 
            this.Timer_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Timer_label.BackColor = System.Drawing.Color.DimGray;
            this.Timer_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer_label.ForeColor = System.Drawing.Color.Transparent;
            this.Timer_label.Location = new System.Drawing.Point(0, 483);
            this.Timer_label.Name = "Timer_label";
            this.Timer_label.Size = new System.Drawing.Size(810, 29);
            this.Timer_label.TabIndex = 22;
            this.Timer_label.Text = "18 дней 8 часов и 17 минут до старта марафона!";
            this.Timer_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Logout
            // 
            this.Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Logout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Logout.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Logout.BorderColor = System.Drawing.SystemColors.Control;
            this.Logout.BorderRadius = 7;
            this.Logout.BorderSize = 1;
            this.Logout.FlatAppearance.BorderSize = 0;
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Logout.Location = new System.Drawing.Point(704, 12);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(93, 42);
            this.Logout.TabIndex = 6;
            this.Logout.Text = "Logout";
            this.Logout.TextColor = System.Drawing.SystemColors.ControlText;
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
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
            this.Back.TabIndex = 6;
            this.Back.Text = "Назад";
            this.Back.TextColor = System.Drawing.SystemColors.ControlText;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Adm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.Timer_label);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Headers);
            this.Controls.Add(this.FAQ_Panel);
            this.MinimumSize = new System.Drawing.Size(825, 550);
            this.Name = "Adm";
            this.Text = "Adm";
            this.Load += new System.EventHandler(this.Adm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).EndInit();
            this.FAQ_Panel.ResumeLayout(false);
            this.FAQ_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Drawer Back;
        private System.Windows.Forms.PictureBox Headers;
        private System.Windows.Forms.TableLayoutPanel FAQ_Panel;
        private System.Windows.Forms.Label Info_Text_label;
        private Drawer users_But;
        private Drawer volunteers_But;
        private Drawer invent_But;
        private Drawer organiz_But;
        private Drawer Logout;
        private System.Windows.Forms.Label Timer_label;
    }
}