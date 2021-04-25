using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
   public abstract class RoomBase
    {
        public List<Room> Room { get; set; }

        public RoomBase()
        {

        }
        protected RoomBase(List<Room> rooms)
        {
            Room = rooms;
        }

    }
}