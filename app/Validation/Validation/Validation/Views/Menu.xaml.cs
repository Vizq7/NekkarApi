using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Validation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent(); MyMenu();

        }

        public void MyMenu()
        {

            Detail = new NavigationPage(new Views.Tasques());
            List<MenuTipus> menu = new List<MenuTipus>
            {
                new MenuTipus{ Page = new Views.Tasques(), MenuTitle= "Tasques", Color="Black" },
                new MenuTipus{ Page = new Views.Control(), MenuTitle= "Control", Color="Black"},
                new MenuTipus{ Page =new Views.Login(), MenuTitle = "Tancar sesió", Color="Red"},
        };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as MenuTipus;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }
        public class MenuTipus
        {
            public string MenuTitle { get; set; }
            public string MenuDetail { get; set; }
            public ImageSource icon { get; set; }
            public Page Page { get; set; }
            public string Color { get; set; }
        }
    }
}