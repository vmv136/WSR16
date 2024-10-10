namespace Maraphon
{
    partial class Edit_run_prof
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
            this.Timer_label = new System.Windows.Forms.Label();
            this.Back = new Maraphon.Drawer();
            this.Headers = new System.Windows.Forms.PictureBox();
            this.Auth_panel = new System.Windows.Forms.TableLayoutPanel();
            this.Reg_Label = new System.Windows.Forms.Label();
            this.Email_label = new System.Windows.Forms.Label();
            this.Name_label = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.last_name_label = new System.Windows.Forms.Label();
            this.last_name_textBox = new System.Windows.Forms.TextBox();
            this.Gender_comboBox = new System.Windows.Forms.ComboBox();
            this.gender_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Red_but = new Maraphon.Drawer();
            this.Cancel = new Maraphon.Drawer();
            this.label2 = new System.Windows.Forms.Label();
            this.Country_ComboBox = new System.Windows.Forms.ComboBox();
            this.email_value_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Pass_label = new System.Windows.Forms.Label();
            this.Pass_textBox = new System.Windows.Forms.TextBox();
            this.Pass_Reap_label = new System.Windows.Forms.Label();
            this.PassReap_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pay_combox = new System.Windows.Forms.ComboBox();
            this.Logout = new Maraphon.Drawer();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).BeginInit();
            this.Auth_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_label
            // 
            this.Timer_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Timer_label.BackColor = System.Drawing.Color.DimGray;
            this.Timer_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer_label.ForeColor = System.Drawing.Color.Transparent;
            this.Timer_label.Location = new System.Drawing.Point(-1, 482);
            this.Timer_label.Name = "Timer_label";
            this.Timer_label.Size = new System.Drawing.Size(810, 29);
            this.Timer_label.TabIndex = 26;
            this.Timer_label.Text = "18 дней 8 часов и 17 минут до старта марафона!";
            this.Timer_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.Back.TabIndex = 25;
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
            this.Headers.Size = new System.Drawing.Size(811, 62);
            this.Headers.TabIndex = 24;
            this.Headers.TabStop = false;
            // 
            // Auth_panel
            // 
            this.Auth_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_panel.ColumnCount = 4;
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.4586F));
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.60509F));
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.60509F));
            this.Auth_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.33121F));
            this.Auth_panel.Controls.Add(this.Reg_Label, 0, 0);
            this.Auth_panel.Controls.Add(this.Email_label, 0, 1);
            this.Auth_panel.Controls.Add(this.Name_label, 0, 2);
            this.Auth_panel.Controls.Add(this.name_textBox, 1, 2);
            this.Auth_panel.Controls.Add(this.last_name_label, 0, 3);
            this.Auth_panel.Controls.Add(this.last_name_textBox, 1, 3);
            this.Auth_panel.Controls.Add(this.Gender_comboBox, 1, 4);
            this.Auth_panel.Controls.Add(this.gender_label, 0, 4);
            this.Auth_panel.Controls.Add(this.label1, 0, 5);
            this.Auth_panel.Controls.Add(this.dateTimePicker1, 1, 5);
            this.Auth_panel.Controls.Add(this.Red_but, 1, 7);
            this.Auth_panel.Controls.Add(this.Cancel, 2, 7);
            this.Auth_panel.Controls.Add(this.label2, 0, 6);
            this.Auth_panel.Controls.Add(this.Country_ComboBox, 1, 6);
            this.Auth_panel.Controls.Add(this.email_value_label, 1, 1);
            this.Auth_panel.Controls.Add(this.label3, 2, 1);
            this.Auth_panel.Controls.Add(this.Pass_label, 2, 2);
            this.Auth_panel.Controls.Add(this.Pass_textBox, 3, 2);
            this.Auth_panel.Controls.Add(this.Pass_Reap_label, 2, 3);
            this.Auth_panel.Controls.Add(this.PassReap_TextBox, 3, 3);
            this.Auth_panel.Controls.Add(this.label4, 2, 5);
            this.Auth_panel.Controls.Add(this.pay_combox, 2, 6);
            this.Auth_panel.Location = new System.Drawing.Point(11, 68);
            this.Auth_panel.Name = "Auth_panel";
            this.Auth_panel.RowCount = 8;
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.32068F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2399F));
            this.Auth_panel.Size = new System.Drawing.Size(785, 411);
            this.Auth_panel.TabIndex = 27;
            // 
            // Reg_Label
            // 
            this.Reg_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Reg_Label.AutoSize = true;
            this.Auth_panel.SetColumnSpan(this.Reg_Label, 4);
            this.Reg_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reg_Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Reg_Label.Location = new System.Drawing.Point(3, 0);
            this.Reg_Label.Name = "Reg_Label";
            this.Reg_Label.Size = new System.Drawing.Size(779, 58);
            this.Reg_Label.TabIndex = 7;
            this.Reg_Label.Text = "Редактирование профиля";
            this.Reg_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Email_label
            // 
            this.Email_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Email_label.AutoSize = true;
            this.Email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Email_label.Location = new System.Drawing.Point(127, 71);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(62, 24);
            this.Email_label.TabIndex = 7;
            this.Email_label.Text = "Email:";
            this.Email_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Name_label
            // 
            this.Name_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Name_label.AutoSize = true;
            this.Name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name_label.Location = new System.Drawing.Point(138, 121);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(51, 24);
            this.Name_label.TabIndex = 7;
            this.Name_label.Text = "Имя:";
            this.Name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name_textBox
            // 
            this.name_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_textBox.Location = new System.Drawing.Point(195, 118);
            this.name_textBox.MaxLength = 20;
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(194, 29);
            this.name_textBox.TabIndex = 4;
            this.name_textBox.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.name_textBox.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // last_name_label
            // 
            this.last_name_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.last_name_label.AutoSize = true;
            this.last_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.last_name_label.Location = new System.Drawing.Point(93, 171);
            this.last_name_label.Name = "last_name_label";
            this.last_name_label.Size = new System.Drawing.Size(96, 24);
            this.last_name_label.TabIndex = 13;
            this.last_name_label.Text = "Фамилия:";
            this.last_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // last_name_textBox
            // 
            this.last_name_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.last_name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_textBox.Location = new System.Drawing.Point(195, 168);
            this.last_name_textBox.MaxLength = 20;
            this.last_name_textBox.Name = "last_name_textBox";
            this.last_name_textBox.Size = new System.Drawing.Size(194, 29);
            this.last_name_textBox.TabIndex = 5;
            this.last_name_textBox.Enter += new System.EventHandler(this.last_name_textBox_Enter);
            this.last_name_textBox.Leave += new System.EventHandler(this.last_name_textBox_Leave);
            // 
            // Gender_comboBox
            // 
            this.Gender_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Gender_comboBox.BackColor = System.Drawing.SystemColors.Window;
            this.Gender_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Gender_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Gender_comboBox.FormattingEnabled = true;
            this.Gender_comboBox.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.Gender_comboBox.Location = new System.Drawing.Point(195, 217);
            this.Gender_comboBox.Name = "Gender_comboBox";
            this.Gender_comboBox.Size = new System.Drawing.Size(194, 32);
            this.Gender_comboBox.TabIndex = 6;
            // 
            // gender_label
            // 
            this.gender_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gender_label.AutoSize = true;
            this.gender_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gender_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gender_label.Location = new System.Drawing.Point(140, 221);
            this.gender_label.Name = "gender_label";
            this.gender_label.Size = new System.Drawing.Size(49, 24);
            this.gender_label.TabIndex = 7;
            this.gender_label.Text = "Пол:";
            this.gender_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(34, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Дата рождения:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(195, 268);
            this.dateTimePicker1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(194, 29);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // Red_but
            // 
            this.Red_but.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Red_but.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Red_but.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Red_but.BorderColor = System.Drawing.Color.Gray;
            this.Red_but.BorderRadius = 7;
            this.Red_but.BorderSize = 1;
            this.Red_but.FlatAppearance.BorderSize = 0;
            this.Red_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Red_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Red_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Red_but.Location = new System.Drawing.Point(239, 364);
            this.Red_but.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.Red_but.Name = "Red_but";
            this.Red_but.Size = new System.Drawing.Size(143, 40);
            this.Red_but.TabIndex = 9;
            this.Red_but.Text = "Сохранить";
            this.Red_but.TextColor = System.Drawing.SystemColors.ControlText;
            this.Red_but.UseVisualStyleBackColor = false;
            this.Red_but.Click += new System.EventHandler(this.Red_but_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.BorderColor = System.Drawing.Color.Gray;
            this.Cancel.BorderRadius = 7;
            this.Cancel.BorderSize = 1;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Cancel.Location = new System.Drawing.Point(402, 364);
            this.Cancel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(115, 40);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Отмена";
            this.Cancel.TextColor = System.Drawing.SystemColors.ControlText;
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(109, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Страна:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Country_ComboBox
            // 
            this.Country_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Country_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Country_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Country_ComboBox.FormattingEnabled = true;
            this.Country_ComboBox.Location = new System.Drawing.Point(195, 317);
            this.Country_ComboBox.Name = "Country_ComboBox";
            this.Country_ComboBox.Size = new System.Drawing.Size(194, 32);
            this.Country_ComboBox.TabIndex = 8;
            // 
            // email_value_label
            // 
            this.email_value_label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.email_value_label.AutoSize = true;
            this.email_value_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_value_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.email_value_label.Location = new System.Drawing.Point(195, 71);
            this.email_value_label.Name = "email_value_label";
            this.email_value_label.Size = new System.Drawing.Size(0, 24);
            this.email_value_label.TabIndex = 7;
            this.email_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.Auth_panel.SetColumnSpan(this.label3, 2);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(395, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 50);
            this.label3.TabIndex = 7;
            this.label3.Text = "Смена пароля";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pass_label
            // 
            this.Pass_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Pass_label.AutoSize = true;
            this.Pass_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pass_label.Location = new System.Drawing.Point(508, 121);
            this.Pass_label.Name = "Pass_label";
            this.Pass_label.Size = new System.Drawing.Size(81, 24);
            this.Pass_label.TabIndex = 7;
            this.Pass_label.Text = "Пароль:";
            this.Pass_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Pass_textBox
            // 
            this.Pass_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Pass_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass_textBox.Location = new System.Drawing.Point(595, 118);
            this.Pass_textBox.MaxLength = 30;
            this.Pass_textBox.Name = "Pass_textBox";
            this.Pass_textBox.PasswordChar = '*';
            this.Pass_textBox.Size = new System.Drawing.Size(187, 29);
            this.Pass_textBox.TabIndex = 2;
            this.Pass_textBox.Enter += new System.EventHandler(this.Pass_textBox_Enter);
            this.Pass_textBox.Leave += new System.EventHandler(this.Pass_textBox_Leave);
            // 
            // Pass_Reap_label
            // 
            this.Pass_Reap_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Pass_Reap_label.AutoSize = true;
            this.Pass_Reap_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass_Reap_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pass_Reap_label.Location = new System.Drawing.Point(406, 171);
            this.Pass_Reap_label.Name = "Pass_Reap_label";
            this.Pass_Reap_label.Size = new System.Drawing.Size(183, 24);
            this.Pass_Reap_label.TabIndex = 7;
            this.Pass_Reap_label.Text = "Повторите пароль:";
            this.Pass_Reap_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PassReap_TextBox
            // 
            this.PassReap_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PassReap_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassReap_TextBox.Location = new System.Drawing.Point(595, 168);
            this.PassReap_TextBox.MaxLength = 30;
            this.PassReap_TextBox.Name = "PassReap_TextBox";
            this.PassReap_TextBox.PasswordChar = '*';
            this.PassReap_TextBox.Size = new System.Drawing.Size(187, 29);
            this.PassReap_TextBox.TabIndex = 3;
            this.PassReap_TextBox.Enter += new System.EventHandler(this.PassReap_TextBox_Enter);
            this.PassReap_TextBox.Leave += new System.EventHandler(this.PassReap_TextBox_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.Auth_panel.SetColumnSpan(this.label4, 2);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(395, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(387, 50);
            this.label4.TabIndex = 7;
            this.label4.Text = "Регистрационный статус";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pay_combox
            // 
            this.pay_combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth_panel.SetColumnSpan(this.pay_combox, 2);
            this.pay_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pay_combox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pay_combox.FormattingEnabled = true;
            this.pay_combox.Location = new System.Drawing.Point(462, 317);
            this.pay_combox.Margin = new System.Windows.Forms.Padding(70, 3, 70, 3);
            this.pay_combox.Name = "pay_combox";
            this.pay_combox.Size = new System.Drawing.Size(253, 32);
            this.pay_combox.TabIndex = 8;
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
            this.Logout.TabIndex = 28;
            this.Logout.Text = "Logout";
            this.Logout.TextColor = System.Drawing.SystemColors.ControlText;
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Edit_run_prof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Auth_panel);
            this.Controls.Add(this.Timer_label);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Headers);
            this.MinimumSize = new System.Drawing.Size(825, 550);
            this.Name = "Edit_run_prof";
            this.Text = "Edit_run_prof";
            this.Load += new System.EventHandler(this.Edit_run_prof_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).EndInit();
            this.Auth_panel.ResumeLayout(false);
            this.Auth_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Timer_label;
        private Drawer Back;
        private System.Windows.Forms.PictureBox Headers;
        private System.Windows.Forms.TableLayoutPanel Auth_panel;
        private System.Windows.Forms.Label Reg_Label;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label last_name_label;
        private System.Windows.Forms.TextBox last_name_textBox;
        private System.Windows.Forms.ComboBox Gender_comboBox;
        private System.Windows.Forms.Label gender_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label Pass_label;
        private System.Windows.Forms.TextBox Pass_textBox;
        private System.Windows.Forms.Label Pass_Reap_label;
        private System.Windows.Forms.TextBox PassReap_TextBox;
        private Drawer Red_but;
        private Drawer Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Country_ComboBox;
        private System.Windows.Forms.Label email_value_label;
        private System.Windows.Forms.Label label3;
        private Drawer Logout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox pay_combox;
    }
}