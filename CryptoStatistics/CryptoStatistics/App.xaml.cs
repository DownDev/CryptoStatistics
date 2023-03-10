using CryptoStatistics.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Poppins-SemiBold.ttf", Alias = "Poppins")]

namespace CryptoStatistics
{
    public partial class App : Application
    {
        private static CryptoData database;

        public static CryptoData Database
        {
            get
            {
                if(database == null)
                {
                    database = new CryptoData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CryptoDb.db3"));
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

