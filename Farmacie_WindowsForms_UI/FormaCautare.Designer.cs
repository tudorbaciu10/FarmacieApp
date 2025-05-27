namespace Farmacie_WindowsForms_UI
{
    partial class FormaCautare
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
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.lblDenumire = new System.Windows.Forms.Label();
            this.btnCautare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDenumire
            // 
            this.txtDenumire.Location = new System.Drawing.Point(65, 77);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(413, 22);
            this.txtDenumire.TabIndex = 9;
            // 
            // lblDenumire
            // 
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(240, 34);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(65, 16);
            this.lblDenumire.TabIndex = 8;
            this.lblDenumire.Text = "Denumire";
            // 
            // btnCautare
            // 
            this.btnCautare.Location = new System.Drawing.Point(65, 140);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(413, 23);
            this.btnCautare.TabIndex = 10;
            this.btnCautare.Text = "Cautare";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // FormaCautare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 221);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.txtDenumire);
            this.Controls.Add(this.lblDenumire);
            this.Name = "FormaCautare";
            this.Text = "FormaCautare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.Label lblDenumire;
        private System.Windows.Forms.Button btnCautare;
    }
}