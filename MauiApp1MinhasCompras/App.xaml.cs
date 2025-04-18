﻿using MauiApp1MinhasCompras.Helpers;

namespace MauiApp1MinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper? _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compra,db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-Br");

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }

        
    }
}