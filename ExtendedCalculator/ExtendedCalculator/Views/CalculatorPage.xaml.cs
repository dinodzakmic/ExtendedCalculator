using System;
using System.Collections.Generic;
using CalculatorEngine.Portable.Implementation;
using CalculatorInterfaces;
using ExtendedCalculator.Configuration;
using ExtendedCalculator.Helpers;
using Xamarin.Forms;

namespace ExtendedCalculator.Views
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage(bool useCustomEngine = false)
        {
            InitializeComponent();
            var calculator = new Calculator(useCustomEngine);

            CalculatorKeyboard.NumberClickedEvent += (number, args) =>
            {
                calculator.EnteredNumber(number.ToString());
                CalculatorText.Text = calculator.CurrentText;
                Result.Text = $"= {calculator.CurrentResult}";
            };

            CalculatorKeyboard.ClearClickedEvent += (sender, args) =>
            {
                calculator.Clear();
                CalculatorText.Text = calculator.CurrentText;
                Result.Text = $"= {calculator.CurrentResult}";
            };

            CalculatorKeyboard.UndoClickedEvent += (sender, args) =>
            {
                calculator.Undo();
                CalculatorText.Text = calculator.CurrentText;
                Result.Text = $"= {calculator.CurrentResult}";
            };

            CalculatorOperators.OperatorClickedEvent += (operation, args) =>
            {
                if (calculator.OperationsAvailable || calculator.CurrentText.Equals(string.Empty) 
                && operation != null)
                {
                    if (operation.ToString().Equals("+") || operation.ToString().Equals("-"))
                        calculator.OperationsAvailable = true;

                    if (calculator.OperationsAvailable)
                    {
                        calculator.EnteredOperator(operation.ToString());
                        CalculatorText.Text = calculator.CurrentText;
                    }
                }
            };

            DisneyRegularButton.Clicked += (sender, args) =>
            {
                Config.IsDisneyModeOn = !Config.IsDisneyModeOn;
                DisneyRegularButton.Image = Config.IsDisneyModeOn ? "CalculatorIcon.png" : "DisneyIcon.png";
            };
        }

        
    }
}
