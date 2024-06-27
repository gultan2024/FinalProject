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
       public Form5 form5 = null;


        public Form4()
        {
            InitializeComponent();
           
            label1.Text = "Toplam Qiymуеt";
            label2.Text = "Balans";

         

            button4.Text = "Balansı dəyiş";
          //  textBox1.ReadOnly = true;
          
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
            form5.button1.Name = "insert";
            form5.button1.Text = "Sebete elave et";
         
            form5.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (form5 == null)
            {
                form5 = new Form5();
            }
            form5.button1.Name = "update";
            form5.button1.Text = "Alisi sonlandir";

            form5.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Program.form1.userProductManager.get_add_update_delete(30);
     
            if (Program.form1.userProductManager.userProductList.Count > 0)
            {
               // dataGridView1.DataSource = null;
                dataGridView1.DataSource = Program.form1.userProductManager.userProductList;

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["U_ID"].Visible = false;
          //      dataGridView1.Columns["ROLE_ID"].Visible = false;
           //     dataGridView1.Columns["ROLE_NAME"].Visible = false;
                dataGridView1.Columns["P_ID"].Visible = false;
                dataGridView1.Columns["ACTIVE"].Visible = false;
              


                dataGridView1.Columns["ACTIVE_NAME"].HeaderText = "Alısın statusu";

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

            Program.form1.userProductManager.get_update_userBalance(1);
            textBox1.Text = Program.form1.userProductManager.loginUser.TOTAL_PRICE.ToString();
            textBox2.Text = Program.form1.userProductManager.loginUser.BALANCE.ToString();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int balance)) 
            {
                Program.form1.userProductManager.loginUser.BALANCE = balance;
                Program.form1.userProductManager.get_update_userBalance(2);
                getUserBalance();
                MessageBox.Show("Balans dəyişdi!");
            }
           
        }


     
    }
}
