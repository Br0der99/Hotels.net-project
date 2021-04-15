using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class RoomTypes
    {
        public int RoomId { get; set; }
        public String Singlebed { get; set; }

        public enum RoomType
        {
            Singlebed, Doublebed, FamilyRoom, Suite
        }


      
    }
}
