using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCuoiKy
{
    [Serializable]
    public class UserLogin
    {

        public long UserID { get; set; }
        public string UserName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }
}