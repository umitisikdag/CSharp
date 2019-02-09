using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
            int.TryParse(textBox2.Text,out int y);  //String to int conversion da hata olmasın diye...int.tryparse i kullandim.
            string r = textBox3.Text;

            Kume.canlilistesi.Add(new Canli(n, y, r));
            //MessageBox.Show(Kume.canlilistesi[0].Name);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isim = textBox4.Text;
            Canli bulunan = Kume.canlilistesi.Find(i => i.Name == isim);
            if (bulunan != null)
            {
                textBox1.Text = bulunan.Name;
                textBox2.Text = Convert.ToString(bulunan.Age);
                textBox3.Text = bulunan.Color;
            }
            else
            {
                textBox1.Text = "Bulunamadi";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                        allListsRefresh();
        }

        private void allListsRefresh()
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


        private void button4_Click(object sender, EventArgs e)
        {
            Databasez.Delete();
            Databasez.Create();
            MessageBox.Show("Yeni Veritabanı Olusturuldu");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_conn = Databasez.Connect();
            m_conn.Open();

            string sql = "create table canlilar (name varchar(20), age int, color varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, m_conn);
            command.ExecuteNonQuery();

            m_conn.Close();
            MessageBox.Show("Canlilar isimli yeni Tablo olusturuldu");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SQLiteConnection m_conn = Databasez.Connect();
            m_conn.Open();

            for (int i = 0; i < Kume.canlilistesi.Count(); i++)
            {
                string str1 = Kume.canlilistesi[i].Name;
                string str2 = Convert.ToString(Kume.canlilistesi[i].Age); 
                string str3 = Kume.canlilistesi[i].Color;
                string sql = "insert into canlilar (name, age,color) values ('"+str1+"','"+str2+"','"+str3+"')";
                SQLiteCommand command = new SQLiteCommand(sql, m_conn);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Tablo ya -Runtime da-mevcut tum nesneler=>"+Kume.canlilistesi.Count()+" adet nesne eklendi");
            m_conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_conn = Databasez.Connect();
            m_conn.Open();
            string sql = "select * from canlilar order by name desc";

            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, m_conn);
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
            m_conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Databasez.Delete();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isim = listBox3.GetItemText(listBox3.SelectedItem);
            int idx = Kume.canlilistesi.FindIndex(i => i.Name == isim);
            Kume.canlilistesi.RemoveAt(idx);
            allListsRefresh();
        

        }
    }

    public static class Databasez
    {
        public static void Create()
        {

            SQLiteConnection.CreateFile("MyDatabase.sqlite");

        }

        public static void Delete()
        {

            SQLiteConnection.ClearAllPools();
        }

        public static SQLiteConnection Connect()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

            return m_dbConnection;
        }
    }

}
