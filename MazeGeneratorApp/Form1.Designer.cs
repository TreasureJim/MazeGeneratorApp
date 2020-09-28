namespace MazeGeneratorApp
{
    partial class Form1
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
            this.GenerateButton = new System.Windows.Forms.Button();
            this.BoxSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deadEndsCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.connectionChanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.windingChanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.MazeSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roomBuildAttemptsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roomMaxSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.roomMinSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BoxSizeNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionChanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windingChanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazeSizeNumeric)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomBuildAttemptsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomMaxSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomMinSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.AutoSize = true;
            this.GenerateButton.Location = new System.Drawing.Point(506, 466);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(200, 23);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate Maze";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // BoxSizeNumeric
            // 
            this.BoxSizeNumeric.Location = new System.Drawing.Point(6, 19);
            this.BoxSizeNumeric.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.BoxSizeNumeric.Name = "BoxSizeNumeric";
            this.BoxSizeNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BoxSizeNumeric.Size = new System.Drawing.Size(174, 20);
            this.BoxSizeNumeric.TabIndex = 2;
            this.BoxSizeNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BoxSizeNumeric.ValueChanged += new System.EventHandler(this.BoxSizeNumeric_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.BoxSizeNumeric);
            this.groupBox1.Location = new System.Drawing.Point(506, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Box Size";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.deadEndsCheck);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.connectionChanceNumeric);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.windingChanceNumeric);
            this.groupBox2.Controls.Add(this.MazeSizeNumeric);
            this.groupBox2.Location = new System.Drawing.Point(506, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 176);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maze Settings";
            // 
            // deadEndsCheck
            // 
            this.deadEndsCheck.AutoSize = true;
            this.deadEndsCheck.Checked = true;
            this.deadEndsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deadEndsCheck.Location = new System.Drawing.Point(9, 140);
            this.deadEndsCheck.Name = "deadEndsCheck";
            this.deadEndsCheck.Size = new System.Drawing.Size(122, 17);
            this.deadEndsCheck.TabIndex = 13;
            this.deadEndsCheck.Text = "Remove Dead Ends";
            this.deadEndsCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Connection Chance (%)";
            // 
            // connectionChanceNumeric
            // 
            this.connectionChanceNumeric.Location = new System.Drawing.Point(9, 113);
            this.connectionChanceNumeric.Name = "connectionChanceNumeric";
            this.connectionChanceNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.connectionChanceNumeric.Size = new System.Drawing.Size(60, 20);
            this.connectionChanceNumeric.TabIndex = 11;
            this.connectionChanceNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Maze Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Winding Chance (%)";
            // 
            // windingChanceNumeric
            // 
            this.windingChanceNumeric.Location = new System.Drawing.Point(9, 74);
            this.windingChanceNumeric.Name = "windingChanceNumeric";
            this.windingChanceNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.windingChanceNumeric.Size = new System.Drawing.Size(60, 20);
            this.windingChanceNumeric.TabIndex = 8;
            this.windingChanceNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // MazeSizeNumeric
            // 
            this.MazeSizeNumeric.Location = new System.Drawing.Point(6, 35);
            this.MazeSizeNumeric.Name = "MazeSizeNumeric";
            this.MazeSizeNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MazeSizeNumeric.Size = new System.Drawing.Size(174, 20);
            this.MazeSizeNumeric.TabIndex = 2;
            this.MazeSizeNumeric.Value = new decimal(new int[] {
            29,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.roomBuildAttemptsNumeric);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.roomMaxSizeNumeric);
            this.groupBox3.Controls.Add(this.roomMinSizeNumeric);
            this.groupBox3.Location = new System.Drawing.Point(506, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 117);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Room Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Room Build Attempts";
            // 
            // roomBuildAttemptsNumeric
            // 
            this.roomBuildAttemptsNumeric.Location = new System.Drawing.Point(20, 78);
            this.roomBuildAttemptsNumeric.Name = "roomBuildAttemptsNumeric";
            this.roomBuildAttemptsNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roomBuildAttemptsNumeric.Size = new System.Drawing.Size(160, 20);
            this.roomBuildAttemptsNumeric.TabIndex = 6;
            this.roomBuildAttemptsNumeric.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min Size";
            // 
            // roomMaxSizeNumeric
            // 
            this.roomMaxSizeNumeric.Location = new System.Drawing.Point(120, 37);
            this.roomMaxSizeNumeric.Name = "roomMaxSizeNumeric";
            this.roomMaxSizeNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roomMaxSizeNumeric.Size = new System.Drawing.Size(60, 20);
            this.roomMaxSizeNumeric.TabIndex = 3;
            this.roomMaxSizeNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // roomMinSizeNumeric
            // 
            this.roomMinSizeNumeric.Location = new System.Drawing.Point(20, 37);
            this.roomMinSizeNumeric.Name = "roomMinSizeNumeric";
            this.roomMinSizeNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roomMinSizeNumeric.Size = new System.Drawing.Size(60, 20);
            this.roomMinSizeNumeric.TabIndex = 2;
            this.roomMinSizeNumeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.Picture_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 501);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GenerateButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Picture_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.BoxSizeNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionChanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windingChanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazeSizeNumeric)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomBuildAttemptsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomMaxSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomMinSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.NumericUpDown BoxSizeNumeric;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown MazeSizeNumeric;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown roomMaxSizeNumeric;
        private System.Windows.Forms.NumericUpDown roomMinSizeNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown roomBuildAttemptsNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown windingChanceNumeric;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox deadEndsCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown connectionChanceNumeric;
    }
}

