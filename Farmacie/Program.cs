using System;
using LibrarieModele;
using NivelStocareDate;

namespace FirmaFarmacie
{
    class Program
    {
        static void Main()
        {
            // Create memory-based storage for Medicaments
            GestionareMedicamente_Memorie gestiuneMedicamente = new GestionareMedicamente_Memorie();

            Medicament medicamentNou = new Medicament();
            int nrMedicamente = 0;

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii medicament de la tastatura");
                Console.WriteLine("I. Afisarea informatiilor despre ultimul medicament introdus");
                Console.WriteLine("A. Afisare medicamente");
                Console.WriteLine("S. Salvare medicament in memorie");
                Console.WriteLine("F. Cautare medicament dupa denumire");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        medicamentNou = CitireMedicamentTastatura();
                        break;

                    case "I":
                        AfisareMedicament(medicamentNou);
                        break;

                    case "A":
                        Medicament[] medicamente = gestiuneMedicamente.GetMedicamente(out nrMedicamente);
                        AfisareMedicamente(medicamente, nrMedicamente);
                        break;

                    case "S":
                        gestiuneMedicamente.AddMedicament(medicamentNou);
                        break;

                    case "F":
                        Console.WriteLine("Introduceti denumirea medicamentului cautat:");
                        string denumireCautata = Console.ReadLine();
                        Medicament medicamentCautat = CautareMedicamentDupaDenumire(gestiuneMedicamente, denumireCautata);
                        if (medicamentCautat != null)
                        {
                            Console.WriteLine("Medicamentul a fost gasit:");
                            AfisareMedicament(medicamentCautat);
                        }
                        else
                        {
                            Console.WriteLine($"Medicamentul cu denumirea {denumireCautata} nu a fost gasit.");
                        }
                        break;

                    case "X":
                        return;

                    default:
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static Medicament CitireMedicamentTastatura()
        {
            Console.WriteLine("Introduceti denumirea medicamentului: ");
            string denumire = Console.ReadLine();

            Console.WriteLine("Introduceti producatorul: ");
            string producator = Console.ReadLine();

            Console.WriteLine("Introduceti pretul medicamentului: ");
            double pret = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti stocul medicamentului: ");
            int stoc = int.Parse(Console.ReadLine());

            Console.WriteLine("Este necesara reteta? (true/false): ");
            bool retetaNecesara = bool.Parse(Console.ReadLine());

            Medicament medicament = new Medicament(denumire, producator, pret, stoc, retetaNecesara);
            return medicament;
        }

        public static void AfisareMedicament(Medicament medicament)
        {
            string infoMedicament = string.Format("\nMedicamentul '{0}' are următoarele detalii:\n"
                                                  + "Producător: {1}\n"
                                                  + "Preț: {2} RON\n"
                                                  + "Stoc: {3}\n"
                                                  + "Rețetă necesară: {4}\n",
                                                  medicament.Denumire,
                                                  medicament.Producator,
                                                  medicament.Pret,
                                                  medicament.Stoc,
                                                  medicament.RetetaNecesara ? "Da" : "Nu");

            Console.WriteLine(infoMedicament);
        }

        public static void AfisareMedicamente(Medicament[] medicamente, int nrMedicamente)
        {
            Console.WriteLine("Medicamentele disponibile sunt:");
            for (int i = 0; i < nrMedicamente; i++)
            {
                AfisareMedicament(medicamente[i]);
            }
        }

        public static Medicament CautareMedicamentDupaDenumire(GestionareMedicamente_Memorie gestiune, string denumire)
        {
            int nrMedicamente;
            Medicament[] medicamente = gestiune.GetMedicamente(out nrMedicamente);
            foreach (var medicament in medicamente)
            {
                if (medicament != null && medicament.Denumire.Equals(denumire, StringComparison.OrdinalIgnoreCase))
                {
                    return medicament;
                }
            }
            return null;  // Return null if no medicament found
        }
    }
}
