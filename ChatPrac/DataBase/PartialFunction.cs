using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPrac.DataBase
{
    public partial class Chatroom
    {
        //public DateTime LastChatMessage => this.ChatMessage.Max(x => (DateTime)x.Date);
    }
    public partial class Department
    {
        public bool IsChecked { get; set; } = false;
    }
}
