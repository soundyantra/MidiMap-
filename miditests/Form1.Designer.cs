namespace miditests
{
    partial class Form1
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MapButton = new System.Windows.Forms.Button();
            this.MappingTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LastMidiEventTextbox = new System.Windows.Forms.TextBox();
            this.MappingListBox = new System.Windows.Forms.ListBox();
            this.DeleteFromListButtton = new System.Windows.Forms.Button();
            this.DevicesListLabel = new System.Windows.Forms.Label();
            this.MappingListBoxLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(322, 256);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "enable scrolls";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(75, 112);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(203, 256);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MapButton
            // 
            this.MapButton.Location = new System.Drawing.Point(104, 50);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(110, 23);
            this.MapButton.TabIndex = 7;
            this.MapButton.Text = "Map";
            this.MapButton.UseVisualStyleBackColor = true;
            this.MapButton.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // MappingTextbox
            // 
            this.MappingTextbox.Location = new System.Drawing.Point(165, 76);
            this.MappingTextbox.Name = "MappingTextbox";
            this.MappingTextbox.Size = new System.Drawing.Size(45, 20);
            this.MappingTextbox.TabIndex = 9;
            this.MappingTextbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mapping";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "LastMidiEvent";
            // 
            // LastMidiEventTextbox
            // 
            this.LastMidiEventTextbox.Location = new System.Drawing.Point(104, 116);
            this.LastMidiEventTextbox.Name = "LastMidiEventTextbox";
            this.LastMidiEventTextbox.Size = new System.Drawing.Size(110, 20);
            this.LastMidiEventTextbox.TabIndex = 12;
            this.LastMidiEventTextbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // MappingListBox
            // 
            this.MappingListBox.FormattingEnabled = true;
            this.MappingListBox.Location = new System.Drawing.Point(241, 54);
            this.MappingListBox.Name = "MappingListBox";
            this.MappingListBox.Size = new System.Drawing.Size(120, 82);
            this.MappingListBox.TabIndex = 13;
            this.MappingListBox.SelectedIndexChanged += new System.EventHandler(this.MappingListBox_SelectedIndexChanged);
            // 
            // DeleteFromListButtton
            // 
            this.DeleteFromListButtton.Location = new System.Drawing.Point(241, 141);
            this.DeleteFromListButtton.Name = "DeleteFromListButtton";
            this.DeleteFromListButtton.Size = new System.Drawing.Size(120, 23);
            this.DeleteFromListButtton.TabIndex = 14;
            this.DeleteFromListButtton.Text = "DeleteFromListButtton";
            this.DeleteFromListButtton.UseVisualStyleBackColor = true;
            this.DeleteFromListButtton.Click += new System.EventHandler(this.DeleteFromListButtton_Click);
            // 
            // DevicesListLabel
            // 
            this.DevicesListLabel.AutoSize = true;
            this.DevicesListLabel.Location = new System.Drawing.Point(29, 38);
            this.DevicesListLabel.Name = "DevicesListLabel";
            this.DevicesListLabel.Size = new System.Drawing.Size(60, 13);
            this.DevicesListLabel.TabIndex = 15;
            this.DevicesListLabel.Text = "Device List";
            // 
            // MappingListBoxLabel
            // 
            this.MappingListBoxLabel.AutoSize = true;
            this.MappingListBoxLabel.Location = new System.Drawing.Point(261, 38);
            this.MappingListBoxLabel.Name = "MappingListBoxLabel";
            this.MappingListBoxLabel.Size = new System.Drawing.Size(82, 13);
            this.MappingListBoxLabel.TabIndex = 16;
            this.MappingListBoxLabel.Text = "MappingListBox";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(516, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 310);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MappingListBoxLabel);
            this.Controls.Add(this.DevicesListLabel);
            this.Controls.Add(this.DeleteFromListButtton);
            this.Controls.Add(this.MappingListBox);
            this.Controls.Add(this.LastMidiEventTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MappingTextbox);
            this.Controls.Add(this.MapButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Miditest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button MapButton;
        private System.Windows.Forms.TextBox MappingTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LastMidiEventTextbox;
        private System.Windows.Forms.ListBox MappingListBox;
        private System.Windows.Forms.Button DeleteFromListButtton;
        private System.Windows.Forms.Label DevicesListLabel;
        private System.Windows.Forms.Label MappingListBoxLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

