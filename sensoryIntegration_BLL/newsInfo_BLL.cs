using sensoryIntegration_DLL;
using sensoryIntegration_Model;
using sensoryIntrgration_Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntegration_BLL
{
    public class newsInfo_BLL
    {
        newsInfo_DLL nid = new newsInfo_DLL();
        public bool SaveNewsInfo(newsInfo encyClopedias)
        {
            if (string.IsNullOrWhiteSpace(encyClopedias.ID))
            {
                try
                {

                    encyClopedias.ID = CommonUtil.GetID();
                    return nid.InsertNewsInfo(encyClopedias) > 0;
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

        public List<newsInfo> GetNewsInfo(newsInfo newsInfo)
        {
            try
            {
                return CommonUtil.DataTableToList<newsInfo>(nid.GetNewsInfo(newsInfo));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
