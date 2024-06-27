using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject.Entities
{  
     public class User
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
    
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }


        public int BALANCE { get; set; }
        public int TOTAL_PRICE { get; set; }
    }

         public  class Product

    {

        public int ID { get; set; }
        public string NAME { get; set; }
        public int COUNT { get; set; }
        public int PRICE { get; set; }

    }

    public class UserProduct
    {

        public int ID { get; set; }
        public int COUNT { get; set; }
       
        public int U_ID { get; set; }
        public string U_NAME { get; set; }
            
           
        public int P_ID { get; set; }
        public string P_NAME { get; set; }
        public int P_COUNT { get; set; }
        public int P_PRICE { get; set; }

     
       
        public int ACTIVE { get; set; }

     
        public string OPERATION_DATE { get; set; }
        public int PRICE { get; set; }
     
        public string ACTIVE_NAME { get; set; }


    }


    public class UserProductManager
    {
  

        public User loginUser = null;

         // public Product product { get; set; }
        //  public UserProduct userProduct { get; set; }
      
        public Dictionary<string, User> userList =new Dictionary<string, User>();
        public Dictionary<string,Product> productList=new Dictionary<string,Product>();
        public List<UserProduct> userProductList =new List<UserProduct>();
       
      

        public void get_add_update_delete(byte operType)
        {

            try
            {
                using (var connection = new SqlConnection("Server=LAPTOP-4S71K1KD; Database=FINAL_PROJECT;Trusted_Connection=True;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    if (operType <= 10)
                    {
                        // Admin user operations ==============================================================================================
                        if (operType >= 10 & operType < 20)
                        {
                            cmd.CommandText = "SELECT U.ID,U.NAME NAME,BALANCE ,USER_NAME,PASSWORD ,R.ID ROLE_ID ,R.NAME ROLE_NAME  FROM USERS U, ROLE R WHERE U.FK_ROLE_ID=R.ID AND U.ACTIVE=1";


                            var dataReader = cmd.ExecuteReader();

                            while (dataReader.Read())
                            {
                                    userList.Add(dataReader.GetString(3), new User()
                                {
                                    ID = dataReader.GetInt32(0),
                                    NAME = dataReader.GetString(1),
                                    BALANCE = dataReader.GetInt32(2),
                                    USER_NAME = dataReader.GetString(3),
                                    PASSWORD = dataReader.GetString(4),
                                    ROLE_ID = dataReader.GetInt32(5),
                                    ROLE_NAME = dataReader.GetString(6)
                                });

                            }
                        }
                        else
                        {
                            if (operType == 13)
                            {
                                int id = (int)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["ID"].Value;
                                cmd.CommandText = "UPDATE  USERS SET ACTIVE=0 WHERE id=@ID";
                                cmd.Parameters.Add(new SqlParameter("@ID", id));

                            }
                            else
                            {
                                if (operType == 11)
                                {
                                    cmd.CommandText = "insert into users (FK_ROLE_ID,NAME,USER_NAME,PASSWORD) values (@FK_ROLE_ID,@NAME,@USER_NAME,@PASSWORD)";

                                }
                                else if (operType == 12)
                                {
                                    int id = (int)Program.form1.form2.dataGridView1.SelectedRows[0].Cells["ID"].Value;
                                    cmd.CommandText = "UPDATE  USERS SET ROLL_ID=@ROLL_ID,NAME=@NAME, USER_NAME=@USER_NAME, PASSWORD=@PASSWORD,  WHERE id=@ID";
                                    cmd.Parameters.Add(new SqlParameter("@ID",id));
                                }


                                int key = ((KeyValuePair<byte, string>)Program.form1.form2.form3.comboBox1.SelectedItem).Key;
                                cmd.Parameters.Add(new SqlParameter("@ROLE_ID", key));
                                cmd.Parameters.Add(new SqlParameter("@NAME", Program.form1.form2.form3.textBox3.Text));
                                cmd.Parameters.Add(new SqlParameter("@USER_NAME", Program.form1.form2.form3.textBox4.Text));
                                cmd.Parameters.Add(new SqlParameter("@PASSWORD", Program.form1.form2.form3.textBox4.Text));
                            }



                            var dataReader = cmd.ExecuteNonQuery();
                        }
                    }
                    else if (operType >= 20 & operType < 30)
                    {
                        // Admin operations ==============================================================================================
                        if (operType == 20)
                        {
                            cmd.CommandText = "SELECT P.ID,P.NAME,P.COUNT,P.PRICE  FROM PRODUCTS P WHERE  P.ACTIVE=1";


                            var dataReader = cmd.ExecuteReader();

                            while (dataReader.Read())
                            {
                                Program.form1.userProductManager.productList.Add(dataReader.GetString(1), new Product
                                {
                                    ID = dataReader.GetInt32(0),
                                    NAME = dataReader.GetString(1),
                                    COUNT = dataReader.GetInt32(2),
                                    PRICE = dataReader.GetInt32(3),

                                });

                            }
                        }
                        else
                        {
                            if (operType == 23)
                            {
                                int id = (int)Program.form1.form2.dataGridView2.SelectedRows[0].Cells["ID"].Value;
                                cmd.CommandText = "UPDATE  PRODUCTS SET ACTIVE=0 WHERE id=@ID";
                                cmd.Parameters.Add(new SqlParameter("@ID", id));

                            }
                            else
                            {
                                if (operType == 21)
                                {
                                    cmd.CommandText = "INSERT INTO PRODUCTS(NAME,PRICE,COUNT) VALUES (@NAME,@PRICE,@COUNT)";

                                }
                                else if (operType == 22)
                                {
                                    int id = (int)Program.form1.form2.dataGridView2.SelectedRows[0].Cells["ID"].Value;
                                    cmd.CommandText = "UPDATE  PRODUCTS SET NAME=@NAME ,PRICE=@PRICE,COUNT=@COUNT WHERE id=@ID";
                                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                                }

                                
                               
                                    cmd.Parameters.Add(new SqlParameter("@NAME", Program.form1.form2.form6.textBox1.Text));
                                    cmd.Parameters.Add(new SqlParameter("@PRICE", Program.form1.form2.form6.textBox2.Text));
                                    cmd.Parameters.Add(new SqlParameter("@COUNT", Program.form1.form2.form6.textBox3.Text));

                              
                               
                            }

                            var dataReader = cmd.ExecuteNonQuery();
                        }
                    }
                    else if (operType >= 30&operType < 40)
                    {
                        // User operations ==============================================================================================


                        if (operType == 30)
                        {
                            cmd.CommandText = "SELECT UP.ID ID, UP.COUNT COUNT, P.ID P_ID ,P.NAME P_NAME, P.PRICE P_PRICE, P.COUNT P_COUNT,U.ID U_ID ,U.NAME U_NAME ,UP.ACTIVE ACTIVE, ACTIVE_NAME=case UP.ACTIVE  when 2 then  'Sonlanmis alıs' else 'Sebet' end, UP.COUNT*P.PRICE UP_PRICE,  CONVERT(nvarchar,UP.OPERATION_DATE) UP_OPERATION_DATE  FROM USERS U ,   PRODUCTS P,   USER_PRODUCTS UP   WHERE   UP.FK_USER_ID=U.ID AND   UP.FK_PRODUCT_ID=P.ID AND   UP.ACTIVE<>0 AND   P.ACTIVE=1 AND   U.ACTIVE=1 and u.ID=@ID ORDER BY OPERATION_DATE DESC";
                            cmd.Parameters.Add(new SqlParameter("@ID", loginUser.ID));
                       
                            var dataReader = cmd.ExecuteReader();
                            Program.form1.userProductManager.userProductList.Clear();
                          
                            while (dataReader.Read())
                            {
                                Program.form1.userProductManager.userProductList.Add(new UserProduct()
                                    {

                                        ID = dataReader.GetInt32(0),
                                        COUNT = dataReader.GetInt32(1),

                                        P_ID = dataReader.GetInt32(2),
                                        P_NAME = dataReader.GetString(3),
                                        P_PRICE = dataReader.GetInt32(4),
                                        P_COUNT = dataReader.GetInt32(5),


                                        U_ID = dataReader.GetInt32(6),
                                        U_NAME = dataReader.GetString(7),
                                        //  BALANCE = dataReader.GetInt32(8),

                                        ACTIVE = dataReader.GetInt32(8),
                                        ACTIVE_NAME = dataReader.GetString(9),
                                        PRICE = dataReader.GetInt32(10),
                                        OPERATION_DATE = dataReader.GetString(11)
                                    });

                            }
                        }
                        else
                        {
                            if (operType == 33)
                            {

                                cmd.CommandText = "UPDATE  USER_PRODUCTS SET ACTIVE=0 WHERE id=@ID";
                                cmd.Parameters.Add(new SqlParameter("@ID", 1));

                            }
                            else
                            {
                                if (operType == 31)
                                {
                                    cmd.CommandText = "İNSERT INTO USER_PRODUCTS (FK_USER_ID,FK_PRODUCT_ID,COUNT,ACTIVE) values (@FK_USER_ID,@FK_PRODUCT_ID,@COUNT,@ACTIVE)";

                                }
                                else if (operType == 32)
                                {
                                    cmd.CommandText = "UPDATE  USER_PRODUCTS SET FK_PRODUCT_ID=@FK_PRODUCT_ID,COUNT=@COUNT,ACTIVE=2 WHERE id=@ID";

                                }

                                if (int.TryParse(Program.form1.form2.form3.textBox3.Text, out int count))
                                { 
                                
                                 //   cmd.Parameters.Add(new SqlParameter("@FK_PRODUCT_ID", Program.form1.form4.form5.listBox1.SelectedItem.Text));
                                    cmd.Parameters.Add(new SqlParameter("@COUNT", Program.form1.form4.form5.textBox1.Text));

                                }
                            }



                            var dataReader = cmd.ExecuteNonQuery();
                        }

                    }
                    connection.Close();

                }


            }
            catch (Exception ex) { throw; }

        }




        public void get_update_userBalance(int operType)
        {

            try
            {
                using (var connection = new SqlConnection("Server=LAPTOP-4S71K1KD; Database=FINAL_PROJECT;Trusted_Connection=True;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    if (operType == 1)
                    {
                        cmd.CommandText = "SELECT BALANCE, SUM(UP.COUNT*P.PRICE) UP_TOTAL_PRICE  from USERS U,PRODUCTS P,USER_PRODUCTS UP WHERE  U.ID= UP.FK_USER_ID AND P.ID=UP.FK_PRODUCT_ID AND U.ID=@ID AND   UP.ACTIVE=1 AND   P.ACTIVE=1  GROUP BY BALANCE";

                        cmd.Parameters.Add(new SqlParameter("@ID", Program.form1.userProductManager.loginUser.ID));

                        var dataReader = cmd.ExecuteReader();
                        dataReader.Read();
                        Program.form1.userProductManager.loginUser.BALANCE = dataReader.GetInt32(0);
                        Program.form1.userProductManager.loginUser.TOTAL_PRICE = dataReader.GetInt32(1);


                    }
                    else if (operType == 2)
                    {
                        cmd.CommandText = "UPDATE USERS  SET BALANCE=@BALANCE WHERE ID=@ID";

                        cmd.Parameters.Add(new SqlParameter("@ID", Program.form1.userProductManager.loginUser.ID));

                        cmd.Parameters.Add(new SqlParameter("@BALANCE", Program.form1.userProductManager.loginUser.BALANCE));

                        var dataReader = cmd.ExecuteNonQuery();

                    }

                    connection.Close();
                }

            }
            catch (Exception ex) { throw; }

        }




        public void getUserForLogin(string userName, string password)
        {
            try
            {
                using (var connection = new SqlConnection("Server=LAPTOP-4S71K1KD; Database=FINAL_PROJECT;Trusted_Connection=True;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT U.ID,U.NAME NAME ,USER_NAME,PASSWORD ,R.ID ROLE_ID ,R.NAME ROLE_NAME  FROM USERS U, ROLE R WHERE U.FK_ROLE_ID=R.ID AND U.ACTIVE=1 and USER_NAME=@USER_NAME and U.PASSWORD=@PASSWORD ";

                    cmd.Parameters.Add(new SqlParameter("@USER_NAME", userName));
                    cmd.Parameters.Add(new SqlParameter("@PASSWORD", password));


                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        Program.form1.userProductManager.loginUser=new User()
                        {
                            ID = dataReader.GetInt32(0),
                            NAME = dataReader.GetString(1),
                            USER_NAME = dataReader.GetString(2),
                            PASSWORD = dataReader.GetString(3),
                            ROLE_ID = dataReader.GetInt32(4),
                            ROLE_NAME = dataReader.GetString(5)
                        };

                    }



                }

            }
            catch (Exception ex) { throw; }



        }
    }
}

