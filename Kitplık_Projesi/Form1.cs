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

namespace Kitplık_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kitaplar", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        
        void temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtYazar.Text = "";
            cmbTur.Text = "";
            txtSayfa.Text = "";
            radioButton2.Checked = false;
            radioButton1.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            txtYazar.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            cmbTur.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            txtSayfa.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            if ((bool)dataGridView2.Rows[secilen].Cells[5].Value == true)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if ((bool)dataGridView2.Rows[secilen].Cells[5].Value == false)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }

        }

        public string ktpDurum = "";

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kyt = new SqlCommand(
                "Insert Into Tbl_Kitaplar (KitapAd, KitapYazar, KitapTur, KitapSayfa, KitapDurum) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());

            kyt.Parameters.AddWithValue("@p1", txtAd.Text);
            kyt.Parameters.AddWithValue("@p2", txtYazar.Text);
            kyt.Parameters.AddWithValue("@p3", cmbTur.Text);
            kyt.Parameters.AddWithValue("@p4", txtSayfa.Text);
            kyt.Parameters.AddWithValue("@p5", ktpDurum);

            kyt.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kitap başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ktpDurum = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ktpDurum = "0";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand del = new SqlCommand(
                "Delete From Tbl_Kitaplar Where KitapID = @p1", bgl.baglanti());
            del.Parameters.AddWithValue("@p1", txtID.Text);
            del.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kitap başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand upd = new SqlCommand(
                "Update Tbl_Kitaplar Set KitapAd=@p1, KitapYazar=@p2, KitapTur=@p3, KitapSayfa=@p4, KitapDurum=@p5 Where KitapID=@p6", bgl.baglanti());
            
            upd.Parameters.AddWithValue("@p1", txtAd.Text); 
            upd.Parameters.AddWithValue("@p2", txtYazar.Text); 
            upd.Parameters.AddWithValue("@p3", cmbTur.Text); 
            upd.Parameters.AddWithValue("@p4", txtSayfa.Text); 
            upd.Parameters.AddWithValue("@p5", ktpDurum); 
            upd.Parameters.AddWithValue("@p6", txtID.Text);

            upd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kitap başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand(
                "Select * From Tbl_Kitaplar Where KitapAd Like '%" + txtAra.Text +"%'", bgl.baglanti());

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            if (txtAra.Text == "")
                dt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtYazar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbTur.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSayfa.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if ((bool)dataGridView1.Rows[secilen].Cells[5].Value == true)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if ((bool)dataGridView1.Rows[secilen].Cells[5].Value == false)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
        }
    }
}
