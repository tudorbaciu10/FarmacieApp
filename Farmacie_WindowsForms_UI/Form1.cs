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
        private const int NR_MAX_CARACTERE = 15;

        private Label lblDenumire;
        private Label lblProducator;
        private Label lblPret;
        private Label lblStoc;
        private Label lblRetetaNecesara;
        private Label lblCategorie;
        private Label lblOptiuni;

        private Label eroareDenumire;
        private Label eroareProducator;
        private Label eroarePret;
        private Label eroareStoc;
        private Label eroareRetetaNecesara;
        private Label eroareCategorie;
        private Label eroareOptiuni;

        private TextBox txtDenumire;
        private TextBox txtProducator;
        private TextBox txtPret;
        private TextBox txtStoc;
        private TextBox txtRetetaNecesara;
        private TextBox txtCategorie;
        private TextBox txtOptiuni;

        private Button buttonAdauga;
        private Button buttonRefresh;

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

            // Adăugare controale pentru fiecare câmp
            lblDenumire = new Label();
            lblDenumire.Width = LATIME_CONTROL;
            lblDenumire.Text = "Denumire";
            lblDenumire.Left = DIMENSIUNE_PAS_X;
            lblDenumire.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblDenumire);

            txtDenumire = new TextBox();
            txtDenumire.Width = LATIME_CONTROL;
            txtDenumire.Left = DIMENSIUNE_PAS_X;
            txtDenumire.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtDenumire);

            eroareDenumire = new Label();
            eroareDenumire.Width = LATIME_CONTROL;
            eroareDenumire.Left = DIMENSIUNE_PAS_X;
            eroareDenumire.Top = 2 * DIMENSIUNE_PAS_Y;
            eroareDenumire.ForeColor = Color.Red;
                
            this.Controls.Add(eroareDenumire);

            lblProducator = new Label();
            lblProducator.Width = LATIME_CONTROL;
            lblProducator.Text = "Producator";
            lblProducator.Left = 2 * DIMENSIUNE_PAS_X;
            lblProducator.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblProducator);

            txtProducator = new TextBox();
            txtProducator.Width = LATIME_CONTROL;
            txtProducator.Left = 2 * DIMENSIUNE_PAS_X;
            txtProducator.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtProducator);

            eroareProducator = new Label();
            eroareProducator.Width = LATIME_CONTROL;
            eroareProducator.Left = 2 * DIMENSIUNE_PAS_X;
            eroareProducator.Top = 2 * DIMENSIUNE_PAS_Y;
            eroareProducator.ForeColor = Color.Red;
            this.Controls.Add(eroareProducator);

            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret";
            lblPret.Left = 3 * DIMENSIUNE_PAS_X;
            lblPret.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblPret);

            txtPret = new TextBox();
            txtPret.Width = LATIME_CONTROL;
            txtPret.Left = 3 * DIMENSIUNE_PAS_X;
            txtPret.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtPret);

            eroarePret = new Label();
            eroarePret.Width = LATIME_CONTROL;
            eroarePret.Left = 3 * DIMENSIUNE_PAS_X;
            eroarePret.Top = 2 * DIMENSIUNE_PAS_Y;
            eroarePret.ForeColor = Color.Red;
            this.Controls.Add(eroarePret);

            lblStoc = new Label();
            lblStoc.Width = LATIME_CONTROL;
            lblStoc.Text = "Stoc";
            lblStoc.Left = 4 * DIMENSIUNE_PAS_X;
            lblStoc.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblStoc);

            txtStoc = new TextBox();
            txtStoc.Width = LATIME_CONTROL;
            txtStoc.Left = 4 * DIMENSIUNE_PAS_X;
            txtStoc.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtStoc);

            eroareStoc = new Label();
            eroareStoc.Width = LATIME_CONTROL;
            eroareStoc.Left = 4 * DIMENSIUNE_PAS_X;
            eroareStoc.Top = 2 * DIMENSIUNE_PAS_Y;
            eroareStoc.ForeColor = Color.Red;
            this.Controls.Add(eroareStoc);

            lblRetetaNecesara = new Label();
            lblRetetaNecesara.Width = LATIME_CONTROL;
            lblRetetaNecesara.Text = "Reteta Necesara";
            lblRetetaNecesara.Left = 5 * DIMENSIUNE_PAS_X;
            lblRetetaNecesara.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblRetetaNecesara);

            txtRetetaNecesara = new TextBox();
            txtRetetaNecesara.Width = LATIME_CONTROL;
            txtRetetaNecesara.Left = 5 * DIMENSIUNE_PAS_X;
            txtRetetaNecesara.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtRetetaNecesara);

            eroareRetetaNecesara = new Label();
            eroareRetetaNecesara.Width = LATIME_CONTROL;
            eroareRetetaNecesara.Left = 5 * DIMENSIUNE_PAS_X;
            eroareRetetaNecesara.Top = 2 * DIMENSIUNE_PAS_Y;
            eroareRetetaNecesara.ForeColor = Color.Red;
            this.Controls.Add(eroareRetetaNecesara);

            lblCategorie = new Label();
            lblCategorie.Width = LATIME_CONTROL;
            lblCategorie.Text = "Categorie";
            lblCategorie.Left = 6 * DIMENSIUNE_PAS_X;
            lblCategorie.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblCategorie);

            txtCategorie = new TextBox();
            txtCategorie.Width = LATIME_CONTROL;
            txtCategorie.Left = 6 * DIMENSIUNE_PAS_X;
            txtCategorie.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtCategorie);

            eroareCategorie = new Label();
            eroareCategorie.Width = LATIME_CONTROL;
            eroareCategorie.Left = 6 * DIMENSIUNE_PAS_X;
            eroareCategorie.Top = 2 * DIMENSIUNE_PAS_Y;
            eroareCategorie.ForeColor = Color.Red;
            this.Controls.Add(eroareCategorie);

            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = 7 * DIMENSIUNE_PAS_X;
            lblOptiuni.ForeColor = Color.OrangeRed;
            this.Controls.Add(lblOptiuni);

            txtOptiuni = new TextBox();
            txtOptiuni.Width = LATIME_CONTROL;
            txtOptiuni.Left = 7 * DIMENSIUNE_PAS_X;
            txtOptiuni.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtOptiuni);

            eroareOptiuni = new Label();
            eroareOptiuni.Width = LATIME_CONTROL;
            eroareOptiuni.Left = 7 * DIMENSIUNE_PAS_X;
            eroareOptiuni.Top = 2 * DIMENSIUNE_PAS_Y;
            eroareOptiuni.ForeColor = Color.Red;
            this.Controls.Add(eroareOptiuni);

            // Adăugare butoane
            buttonAdauga = new Button();
            buttonAdauga.Width = LATIME_CONTROL;
            buttonAdauga.Location = new Point(0, DIMENSIUNE_PAS_Y);
            buttonAdauga.Text = "Adauga Medicament";
            buttonAdauga.Click += OnButtonAdaugaClicked;
            this.Controls.Add(buttonAdauga);

            buttonRefresh = new Button();
            buttonRefresh.Width = LATIME_CONTROL;
            buttonRefresh.Location = new Point(0, 2 * DIMENSIUNE_PAS_Y);
            buttonRefresh.Text = "Refresh";
            buttonRefresh.Click += OnButtonRefreshClicked;
            this.Controls.Add(buttonRefresh);

            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaMedicamente();
        }

        private void OnButtonAdaugaClicked(object sender, EventArgs e)
        {
            ResetErrors();

            if (!Prevalidare() && !Validare())
            {
                string denumire = txtDenumire.Text;
                string producator = txtProducator.Text;
                double pret = double.Parse(txtPret.Text);
                int stoc = int.Parse(txtStoc.Text);
                string retetaNecesara = txtRetetaNecesara.Text;
                CategorieMedicament categorie = (CategorieMedicament)Enum.Parse(typeof(CategorieMedicament), txtCategorie.Text);
                OptiuniMedicament optiuni = (OptiuniMedicament)Enum.Parse(typeof(OptiuniMedicament), txtOptiuni.Text);

                Medicament medicament = new Medicament(denumire, producator, pret, stoc, retetaNecesara, categorie, optiuni);
                adminMedicamente.AddMedicament(medicament);

                MessageBox.Show("Medicamentul a fost adaugat cu succes!");
            }
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
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

        private void ResetErrors()
        {
            eroareDenumire.Text = "";
            eroareProducator.Text = "";
            eroarePret.Text = "";
            eroareStoc.Text = "";
            eroareRetetaNecesara.Text = "";
            eroareCategorie.Text = "";
            eroareOptiuni.Text = "";
        }

        private bool Prevalidare()
        {
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(txtDenumire.Text))
            {
                eroareDenumire.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtProducator.Text))
            {
                eroareProducator.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtPret.Text))
            {
                eroarePret.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtStoc.Text))
            {
                eroareStoc.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtRetetaNecesara.Text))
            {
                eroareRetetaNecesara.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtCategorie.Text))
            {
                eroareCategorie.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtOptiuni.Text))
            {
                eroareOptiuni.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            return hasErrors;
        }

        private bool Validare()
        {
            bool hasErrors = false;

            if (txtDenumire.Text.Length > NR_MAX_CARACTERE)
            {
                eroareDenumire.Text = $"Nr. max {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtProducator.Text.Length > NR_MAX_CARACTERE)
            {
                eroareProducator.Text = $"Nr. max {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (!double.TryParse(txtPret.Text, out _))
            {
                eroarePret.Text = "Trebuie sa fie un numar real!";
                hasErrors = true;
            }

            if (!int.TryParse(txtStoc.Text, out _))
            {
                eroareStoc.Text = "Trebuie sa fie un numar intreg!";
                hasErrors = true;
            }

            return hasErrors;
        }
    }
}
