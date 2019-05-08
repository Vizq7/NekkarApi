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
	public partial class Tasques : ContentPage
	{
		ModelTasques model;
		protected override async void OnAppearing()
		{
            
            lstTasques.ItemsSource = Models.Local.DadesTasques.tasques;
            lstTasques.SelectedItem = null;
        }

		public Tasques ()
		{
			InitializeComponent ();

			lstTasques.ItemSelected += LstTasques_ItemSelected;
		}

		private void LstTasques_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			model = e.SelectedItem as ModelTasques;
			Navigation.PushAsync(new Views.Tasca(model));
		}


	}
}