using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensoryIntegration_Model
{
    public class newsInfo
    {

        private string _ID = "";
        private string _title = "";
        private string _remark = "";
        private string _imageUrl = "";
        private string _createTime = DateTime.Now.ToString("G");
        private string _IsDelete = "";
        private string _defaultImageUrl = "/content/images/sl_icon.png";

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

        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
            }
        }
        public string imageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
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
        public string defaultImageUrl
        {
            get
            {
                return _defaultImageUrl;
            }
            set
            {
                _defaultImageUrl = value;
            }
        }







    }
}
