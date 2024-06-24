using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class Form4 : Form
    {
        Form5 form5 = null;
        public  List<UserProduct> userProductList = new List<UserProduct>();

        public Form4()
        {
            InitializeComponent();
           
            label1.Text = "Toplam Qiymуеt";
            label2.Text = "Balans";

         

            button4.Text = "Balansı dəyiş";
            textBox1.ReadOnly = true;
          
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (form5 == null)
            {
                form5 = new Form5();
            }
          //  form5.button1.Name = "Səbətə əlavə et";
            form5.button1.Text = "Səbətə əlavə et";
            form5.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Program.form1.userProduct.get_add_update_delete(30, null, -1);
            if (userProductList.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = userProductList;
            
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["ROLE_ID"].Visible = false;
                dataGridView1.Columns["ROLE_NAME"].Visible = false;
                dataGridView1.Columns["P_ID"].Visible = false;
                dataGridView1.Columns["UP_ID"].Visible = false;
               
                dataGridView1.Columns["UP_ACTIVE"].HeaderText = "Status";
                dataGridView1.Columns["UP_ACTIVE_NAME"].HeaderText = "Status";

                getUserBalance();
            }
            //Program.form1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getUserBalance() {

            Program.form1.userProduct.get_update_userBalance(1);
            textBox1.Text = Program.form1.userProduct.UP_TOTAL_PRICE.ToString();
            textBox2.Text = Program.form1.userProduct.BALANCE.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int balance)) {
                Program.form1.userProduct.BALANCE = balance;
                Program.form1.userProduct.get_update_userBalance(2);
                getUserBalance();
                MessageBox.Show("Balans dəyişdi!");
            }
           
        }

     
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
