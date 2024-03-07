using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : MainMenu
    {
        private bool m_IsSubMenu;

        public bool IsSubMenu => m_IsSubMenu;
        
        public MenuItem(string i_Title, IMenuSelection i_AllMenuSelection, bool i_IsSubMenu) 
            : base(i_Title, i_AllMenuSelection)
        {
            m_IsSubMenu = i_IsSubMenu;
        }
    }
}
