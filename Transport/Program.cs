using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transport.models;

namespace Transport
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    static class ConstantLinks
    {
        public static string domain = "http://localhost:8000/api";
        public static string token;
        public static User user;
        public static List<Post> posts = new List<Post>();

        public static string authorization = "/login";
    }
}
