using System;
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
            Array.Resize(ref medicamente, nrMedicamente);
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

        public Medicament GetMedicament(string denumire)
        {
            // Folosește 'using' pentru a închide automat StreamReader
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                // Citește fiecare linie din fișier
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Creează un obiect de tip medicament pe baza liniei citite
                    Medicament medicament = new Medicament(linieFisier);

                    // Verifică dacă ID-ul comenzii corespunde
                    if (medicament.Denumire == denumire)
                        return medicament;
                }
            }

            return null;
        }
        public bool UpdateMedicament(Medicament medicamentActual, string denumireOriginala)
        {
            Medicament[] medicamente = GetMedicamente(out int nrMedicamente);
            bool actualizareCuSucces = false;

            // Găsim indexul medicamentului care trebuie actualizat
            int indexMedicament = -1;
            for (int i = 0; i < nrMedicamente; i++)
            {
                if (medicamente[i].Denumire == denumireOriginala)
                {
                    indexMedicament = i;
                    break;
                }
            }

            if (indexMedicament != -1)
            {
                using (StreamWriter streamWriter = new StreamWriter(numeFisier, false))
                {
                    for (int i = 0; i < nrMedicamente; i++)
                    {
                        if (i == indexMedicament)
                        {
                            streamWriter.WriteLine(medicamentActual.ConversieLaSir_PentruFisier());
                        }
                        else
                        {
                            streamWriter.WriteLine(medicamente[i].ConversieLaSir_PentruFisier());
                        }
                    }
                    actualizareCuSucces = true;
                }
            }
            return actualizareCuSucces;
        }

        public Medicament[] CautareToateDupaDenumire(string denumire)
        {
            Medicament[] medicamente = GetMedicamente(out int nrMedicamente);
            List<Medicament> medicamenteGasite = new List<Medicament>();

            foreach (var medicament in medicamente)
            {
                if (medicament != null && medicament.Denumire == denumire)
                {
                    medicamenteGasite.Add(medicament);
                }
            }

            return medicamenteGasite.ToArray();
        }

        public bool StergeMedicament(string denumire)
        {
            Medicament[] medicamente = GetMedicamente(out int nrMedicamente);
            bool stersCuSucces = false;

            using (StreamWriter streamWriter = new StreamWriter(numeFisier, false))
            {
                for (int i = 0; i < nrMedicamente; i++)
                {
                    if (medicamente[i].Denumire != denumire)
                    {
                        streamWriter.WriteLine(medicamente[i].ConversieLaSir_PentruFisier());
                    }
                    else
                    {
                        stersCuSucces = true;
                    }
                }
            }
            return stersCuSucces;
        }
    }
}