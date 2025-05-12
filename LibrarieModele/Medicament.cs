using System;
using System.Collections;

namespace LibrarieModele
{
    public class Medicament
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ',';
        private const int DENUMIRE = 0;
        private const int PRODUCATOR = 1;
        private const int PRET = 2;
        private const int STOC = 3;
        private const int RETETA_NECESARA = 4;
        private const int CATEGORIE = 5;
        private const int OPTIUNI = 6;

        public string Denumire { get; set; }
        public string Producator { get; set; }
        public double Pret { get; set; }
        public int Stoc { get; set; }
        public string RetetaNecesara { get; set; }
        public CategorieMedicament Categorie { get; set; }
        public ArrayList Optiuni { get; set; }

        public string OptiuniAsString
        {
            get
            {
                return string.Join(SEPARATOR_SECUNDAR_FISIER.ToString(), Optiuni.ToArray());
            }
        }

        // Constructor fără parametri
        public Medicament()
        {
            Optiuni = new ArrayList();
        }

        // Constructor cu parametri
        public Medicament(string denumire, string producator, double pret, int stoc, string retetaNecesara, CategorieMedicament categorie, ArrayList optiuni)
        {
            Denumire = denumire;
            Producator = producator;
            Pret = pret;
            Stoc = stoc;
            RetetaNecesara = retetaNecesara;
            Categorie = categorie;
            Optiuni = optiuni ?? new ArrayList();
        }

        // Constructor pentru citirea din fișier
        public Medicament(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            Denumire = date[DENUMIRE];
            Producator = date[PRODUCATOR];
            Pret = Convert.ToDouble(date[PRET]);
            Stoc = Convert.ToInt32(date[STOC]);
            RetetaNecesara = date[RETETA_NECESARA];
            Categorie = (CategorieMedicament)Enum.Parse(typeof(CategorieMedicament), date[CATEGORIE]);
            Optiuni = new ArrayList();
            if (!string.IsNullOrWhiteSpace(date[OPTIUNI]))
                Optiuni.AddRange(date[OPTIUNI].Split(SEPARATOR_SECUNDAR_FISIER));
        }

        public string Info()
        {
            return $"{Denumire} {Producator} {Pret} RON {Stoc} buc. Reteta: {RetetaNecesara} Categorie: {Categorie} Optiuni: {OptiuniAsString}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return $"{Denumire}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{Producator}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{Pret}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{Stoc}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{RetetaNecesara}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{Categorie}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{OptiuniAsString}";
        }
    }
}
