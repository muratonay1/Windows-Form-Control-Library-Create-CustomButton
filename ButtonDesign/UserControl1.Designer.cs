namespace ButtonDesign
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.muratButton1 = new ButtonDesign.MuratButton();
            this.SuspendLayout();
            // 
            // muratButton1
            // 
            this.muratButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.muratButton1.ClickEventSize = 10;
            this.muratButton1.Font = new System.Drawing.Font("Rajdhani", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.muratButton1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.muratButton1.Location = new System.Drawing.Point(253, 135);
            this.muratButton1.MouseDownBackcolor = System.Drawing.Color.Red;
            this.muratButton1.Name = "muratButton1";
            this.muratButton1.RandomChangeTextColor = false;
            this.muratButton1.RandomColorChange = 10;
            this.muratButton1.Size = new System.Drawing.Size(284, 136);
            this.muratButton1.TabIndex = 0;
            this.muratButton1.Text = "muratButton1";
            this.muratButton1.UseVisualStyleBackColor = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.muratButton1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private MuratButton muratButton1;
    }
}
