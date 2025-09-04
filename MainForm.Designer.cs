namespace RevitNanoBanana
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox promptBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label promptLabel;

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

        private void InitializeComponent()
        {
            promptLabel = new Label();
            promptBox = new TextBox();
            processButton = new Button();
            saveButton = new Button();
            pictureBox = new PictureBox();
            label1 = new Label();
            txtApiKey = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // promptLabel
            // 
            promptLabel.AutoSize = true;
            promptLabel.Location = new Point(12, 51);
            promptLabel.Name = "promptLabel";
            promptLabel.Size = new Size(80, 15);
            promptLabel.TabIndex = 0;
            promptLabel.Text = "Enter Prompt:";
            // 
            // promptBox
            // 
            promptBox.Location = new Point(120, 51);
            promptBox.Multiline = true;
            promptBox.Name = "promptBox";
            promptBox.Size = new Size(817, 51);
            promptBox.TabIndex = 1;
            // 
            // processButton
            // 
            processButton.Location = new Point(121, 117);
            processButton.Name = "processButton";
            processButton.Size = new Size(100, 30);
            processButton.TabIndex = 2;
            processButton.Text = "Process";
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += ProcessButton_Click;
            // 
            // saveButton
            // 
            saveButton.Enabled = false;
            saveButton.Location = new Point(241, 117);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 30);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(20, 164);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(940, 625);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 4;
            pictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(375, 13);
            label1.Name = "label1";
            label1.Size = new Size(220, 21);
            label1.TabIndex = 0;
            label1.Text = "Nano Banana - Revit Plugin";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(600, 117);
            txtApiKey.Multiline = true;
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(337, 25);
            txtApiKey.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(552, 123);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "API Key";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 801);
            Controls.Add(pictureBox);
            Controls.Add(saveButton);
            Controls.Add(processButton);
            Controls.Add(txtApiKey);
            Controls.Add(promptBox);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(promptLabel);
            Name = "MainForm";
            Text = "Nano Banana - Revit Plugin";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtApiKey;
        private Label label2;
    }
}