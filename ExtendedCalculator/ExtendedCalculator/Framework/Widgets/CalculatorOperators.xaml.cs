using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExtendedCalculator.Framework.Widgets
{
    public partial class CalculatorOperators : ContentView
    {
        public EventHandler<EventArgs> OperatorClickedEvent { get; set; }
        public CalculatorOperators()
        {
            InitializeComponent();
            var t = new EventArgs();
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <remarks>
        /// When operator is clicked, this method is invoke
        /// </remarks>
        private void OperatorClicked(object sender, EventArgs e)
        {
            var operation = ((Button)sender).Text;
            OperatorClickedEvent.Invoke(operation, e);
        }
    }
}
