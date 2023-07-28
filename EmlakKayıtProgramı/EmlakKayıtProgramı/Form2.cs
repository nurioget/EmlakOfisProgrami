using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmlakKayıtProgramı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-BT6MOGH\\SQLEXPRESS;Initial Catalog=EmlakOfisiUygulaması;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select* From EmlakOfisprogramı", baglan);
            SqlDataReader oku = komut.ExecuteReader();



            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                ekle.SubItems.Add(oku["odasayısı"].ToString());
                ekle.SubItems.Add(oku["metrekare"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["kapıno"].ToString());
                ekle.SubItems.Add(oku["isimsoyisim"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button2.BackColor = Color.Salmon;
                button1.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                button4.BackColor = Color.Salmon;
                button1.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                button1.BackColor = Color.Salmon;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                button3.BackColor = Color.Salmon;
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }


        }

        private void btngoruntule_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into EmlakOfisprogramı (id,site,satkira,odasayısı,metrekare,fiyat,blok,kapıno,isimsoyisim,telefon,notlar) values('" + textBox7.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }
        int id = 0;
        private void btnsil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from EmlakOfisprogramı where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update EmlakOfisprogramı set id='" + textBox7.Text.ToString() + "',site='" + comboBox1.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "',odasayısı='" + comboBox3.Text.ToString() + "',metrekare='" + textBox1.Text.ToString() + "',fiyat='" + textBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',kapıno='" + textBox6.Text.ToString() + "',isimsoyisim='" + textBox4.Text.ToString() + "',telefon='" + textBox3.Text.ToString() + "',notlar='" + textBox5.Text.ToString() + "'where id=" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }
    }
}
