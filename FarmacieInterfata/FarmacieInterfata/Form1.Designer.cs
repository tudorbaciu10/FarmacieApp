namespace FarmacieInterfata
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
            this.dataGridViewMedicamente = new System.Windows.Forms.DataGridView();
            this.btnIncarca = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicamente)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMedicamente
            // 
            this.dataGridViewMedicamente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMedicamente.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewMedicamente.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMedicamente.Name = "dataGridViewMedicamente";
            this.dataGridViewMedicamente.Size = new System.Drawing.Size(800, 300);
            this.dataGridViewMedicamente.TabIndex = 0;
            // 
            // btnIncarca
            // 
            // 
            // FormMedicamente

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMedicamente;
        private System.Windows.Forms.Button btnIncarca;
    }
}
