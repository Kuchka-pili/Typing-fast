using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_fast
{
    public partial class Form1 : Form
    {
        private DateTime startTime;
        private bool isStarted = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] texts = new string[]
   {
        "кот собака дом солнце",
        "мама мыла раму",
        "зеленый чай вкусный",
        "я люблю программировать",
        "сегодня хорошая погода",
        "быстрый коричневый лис",
        "привет как дела"
   };
            Random rand = new Random();
            int index = rand.Next(texts.Length);
            label4.Text = texts[index];
            textBox1.Clear();
            isStarted = false;
            label5.Text = "0";
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isStarted && textBox1.Text.Length > 0)
            {
                startTime = DateTime.Now;
                isStarted = true;
            }
            if (isStarted)
            {
                double minutes = (DateTime.Now - startTime).TotalMinutes;
                if (minutes > 0)
                {
                    int cpm = (int)(textBox1.Text.Length / minutes); 
                    label5.Text = cpm.ToString(); 
                }
            }
            if (textBox1.Text == label4.Text)
            {
                MessageBox.Show("Молодец! Ты справился!", "Победа");
                isStarted = false;
            }
        }
    }
}
