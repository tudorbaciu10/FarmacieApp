using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacie_WindowsForms_UI
{
    public partial class FormaAdaugare: Form
    {
        private GestionareMedicamente_FisierText adminMedicamente;

        
        private const int NR_MAX_CARACTERE = 15;
        public FormaAdaugare()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMedicamente = new GestionareMedicamente_FisierText(caleCompletaFisier);

            InitializeComponent();
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
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
        private void ResetErrors()
        {
            lbleroareDenumire.Text = "";
            lbleroareProducator.Text = "";
            lbleroarePret.Text = "";
            lbleroareStoc.Text = "";
            lbleroareRetetaNecesara.Text = "";
            lbleroareCategorie.Text = "";
            lbleroareOptiuni.Text = "";
        }

        private bool Prevalidare()
        {
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(txtDenumire.Text))
            {
                lbleroareDenumire.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtProducator.Text))
            {
                lbleroareProducator.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtPret.Text))
            {
                lbleroarePret.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtStoc.Text))
            {
                lbleroareStoc.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtRetetaNecesara.Text))
            {
                lbleroareRetetaNecesara.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtCategorie.Text))
            {
                lbleroareCategorie.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtOptiuni.Text))
            {
                lbleroareOptiuni.Text = "Nu poate fi gol!";
                hasErrors = true;
            }

            return hasErrors;
        }

        private bool Validare()
        {
            bool hasErrors = false;

            if (txtDenumire.Text.Length > NR_MAX_CARACTERE)
            {
                lbleroareDenumire.Text = $"Nr. max {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtProducator.Text.Length > NR_MAX_CARACTERE)
            {
                lbleroareProducator.Text = $"Nr. max {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (!double.TryParse(txtPret.Text, out _))
            {
                lbleroarePret.Text = "Trebuie sa fie un numar real!";
                hasErrors = true;
            }

            if (!int.TryParse(txtStoc.Text, out _))
            {
                lbleroareStoc.Text = "Trebuie sa fie un numar intreg!";
                hasErrors = true;
            }

            return hasErrors;
        }
    }
}

