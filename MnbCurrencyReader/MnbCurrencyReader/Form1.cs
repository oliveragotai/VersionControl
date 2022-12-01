using MnbCurrencyReader.Entities;
using MnbCurrencyReader.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MnbCurrencyReader
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Rates;
            chartRateData.DataSource = Rates;
            comboBoxCurrency.DataSource = Currencies;

            GetCurrencies();
            RefreshData();
        }

        void GetCurrencies()
        {
            var client = new MNBArfolyamServiceSoapClient();
            var requestBody = new GetCurrenciesRequestBody();

            var response = client.GetCurrencies(requestBody);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response.GetCurrenciesResult);
            Console.WriteLine(response.GetCurrenciesResult);
            foreach (XmlElement element in xml.DocumentElement.ChildNodes[0])
            {
                Currencies.Add(element.InnerText);
            }
            comboBoxCurrency.DataSource = Currencies;
        }

        public string Task3() 
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBoxCurrency?.SelectedItem?.ToString() ?? "EUR",
                startDate = dateTimePickerStart.Value.ToString("yyyy-MM-dd"),
                endDate = dateTimePickerEnd.Value.ToString("yyyy-MM-dd")
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;
            return result;
        }

        public void Task5(string result)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                XmlElement childElement = ((XmlElement)element.ChildNodes[0]);

                if (childElement == null)
                {
                    continue;
                }

                decimal unit = decimal.Parse(childElement.GetAttribute("unit"));

                NumberFormatInfo numberFormatWithComma = new NumberFormatInfo();
                numberFormatWithComma.NumberDecimalSeparator = ",";

                decimal value = Math.Round(decimal.Parse(childElement.InnerText, numberFormatWithComma), 2);

                RateData rate = new RateData
                {
                    Date = Convert.ToDateTime(element.GetAttribute("date")),
                    Currency = childElement.GetAttribute("curr"),
                    Value = unit != 0 ? value / unit : value,
                };

                Rates.Add(rate);
            }
        }

        public void RefreshData()
        {
            Rates.Clear();

            string result = Task3();
            Task5(result);

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
