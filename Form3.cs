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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class Form3 : Form
    {

        UserProductManager upm = new UserProductManager();






        public Form3()
        {
            InitializeComponent();

                Dictionary<byte, string> dictCombo  = new Dictionary<byte, string>();
                dictCombo.Add(1, "Admin");
                dictCombo.Add(2, "User");

                comboBox1.DataSource = new BindingSource(dictCombo, null);
               //comboBox1.Items.Add(dictCombo);
           
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
              
            
        }

    


        private void button1_Click(object sender, EventArgs e)
        
        {
            if (Program.form1.userProductManager.userList.ContainsKey(textBox3.Text))
            {
              
                MessageBox.Show("Bu istifadəçi adı sistemdə mövcuddur!");
            }
            else
            {
               
                if (button1.Name == "insert")
                {
                    Program.form1.userProductManager.get_add_update_delete(11);
                }
                
                else if (button1.Name == "update")
                
                {
                 string userNmeGrid=(string)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["USER_NAME"].Value;               
                 
                    Program.form1.userProductManager.get_add_update_delete(12);
                }
               
                    Program.form1.form2.Form2_Load(sender, e);
                this.Hide();

            }
        

        }

      
        public void Form3_Load(object sender, EventArgs e)
        {
          
            if (button1.Name == "update")
            {
                 comboBox1.SelectedIndex = (int)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["ROLE_ID"].Value-1;
                textBox2.Text = (string)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["NAME"].Value;
                textBox3.Text = (string)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["USER_NAME"].Value;
                textBox4.Text = (string)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["PASSWORD"].Value;
            }
            else {

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
           
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  byte key= ((KeyValuePair<byte, string>)comboBox1.SelectedItem).Key; MessageBox.Show(key.ToString()) ;

         //  

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
