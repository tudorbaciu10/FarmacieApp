using System;
using System.Windows.Forms;

namespace FarmacieApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMedicamente());  // Deschide formularul medicamente
        }
    }
}
