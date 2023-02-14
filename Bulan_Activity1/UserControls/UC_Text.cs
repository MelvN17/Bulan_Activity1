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
namespace Bulan_Activity1.UserControls
{
    public partial class UC_Text : UserControl
    {
        public UC_Text()
        {
            InitializeComponent();
        }

        Form2 form = new Form2();

        //button handlers
        public void encryptBtn_Click(object sender, EventArgs e)
        {
            
            guna2TextBox3.Text = encryptReturn(guna2TextBox1.Text, guna2TextBox2.Text);
            guna2TextBox4.Clear();
            form.label = "The text  has been encrypted!";
            form.ShowDialog();
            
            return;

        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            guna2TextBox4.Text = decryptReturn(guna2TextBox3.Text, guna2TextBox2.Text);
            form.label = "The text  has been decrypted!";
            form.ShowDialog();

            return;
        }


        //extra methods
        public static string encryptReturn(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public static string decryptReturn(string input, string key)
        {
            return Cipher(input, key, false);
        }

        // Vigenère Cipher encryption/decryption algorithm 
        private static string Cipher(string input, string key, bool encipher)
        {
            
            foreach (char c in key)
                if (!char.IsLetter(c))
                    return null;

            string output = string.Empty;
            int keyIndex = 0;

            foreach (char c in input)
            {
                
                if (char.IsLetter(c))
                {
                    int offset = char.IsUpper(c) ? 'A' : 'a';
                    int k = char.ToUpper(key[keyIndex]) - 'A';
                    k = encipher ? k : -k;
                    char ch = (char)(((c + k - offset) % 26 + 26) % 26 + offset);
                    output += ch;
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    output += c;
                }
            }

            return output;
        }

    }
}
