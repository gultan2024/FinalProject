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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            label1.Text = "Mehsulun adı";
            label2.Text = "Mehsulun sayı";
            label3.Text = "Mehsulun qiyməti";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (button1.Name == "update")
            {
                int ID = (int)Program.form1.form2.dataGridView2.SelectedRows[0].Cells["ID"].Value;
                textBox1.Text = Program.form1.form2.dataGridView2.SelectedRows[0].Cells["NAME"].Value.ToString();
                textBox2.Text = Program.form1.form2.dataGridView2.SelectedRows[0].Cells["COUNT"].Value.ToString();
                textBox3.Text = Program.form1.form2.dataGridView2.SelectedRows[0].Cells["PRICE"].Value.ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.form1.userProductManager.userList.ContainsKey(textBox1.Text))
            {

                MessageBox.Show("Bu məhsul adı sistemdə mövcuddur!");
            }
            else
            {
                if (int.TryParse(textBox2.Text, out int price) & (int.TryParse(textBox3.Text, out int count)))
                {
                    if (button1.Name == "insert")
                    {
                        Program.form1.userProductManager.get_add_update_delete(21);
                    }
                    else if (button1.Name == "update")
                    {

                        Program.form1.userProductManager.get_add_update_delete(22);
                    }

                    this.Hide();
                    Program.form1.form2.Form2_Load(sender, e);
                }
                else 
                
                { 
                    MessageBox.Show("Məhsulun sayı və ya qiyməti doğru göstərilməyib!"); 
                
                }


            }
        }

        
    }
}
