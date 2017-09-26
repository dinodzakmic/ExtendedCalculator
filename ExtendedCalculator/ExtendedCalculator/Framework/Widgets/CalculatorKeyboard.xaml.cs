using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExtendedCalculator.Framework.Widgets
{
    public partial class CalculatorKeyboard : ContentView
    {
        public EventHandler<EventArgs> NumberClickedEvent { get; set; }
        public EventHandler<EventArgs> ClearClickedEvent { get; set; }
        public EventHandler<EventArgs> UndoClickedEvent { get; set; }

        public CalculatorKeyboard()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event handler
        /// </summary>
        /// <remarks>
        /// When number is clicked, this method is invoked
        /// </remarks>
        private void NumberClicked(object sender, EventArgs e)
        {     
            var number = ((Button)sender).Text;
            NumberClickedEvent.Invoke(number, e);
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <remarks>
        /// When undo is clicked, this method is invoke
        /// </remarks>
        private void UndoClicked(object sender, EventArgs e)
        {
            UndoClickedEvent.Invoke(sender, e);
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <remarks>
        /// When clear is clicked, this method is invoke
        /// </remarks>
        private void ClearClicked(object sender, EventArgs e)
        {
            ClearClickedEvent.Invoke(sender, e);
        }
    }
}
