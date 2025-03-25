using System;

public enum CategorieMedicament
{
    Analgezic = 1,
    Antibiotic = 2,
    Antiinflamator = 3,
    Vitamine = 4,
    Antialergic = 5
}
public class Medicament
{
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
    public string RetetaNecesara { get; set; } // Changed to string

    // Constructor fara parametri
    public Medicament() { }

    // Constructor cu parametri
    public Medicament(string denumire, string producator, double pret, int stoc, string retetaNecesara)
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
        var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
        Denumire = date[DENUMIRE];
        Producator = date[PRODUCATOR];
        Pret = Convert.ToDouble(date[PRET]);
        Stoc = Convert.ToInt32(date[STOC]);
        RetetaNecesara = date[RETETA_NECESARA];
    }

    //Metodă pentru afișarea informațiilor
    public string Info()
    {
        return $"{Denumire} {Producator} {Pret} {Stoc} {RetetaNecesara}";
    }

    //Metodă pentru conversie la format fișier.Creează un string formatat pentru salvarea medicamentului într-un fișier.
    public string ConversieLaSir_PentruFisier()
    {
        return $"{Denumire}{SEPARATOR_PRINCIPAL_FISIER}{Producator}{SEPARATOR_PRINCIPAL_FISIER}{Pret}{SEPARATOR_PRINCIPAL_FISIER}{Stoc}{SEPARATOR_PRINCIPAL_FISIER}{RetetaNecesara}";
    }
}
