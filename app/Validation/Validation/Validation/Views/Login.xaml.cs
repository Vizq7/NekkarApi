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
	public partial class Login : ContentPage
	{
		public Login ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            btnLogin.Clicked += BtnLogin_Clicked;
		}

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Menu();
        }
    }
}