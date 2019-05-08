using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Models.Local;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Validation.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tasca : ContentPage
	{
		public Tasca (ModelTasques tasques)
		{
			InitializeComponent ();
            CarregarDades(tasques);

            btnDownload.Clicked += BtnDownload_Clicked;
            //tasques.Image;
        }

        private void BtnDownload_Clicked(object sender, EventArgs e)
        {

            lblDownload.IsVisible = true;
            EffectDownload();
            
        }

        private async void EffectDownload()
        {
            await lblDownload.FadeTo(0.1, 100, Easing.Linear);
            await lblDownload.FadeTo(1, 2500, Easing.Linear);
            await lblDownload.FadeTo(0.01, 1300, Easing.Linear);
            lblDownload.IsVisible = false;

        }

        private void CarregarDades(ModelTasques tasques)
        {
            Title = tasques.Name;
            lbl1.Text = tasques.Details;
            lbl2.Text = tasques.Location;
            lbl3.Text = tasques.Name;
        }
    }
}