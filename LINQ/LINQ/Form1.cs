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
        private List<Brand> brands = new List<Brand>();

        void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                string countryName = line[2];
                string brandName = line[0];
                Country country = AddCountry(countryName);
                AddBrand(brandName);
                AddRamen(line, country);
            }
            sr.Close();
        }

        private void AddRamen(string[] line, Country country)
        {
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

        private void AddBrand(string brandName)
        {
            var currentBrand = brands.Where(i => i.Name.Equals(brandName)).FirstOrDefault();
            if (currentBrand == null)
            {
                currentBrand = new Brand()
                {
                    ID = brands.Count + 1,
                    Name = brandName
                };
                brands.Add(currentBrand);
            }
        }

        private void GetCountries()
        {
            var countriesList = from c in countries
                                where c.Name.Contains(txtCountryFilter.Text)
                                orderby c.Name
                                select c;
            listCountries.DataSource = countriesList.ToList();
        }


        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");
            listCountries.DisplayMember = "Name";
            GetCountries();
        }

        private void txtCountryFilter_TextChanged(object sender, EventArgs e)
        {
            GetCountries();
        }
    }
}
