using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject.Entities
{
    public class UserProduct
    {
        //
        public UserProduct() { }


        // user entity
        public int ID { get; set; }
        public string NAME { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public int BALANCE { get; set; }
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }




        // Product entity
        public int P_ID { get; set; }
        public string P_NAME { get; set; }
        public int P_COUNT { get; set; }
        public int P_PRICE { get; set; }




        //userProduct entity

        public int UP_ID { get; set; }
        public int UP_COUNT { get; set; }
        public int UP_ACTIVE { get; set; }
    
       // 
        public string UP_OPERATION_DATE { get; set; }
        public int UP_PRICE { get; set; }
        public int UP_TOTAL_PRICE { get; set; }
        public string UP_ACTIVE_NAME { get; set; }


        
      






        public void get_add_update_delete(byte operType, UserProduct user, int id)
        {

            byte res = 0;

            try
            {
                using (var connection = new SqlConnection("Server=LAPTOP-4S71K1KD; Database=FINAL_PROJECT;Trusted_Connection=True;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    if (operType <=10)
                    {
                        // Admin user operations ==============================================================================================
                        if(operType >= 10 & operType <20)
                        {
                            cmd.CommandText = "SELECT U.ID,U.NAME NAME,BALANCE ,USER_NAME,PASSWORD ,R.ID ROLE_ID ,R.NAME ROLE_NAME  FROM USERS U, ROLE R WHERE U.FK_ROLE_ID=R.ID AND U.ACTIVE=1";


                            var dataReader = cmd.ExecuteReader();
                            Program.form1.form2.userList.Clear();
                            while (dataReader.Read())
                            {
                                Program.form1.form2.userList.Add(dataReader.GetString(3), new UserProduct()
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
                                    cmd.CommandText = "UPDATE  USERS SET ROLL_ID=@ROLL_ID,NAME=@NAME, USER_NAME=@USER_NAME, PASSWORD=@PASSWORD,  WHERE id=@ID";

                                }

                                cmd.Parameters.Add(new SqlParameter("@ROLE_ID", user.ROLE_ID));
                                cmd.Parameters.Add(new SqlParameter("@NAME", user.NAME));
                                cmd.Parameters.Add(new SqlParameter("@USER_NAME", user.USER_NAME));
                                cmd.Parameters.Add(new SqlParameter("@PASSWORD", user.PASSWORD));
                            }



                            var dataReader = cmd.ExecuteNonQuery();
                        }
                    }
                    else if(operType>=20& operType <30)
                    {
                        // Admin operations ==============================================================================================
                        if (operType == 20)
                        {
                            cmd.CommandText = "SELECT U.ID,U.NAME NAME,BALANCE ,USER_NAME,PASSWORD ,R.ID ROLE_ID ,R.NAME ROLE_NAME  FROM USERS U, ROLE R WHERE U.FK_ROLE_ID=R.ID AND U.ACTIVE=1";


                            var dataReader = cmd.ExecuteReader();
                            Program.form1.form2.userList.Clear();
                            while (dataReader.Read())
                            {
                                Program.form1.form2.userList.Add(dataReader.GetString(3), new UserProduct()
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
                            if (operType == 23)
                            {
                                cmd.CommandText = "UPDATE  USERS SET ACTIVE=0 WHERE id=@ID";
                                cmd.Parameters.Add(new SqlParameter("@ID", id));

                            }
                            else
                            {
                                if (operType == 21)
                                {
                                    cmd.CommandText = "insert into users (FK_ROLE_ID,NAME,USER_NAME,PASSWORD) values (@FK_ROLE_ID,@NAME,@USER_NAME,@PASSWORD)";

                                }
                                else if (operType == 22)
                                {
                                    cmd.CommandText = "UPDATE  USERS SET ROLL_ID=@ROLL_ID,NAME=@NAME, USER_NAME=@USER_NAME, PASSWORD=@PASSWORD,  WHERE id=@ID";

                                }

                                cmd.Parameters.Add(new SqlParameter("@FK_ROLE_ID", user.ROLE_ID));
                                cmd.Parameters.Add(new SqlParameter("@NAME", user.NAME));
                                cmd.Parameters.Add(new SqlParameter("@USER_NAME", user.USER_NAME));
                                cmd.Parameters.Add(new SqlParameter("@PASSWORD", user.PASSWORD));
                            }



                            var dataReader = cmd.ExecuteNonQuery();
                        }
                    }
                    else if (operType >=30)
                    {
                        // User operations ==============================================================================================


                        if (operType == 30)
                        {
                            cmd.CommandText = "SELECT UP.ID UP_ID, UP.COUNT UP_COUNT, P.ID P_ID ,P.NAME P_NAME, P.PRICE P_PRICE, P.COUNT P_COUNT,U.ID ,U.NAME ,UP.ACTIVE UP_ACTIVE, UP_ACTIVE_NAME=case UP.ACTIVE  when 2 then  'Sonlanmis alıs' else 'Sebet' end, UP.COUNT*P.PRICE UP_PRICE,  CONVERT(nvarchar,UP.OPERATION_DATE) UP_OPERATION_DATE  FROM USERS U ,   PRODUCTS P,   USER_PRODUCTS UP   WHERE   UP.FK_USER_ID=U.ID AND   UP.FK_PRODUCT_ID=P.ID AND   UP.ACTIVE<>0 AND   P.ACTIVE=1 AND   U.ACTIVE=1 and u.ID=@ID ORDER BY OPERATION_DATE DESC";
                            cmd.Parameters.Add(new SqlParameter("@ID", Program.form1.userProduct.ID));
                            var dataReader = cmd.ExecuteReader();
                            Program.form1.form4.userProductList.Clear();
                            while (dataReader.Read())
                            {
                                Program.form1.form4.
                                    userProductList.Add(new UserProduct()
                                    {

                                        UP_ID = dataReader.GetInt32(0),
                                        UP_COUNT = dataReader.GetInt32(1),

                                        P_ID = dataReader.GetInt32(2),
                                        P_NAME = dataReader.GetString(3),
                                        P_PRICE = dataReader.GetInt32(4),
                                        P_COUNT = dataReader.GetInt32(5),


                                        ID = dataReader.GetInt32(6),
                                        NAME = dataReader.GetString(7),
                                      //  BALANCE = dataReader.GetInt32(8),

                                        UP_ACTIVE = dataReader.GetInt32(8),
                                        UP_ACTIVE_NAME = dataReader.GetString(9),
                                        UP_PRICE = dataReader.GetInt32(10),
                                        UP_OPERATION_DATE = dataReader.GetString(11)
                                    }) ;

                            }
                        }
                        else
                        {
                            if (operType == 33)
                            {
                                cmd.CommandText = "UPDATE  USER_PRODUCTS SET ACTIVE=0 WHERE id=@ID";
                                cmd.Parameters.Add(new SqlParameter("@ID", id));

                            }
                            else
                            {
                                if (operType == 31)
                                {
                                    cmd.CommandText = "İNSERT into USER_PRODUCTS (FK_ROLE_ID,NAME,USER_NAME,PASSWORD) values (@FK_ROLE_ID,@NAME,@USER_NAME,@PASSWORD)";

                                }
                                else if (operType == 32)
                                {
                                    cmd.CommandText = "UPDATE  USERS SET ROLL_ID=@ROLL_ID,NAME=@NAME, USER_NAME=@USER_NAME, PASSWORD=@PASSWORD,  WHERE id=@ID";

                                }

                                cmd.Parameters.Add(new SqlParameter("@FK_ROLE_ID", user.ROLE_ID));
                                cmd.Parameters.Add(new SqlParameter("@NAME", user.NAME));
                                cmd.Parameters.Add(new SqlParameter("@USER_NAME", user.USER_NAME));
                                cmd.Parameters.Add(new SqlParameter("@PASSWORD", user.PASSWORD));
                            }



                            var dataReader = cmd.ExecuteNonQuery();
                        }

                    }
                      connection.Close();

                }


            }
            catch (Exception ex) { throw; }

        }

        public void getUserProducstTotalPrice(int id) {
            try
            {
                using (var connection = new SqlConnection("Server=LAPTOP-4S71K1KD; Database=FINAL_PROJECT;Trusted_Connection=True;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT U.ID,U.NAME NAME ,USER_NAME,PASSWORD ,R.ID ROLE_ID ,R.NAME ROLE_NAME  FROM USERS U, ROLE R WHERE U.FK_ROLE_ID=R.ID AND U.ACTIVE=1 and USER_NAME=@USER_NAME and U.PASSWORD=@PASSWORD ";

                  //  cmd.Parameters.Add(new SqlParameter("@USER_NAME", userName));
                    //cmd.Parameters.Add(new SqlParameter("@PASSWORD", password));


                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        Program.form1.userProduct = new UserProduct()
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



        public void get_update_userBalance(int operType) {

            try
            {
                using (var connection = new SqlConnection("Server=LAPTOP-4S71K1KD; Database=FINAL_PROJECT;Trusted_Connection=True;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    if (operType == 1)
                    {
                        cmd.CommandText = "SELECT BALANCE, SUM(UP.COUNT*P.PRICE) UP_TOTAL_PRICE  from USERS U,PRODUCTS P,USER_PRODUCTS UP WHERE  U.ID= UP.FK_USER_ID AND P.ID=UP.FK_PRODUCT_ID AND U.ID=1 AND   UP.ACTIVE=1 AND   P.ACTIVE=1  GROUP BY BALANCE";

                        cmd.Parameters.Add(new SqlParameter("@ID", Program.form1.userProduct.ID));

                        var dataReader = cmd.ExecuteReader();
                        dataReader.Read();
                           
                            Program.form1.userProduct.BALANCE = dataReader.GetInt32(0);
                            Program.form1.userProduct.UP_TOTAL_PRICE = dataReader.GetInt32(1);

                      
                    } else  if (operType==2)
                    {
                        cmd.CommandText = "UPDATE USERS  SET BALANCE=@BALANCE WHERE ID=@ID";
                       
                        cmd.Parameters.Add(new SqlParameter("@ID", Program.form1.userProduct.ID));
                       
                        cmd.Parameters.Add(new SqlParameter("@BALANCE", Program.form1.userProduct.BALANCE));

                        var dataReader = cmd.ExecuteNonQuery();

                    }
                   
                    connection.Close();
                }             

            }
            catch (Exception ex) { throw; }

        }
       
        
        
        
        public  void getUserForLogin(string userName,string password)
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
                       Program.form1.userProduct =  new UserProduct()
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

