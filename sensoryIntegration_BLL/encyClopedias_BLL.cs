using sensoryIntegration_DLL;
using sensoryIntegration_Model;
using sensoryIntrgration_Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntegration_BLL
{
    public class encyClopedias_BLL
    {
        public static encyClopedias_DLL edl = new encyClopedias_DLL();

        public bool SaveEncyClopedias(encyClopedias_Model encyClopedias) 
        {
            if (string.IsNullOrWhiteSpace(encyClopedias.ID))
            {
                try
                {

                    encyClopedias.ID = CommonUtil.GetID();
                    return edl.InsertNews(encyClopedias) > 0;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {
                    return false;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public List<encyClopedias_Model> GetEncyClopedias(encyClopedias_Model encyClopedias) {
            try
            {
                return CommonUtil.DataTableToList<encyClopedias_Model>(edl.GetEncyClopedias(encyClopedias));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
