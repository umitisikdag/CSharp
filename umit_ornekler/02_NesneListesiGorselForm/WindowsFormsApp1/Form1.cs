using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Kume k1 = new Kume();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string n = textBox1.Text;
            int y = Convert.ToInt32(textBox2.Text);
            string r = textBox3.Text;

            Kume.canlilistesi.Add(new Canli(n, y, r));
            //MessageBox.Show(Kume.canlilistesi[0].Name);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isim = textBox4.Text;
            Canli bulunan = Kume.canlilistesi.Find(i => i.Name == isim);
            textBox1.Text = bulunan.Name;
            textBox2.Text = Convert.ToString(bulunan.Age);
            textBox3.Text = bulunan.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Kume.canlilistesi.Count(); i++)
            {
                string str = Kume.canlilistesi[i].Name + " " + Convert.ToString(Kume.canlilistesi[i].Age) + " " + Kume.canlilistesi[i].Color;
                listBox1.Items.Add(str);

            }

            listBox2.Items.Clear();
            for (int i = 0; i < Kume.canlilistesi.Count(); i++)
            {
                string str = Kume.canlilistesi[i].Name;
                listBox2.Items.Add(str);

            }

            listBox3.Items.Clear();
            for (int i = 0; i < Kume.canlilistesi.Count(); i++)
            {
                string str = Kume.canlilistesi[i].Name;
                listBox3.Items.Add(str);

            }



        }

        public static class Kume
        {
            public static List<Canli> canlilistesi = new List<Canli>();

        }
        public class Canli
        {
            //Attribute tanimlarimiz
            public string Name { get; set; }
            public string Color { get; set; }
            public int Age { get; set; }

            //Constructor Metod 1 Tanimimiz
            public Canli() { }

            //Constructor Metod 2 Tanimimiz
            public Canli(string N, int A, string C)
            {
                Name = N;
                Age = A;
                Color = C;
            }

            //Metod Tanimimiz
            public string SesCikart() { return "\nMeow, meow!\n"; }
        }

        public class Fare : Canli

        {
            public Fare() { }
            public Fare(string N, int A, string C)
            {
                Name = N;
                Age = A;
                Color = C;
            }
            public new string SesCikart() { return "\nkirp,kirp!\n"; }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isim = listBox2.GetItemText(listBox2.SelectedItem);
            Canli bulunan = Kume.canlilistesi.Find(i => i.Name == isim);
            textBox1.Text = bulunan.Name;
            textBox2.Text = Convert.ToString(bulunan.Age);
            textBox3.Text = bulunan.Color;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            string isim = listBox3.GetItemText(listBox3.SelectedItem);
            int idx = Kume.canlilistesi.FindIndex(i => i.Name == isim);
            Kume.canlilistesi.RemoveAt(idx);
        }


    }
}
