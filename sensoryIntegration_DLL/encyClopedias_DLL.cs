using sensoryIntegration_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntegration_DLL
{
    public class encyClopedias_DLL
    {


        public int InsertNews(encyClopedias_Model encyClopedias)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] {
                new SqlParameter("@ID",encyClopedias.ID),
                new SqlParameter("@htmlTxt",encyClopedias.htmlTxt),
                new SqlParameter("@createTime",encyClopedias.createTime),
                new SqlParameter("@IsDelete",encyClopedias.IsDelete),
                new SqlParameter("@newsID",encyClopedias.newsID)
            };
            string sqlStr = "INSERT INTO [dbo].[Encyclopedias]([ID], [htmlTxt], [createTime], [IsDelete], [newsID]) VALUES (@ID, @htmlTxt, @createTime, @IsDelete, @newsID);";
            return SQLHelper.ExecuteNonQuery(sqlStr, sqlParameter);
        }

        public DataTable GetEncyClopedias(encyClopedias_Model encyClopedias)
        {
            string sqlStr = "SELECT ID,htmlTxt,createTime,IsDelete from Encyclopedias WHERE IsDelete = '0'";
            if (!string.IsNullOrWhiteSpace(encyClopedias.ID))
            {
                sqlStr += " and ID = '"+encyClopedias.ID+"'";
            }
            if (!string.IsNullOrWhiteSpace(encyClopedias.newsID))
            {
                sqlStr += " and newsID = '" + encyClopedias.newsID + "'";
            }

            return SQLHelper.ExecuteDataTable(sqlStr);
        }





    }
}
