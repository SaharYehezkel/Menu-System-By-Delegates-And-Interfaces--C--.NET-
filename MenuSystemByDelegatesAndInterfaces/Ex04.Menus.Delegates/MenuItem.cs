using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : MainMenu
    {
        private Action m_Action;
        private readonly bool r_IsSubMenu;

        public Action Action => m_Action;

        public bool IsSubMenu => r_IsSubMenu;

        public MenuItem(string i_MenuItemTitle, Action i_Action) : base(i_MenuItemTitle, i_Action == null)
        {
            m_Action = i_Action;
            if (i_Action == null)
            {
                r_IsSubMenu = true;
            }
            else
            {
                r_IsSubMenu = false;
            }
        }

        protected virtual void OnItemSelected()
        {
            m_Action?.Invoke();
        }

        public void Activate()
        {
            OnItemSelected();
        }
    }
}
