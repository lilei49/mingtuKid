using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntrgration_Util
{
    public class CommonUtil
    {

        /// <summary>
        /// 生成数据库ID
        /// </summary>
        /// <returns></returns>
        public static string GetID()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }

        public static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            List<T> ts = new List<T>();
            string tempName = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    tempName = property.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        object value = dr[tempName];
                        if (value !=DBNull.Value)
                        {
                            property.SetValue(t, value, null);
                        }
                    }
                }
                ts.Add(t);
            }
            return ts;
        }

    }
}
