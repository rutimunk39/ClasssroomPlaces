namespace GUI
{
    partial class AddPropertiesForStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPropertiesForStudent));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.window = new System.Windows.Forms.Button();
            this.bt_door = new System.Windows.Forms.Button();
            this.conditiner = new System.Windows.Forms.Button();
            this.bt_hide = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(372, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 421);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 115);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // window
            // 
            this.window.Location = new System.Drawing.Point(174, 162);
            this.window.Name = "window";
            this.window.Size = new System.Drawing.Size(80, 33);
            this.window.TabIndex = 2;
            this.window.Text = "חלון";
            this.window.UseVisualStyleBackColor = true;
            this.window.Click += new System.EventHandler(this.window_Click);
            // 
            // bt_door
            // 
            this.bt_door.Location = new System.Drawing.Point(174, 225);
            this.bt_door.Name = "bt_door";
            this.bt_door.Size = new System.Drawing.Size(80, 32);
            this.bt_door.TabIndex = 3;
            this.bt_door.Text = "דלת";
            this.bt_door.UseVisualStyleBackColor = true;
            this.bt_door.Click += new System.EventHandler(this.bt_door_Click);
            // 
            // conditiner
            // 
            this.conditiner.Location = new System.Drawing.Point(174, 287);
            this.conditiner.Name = "conditiner";
            this.conditiner.Size = new System.Drawing.Size(80, 33);
            this.conditiner.TabIndex = 4;
            this.conditiner.Text = "מזגן";
            this.conditiner.UseVisualStyleBackColor = true;
            this.conditiner.Click += new System.EventHandler(this.conditiner_Click);
            // 
            // bt_hide
            // 
            this.bt_hide.Location = new System.Drawing.Point(174, 347);
            this.bt_hide.Name = "bt_hide";
            this.bt_hide.Size = new System.Drawing.Size(80, 32);
            this.bt_hide.TabIndex = 5;
            this.bt_hide.Text = "מוסתר";
            this.bt_hide.UseVisualStyleBackColor = true;
            this.bt_hide.Click += new System.EventHandler(this.bt_hide_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "המשך";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddPropertiesForStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(918, 527);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_hide);
            this.Controls.Add(this.conditiner);
            this.Controls.Add(this.bt_door);
            this.Controls.Add(this.window);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "AddPropertiesForStudent";
            this.Text = "AddPropertiesForStudent";
            this.Load += new System.EventHandler(this.AddPropertiesForStudent_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button window;
        private System.Windows.Forms.Button bt_door;
        private System.Windows.Forms.Button conditiner;
        private System.Windows.Forms.Button bt_hide;
        private System.Windows.Forms.Button button1;
    }
}