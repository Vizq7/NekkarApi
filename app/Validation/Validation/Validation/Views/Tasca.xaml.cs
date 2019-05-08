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
           
            //tasques.Image;
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