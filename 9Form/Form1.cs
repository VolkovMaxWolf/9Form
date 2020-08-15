using System;
using System.IO;
using System.Windows.Forms;

namespace _9Form
{
    public partial class Form1 : Form
    {
        private const String PATH = "..\\..\\..\\text.txt";
        private const String PATH2 = "..\\..\\..\\text2.txt";
        private const String PATH3 = "..\\..\\..\\text3.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void FilterButton(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && Сheck(textBox1.Text) && textBox2.Text != "")
            {
                textBox3.Clear();
                String sentence = textBox2.Text;
                FileStream f = new FileStream(PATH, FileMode.OpenOrCreate);
                BinaryWriter fOut = new BinaryWriter(f);
                char[] chArray = sentence.ToCharArray();
                for (int i = 0; i < chArray.Length; i++)
                {
                    if (!Char.IsDigit(chArray[i])) fOut.Write(chArray[i]);
                }
                fOut.Close();

                int n = Convert.ToInt32(textBox1.Text);
                FileStream fileStream = new FileStream(PATH, FileMode.OpenOrCreate);
                StreamReader sR = new StreamReader(fileStream);
                String str1 = String.Empty;
                int count = 1;
                while ((str1 = sR.ReadLine()) != null && str1 != String.Empty)
                {

                    String[] arr = str1.Split(' ');

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].Length == n) textBox3.AppendText(arr[i] + " ");
                    }

                }
                sR.Close();
                fileStream.Close();
            }
        }

        private bool Сheck(String s)
        {
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsDigit(arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void FilterButton2(object sender, EventArgs e)
        {
            if(textBox4.Text != "" && Сheck(textBox4.Text))
            {
                int n1 = Convert.ToInt32(textBox4.Text);
                String str2 = String.Empty;
                FileStream fileStream1 = new FileStream(PATH2, FileMode.Open);
                StreamReader sR2 = new StreamReader(fileStream1);
                while ((str2 = sR2.ReadLine()) != null && str2 != String.Empty)
                {
                    if (str2.Length > n1) File.AppendAllText(PATH3, str2 + Environment.NewLine);
                }
                sR2.Close();
                fileStream1.Close();

                textBox5.Text = File.ReadAllText(PATH3);
            }
        }
    }
}
