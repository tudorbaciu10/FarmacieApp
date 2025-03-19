using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Medicament
    {
        // Constante pentru delimitarea în fișier
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int DENUMIRE = 0;
        private const int PRODUCATOR = 1;
        private const int PRET = 2;
        private const int STOC = 3;
        private const int RETETA_NECESARA = 4;

        public string Denumire { get; set; }
        public string Producator { get; set; }
        public double Pret { get; set; }
        public int Stoc { get; set; }
        public bool RetetaNecesara { get; set; }

        // Constructor fara parametri
        public Medicament()
        {
            Denumire = string.Empty;
            Producator = string.Empty;
            Pret = 0.0;
            Stoc = 0;
            RetetaNecesara = false;
        }

        // Constructor cu parametri
        public Medicament(string denumire, string producator, double pret, int stoc, bool retetaNecesara)
        {
            Denumire = denumire;
            Producator = producator;
            Pret = pret;
            Stoc = stoc;
            RetetaNecesara = retetaNecesara;
        }

        // Constructor care preia date dintr-o linie de fișier
        public Medicament(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            Denumire = dateFisier[DENUMIRE];
            Producator = dateFisier[PRODUCATOR];
            Pret = double.Parse(dateFisier[PRET]);
            Stoc = int.Parse(dateFisier[STOC]);
            RetetaNecesara = bool.Parse(dateFisier[RETETA_NECESARA]);
        }

        public string Info()
        {
            return $"Denumire: {Denumire}, Producător: {Producator}, Preț: {Pret} RON, Stoc: {Stoc}, Rețetă necesară: {(RetetaNecesara ? "Da" : "Nu")}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER,
                Denumire,
                Producator,
                Pret,
                Stoc,
                RetetaNecesara);
        }
    }
}
