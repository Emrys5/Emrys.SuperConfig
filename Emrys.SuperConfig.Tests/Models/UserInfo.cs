using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Tests.Models
{
    class UserInfo
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string BlogUrl { get; set; }

        public Color FavoriteColor { get; set; }
        public Color DislikeColor { get; set; }

        public KeyValuePair<int, string> Sports { get; set; }

        public List<string> Language { get; set; }

        public List<UserInfo> Family { get; set; }

        public UserInfo[] Friends { get; set; }

        public Dictionary<int, UserInfo> Colleagues { get; set; }
         

    }
    enum Color
    {
        Red,
        Blue,
        Black
    }




}
