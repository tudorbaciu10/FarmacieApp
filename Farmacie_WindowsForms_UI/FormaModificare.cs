﻿using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections;
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
    public partial class gpbOpt: Form
    {
        private GestionareMedicamente_FisierText adminMedicamente;
        private OptiuniMedicament optiuniSelectate = OptiuniMedicament.Niciuna;
        private string denumireOriginala;

        private const int NR_MAX_CARACTERE = 15;
        public gpbOpt(string denumire)
        {
            InitializeComponent(); // Ensure this is the first line
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMedicamente = new GestionareMedicamente_FisierText(caleCompletaFisier);
            denumireOriginala = denumire;
            txtDenumire.Text = denumire.ToString();

            SetareControle();
        }

        private void SetareControle()
        {
            Medicament medicament = adminMedicamente.GetMedicament(txtDenumire.Text);

            if (medicament != null)
            {
                txtProducator.Text = medicament.Producator;
                txtPret.Text = medicament.Pret.ToString();
                txtStoc.Text = medicament.Stoc.ToString();
                txtRetetaNecesara.Text = medicament.RetetaNecesara;

                switch (medicament.Categorie)
                {
                    case CategorieMedicament.Analgezic:
                        rdbAnalgezic.Checked = true;
                        break;
                    case CategorieMedicament.Antibiotic:
                        rdbAntibiotic.Checked = true;
                        break;
                    case CategorieMedicament.Antiinflamator:
                        rdbAntiinflamator.Checked = true;
                        break;
                    case CategorieMedicament.Vitamine:
                        rdbVitamine.Checked = true;
                        break;
                    case CategorieMedicament.Antialergic:
                        rdbAntialergic.Checked = true;
                        break;
                }

                foreach (var opt in gpbOtiuni.Controls)
                {
                    if (opt is CheckBox)
                    {
                        var optiune = opt as CheckBox;
                        if (Enum.TryParse(optiune.Text, out OptiuniMedicament optiuneEnum))
                        {
                            optiune.Checked = (medicament.Optiuni & optiuneEnum) == optiuneEnum;
                        }
                    }
                }
            }
        }

        private void CkbOptiuni_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox;
            string optiuneSelectata = checkBoxControl.Text;

            if (Enum.TryParse(optiuneSelectata, out OptiuniMedicament optiune))
            {
                if (checkBoxControl.Checked)
                    optiuniSelectate |= optiune;
                else
                    optiuniSelectate &= ~optiune;
            }
        }

        private CategorieMedicament GetCategorieSelectat()
        {
            if (rdbAnalgezic.Checked)
                return CategorieMedicament.Analgezic;
            else if (rdbAntialergic.Checked)
                return CategorieMedicament.Antialergic;
            else if (rdbAntibiotic.Checked)
                return CategorieMedicament.Antibiotic;
            else if (rdbAntiinflamator.Checked)
                return CategorieMedicament.Antiinflamator;
            else if (rdbVitamine.Checked)
                return CategorieMedicament.Vitamine;
            else
                return CategorieMedicament.Analgezic;
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

                CategorieMedicament categorie = GetCategorieSelectat();

                Medicament medicament = new Medicament(denumire, producator, pret, stoc, retetaNecesara, categorie, optiuniSelectate);
                adminMedicamente.UpdateMedicament(medicament, denumireOriginala);

                MessageBox.Show("Medicamentul a fost modificat cu succes!!!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
