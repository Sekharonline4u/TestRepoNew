using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UseCalcService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            var service = new CalculatorService.CalculatorServiceSoapClient(CalculatorService.CalculatorServiceSoapClient.EndpointConfiguration.CalculatorServiceSoap12);
            int.TryParse(No1.Text, out int no1);
            int.TryParse(No2.Text, out int no2);
            var result = await service.AddAsync(no1, no2);
            LabelResult.Text = $"Sum of {no1} and {no2} = {result}";
        }
    }
}