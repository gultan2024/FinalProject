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
        public UserProductManager userProductManager=new UserProductManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           userProductManager.getUserForLogin(textBox1.Text, textBox2.Text);


            if (userProductManager.loginUser.USER_NAME == null) 
            {

                MessageBox.Show(" İstifadəci adı və ya Parol yalnışdır! ");
            }
            else
            {
                if (userProductManager.loginUser.ROLE_ID == 1) 
                {
                    if (form2 == null) { form2 = new Form2(); }
          
                    form2.ShowDialog();
                }
                else
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
