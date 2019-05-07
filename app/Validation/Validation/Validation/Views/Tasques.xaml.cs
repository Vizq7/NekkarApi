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
		public Tasques ()
		{
			InitializeComponent ();
            lstTasques.ItemsSource = Models.Local.DadesTasques.tasques;
        }
	}
}