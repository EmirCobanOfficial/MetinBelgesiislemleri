using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MetinBelgesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StreamWriter sw;
        string belgead, belgeyolu;

        private void button2_Click(object sender, EventArgs e)
        {
            belgead = textBox1.Text;
            sw = File.CreateText(belgeyolu + "\\" + belgead + ".txt");
            sw.Close();
            MessageBox.Show("Belgeniz Oluşturuldu");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamReader oku = new StreamReader(openFileDialog1.FileName);
                string satır = oku.ReadLine();
                while (satır !=null)
                {
                    listBox1.Items.Add(satır);
                    satır = oku.ReadLine();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac= new OpenFileDialog();
            ac.Filter = "Metin Dosyası(*.txt) | *txt";
            ac.Multiselect = false;
            if (ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = ac.SafeFileName;
                try
                {
                    StreamReader oku = new StreamReader(ac.FileName);
                    richTextBox1.Text=oku.ReadToEnd();
                    oku.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bu dosyayı okurken bir hata oluştu");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt yerini Seçiniz";
                saveFileDialog1.Filter= "Metin Dosyası(*.txt) | *.txt";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.InitialDirectory = "C:\\";
                saveFileDialog1.ShowDialog();
                StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
                kaydet.WriteLine(richTextBox2.Text);
                kaydet.Close();
                MessageBox.Show("Kaynak Metin belgesine Yazdırıldı");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu İşlem Gerçekleşti");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                belgeyolu = folderBrowserDialog1.SelectedPath.ToString();
                textBox2.Text = belgeyolu.ToString();
            }

        }
    }
}
