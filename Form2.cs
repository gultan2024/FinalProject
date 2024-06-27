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

namespace FinalProject
{
    public partial class Form2 : Form
    {
        public Form3 form3 = null;
        public Form6 form6 = null;

             public Form2()
        {
            InitializeComponent();
          
            button2.Hide();
            button4.Hide();

            button6.Hide();
            button7.Hide();
        }
      
        
        internal void Form2_Load(object sender, EventArgs e)
        {
            Program.form1.userProductManager.userList.Clear();
            Program.form1.userProductManager.productList.Clear();

            Program.form1.userProductManager.get_add_update_delete(10);
            Program.form1.userProductManager.get_add_update_delete(20);
           
            if (Program.form1.userProductManager.userList.Count > 0)
            {
                dataGridView1.DataSource = Program.form1.userProductManager.userList.Values.ToList();
              //  dataGridView1.Columns["ID"].Visible = false;
              //  dataGridView1.Columns["ROLE_ID"].Visible = false;
            }
       
            if (Program.form1.userProductManager.productList.Count > 0)
            {
                dataGridView2.DataSource = Program.form1.userProductManager.productList.Values.ToList();
            }
            Program.form1.Visible = false;

        }
      
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            button2.Show();
            button4.Show();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
          
            button6.Show();
            button7.Show();
        }


     
        private void button1_Click(object sender, EventArgs e)
        {
            if (form3 == null)
            {
                form3 = new Form3();
            }
            form3.button1.Name = "insert";
            form3.button1.Text = "Əlavə et";
            form3.ShowDialog();
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
           if (form3 == null)
            {
                form3 = new Form3();
            }
            form3.button1.Name = "update";
            form3.button1.Text = "Yadda saxla";
            form3.ShowDialog();

        }
      

        private void button4_Click(object sender, EventArgs e)
        
        {
            //int rowIndex = (int)dataGridView1.CurrentCell.RowIndex;
            int userID = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
          //  button4.Text = userID.ToString();
            Program.form1.userProductManager.get_add_update_delete(13);
           this.Form2_Load(sender, e);
        }



        //Procuct
   
        private void button5_Click(object sender, EventArgs e)
        
        {
            if (form6 == null)
            {
                form6 = new Form6();
            }
          
            form6.button1.Name = "insert";
            form6.button1.Text = "Əlavə et";
            form6.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (form6 == null)
            {
                form6 = new Form6();
            }

            form6.button1.Name = "update";
            form6.button1.Text = "Yadda saxla";
            form6.ShowDialog();
        }
    

        private void button7_Click(object sender, EventArgs e)
        {
            //int rowIndex = (int)dataGridView1.CurrentCell.RowIndex;
          
           // button4.Text = productId.ToString();
            Program.form1.userProductManager.get_add_update_delete(23);
            this.Form2_Load(sender, e);
        }
     
        private void button8_Click(object sender, EventArgs e)
        {
            Program.form1.Visible = true;
            this.Hide();
        }



    }
}
