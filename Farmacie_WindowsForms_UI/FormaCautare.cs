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
                Medicament medicamentGasit = adminMedicamente.CautareDupaDenumire(txtDenumire.Text);

                if (medicamentGasit != null)
                {

                    MessageBox.Show(medicamentGasit.Info(), "Medicament gasit");
                }
                else
                {
                    MessageBox.Show("Medicamentul cu denumirea specificata nu a fost gasit.");
                }
            }
            else
            {
                MessageBox.Show("Introduceti o descriere valida.");
            }
        }
    }
}
