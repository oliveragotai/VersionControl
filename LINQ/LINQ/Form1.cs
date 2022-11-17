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
            StreamReader sr = new StreamReader(fileName, Encoding.Default);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                string countryName = line[2];
                string brandName = line[0];
                Country country = AddCountry(countryName);
                Brand brand = AddBrand(brandName);
                AddRamen(line, country, brand);
            }
            sr.Close();
        }

        private void AddRamen(string[] line, Country country, Brand brand)
        {
            var ramen = new Ramen()
            {
                ID = ramens.Count + 1,
                Brand = brand,
                Name = line[1],
                CountryFK = country.ID,
                Country = country,
                Stars = Convert.ToDouble(line[3].Replace(",","."))
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

        private Brand AddBrand(string brandName)
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
            return currentBrand;
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

        private void listCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var country = (Country)((ListBox)sender).SelectedItem;
            if (country == null)
                return;
            var countryRamens = from r in ramens
                                where r.CountryFK == country.ID
                                select r;
            var groupedRamens = from r in countryRamens
                                group r.Stars by r.Brand.Name into g
                                select new
                                {
                                    BrandName = g.Key,
                                    AverageRating = Math.Round(g.Average(), 2)
                                };
            var orderedGroups = from g in groupedRamens
                                orderby g.AverageRating descending
                                select g;
            dataGridView1.DataSource = orderedGroups.ToList();
        }
    }
}
