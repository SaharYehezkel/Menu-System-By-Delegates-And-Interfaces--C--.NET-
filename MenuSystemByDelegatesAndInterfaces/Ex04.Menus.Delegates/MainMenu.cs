using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        protected readonly string r_Title;
        private const int m_ExitFlag = 0;
        protected List<MenuItem> m_MainMenu;

        public string Title => r_Title;

        public MainMenu(string i_Title)
        {
            r_Title = i_Title;
            m_MainMenu = new List<MenuItem>();
        }

        protected MainMenu(string i_MainMenuTitle, bool i_IsSubMenu)
        {
            r_Title = i_MainMenuTitle;
            m_MainMenu = i_IsSubMenu ? new List<MenuItem>() : null;
        }

        public void Show()
        {
            do
            {
                printMenuSelections();
            }
            while (startItemAction());
        }

        private void printTitle()
        {
            string title = string.Format("**{0}**", r_Title);
            string dividingLine = "------------------------";

            Console.WriteLine(title);
            Console.WriteLine(dividingLine);
        }

        private void printZeroSelection()
        {
            Console.WriteLine("0 -> Exit\n\nEnter item selection or '0' to exit.");
        }

        private void printMenuSelections()
        {
            int indexSelection = 1;

            printTitle();
            foreach (MenuItem item in m_MainMenu)
            {
                Console.WriteLine("{0} -> {1}", indexSelection++, item.Title);
            }

            printZeroSelection();
        }

        private int getUserSelection()
        {
            int userSelection = -1;
            string userInput;
            bool isValidInput = false;

            do
            {
                try
                {
                    Console.WriteLine("Enter your selection:");
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out userSelection) || userSelection < 0 || userSelection > m_MainMenu.Count)
                    {
                        throw new Exception("Invalid input! Enter valid number for your selection from the list!");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            while (!isValidInput);

            return userSelection;
        }

        public bool AddItem(string i_Title, string i_MenuName, Action i_Action)
        {
            bool isValid = false;
            MenuItem menuItem;

            if (m_MainMenu != null)
            {
                if (i_MenuName == r_Title)
                {
                    menuItem = new MenuItem(i_Title, i_Action);
                    m_MainMenu.Add(menuItem);
                    isValid = true;
                }
                else
                {
                    foreach (MenuItem item in m_MainMenu)
                    {
                        if (item.Title == i_MenuName)
                        {
                            isValid = item.AddItem(i_Title, i_MenuName, i_Action);
                        }

                        if (isValid)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Not founded an menu to add.");
            }

            return isValid;
        }

        private bool startItemAction()
        {
            bool hasNext = true;
            int userSelection = getUserSelection();

            Console.Clear();
            if (userSelection == m_ExitFlag)
            {
                hasNext = false;
            }
            else
            {
                if (m_MainMenu[userSelection - 1].IsSubMenu)
                {
                    m_MainMenu[userSelection - 1].Show();
                }
                else
                {
                    m_MainMenu[userSelection - 1].Activate();
                    getInputToReturn();
                    hasNext = false;
                }
            }

            return hasNext;
        }

        private void getInputToReturn()
        {
            Console.WriteLine("\nPlease press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Show();
        }
    }
}
