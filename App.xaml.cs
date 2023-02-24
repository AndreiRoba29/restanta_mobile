using System;
using ProgramareRevizie.Data;
using System.IO;

namespace ProgramareRevizie;

public partial class App : Application
{
    static AutoDatabase database;
    public static AutoDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               AutoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ShoppingList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
