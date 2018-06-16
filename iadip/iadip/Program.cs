using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iadip
{
    static class Program
    {
        public static ClusterData DataExample;
        public static int PrimaryParamIndex = 2;
        public static List<int> AdditionalParams;

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

            AdditionalParams = Localization.Instance.GetAdditionalParams();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
