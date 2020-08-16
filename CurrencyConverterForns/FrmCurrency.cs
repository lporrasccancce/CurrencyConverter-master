using CurrencyConverterLibreria;
using System;
using System.Collections;
using System.Windows.Forms;

namespace CurrencyConverterForms
{
    public partial class FrmCurrency : Form
    {
        public FrmCurrency()
        {
            InitializeComponent();
        }
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            decimal converted = 0;
            decimal initial = 0;
            BaseCurrency fromCur;
            BaseCurrency toCur;

            initial = Convert.ToDecimal(Amount.Text);
            fromCur = fromCombo.SelectedItem as BaseCurrency;
            toCur = toCombo.SelectedItem as BaseCurrency;
            converted = ConvertibleCurrency.CurrencyConvert(initial, fromCur, toCur);
            Result.Text = converted.ToString();
        }

        private void FrmCurrency_Load(object sender, EventArgs e)
        {
            ArrayList currencyList = new ArrayList();

            currencyList.Add(new PenCurrency());
            currencyList.Add(new UsdCurrency());
            currencyList.Add(new EurCurrency());
            fromCombo.DataSource = currencyList;
            toCombo.DataSource = currencyList.Clone();
        }
    }
}
