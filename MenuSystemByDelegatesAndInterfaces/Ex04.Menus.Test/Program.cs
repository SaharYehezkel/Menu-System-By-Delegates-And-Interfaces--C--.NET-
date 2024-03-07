using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class Program : Interfaces.IMenuSelection
    {
        private const string k_ShowDateStr = "Show Date";
        private const string k_ShowTimeStr = "Show Time";
        private const string k_CountCapitalsStr = "Count Capitals";
        private const string k_ShowVersionStr = "Show Version";
        private const string k_CountCapitalsShowVersionMenuTitle = "Count Capitals and Show Version";
        private const string k_ShowDateTimeMenuTitle = "Show Date and Time";

        public static void Main()
        {
            InterfaceTestCreator();
            DelegatesTestCreator();
        }

        public static void InterfaceTestCreator()
        {
            try
            {
                Ex04.Menus.Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interfaces Main Menu", new Program());
                /// next we add the 2 sub menus.
                mainMenu.AddItem(k_ShowDateTimeMenuTitle, mainMenu.Title, true);
                mainMenu.AddItem(k_CountCapitalsShowVersionMenuTitle, mainMenu.Title, true);
                /// next add the leaves that start an action.
                mainMenu.AddItem(k_ShowDateStr, k_ShowDateTimeMenuTitle, false);
                mainMenu.AddItem(k_ShowTimeStr, k_ShowDateTimeMenuTitle, false);
                mainMenu.AddItem(k_CountCapitalsStr, k_CountCapitalsShowVersionMenuTitle, false);
                mainMenu.AddItem(k_ShowVersionStr, k_CountCapitalsShowVersionMenuTitle, false);
                mainMenu.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static void DelegatesTestCreator()
        {
            try
            {
                Ex04.Menus.Delegates.MainMenu mainMenu = new Delegates.MainMenu("Delegates Main Menu");
                /// next we add the 2 sub menus.
                mainMenu.AddItem(k_ShowDateTimeMenuTitle, mainMenu.Title, null);
                mainMenu.AddItem(k_CountCapitalsShowVersionMenuTitle, mainMenu.Title, null);
                /// next add the leaves that start an action.
                mainMenu.AddItem(k_ShowDateStr, k_ShowDateTimeMenuTitle, ShowDateTime.ShowDate);
                mainMenu.AddItem(k_ShowTimeStr, k_ShowDateTimeMenuTitle, ShowDateTime.ShowTime);
                mainMenu.AddItem(k_CountCapitalsStr, k_CountCapitalsShowVersionMenuTitle, CapitalsAndVersion.CountCapitals);
                mainMenu.AddItem(k_ShowVersionStr, k_CountCapitalsShowVersionMenuTitle, CapitalsAndVersion.ShowVersion);
                mainMenu.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        void IMenuSelection.Action(string i_MethodNameToCall)
        {
            if (i_MethodNameToCall == k_ShowDateStr)
            {
                ShowDateTime.ShowDate();
            }
            else if (i_MethodNameToCall == k_ShowTimeStr)
            {
                ShowDateTime.ShowTime();
            }
            else if (i_MethodNameToCall == k_CountCapitalsStr)
            {
                CapitalsAndVersion.CountCapitals();
            }
            else if (i_MethodNameToCall == k_ShowVersionStr)
            {
                CapitalsAndVersion.ShowVersion();
            }
        }
    }
}
