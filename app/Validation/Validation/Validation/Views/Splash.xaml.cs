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
	public partial class Splash : ContentPage
	{
        public Splash()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutFlags(lblEBet,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(lblEBet,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            sub.Children.Add(lblEBet);

            this.Content = sub;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await lblEBet.ScaleTo(2, 1800, Easing.SinIn);
            await this.ScaleTo(0.001, 2000, Easing.CubicInOut);
            

            Application.Current.MainPage = new NavigationPage(new Login());

        }
    }
}