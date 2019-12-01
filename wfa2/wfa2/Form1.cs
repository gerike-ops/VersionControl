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
using wfa2.Entities;

namespace wfa2
{
    public partial class Form1 : Form
    {
        BindingList<usher> users = new BindingList<usher>();

        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName; 
            
            btnAdd.Text = Resource1.Add;
            writebtn.Text = Resource1.write;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new usher();
            u.FullName = textBox1.Text;
           

            users.Add(u);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Writebtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (.csv)|.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var item in users)
                {
                    sw.Write(item.ID);
                    sw.Write(";");
                    sw.Write(item.FullName);
                    sw.WriteLine();
                }
            }
        }
    }
}
