using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntegration_DLL
{
    public class SQLHelper
    {
        private static string getSqlConnectionStr()
        {
            return ConfigurationManager.ConnectionStrings["sqlconnectionString"].ConnectionString;
        }


        //适合增删改操作，返回影响条数
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(getSqlConnectionStr()))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = sql;
                        comm.Parameters.AddRange(parameters);
                        return comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (conn != null && conn.State != ConnectionState.Closed)
                            conn.Close();
                    }

                }
            }
        }
        //查询操作，返回查询结果中的第一行第一列的值
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(getSqlConnectionStr()))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = sql;
                        comm.Parameters.AddRange(parameters);
                        return comm.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (conn != null && conn.State != ConnectionState.Closed)
                            conn.Close();
                    }
                }
            }
        }
        //Adapter调整，查询操作，返回DataTable
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, getSqlConnectionStr()))
            {
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(parameters);
                adapter.Fill(dt);
                return dt;
            }
        }

        public static SqlDataReader ExecuteReader(string sqlText, params SqlParameter[] parameters)
        {
            //SqlDataReader要求，它读取数据的时候有，它独占它的SqlConnection对象，而且SqlConnection必须是Open状态
            SqlConnection conn = new SqlConnection(getSqlConnectionStr());//不要释放连接，因为后面还需要连接打开状态
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            //CommandBehavior.CloseConnection当SqlDataReader释放的时候，顺便把SqlConnection对象也释放掉
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
