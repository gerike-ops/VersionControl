using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            lblLastName.Text = Resource1.LastName; 
            lblFirstName.Text = Resource1.FirstName; 
            btnAdd.Text = Resource1.Add;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new usher();
            u.LastName = textBox1.Text;
            u.FirstName = textBox2.Text;

            users.Add(u);

        }
    }
}
