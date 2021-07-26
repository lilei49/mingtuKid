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
    public class newsInfo_DLL
    {

        public int InsertNewsInfo(newsInfo newsInfo)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] {
                new SqlParameter("@ID",newsInfo.ID),
                new SqlParameter("@title",newsInfo.title),
                new SqlParameter("@remark",newsInfo.remark),
                new SqlParameter("@imageUrl",newsInfo.imageUrl),
                new SqlParameter("@createTime",newsInfo.createTime),
                new SqlParameter("@IsDelete",newsInfo.IsDelete),
                new SqlParameter("@defaultImageUrl",newsInfo.defaultImageUrl)
            };
            string sqlStr = "INSERT INTO [dbo].[newsInfo]([ID], [title], [remark], [imageUrl], [createTime], [IsDelete], [defaultImageUrl]) VALUES (@ID, @title, @remark, @imageUrl, @createTime, @IsDelete, @defaultImageUrl);";
            return SQLHelper.ExecuteNonQuery(sqlStr, sqlParameter);
        }

        public DataTable GetNewsInfo(newsInfo newsInfo)
        {
            string sqlStr = "select ID,title,remark,imageUrl,defaultImageUrl from newsInfo where isDelete = '0'";
            if (!string.IsNullOrWhiteSpace(newsInfo.ID))
            {
                sqlStr += " and ID = '" + newsInfo.ID + "'";
            }
            return SQLHelper.ExecuteDataTable(sqlStr);
        }


    }
}
