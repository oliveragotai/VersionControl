﻿using MnbCurrencyReader.Entities;
using MnbCurrencyReader.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MnbCurrencyReader
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            Task3();
            InitializeComponent();
        }

        public void Task3() 
        {
            // A változó deklarációk jobb oldalán a "var" egy dinamikus változó típus.
            // A "var" változó az első értékadás pillanatában a kapott érték típusát veszi fel, és később nem változtatható.
            // Jelen példa első sora tehát ekvivalens azzal, ha a "var" helyélre a MNBArfolyamServiceSoapClient-t írjuk.
            // Ebben a formában azonban olvashatóbb a kód, és változtatás esetén elég egy helyen átírni az osztály típusát.
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            // Ebben az esetben a "var" a GetExchangeRates visszatérési értékéből kapja a típusát.
            // Ezért a response változó valójában GetExchangeRatesResponseBody típusú.
            var response = mnbService.GetExchangeRates(request);

            // Ebben az esetben a "var" a GetExchangeRatesResult property alapján kapja a típusát.
            // Ezért a result változó valójában string típusú.
            var result = response.GetExchangeRatesResult;
        }
    }
}
