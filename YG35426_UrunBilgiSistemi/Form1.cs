using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YG35426_UrunBilgiSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                else if(item is NumericUpDown)
                {
                    NumericUpDown nu = (NumericUpDown)item;
                    nu.Value = 0;
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)item;
                    dt.Value = DateTime.Now;
                }
                else if (item is CheckBox)
                {
                    CheckBox chk = (CheckBox)item;
                    chk.Checked = false;
                }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.DevamDurumu = chkDevamDurumu.Checked;
            urun.Fiyati = nuFiyati.Value;
            urun.GarantiSuresi = Convert.ToInt32(nuGarantiSuresi.Value);
            urun.StokMiktari = Convert.ToInt32(nuStokMiktari.Value);
            urun.UretimTarihi = dtUretimTarihi.Value;
            urun.UrunAdi = txtUrunAdi.Text;
            urun.UrunKodu = txtUrunKodu.Text;


            //1.Yol
            //string[] satirBilgisi = { urun.UrunKodu, urun.UrunAdi, urun.Fiyati.ToString(), urun.StokMiktari.ToString(), urun.UretimTarihi.ToShortDateString() };

            //ListViewItem lvi = new ListViewItem(satirBilgisi);
            //listView1.Items.Add(lvi);

            //2.Yol
            ListViewItem lvi = new ListViewItem();
            lvi.Text = urun.UrunKodu;
            lvi.SubItems.Add(urun.UrunAdi);
            lvi.SubItems.Add(urun.Fiyati.ToString());
            lvi.SubItems.Add(urun.StokMiktari.ToString());
            lvi.SubItems.Add(urun.UretimTarihi.ToShortDateString());
            lvi.Tag = urun;
            listView1.Items.Add(lvi);
            Temizle();
        }
        Urun guncellenecek;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //Listview'in fullrowselect özelliğini true yaptık.
            guncellenecek = (Urun)listView1.SelectedItems[0].Tag;
            txtUrunAdi.Text = guncellenecek.UrunAdi;
            txtUrunKodu.Text = guncellenecek.UrunKodu;
            nuFiyati.Value = guncellenecek.Fiyati;
            nuGarantiSuresi.Value = guncellenecek.GarantiSuresi;
            dtUretimTarihi.Value = guncellenecek.UretimTarihi;
            chkDevamDurumu.Checked = guncellenecek.DevamDurumu;
            nuStokMiktari.Value = guncellenecek.StokMiktari;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncellenecek.DevamDurumu = chkDevamDurumu.Checked;
            guncellenecek.Fiyati = nuFiyati.Value;
            guncellenecek.GarantiSuresi = Convert.ToInt32(nuGarantiSuresi.Value);
            guncellenecek.StokMiktari = Convert.ToInt32(nuStokMiktari.Value);
            guncellenecek.UretimTarihi = dtUretimTarihi.Value;
            guncellenecek.UrunAdi = txtUrunAdi.Text;
            guncellenecek.UrunKodu = txtUrunKodu.Text;

            string[] satirBilgisi = { guncellenecek.UrunKodu, guncellenecek.UrunAdi, guncellenecek.Fiyati.ToString(), guncellenecek.StokMiktari.ToString(), guncellenecek.UretimTarihi.ToShortDateString() };

            ListViewItem lvi = new ListViewItem(satirBilgisi);
            lvi.Tag = guncellenecek;

            int index = listView1.SelectedItems[0].Index;
            listView1.Items.RemoveAt(index);
            listView1.Items.Insert(index, lvi);
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }
    }
}
