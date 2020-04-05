using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsimSehirHayvan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] harfler = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "İ", "Ç", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };
        //string[] harfler = new string[] { "A" }; // A harfi seçildiğinde isimlerin, isimler dizisinden kontrolü için deneme amacı ile

        string[] isimler = new string[] { "Ali", "Ahmet", "Ayhan", "Ayşe", "Aynur", "Ayşenur", "Abdullah", "Açelya","Adalet","Adile"
        ,"Ahsen","Ajda","Alev","Anıl","Arife","arzu","asena","asiye","aslı","aslıhan","asu","asude","asya","asuman","ayben","ayfer","aybike"
        ,"ayça","aydoğan","aygün","ayla","ayperi","aysel","aysu","aysun","ayşegül","ayten","azize","azra","abbas","abulaziz","abdulhamit"
        ,"abdulkerim","Abdurrahman","Abidin","Abuzer","adal","adil","ayhan","adnan","alp","alper","akif","akman","aktan","alaaddin","aladdin"
        ,"alican","alişan","alperen","altay","anıl","arda","arif","akif"};
        int saniye = 0;



        private void Form1_Load(object sender, EventArgs e)
        {
            pnl_txt.Enabled = false;
            timer1.Interval = 1000;
        }
        private void btn_harf_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int sayi = rnd.Next(harfler.Count());
            lbl_harf.Text = harfler[sayi];
        }
        private void btn_basla_Click(object sender, EventArgs e)
        {
            if (lbl_harf.Text.Length > 0)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Harf seçilmedi");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            pnl_txt.Enabled = true;
            lbl_zaman.Text = "Zaman : " + saniye.ToString();
            if (saniye == 60)
            {
                timer1.Enabled = false;
                pnl_txt.Enabled = false;
                lbl_harf.Text = "";
                saniye = 0;
                MessageBox.Show("Zaman Bitti!");
            }
        }
        private void brn_kontrol_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                if (lbl_harf.Text.Length > 0)
                {
                    timer1.Enabled = false;
                    pnl_txt.Enabled = false;

                    string harf = lbl_harf.Text;
                    int kontrol = 0;
                    int puan = 0;


                    // Harf bazlı, diziden arama. Eğer Harf A ise belirlediğimiz Dizide olup olmadığını kontrol edecek.
                    // bir arraylist'e tüm harfler için isimler yazarsanız ilk if şartına gerek kalmaz.
                    if (harf == "A")
                    {
                        // varsayılan olarak XXX == True kontrolü yapar. Yani if(XXX == True) yazmaya gerek yok.
                        if (isimler.Contains(txt_isim.Text)) { kontrol = 2; puan += 10; };
                    }
                    else
                    {
                        if (txt_isim.Text.ToUpper().Substring(0, 1) == harf && txt_isim.Text.Length >= 2) { kontrol = 1; puan += 10; }
                    }


                    if (txt_sehir.Text.ToUpper().Substring(0, 1) == harf && txt_sehir.Text.Length >= 3) { kontrol = 2; puan += 10; }
                    if (txt_hayvan.Text.ToUpper().Substring(0, 1) == harf && txt_hayvan.Text.Length >= 2) { kontrol = 3; puan += 10; }
                    if (txt_bitki.Text.ToUpper().Substring(0, 1) == harf && txt_bitki.Text.Length >= 3) { kontrol = 4; puan += 10; }
                    if (txt_esya.Text.ToUpper().Substring(0, 1) == harf && txt_esya.Text.Length >= 3) { kontrol = 5; puan += 10; }
                    if (txt_unlu.Text.ToUpper().Substring(0, 1) == harf && txt_unlu.Text.Length >= 5) { kontrol = 6; puan += 10; }


                    if (kontrol == 6)
                    {
                        MessageBox.Show("Tebrikler!. :) Hepsi Doğru" + Environment.NewLine + "Puanınız: " + puan.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Üzgünüm. :( Hepsi doğru değildi." + Environment.NewLine + "Puanınız: " + puan.ToString());
                    }
                    lbl_puan.Text = "Puan : " + puan.ToString();
                }
                else
                {
                    MessageBox.Show("Harf seçilmedi");
                }
            }
            else
            {
                MessageBox.Show("Zamanı başlatmadınız.");
            }

        }
    }
}
