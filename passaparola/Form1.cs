using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passaparola
{
    public partial class Form1 : Form
    {
        int SoruNo = 0, Dogru = 0, Yanlis = 0, Bos = 0;
        string dogruCevap = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDogru.Text = "0";
            lblYanlis.Text = "0";
            lblBos.Text = "0";

        }

 
        private void tctCevap_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Text = "Cevapla";
            SoruNo++; //        
            this.Text = SoruNo.ToString();

            try
            {
                using (SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OD8JBL6\SQLEXPRESS;Initial Catalog=SU_Project;Integrated Security=True"))
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand(
                        "SELECT SoruMetni, Cevap FROM Sorular WHERE Id = @num",
                        baglanti
                    );
                    komut.Parameters.AddWithValue("@num", SoruNo);

                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        richTextBox1.Text = dr["SoruMetni"].ToString();
                        dogruCevap = dr["Cevap"].ToString(); //  cevap hafızada
                    }
                    else
                    {
                        richTextBox1.Text = "Sorular bitti!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnCevapla_Click(object sender, EventArgs e)
        {
            btnCevapla.BackColor = SystemColors.Control;

            if (string.IsNullOrWhiteSpace(txtCevap.Text))
            {
                Bos++;
                lblBos.Text = Bos.ToString();
                btnCevapla.BackColor = Color.Yellow;
            }
            else if (txtCevap.Text.Trim().ToLower() == dogruCevap.Trim().ToLower())
            {
                Dogru++;
                lblDogru.Text = Dogru.ToString();
                btnCevapla.BackColor = Color.Green;
            }
            else
            {
                Yanlis++;
                lblYanlis.Text = Yanlis.ToString();
                btnCevapla.BackColor = Color.Red;
            }

            txtCevap.Clear();
        }


    }
}
