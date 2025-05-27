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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Farmacie_WindowsForms_UI
{
    public partial class FormaCautare: Form
    {
        private GestionareMedicamente_FisierText adminMedicamente;
        public FormaCautare()
        {
            this.MinimizeBox = false;
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMedicamente = new GestionareMedicamente_FisierText(caleCompletaFisier);

        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDenumire.Text))
            {
                Medicament[] medicamenteGasite = adminMedicamente.CautareToateDupaDenumire(txtDenumire.Text);

                if (medicamenteGasite.Length > 0)
                {
                    string rezultat = "Medicamente gasite:\n\n";
                    foreach (var medicament in medicamenteGasite)
                    {
                        rezultat += medicament.Info() + "\n\n";
                    }
                    MessageBox.Show(rezultat, "Medicamente gasite");
                }
                else
                {
                    MessageBox.Show("Nu s-au gasit medicamente cu denumirea specificata.");
                }
            }
            else
            {
                MessageBox.Show("Introduceti o denumire valida.");
            }
        }
    }
}
