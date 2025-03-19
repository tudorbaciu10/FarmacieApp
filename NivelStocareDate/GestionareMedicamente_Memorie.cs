using System;
using System.Collections.Generic;
using LibrarieModele;

namespace NivelStocareDate
{
    public class GestionareMedicamente_Memorie
    {
        private const int NR_MAX_MEDICAMENTE = 100;
        private Medicament[] medicamente;
        private int nrMedicamente;

        public GestionareMedicamente_Memorie()
        {
            medicamente = new Medicament[NR_MAX_MEDICAMENTE];
            nrMedicamente = 0;
        }

        public void AddMedicament(Medicament medicament)
        {
            if (nrMedicamente < NR_MAX_MEDICAMENTE)
            {
                medicamente[nrMedicamente] = medicament;
                nrMedicamente++;
            }
            else
            {
                Console.WriteLine("Numărul maxim de medicamente a fost atins.");
            }
        }

        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            nrMedicamente = this.nrMedicamente;
            return medicamente;
        }
    }
}
