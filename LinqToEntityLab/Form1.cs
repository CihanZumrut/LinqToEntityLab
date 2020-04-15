using LinqToEntityLab.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToEntityLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindEntities db = new NorthwindEntities();

        private void btnSorgu1_Click(object sender, EventArgs e)
        {
            //Soru: Tüm kategorileri listeleyiniz.

            dataGridView1.DataSource = db.Categories.ToList();
        }

        private void btnSorgu2_Click(object sender, EventArgs e)
        {
            //Soru:Tüm ürünleri listeleyiniz.
            dataGridView1.DataSource = db.Products.ToList();
        }

        private void btnSorgu3_Click(object sender, EventArgs e)
        {
            //Soru: Birim fiyatı 18'den büyük olan ürünlerin Id, Adı, birim fiyatı ve stok durumunu listeleyiniz.

            dataGridView1.DataSource = db.Products.Where(x => x.UnitPrice > 18).Select(y => new
            {
                y.ProductID,
                y.ProductName,
                y.UnitPrice,
                y.UnitsInStock
            }).ToList();

        }

        private void btnSorgu4_Click(object sender, EventArgs e)
        {
            //Soru: EmployeeID' si  5 ten büyük olan çalışanların Adını, Soyadını ve ünvanını getiriniz.

            dataGridView1.DataSource = db.Employees.Where(x => x.EmployeeID > 5).Select(y => new
            {
                y.EmployeeID,
                y.FirstName,
                y.LastName,
                y.Title
            }).ToList();
        }

        private void btnSorgu5_Click(object sender, EventArgs e)
        {
            //Soru: Stok miktarı sıfır olan ürünlerin ıd, adı, fiyatını, stok miktarını getiriniz.

            dataGridView1.DataSource = db.Products.Where(x => x.UnitsInStock == 0).Select(y => new
            {
                y.ProductID,
                y.ProductName,
                y.UnitPrice,
                y.UnitsInStock
            }).ToList();
        }

        private void btnSorgu6_Click(object sender, EventArgs e)
        {
            //Soru: 1952 ve 1960 yılları arasında doğan çalışanların adı, soyadı, dogum yılı, ünvan bilgilerini listeleyiniz.

            dataGridView1.DataSource = db.Employees.Where
                (x => SqlFunctions.DatePart("Year", x.BirthDate) >= 1952 && SqlFunctions.DatePart("Year", x.BirthDate) <= 1960).Select(y => new
                {
                    y.TitleOfCourtesy,
                    y.FirstName,
                    y.LastName,
                    BirthYear = SqlFunctions.DatePart("Year", y.BirthDate),
                    y.Title
                }).ToList();
        }

        private void btnSorgu7_Click(object sender, EventArgs e)
        {
            //Soru: Ünvanı (TitleOfCourtesy) Mr yada Dr olanları listeleyiniz.

            dataGridView1.DataSource = db.Employees.Where(x => x.TitleOfCourtesy == "Mr." || x.TitleOfCourtesy == "Dr.").Select(y => new
            {
                y.TitleOfCourtesy,
                y.FirstName,
                y.LastName
            }).ToList();
        }

        private void btnSorgu8_Click(object sender, EventArgs e)
        {
            //Soru: Ürünlerin birim fiyatları 18, 19 veya 25 olanları listeleyiniz.

            dataGridView1.DataSource = db.Products.Where(x => x.UnitPrice == 18 || x.UnitPrice == 19 || x.UnitPrice == 25).ToList();
        }

        private void btnSorgu9_Click(object sender, EventArgs e)
        {
            //Soru: Ismi içerisinde "C" harfi geçen çalışanları listeleyiniz.

            dataGridView1.DataSource = db.Employees.Where(x => x.FirstName.Contains("C")).Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Title
            }).ToList();

        }

        private void btnSorgu10_Click(object sender, EventArgs e)
        {
            //Soru. Id'si 2 ile 8 arasında olan çalışanları listeleyiniz.

            dataGridView1.DataSource = db.Employees.Where(x => x.EmployeeID >= 2 && x.EmployeeID <= 8).OrderBy(z => z.EmployeeID).ToList();
        }

        private void btnSorgu11_Click(object sender, EventArgs e)
        {
            //Soru: Ürünlerin  birim fiyatları 15,20 veya 25 olanları listeleyiniz.

            dataGridView1.DataSource = db.Products.Where(x => x.UnitPrice == 15 || x.UnitPrice == 20 || x.UnitPrice == 25).OrderByDescending(x => x.UnitPrice).Select(x => new
            {
                x.ProductName,
                x.UnitPrice
            }).ToList();
        }

        private void btnSorgu12_Click(object sender, EventArgs e)
        {
            //Soru: Doğum tarihi 1940 ile 1960 arasında olup da USA'da çalışanları listeleyiniz.

            dataGridView1.DataSource = db.Employees.Where(x => SqlFunctions.DatePart("Year", x.BirthDate) >= 1930 && SqlFunctions.DatePart("Year", x.BirthDate) <= 1960 && x.Country == "USA").Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Title,
                x.Country,
                x.BirthDate
            }).ToList();

        }
    }
}
