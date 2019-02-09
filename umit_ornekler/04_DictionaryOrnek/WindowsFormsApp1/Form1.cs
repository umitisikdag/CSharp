using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//https://www.dotnetperls.com/dictionary


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> sozluk = new Dictionary<int, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool res = int.TryParse(textBox1.Text,out int key);
            string value = textBox2.Text;
            sozluk.Add(key, value);
            textBox1.Clear();
            textBox2.Clear();
            label5.Text = "Veri eklendi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res = int.TryParse(textBox3.Text, out int searchkey);

            if (sozluk.ContainsKey(searchkey))
            {
                sozluk.TryGetValue(searchkey, out string return_value);
                textBox4.Text = return_value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (KeyValuePair<int, string> pair in sozluk)
            {
                string str = Convert.ToString(pair.Key) + "=>" + pair.Value;
                listBox1.Items.Add(str);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }
    }
}
