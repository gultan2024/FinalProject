using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{using Entities;
    public partial class Form1 : Form
    {
        public Form2 form2  = null;
        public Form4 form4  = null;
        public UserProduct userProduct=new UserProduct();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            userProduct.getUserForLogin(textBox1.Text, textBox1.Text);


            if (userProduct.USER_NAME == null) {

                MessageBox.Show(" İstifadəci adı və ya Parol yalnışdır! ");
            }
            else
            {
                if (userProduct.ROLE_ID == 1) 
                {
                    if (form2 == null) { form2 = new Form2(); }
          
                    form2.ShowDialog();
                }else
                {
                    if (form4 == null) { form4 = new Form4(); }

                    form4.ShowDialog();
                }

                /*

                textBox1.Text = "";
                textBox2.Text = "";*/
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
