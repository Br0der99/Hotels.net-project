using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Room
    {
        public RoomTypes RoomType { get; set; }
        public int RoomNo { get; set; }
        public string Size { get; set; }
        public Room()
        {

        }
    }



    class FinKlasse {

        private void FinTestMetode()
        {
            Room privateBedRoomForTwo = new Room() { RoomType = RoomTypes.Doublebed, RoomNo = 42, Size = "One beds" };
            Room privateBedRoomForOne = new Room() { RoomType = RoomTypes.Singlebed, RoomNo = 44, Size = "Two beds" };
        }

        }
}
