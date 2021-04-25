using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
  public class RoomLine : RoomBase
    {
        public int RoomId { get; set; }
        public RoomLine()
        {
            
        }
       public RoomLine(List<Room> rooms) : base(rooms) { }  

        public RoomLine(int roomId, List<Room> rooms) : this(rooms)
        {
            RoomId = roomId;
        }
    }
}
