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
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Легкий");
            comboBox1.Items.Add("Средний");
            comboBox1.Items.Add("Сложный");
            comboBox1.SelectedIndex = 0;
            InitializeTexts();
            LoadTextByLevel();
        }
        private Dictionary<string, string[]> textsByLevel;

        private void InitializeTexts()
        {
            textsByLevel = new Dictionary<string, string[]>
            {
                ["Легкий"] = new string[]
                {
            "кот собака дом",
            "мама мыла раму",
            "зеленый чай",
            "солнце светит",
            "я люблю спать"
                },
                ["Средний"] = new string[]
                {
            "быстрая лиса прыгает через собаку",
            "программировать на C# интересно",
            "сегодня хорошая погода на улице",
            "учёба свет а неученье тьма",
            "каждый охотник желает знать"
                },
                ["Сложный"] = new string[]
                {
            "Чем больше вы практикуетесь в печати, тем быстрее развивается мышечная память пальцев.",
            "Для успешного изучения программирования необходимо регулярно писать код и разбирать чужие примеры.",
            "В сложных текстах используются знаки препинания: точки, запятые, восклицательные знаки!",
            "Скорость печати измеряется в символах в минуту и зависит от регулярности тренировок."
                }
            };
        }
        private void LoadTextByLevel()
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.SelectedIndex = 0;
            }

            string level = comboBox1.SelectedItem.ToString();
            string[] texts = textsByLevel[level];
            Random rand = new Random();
            int index = rand.Next(texts.Length);
            label4.Text = texts[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTextByLevel();
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
