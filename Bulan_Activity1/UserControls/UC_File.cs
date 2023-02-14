using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulan_Activity1.UserControls
{
    public partial class UC_File : UserControl
    {
        string file = "";
        Form2 form = new Form2();

        public UC_File()
        {
            InitializeComponent();
        }

        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        //open file dialog | shows the filename on textbox
        private void button3_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    guna2TextBox1.Text = file; // for full location
                  
                }
                catch (IOException)
                {
                }
            }
        }

       public string key = "KEY";

        //button handlers
        private void encryptBtn_Click(object sender, EventArgs e)
        {
            form.label = "The file has been encrypted!";
            form.ShowDialog();

            
            cipherAlgorithm(key, true);


        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {

            form.label = "The file  has been decrypted!";
            form.ShowDialog();

            cipherAlgorithm(key, false);
        }

        
        private void cipherAlgorithm(String key, bool encrypt)
        {
            FileStream file = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[file.Length];

            for (int x = 0; x < temp.Length; x++)
            {
                temp[x] = file.ReadByte();
            }
            file.Close();

            int keyIndex = 0;

            // Vigenère Cipher encryption/decryption algorithm
           
                for (int x = 0; x < temp.Length; x++)
                {
                    if (!encrypt)
                        temp[x] = (temp[x] - key[keyIndex]) % 256; //Decrypt
                    else
                        temp[x] = (temp[x] + key[keyIndex]) % 256; //Encrypt
                    keyIndex = (keyIndex + 1) % key.Length;
                }
            

            file = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);

            for (int x = 0; x < temp.Length; x++)
            {
                file.WriteByte((byte)temp[x]);
            }
            file.Close();
        }
       
    }
}
