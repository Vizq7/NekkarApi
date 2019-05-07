using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Validation.Views;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Validation
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            InitializeComponent();

            MainPage = new Splash();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
