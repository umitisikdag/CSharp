using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;  //ayrica eklenir
using System.Net.Http; //ayrica eklenir
using System.Windows.Forms;

//Basvurulardan system.web.extensions eklenmelidir.
//Basvurulardan system.net eklenmelidir.
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var example1 = @"{""name"":""Hasan Yilmaz"",""age"":20}";

            var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(example1);

            string str1=JSONObj["name"]; // equals John Doe
            string str2=JSONObj["age"]; // equals 20

            MessageBox.Show(str1);

            var yeniKisi = new JavaScriptSerializer().Deserialize<Kisi>(example1);
            
            string str3 = yeniKisi.name; // equals John Doe
            int int4 = yeniKisi.age; // equals 20

            MessageBox.Show(Convert.ToString(int4));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var example2 = @"{""custId"": 123, ""ordId"": 4567, ""items"":[{""prodId"":1, ""price"":9.99, ""title"":""Product 1""},{""prodId"":78, ""price"":95.99, ""title"":""Product 2""},{""prodId"":1985, ""price"":3.01, ""title"":""Product 3""}] }";

            var example2Model = new JavaScriptSerializer().Deserialize<CustomerOrderSummary>(example2);

            double dbl1=example2Model.items[0].price;
            int int5=example2Model.custId;

            MessageBox.Show(Convert.ToString(dbl1));
        }

    }

    class Kisi
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    class Item
    {
        public int prodId { get; set; }
        public double price { get; set; }
        public string title { get; set; }
    }
    class CustomerOrderSummary
    {
        public int custId { get; set; }
        public int ordId { get; set; }
        public List<Item> items { get; set; }
    }

}
