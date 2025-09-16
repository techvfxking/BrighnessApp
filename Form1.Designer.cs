namespace BrighnessApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBarBrightness = new TrackBar();
            labelValue = new Label();
            buttonApply = new Button();
            trackBarContrast = new TrackBar();
            labelContrast = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).BeginInit();
            SuspendLayout();
            // 
            // trackBarBrightness
            // 
            trackBarBrightness.Location = new Point(12, 12);
            trackBarBrightness.Maximum = 100;
            trackBarBrightness.Name = "trackBarBrightness";
            trackBarBrightness.Size = new Size(456, 45);
            trackBarBrightness.TabIndex = 0;
            // 
            // labelValue
            // 
            labelValue.AutoSize = true;
            labelValue.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelValue.Location = new Point(166, 60);
            labelValue.Name = "labelValue";
            labelValue.Size = new Size(135, 25);
            labelValue.TabIndex = 1;
            labelValue.Text = "Brightness: 0%";
            // 
            // trackBarContrast
            // 
            trackBarContrast.Location = new Point(12, 110);
            trackBarContrast.Maximum = 100;
            trackBarContrast.Name = "trackBarContrast";
            trackBarContrast.Size = new Size(456, 45);
            trackBarContrast.TabIndex = 3;
            // 
            // labelContrast
            // 
            labelContrast.AutoSize = true;
            labelContrast.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelContrast.Location = new Point(166, 158);
            labelContrast.Name = "labelContrast";
            labelContrast.Size = new Size(120, 25);
            labelContrast.TabIndex = 4;
            labelContrast.Text = "Contrast: 0%";
            // 
            // buttonApply
            // 
            buttonApply.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonApply.Location = new Point(165, 215);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(136, 51);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 307);
            Controls.Add(labelContrast);
            Controls.Add(trackBarContrast);
            Controls.Add(buttonApply);
            Controls.Add(labelValue);
            Controls.Add(trackBarBrightness);
            Name = "Form1";
            Text = "Monitor Brightness & Contrast App";
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBarBrightness;
        private Label labelValue;
        private Button buttonApply;
        private TrackBar trackBarContrast;
        private Label labelContrast;
    }
}
