using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Program.form1.userProductManager.productList.Clear();
            Program.form1.userProductManager.get_add_update_delete(20);
            listBox1.DataSource = Program.form1.userProductManager.productList.Values.ToList();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }     

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
