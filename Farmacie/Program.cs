using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace FirmaFarmacie
{
    class Program
    {
        static void Main()
        {
            // Get the file name from the configuration settings
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            GestionareMedicamente_FisierText gestiuneFisier = new GestionareMedicamente_FisierText(numeFisier);
            Medicament medicamentNou = new Medicament();
            int nrMedicamente = 0;

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii medicament de la tastatura");
                Console.WriteLine("I. Afisarea informatiilor despre ultimul medicament introdus");
                Console.WriteLine("A. Afisare medicamente din fisier");
                Console.WriteLine("S. Salvare medicament in fisier");
                Console.WriteLine("F. Cautare medicament ");
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
                        Medicament[] medicamente = gestiuneFisier.GetMedicamente(out nrMedicamente);
                        AfisareMedicamente(medicamente, nrMedicamente);
                        break;

                    case "S":
                        gestiuneFisier.AddMedicament(medicamentNou);
                        break;

                    case "F":
                        string optiuneCautare;
                        do
                        {
                            Console.WriteLine("Cautare dupa: ");
                            Console.WriteLine("1. Denumire medicament");
                            Console.WriteLine("2. Producator");
                            optiuneCautare = Console.ReadLine();
                            switch (optiuneCautare)
                            {
                                case "1":
                                    Console.WriteLine("Introduceti denumirea medicamentului cautat: ");
                                    string denumire = Console.ReadLine();
                                    Medicament medicamentCautatDenumire = gestiuneFisier.CautareDupaDenumire(denumire);
                                    if (medicamentCautatDenumire != null)
                                    {
                                        Console.WriteLine("Medicamentul a fost gasit: ");
                                        AfisareMedicament(medicamentCautatDenumire);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Medicamentul cu denumirea {denumire} nu a fost gasit.\n");
                                    }
                                    break;

                                case "2":
                                    Console.WriteLine("Introduceti producatorul cautat: ");
                                    string producator = Console.ReadLine();
                                    Medicament medicamentCautatProducator = gestiuneFisier.CautareDupaProducator(producator);
                                    if (medicamentCautatProducator != null)
                                    {
                                        Console.WriteLine("Medicamentul a fost gasit: ");
                                        AfisareMedicament(medicamentCautatProducator);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Medicamentul cu producatorul {producator} nu a fost gasit.\n");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Optiune invalida");
                                    break;
                            }
                        } while (optiuneCautare != "1" && optiuneCautare != "2");
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

        // Function to read a new Medicament from keyboard input
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

        // Function to display a single Medicament's information
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

        // Function to display all Medicaments
        public static void AfisareMedicamente(Medicament[] medicamente, int nrMedicamente)
        {
            Console.WriteLine("Medicamentele disponibile sunt:");
            for (int i = 0; i < nrMedicamente; i++)
            {
                AfisareMedicament(medicamente[i]);
            }
        }
    }
}
