using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedCalculator.Configuration;
using Xamarin.Forms;

namespace ExtendedCalculator
{
    /// <inheritdoc />
    /// <summary>
    /// Xamarin.Forms starting point
    /// </summary>
    /// <remarks>
    /// Native projects use this class for app initialization.
    /// This application represents the implementation of the custom extended calculator 
    /// </remarks>
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Views.CalculatorPage(Config.UseCustomImplementation);
        }
    }
}
