﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class GestionareMedicamente_FisierText
    {
        private const int NR_MAX_MEDICAMENTE = 100;
        private string numeFisier;

        public GestionareMedicamente_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisier = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisier.Close();
        }

        public void AddMedicament(Medicament medicament)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisier, true))
            {
                streamWriter.WriteLine(medicament.ConversieLaSir_PentruFisier());
            }
        }

        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            Medicament[] medicamente = new Medicament[NR_MAX_MEDICAMENTE];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMedicamente = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicamente[nrMedicamente++] = new Medicament(linieFisier);
                }
            }
            return medicamente;
        }

        public Medicament CautareDupaDenumire(string denumire)
        {
            Medicament[] medicamente = GetMedicamente(out int nrMedicamente);
            foreach (var medicament in medicamente)
            {
                if (medicament != null && medicament.Denumire == denumire)
                {
                    return medicament;
                }
            }
            return null;
        }

        public Medicament CautareDupaProducator(string producator)
        {
            Medicament[] medicamente = GetMedicamente(out int nrMedicamente);
            foreach (var medicament in medicamente)
            {
                if (medicament != null && medicament.Producator == producator)
                {
                    return medicament;
                }
            }
            return null;
        }
    }
}
