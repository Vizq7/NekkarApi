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
		protected override async void OnAppearing()
		{

            await this.ScaleTo(0.001, 0, Easing.CubicInOut);
            await btnLogin.ScaleTo(0.001, 1, Easing.BounceOut);
            await imgLogo.ScaleTo(0.001, 1, Easing.BounceOut);
            await txtPassword.ScaleTo(0.001, 1, Easing.BounceOut);
            await txtUsername.ScaleTo(0.001, 1, Easing.BounceOut);
            await lblTittle1.ScaleTo(0.001, 1, Easing.BounceOut);
            await lblTittle2.ScaleTo(0.001, 1, Easing.BounceOut);
            await this.ScaleTo(1, 200, Easing.CubicInOut);
            imgLogo.IsVisible = true;
            btnLogin.IsVisible = true;
            await btnLogin.ScaleTo(1, 500, Easing.BounceOut);
            await imgLogo.ScaleTo(1, 500, Easing.BounceOut);
            await lblTittle1.ScaleTo(1, 500, Easing.BounceOut);
            await txtPassword.ScaleTo(1, 500, Easing.BounceOut);
            await lblTittle2.ScaleTo(1, 500, Easing.BounceOut);
            await txtUsername.ScaleTo(1, 500, Easing.BounceOut);
            
        }

	    public Login ()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent ();
			btnLogin.Clicked += BtnLogin_Clicked;
		}

		private void BtnLogin_Clicked(object sender, EventArgs e)
		{
            LoadAnimation();
		}

        private async void LoadAnimation()
        {
            await btnLogin.ScaleTo(0.01, 400, Easing.BounceOut);
            btnLogin.IsVisible = false;
            await aiLoader.ScaleTo(0.1, 1, Easing.SinInOut);
            aiLoader.IsVisible = true;
            await aiLoader.ScaleTo(1, 300, Easing.CubicInOut);

            ComprovarConexio();
            
        }

        private async void ComprovarConexio()
        {
            if (true)
            {
                Application.Current.MainPage = new Menu();
            }
            else
            {
                await aiLoader.ScaleTo(0.1, 1, Easing.SinInOut);
                aiLoader.IsVisible = false;
                btnLogin.IsVisible = true;
                await btnLogin.ScaleTo(1, 400, Easing.BounceOut);
                lblError.IsVisible = true;
                lblError.Text = "Error al connectar";
                await lblError.ScaleTo(0.1, 50, Easing.CubicIn);
                await lblError.ScaleTo(1, 60, Easing.CubicOut);
                await lblError.ScaleTo(0.6, 50, Easing.CubicInOut);
                await lblError.ScaleTo(1, 60, Easing.CubicOut);
                
            }
            
        }
    }
}