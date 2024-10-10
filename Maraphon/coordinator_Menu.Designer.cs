namespace Maraphon
{
    partial class coordinator_Menu
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
            this.FAQ_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Info_Text_label = new System.Windows.Forms.Label();
            this.runners_But = new Maraphon.Drawer();
            this.sponsList_but = new Maraphon.Drawer();
            this.Back = new Maraphon.Drawer();
            this.Headers = new System.Windows.Forms.PictureBox();
            this.Logout = new Maraphon.Drawer();
            this.Timer_label = new System.Windows.Forms.Label();
            this.FAQ_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).BeginInit();
            this.SuspendLayout();
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
            this.FAQ_Panel.Controls.Add(this.runners_But, 0, 1);
            this.FAQ_Panel.Controls.Add(this.sponsList_but, 1, 1);
            this.FAQ_Panel.Location = new System.Drawing.Point(169, 111);
            this.FAQ_Panel.Name = "FAQ_Panel";
            this.FAQ_Panel.RowCount = 2;
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.FAQ_Panel.Size = new System.Drawing.Size(474, 177);
            this.FAQ_Panel.TabIndex = 19;
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
            this.Info_Text_label.Size = new System.Drawing.Size(468, 70);
            this.Info_Text_label.TabIndex = 4;
            this.Info_Text_label.Text = "Coordinator menu";
            this.Info_Text_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // runners_But
            // 
            this.runners_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runners_But.BackColor = System.Drawing.SystemColors.ControlLight;
            this.runners_But.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.runners_But.BorderColor = System.Drawing.Color.Gray;
            this.runners_But.BorderRadius = 10;
            this.runners_But.BorderSize = 1;
            this.runners_But.FlatAppearance.BorderSize = 0;
            this.runners_But.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runners_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runners_But.ForeColor = System.Drawing.SystemColors.ControlText;
            this.runners_But.Location = new System.Drawing.Point(10, 80);
            this.runners_But.Margin = new System.Windows.Forms.Padding(10);
            this.runners_But.Name = "runners_But";
            this.runners_But.Size = new System.Drawing.Size(217, 87);
            this.runners_But.TabIndex = 1;
            this.runners_But.Text = "Бегуны";
            this.runners_But.TextColor = System.Drawing.SystemColors.ControlText;
            this.runners_But.UseVisualStyleBackColor = false;
            this.runners_But.Click += new System.EventHandler(this.runners_But_Click);
            // 
            // sponsList_but
            // 
            this.sponsList_but.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sponsList_but.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sponsList_but.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.sponsList_but.BorderColor = System.Drawing.Color.Gray;
            this.sponsList_but.BorderRadius = 10;
            this.sponsList_but.BorderSize = 1;
            this.sponsList_but.FlatAppearance.BorderSize = 0;
            this.sponsList_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sponsList_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sponsList_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sponsList_but.Location = new System.Drawing.Point(247, 80);
            this.sponsList_but.Margin = new System.Windows.Forms.Padding(10);
            this.sponsList_but.Name = "sponsList_but";
            this.sponsList_but.Size = new System.Drawing.Size(217, 87);
            this.sponsList_but.TabIndex = 1;
            this.sponsList_but.Text = "Спонсоры";
            this.sponsList_but.TextColor = System.Drawing.SystemColors.ControlText;
            this.sponsList_but.UseVisualStyleBackColor = false;
            this.sponsList_but.Click += new System.EventHandler(this.sponsList_but_Click);
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
            this.Back.TabIndex = 15;
            this.Back.Text = "Назад";
            this.Back.TextColor = System.Drawing.SystemColors.ControlText;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Headers
            // 
            this.Headers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Headers.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Headers.Location = new System.Drawing.Point(0, 0);
            this.Headers.Name = "Headers";
            this.Headers.Size = new System.Drawing.Size(814, 62);
            this.Headers.TabIndex = 18;
            this.Headers.TabStop = false;
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
            this.Logout.TabIndex = 16;
            this.Logout.Text = "Logout";
            this.Logout.TextColor = System.Drawing.SystemColors.ControlText;
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
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
            this.Timer_label.TabIndex = 24;
            this.Timer_label.Text = "18 дней 8 часов и 17 минут до старта марафона!";
            this.Timer_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // coordinator_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.Timer_label);
            this.Controls.Add(this.FAQ_Panel);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Headers);
            this.Name = "coordinator_Menu";
            this.Text = "coordinator_Menu";
            this.Load += new System.EventHandler(this.coordinator_Menu_Load);
            this.FAQ_Panel.ResumeLayout(false);
            this.FAQ_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FAQ_Panel;
        private System.Windows.Forms.Label Info_Text_label;
        private Drawer runners_But;
        private Drawer sponsList_but;
        private Drawer Back;
        private System.Windows.Forms.PictureBox Headers;
        private Drawer Logout;
        private System.Windows.Forms.Label Timer_label;
    }
}