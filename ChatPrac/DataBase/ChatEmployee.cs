//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatPrac.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatEmployee
    {
        public int Id { get; set; }
        public Nullable<int> Chatroom_Id { get; set; }
        public Nullable<int> Employee_Id { get; set; }
    
        public virtual Chatroom Chatroom { get; set; }
        public virtual Employee Employee { get; set; }
    }
}