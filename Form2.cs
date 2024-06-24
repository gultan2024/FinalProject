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
      
        
        Form3 form3 = null;
         public  Dictionary<string,UserProduct> userList = new Dictionary<string, UserProduct>();
     

        public Form2()
        {
            InitializeComponent();
            button2.Hide();
            button4.Hide(); 
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
            form3.button1.Text = "Yadda saxla";
            form3.button1.Name = "update";

            form3.ShowDialog();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            button2.Show();
            button4.Show();


        }
        
        private void dataGridView1_CellContent(object sender, DataGridViewCellEventArgs e)
        {
            //this.Text += " cccccc " + dataGridView1.SelectedRows[0].Cells["ID"].Value;
            dataGridView1.CurrentRow.Selected = true;

        }

        


        internal void Form2_Load(object sender, EventArgs e)
        {
           
               Program.form1.userProduct.get_add_update_delete(10,null,-1);
            if (userList.Count > 0)
            {
                dataGridView1.DataSource= userList.Values.ToList();
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["ROLE_ID"].Visible = false;
            }
            Program.form1.Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int rowIndex = (int)dataGridView1.CurrentCell.RowIndex;
            int userID = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;
            button4.Text = userID.ToString();
            Program.form1.userProduct.get_add_update_delete(13,null,userID);
           this.Form2_Load(null, null);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
          
            Program.form1.Visible = true;
            this.Hide();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
