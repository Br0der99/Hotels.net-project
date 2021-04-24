using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Room
    {
        public int RoomNo { get; set; }
        public string NumberOfBeds { get; set; }
        public int Price { get; set; }
        public int RoomTypes { get; set; }

        public Room()
        {

        }
        public Room(int roomNo, string numberOfBeds, int price, int roomTypes)
        {
          //  RoomNo = roomNo;
            this.RoomNo = roomNo;
            this.NumberOfBeds = numberOfBeds;
            this.Price = price;
            this.RoomTypes = roomTypes;

        }

        public Room(int tempId, Room tempRoom)
        {
        }

        public static implicit operator Room(List<Room> v)
        {
            throw new NotImplementedException();
        }
        ////public Room(int roomNo, string numberOfbeds, int price, int roomTypes)
        //{
        //    this.roomNo = roomNo;
        //    this.numberOfBeds = numberOfBeds;
        //    this.price = price;
        //    this.roomTypes = roomTypes;

        //}


    }
}
