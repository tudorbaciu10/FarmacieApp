using System;

namespace LibrarieModele
{
    public enum CategorieMedicament
    {
        Analgezic = 1,
        Antibiotic = 2,
        Antiinflamator = 3,
        Vitamine = 4,
        Antialergic = 5
    }

    [Flags]
    public enum OptiuniMedicament
    {
        Niciuna = 0,
        Compensat = 1,
        NecesitaReteta = 2,
        Refrigerat = 4
    }
}
