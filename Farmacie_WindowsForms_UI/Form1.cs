using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace Farmacie_WindowsForms_UI
{
    public partial class Form1 : Form
    {
        private GestionareMedicamente_FisierText adminMedicamente;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 40;
        private const int DIMENSIUNE_PAS_X = 160;

        

        public Form1()
        {
            InitializeComponent();

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMedicamente = new GestionareMedicamente_FisierText(caleCompletaFisier);

            // Setare proprietăți formular
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Brown;
            this.Text = "Informatii medicamente";

            

            

            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaMedicamente();
        }

        

        

        private void AfiseazaMedicamente()
        {
            Medicament[] medicamente = adminMedicamente.GetMedicamente(out int nrMedicamente);

            for (int i = 0; i < nrMedicamente; i++)
            {
                Medicament medicament = medicamente[i];

                // Display Denumire
                Label lblDenumire = new Label();
                lblDenumire.Width = LATIME_CONTROL;
                lblDenumire.Text = medicament.Denumire;
                lblDenumire.Left = DIMENSIUNE_PAS_X;
                lblDenumire.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblDenumire);

                // Display Producator
                Label lblProducator = new Label();
                lblProducator.Width = LATIME_CONTROL;
                lblProducator.Text = medicament.Producator;
                lblProducator.Left = 2 * DIMENSIUNE_PAS_X;
                lblProducator.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblProducator);

                // Display Pret
                Label lblPret = new Label();
                lblPret.Width = LATIME_CONTROL;
                lblPret.Text = medicament.Pret.ToString("F2"); // Format as a decimal with 2 places
                lblPret.Left = 3 * DIMENSIUNE_PAS_X;
                lblPret.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblPret);

                // Display Stoc
                Label lblStoc = new Label();
                lblStoc.Width = LATIME_CONTROL;
                lblStoc.Text = medicament.Stoc.ToString();
                lblStoc.Left = 4 * DIMENSIUNE_PAS_X;
                lblStoc.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblStoc);

                // Display Reteta Necesara
                Label lblRetetaNecesara = new Label();
                lblRetetaNecesara.Width = LATIME_CONTROL;
                lblRetetaNecesara.Text = medicament.RetetaNecesara;
                lblRetetaNecesara.Left = 5 * DIMENSIUNE_PAS_X;
                lblRetetaNecesara.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblRetetaNecesara);

                // Display Categorie
                Label lblCategorie = new Label();
                lblCategorie.Width = LATIME_CONTROL;
                lblCategorie.Text = medicament.Categorie.ToString();
                lblCategorie.Left = 6 * DIMENSIUNE_PAS_X;
                lblCategorie.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblCategorie);

                // Display Optiuni
                Label lblOptiuni = new Label();
                lblOptiuni.Width = LATIME_CONTROL;
                lblOptiuni.Text = medicament.Optiuni.ToString();
                lblOptiuni.Left = 7 * DIMENSIUNE_PAS_X;
                lblOptiuni.Top = (i + 3) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblOptiuni);
            }
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            FormaAdaugare formaAdaugare = new FormaAdaugare();
            formaAdaugare.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaMedicamente();
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            FormaCautare formaCautare = new FormaCautare();
            formaCautare.ShowDialog();
        }
    }
}
