using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Producator
    {
        public string Nume { get; set; }
        public string TaraOrigine { get; set; }
        public string CodFiscal { get; set; }

        // Constructor fara parametri
        public Producator()
        {
            Nume = string.Empty;
            TaraOrigine = string.Empty;
            CodFiscal = string.Empty;
        }

        // Constructor cu parametri
        public Producator(string nume, string taraOrigine, string codFiscal)
        {
            Nume = nume;
            TaraOrigine = taraOrigine;
            CodFiscal = codFiscal;
        }

        //Metodă pentru afișarea informațiilor.Returnează un string formatat cu datele producătorului.
        public string Info()
        {
            return $"Nume: {Nume}, Țara de origine: {TaraOrigine}, Cod fiscal: {CodFiscal}";
        }
    }
}