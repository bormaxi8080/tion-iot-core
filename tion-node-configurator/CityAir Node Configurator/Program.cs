using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityAir_Node_Configurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogoForm logoForm = new LogoForm();

            logoForm.BackColor = System.Drawing.Color.Fuchsia;
            logoForm.TransparencyKey = System.Drawing.Color.Fuchsia;
            logoForm.Opacity = 0;

            logoForm.Show();

            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(5);
                logoForm.Opacity += 0.01;
            }

            System.Threading.Thread.Sleep(1500);

            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(5);
                logoForm.Opacity -= 0.01;
            }

            logoForm.Hide();

            Application.Run(new ConfiguratorForm());
        }
    }
}
