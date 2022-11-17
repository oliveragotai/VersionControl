using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
    public partial class Form1 : Form
    {
        private List<Country> countries = new List<Country>();
        private List<Ramen> ramens = new List<Ramen>();

        void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                string countryName = line[2];
                var country = AddCountry(countryName);
                var ramen = new Ramen()
                {
                    ID = ramens.Count + 1,
                    Brand = line[0],
                    Name = line[1],
                    CountryFK = country.ID,
                    Country = country,
                    Stars = Convert.ToDouble(line[3])
                };
                ramens.Add(ramen);
            }
            sr.Close();
        }

        private Country AddCountry(string countryName)
        {
            var currentCountry = countries.Where(i => i.Name.Equals(countryName)).FirstOrDefault();
            if (currentCountry == null)
            {
                currentCountry = new Country()
                {
                    ID = countries.Count + 1,
                    Name = countryName
                };
                countries.Add(currentCountry);
            }
            return currentCountry;
        }


        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");
            Console.WriteLine("breakpoint");
        }
    }
}
