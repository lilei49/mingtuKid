using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntegration_Model
{
    public class encyClopedias_Model
    {
        private string _ID = "";
        private string _htmlTxt = "";
        private string _createTime = DateTime.Now.ToString("G");
        private string _IsDelete = "";
        private string _newsID = "";

        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public string htmlTxt
        {
            get
            {
                return _htmlTxt;
            }
            set
            {
                _htmlTxt = value;
            }
        }

        public string createTime
        {
            get
            {
                return _createTime;
            }
            set
            {
                _createTime = value;
            }
        }

        public string IsDelete
        {
            get
            {
                return _IsDelete;
            }
            set
            {
                _IsDelete = value;
            }
        }
        public string newsID
        {
            get
            {
                return _newsID;
            }
            set
            {
                _newsID = value;
            }
        }
    }
}
