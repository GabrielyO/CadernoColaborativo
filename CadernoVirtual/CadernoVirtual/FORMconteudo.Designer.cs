namespace CadernoVirtual
{
    partial class FORMconteudo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORMconteudo));
            this.txtC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtC
            // 
            this.txtC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.txtC.CausesValidation = false;
            this.txtC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtC.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.ForeColor = System.Drawing.SystemColors.Info;
            this.txtC.Location = new System.Drawing.Point(0, 0);
            this.txtC.MaxLength = 50000;
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.ReadOnly = true;
            this.txtC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC.Size = new System.Drawing.Size(587, 386);
            this.txtC.TabIndex = 0;
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FORMconteudo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(587, 386);
            this.Controls.Add(this.txtC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORMconteudo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conteúdo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtC;
    }
}