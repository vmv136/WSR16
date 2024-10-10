namespace Maraphon
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Headers = new System.Windows.Forms.PictureBox();
            this.Main_panel = new System.Windows.Forms.TableLayoutPanel();
            this.Sponsor_reg = new Maraphon.Drawer();
            this.FAQ = new Maraphon.Drawer();
            this.Runner_reg = new Maraphon.Drawer();
            this.Runner_panel = new System.Windows.Forms.TableLayoutPanel();
            this.New_runner = new Maraphon.Drawer();
            this.Old_runner = new Maraphon.Drawer();
            this.Info_Text_label = new System.Windows.Forms.Label();
            this.FAQ_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Info_But = new Maraphon.Drawer();
            this.Duration_but = new Maraphon.Drawer();
            this.Organiz_but = new Maraphon.Drawer();
            this.Old_results = new Maraphon.Drawer();
            this.Back = new Maraphon.Drawer();
            this.Login = new Maraphon.Drawer();
            this.Timer_label = new System.Windows.Forms.Label();
            this.maraphone_date_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.maraphone_name_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).BeginInit();
            this.Main_panel.SuspendLayout();
            this.Runner_panel.SuspendLayout();
            this.FAQ_Panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.Headers.TabIndex = 2;
            this.Headers.TabStop = false;
            // 
            // Main_panel
            // 
            this.Main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_panel.ColumnCount = 1;
            this.Main_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Main_panel.Controls.Add(this.Sponsor_reg, 0, 1);
            this.Main_panel.Controls.Add(this.FAQ, 0, 2);
            this.Main_panel.Controls.Add(this.Runner_reg, 0, 0);
            this.Main_panel.Location = new System.Drawing.Point(196, 162);
            this.Main_panel.Name = "Main_panel";
            this.Main_panel.RowCount = 3;
            this.Main_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Main_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Main_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Main_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Main_panel.Size = new System.Drawing.Size(420, 279);
            this.Main_panel.TabIndex = 3;
            // 
            // Sponsor_reg
            // 
            this.Sponsor_reg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sponsor_reg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Sponsor_reg.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Sponsor_reg.BorderColor = System.Drawing.Color.Gray;
            this.Sponsor_reg.BorderRadius = 10;
            this.Sponsor_reg.BorderSize = 1;
            this.Sponsor_reg.FlatAppearance.BorderSize = 0;
            this.Sponsor_reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sponsor_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sponsor_reg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Sponsor_reg.Location = new System.Drawing.Point(5, 98);
            this.Sponsor_reg.Margin = new System.Windows.Forms.Padding(5);
            this.Sponsor_reg.Name = "Sponsor_reg";
            this.Sponsor_reg.Size = new System.Drawing.Size(410, 83);
            this.Sponsor_reg.TabIndex = 1;
            this.Sponsor_reg.Text = "Я хочу стать спонсором бегуна";
            this.Sponsor_reg.TextColor = System.Drawing.SystemColors.ControlText;
            this.Sponsor_reg.UseVisualStyleBackColor = false;
            this.Sponsor_reg.Click += new System.EventHandler(this.Sponsor_reg_Click);
            // 
            // FAQ
            // 
            this.FAQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FAQ.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FAQ.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.FAQ.BorderColor = System.Drawing.Color.Gray;
            this.FAQ.BorderRadius = 10;
            this.FAQ.BorderSize = 1;
            this.FAQ.FlatAppearance.BorderSize = 0;
            this.FAQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FAQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FAQ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FAQ.Location = new System.Drawing.Point(5, 191);
            this.FAQ.Margin = new System.Windows.Forms.Padding(5);
            this.FAQ.Name = "FAQ";
            this.FAQ.Size = new System.Drawing.Size(410, 83);
            this.FAQ.TabIndex = 1;
            this.FAQ.Text = "Я хочу узнать больше о событии";
            this.FAQ.TextColor = System.Drawing.SystemColors.ControlText;
            this.FAQ.UseVisualStyleBackColor = false;
            this.FAQ.Click += new System.EventHandler(this.FAQ_Click);
            // 
            // Runner_reg
            // 
            this.Runner_reg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Runner_reg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Runner_reg.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Runner_reg.BorderColor = System.Drawing.Color.Gray;
            this.Runner_reg.BorderRadius = 10;
            this.Runner_reg.BorderSize = 1;
            this.Runner_reg.FlatAppearance.BorderSize = 0;
            this.Runner_reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Runner_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Runner_reg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Runner_reg.Location = new System.Drawing.Point(5, 5);
            this.Runner_reg.Margin = new System.Windows.Forms.Padding(5);
            this.Runner_reg.Name = "Runner_reg";
            this.Runner_reg.Size = new System.Drawing.Size(410, 83);
            this.Runner_reg.TabIndex = 1;
            this.Runner_reg.Text = "Я хочу стать бегуном";
            this.Runner_reg.TextColor = System.Drawing.SystemColors.ControlText;
            this.Runner_reg.UseVisualStyleBackColor = false;
            this.Runner_reg.Click += new System.EventHandler(this.Runner_reg_Click);
            // 
            // Runner_panel
            // 
            this.Runner_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Runner_panel.ColumnCount = 1;
            this.Runner_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Runner_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Runner_panel.Controls.Add(this.New_runner, 0, 1);
            this.Runner_panel.Controls.Add(this.Old_runner, 0, 0);
            this.Runner_panel.Location = new System.Drawing.Point(196, 162);
            this.Runner_panel.Name = "Runner_panel";
            this.Runner_panel.RowCount = 2;
            this.Runner_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Runner_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Runner_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Runner_panel.Size = new System.Drawing.Size(420, 196);
            this.Runner_panel.TabIndex = 3;
            this.Runner_panel.Visible = false;
            // 
            // New_runner
            // 
            this.New_runner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.New_runner.BackColor = System.Drawing.SystemColors.ControlLight;
            this.New_runner.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.New_runner.BorderColor = System.Drawing.Color.Gray;
            this.New_runner.BorderRadius = 10;
            this.New_runner.BorderSize = 1;
            this.New_runner.FlatAppearance.BorderSize = 0;
            this.New_runner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.New_runner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.New_runner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.New_runner.Location = new System.Drawing.Point(5, 103);
            this.New_runner.Margin = new System.Windows.Forms.Padding(5);
            this.New_runner.Name = "New_runner";
            this.New_runner.Size = new System.Drawing.Size(410, 88);
            this.New_runner.TabIndex = 1;
            this.New_runner.Text = "Я новый участник";
            this.New_runner.TextColor = System.Drawing.SystemColors.ControlText;
            this.New_runner.UseVisualStyleBackColor = false;
            this.New_runner.Click += new System.EventHandler(this.New_runner_Click);
            // 
            // Old_runner
            // 
            this.Old_runner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Old_runner.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Old_runner.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Old_runner.BorderColor = System.Drawing.Color.Gray;
            this.Old_runner.BorderRadius = 10;
            this.Old_runner.BorderSize = 1;
            this.Old_runner.FlatAppearance.BorderSize = 0;
            this.Old_runner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Old_runner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Old_runner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Old_runner.Location = new System.Drawing.Point(5, 5);
            this.Old_runner.Margin = new System.Windows.Forms.Padding(5);
            this.Old_runner.Name = "Old_runner";
            this.Old_runner.Size = new System.Drawing.Size(410, 88);
            this.Old_runner.TabIndex = 1;
            this.Old_runner.Text = "Я участвовал ранее";
            this.Old_runner.TextColor = System.Drawing.SystemColors.ControlText;
            this.Old_runner.UseVisualStyleBackColor = false;
            this.Old_runner.Click += new System.EventHandler(this.Old_runner_Click);
            // 
            // Info_Text_label
            // 
            this.Info_Text_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_Text_label.AutoSize = true;
            this.FAQ_Panel.SetColumnSpan(this.Info_Text_label, 2);
            this.Info_Text_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info_Text_label.Location = new System.Drawing.Point(3, 0);
            this.Info_Text_label.Name = "Info_Text_label";
            this.Info_Text_label.Size = new System.Drawing.Size(504, 66);
            this.Info_Text_label.TabIndex = 4;
            this.Info_Text_label.Text = "Подробная информация";
            this.Info_Text_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.FAQ_Panel.Controls.Add(this.Info_But, 0, 1);
            this.FAQ_Panel.Controls.Add(this.Duration_but, 1, 1);
            this.FAQ_Panel.Controls.Add(this.Organiz_but, 1, 2);
            this.FAQ_Panel.Controls.Add(this.Old_results, 0, 2);
            this.FAQ_Panel.Location = new System.Drawing.Point(152, 112);
            this.FAQ_Panel.Name = "FAQ_Panel";
            this.FAQ_Panel.RowCount = 3;
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.FAQ_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.FAQ_Panel.Size = new System.Drawing.Size(510, 288);
            this.FAQ_Panel.TabIndex = 5;
            this.FAQ_Panel.Visible = false;
            // 
            // Info_But
            // 
            this.Info_But.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_But.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Info_But.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Info_But.BorderColor = System.Drawing.Color.Gray;
            this.Info_But.BorderRadius = 10;
            this.Info_But.BorderSize = 1;
            this.Info_But.FlatAppearance.BorderSize = 0;
            this.Info_But.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Info_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info_But.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Info_But.Location = new System.Drawing.Point(3, 69);
            this.Info_But.Name = "Info_But";
            this.Info_But.Size = new System.Drawing.Size(249, 104);
            this.Info_But.TabIndex = 1;
            this.Info_But.Text = "Marathon Skills 2016";
            this.Info_But.TextColor = System.Drawing.SystemColors.ControlText;
            this.Info_But.UseVisualStyleBackColor = false;
            this.Info_But.Click += new System.EventHandler(this.Info_But_Click);
            // 
            // Duration_but
            // 
            this.Duration_but.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Duration_but.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Duration_but.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Duration_but.BorderColor = System.Drawing.Color.Gray;
            this.Duration_but.BorderRadius = 10;
            this.Duration_but.BorderSize = 1;
            this.Duration_but.FlatAppearance.BorderSize = 0;
            this.Duration_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Duration_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Duration_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Duration_but.Location = new System.Drawing.Point(258, 69);
            this.Duration_but.Name = "Duration_but";
            this.Duration_but.Size = new System.Drawing.Size(249, 104);
            this.Duration_but.TabIndex = 1;
            this.Duration_but.Text = "Насколько долгий марафон";
            this.Duration_but.TextColor = System.Drawing.SystemColors.ControlText;
            this.Duration_but.UseVisualStyleBackColor = false;
            this.Duration_but.Click += new System.EventHandler(this.Duration_but_Click);
            // 
            // Organiz_but
            // 
            this.Organiz_but.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Organiz_but.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Organiz_but.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Organiz_but.BorderColor = System.Drawing.Color.Gray;
            this.Organiz_but.BorderRadius = 10;
            this.Organiz_but.BorderSize = 1;
            this.Organiz_but.FlatAppearance.BorderSize = 0;
            this.Organiz_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Organiz_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Organiz_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Organiz_but.Location = new System.Drawing.Point(258, 179);
            this.Organiz_but.Name = "Organiz_but";
            this.Organiz_but.Size = new System.Drawing.Size(249, 106);
            this.Organiz_but.TabIndex = 1;
            this.Organiz_but.Text = "Список благотворительных организаций";
            this.Organiz_but.TextColor = System.Drawing.SystemColors.ControlText;
            this.Organiz_but.UseVisualStyleBackColor = false;
            this.Organiz_but.Click += new System.EventHandler(this.Organiz_but_Click);
            // 
            // Old_results
            // 
            this.Old_results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Old_results.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Old_results.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Old_results.BorderColor = System.Drawing.Color.Gray;
            this.Old_results.BorderRadius = 10;
            this.Old_results.BorderSize = 1;
            this.Old_results.FlatAppearance.BorderSize = 0;
            this.Old_results.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Old_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Old_results.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Old_results.Location = new System.Drawing.Point(3, 179);
            this.Old_results.Name = "Old_results";
            this.Old_results.Size = new System.Drawing.Size(249, 106);
            this.Old_results.TabIndex = 1;
            this.Old_results.Text = "Предыдущие результаты";
            this.Old_results.TextColor = System.Drawing.SystemColors.ControlText;
            this.Old_results.UseVisualStyleBackColor = false;
            this.Old_results.Click += new System.EventHandler(this.Old_results_Click);
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
            this.Back.TabIndex = 1;
            this.Back.Text = "Назад";
            this.Back.TextColor = System.Drawing.SystemColors.ControlText;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Visible = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Login
            // 
            this.Login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Login.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Login.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Login.BorderColor = System.Drawing.Color.Gray;
            this.Login.BorderRadius = 10;
            this.Login.BorderSize = 1;
            this.Login.FlatAppearance.BorderSize = 0;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Login.Location = new System.Drawing.Point(674, 431);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(123, 46);
            this.Login.TabIndex = 1;
            this.Login.Text = "Login";
            this.Login.TextColor = System.Drawing.SystemColors.ControlText;
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
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
            this.Timer_label.Size = new System.Drawing.Size(811, 29);
            this.Timer_label.TabIndex = 24;
            this.Timer_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // maraphone_date_label
            // 
            this.maraphone_date_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maraphone_date_label.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.maraphone_date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maraphone_date_label.ForeColor = System.Drawing.Color.Silver;
            this.maraphone_date_label.Location = new System.Drawing.Point(3, 72);
            this.maraphone_date_label.Margin = new System.Windows.Forms.Padding(3);
            this.maraphone_date_label.Name = "maraphone_date_label";
            this.maraphone_date_label.Size = new System.Drawing.Size(504, 46);
            this.maraphone_date_label.TabIndex = 25;
            this.maraphone_date_label.Text = "label1";
            this.maraphone_date_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.maraphone_date_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.maraphone_name_label, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(152, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.54717F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.45283F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 121);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // maraphone_name_label
            // 
            this.maraphone_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maraphone_name_label.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.maraphone_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maraphone_name_label.ForeColor = System.Drawing.SystemColors.Control;
            this.maraphone_name_label.Location = new System.Drawing.Point(3, 3);
            this.maraphone_name_label.Margin = new System.Windows.Forms.Padding(3);
            this.maraphone_name_label.Name = "maraphone_name_label";
            this.maraphone_name_label.Size = new System.Drawing.Size(504, 53);
            this.maraphone_name_label.TabIndex = 25;
            this.maraphone_name_label.Text = "label1";
            this.maraphone_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.FAQ_Panel);
            this.Controls.Add(this.Timer_label);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Runner_panel);
            this.Controls.Add(this.Headers);
            this.Controls.Add(this.Main_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(825, 550);
            this.Name = "Main";
            this.Text = "Marathon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Headers)).EndInit();
            this.Main_panel.ResumeLayout(false);
            this.Runner_panel.ResumeLayout(false);
            this.FAQ_Panel.ResumeLayout(false);
            this.FAQ_Panel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Headers;
        private Drawer Login;
        private Drawer FAQ;
        private Drawer Sponsor_reg;
        private System.Windows.Forms.TableLayoutPanel Main_panel;
        private Drawer Runner_reg;
        private System.Windows.Forms.TableLayoutPanel Runner_panel;
        private Drawer New_runner;
        private Drawer Old_runner;
        private Drawer Back;
        private System.Windows.Forms.Label Info_Text_label;
        private System.Windows.Forms.TableLayoutPanel FAQ_Panel;
        private Drawer Info_But;
        private Drawer Duration_but;
        private Drawer Organiz_but;
        private Drawer Old_results;
        private System.Windows.Forms.Label Timer_label;
        private System.Windows.Forms.Label maraphone_date_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label maraphone_name_label;
    }
}

