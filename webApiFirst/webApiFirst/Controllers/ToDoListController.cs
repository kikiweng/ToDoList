using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace webApiFirst.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class ToDoListController : ApiController
    {      
        //打某隻 post api 可以新增一個 todo 事件。
        public string Post(string itemName)
        {
            string mesg = "";
            MySqlConnection conn = dbConnect();
            string insertSql = "INSERT INTO list (listName) VALUES ('"+itemName+"')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                cmd.ExecuteNonQuery();
                mesg = itemName;
            }catch(Exception ex)
            {
                mesg = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return mesg;
        }

        //打某隻 get api 可以取得所有的 todo 事件
        public string Get()
        {
            string mesg = "";
            MySqlConnection conn = dbConnect();
            string selectSql = "SELECT * FROM list WHERE delTime IS NULL ";
            try
            {
                MySqlCommand cmd = new MySqlCommand(selectSql, conn);
                cmd.ExecuteNonQuery();
                mesg = "select success";
            }
            catch (Exception ex)
            {
                mesg = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return mesg;
        }


        // 打某隻 delete api 可以移除某個 todo 事件。
        //update delTime
        public string Delete(string listNo)
        {
            string mesg = "";
            string sysTime = DateTime.Now.ToString("yyyy/MM/dd");
            MySqlConnection conn = dbConnect();
            string updateSql = "UPDATE list SET delTime = '"+sysTime+"' WHERE listNo = '"+listNo+"'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(updateSql, conn);
                cmd.ExecuteNonQuery();
                mesg = "delete success";
            }
            catch (Exception ex)
            {
                mesg = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return mesg;
        }


        public string Put(string listNo,string newListName)
        {
            string mesg = "";        
            MySqlConnection conn = dbConnect();
            string updateSql = "UPDATE list SET listName = '" + newListName + "' WHERE listNo = '" + listNo + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(updateSql, conn);
                cmd.ExecuteNonQuery();
                mesg = "update success";
            }
            catch (Exception ex)
            {
                mesg = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return mesg;
        }




        //DBconnect
        public  MySqlConnection dbConnect()
        {
            string dbHost = "166.62.30.147";
            string dbUser = "chichi";
            string dbPass = "123456789";
            string dbName = "77Test";

            string mesg = "";
            MySqlConnection conn = new MySqlConnection();
            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                mesg = "dbConnect success";

            }
            catch (Exception ex)
            {
                mesg = ex.ToString();
            }
            return conn;
        } 



    }
}
