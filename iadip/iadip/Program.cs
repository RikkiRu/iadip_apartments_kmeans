using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iadip
{
    static class Program
    {
        public static ClusterData DataExample;
        public static int PrimaryParamIndex = 1;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Localization.Init();

            DataExample = new ClusterData();

            List<int> p = Localization.Instance.GetLoadedParams();
            foreach (var i in p)
                DataExample.Set(i, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
