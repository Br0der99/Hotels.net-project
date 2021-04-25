using System;
using System.Collections.Generic;
using Model.Model;
using HotelService.DatabaseLayer;
using Microsoft.Extensions.Configuration;
using Model;

namespace HotelService.BusinessLogiclayer
{
    public class RoomControl
    {

        private readonly RoomAccess _dataAccess;
        private IConfiguration Configuration { get; set; }

        public RoomControl(IConfiguration inConfiguration)
        {
            Configuration = inConfiguration;
            _dataAccess = new RoomAccess(Configuration);
        }

        public List<Room> GetAllRooms()
        {
            List<Room> foundRooms;
            try
            {
                foundRooms = _dataAccess.GetAllRooms();
            }
            catch
            {
                foundRooms = null;
            }

            return foundRooms;
        }

        public Room GetRoomById(int id) //roomNo istedet for id?
        {
            Room foundRoom;
            try
            {
                foundRoom = _dataAccess.GetRoom(id);
            }
            catch
            {
                foundRoom = null;
            }

            return foundRoom;
        }

        /* 
         * HNV: Was 'InsertLine(Coordinate inCoord)', must be 'AddLine(Coordinate newCoord1, Coordinate newCoord2)'
         * */

        public bool InsertRoom(Room inRoom1)
        {
            bool wasInserted;
            try
            {
                wasInserted = _dataAccess.AddRoom(inRoom1);
            }
            catch
            {
                wasInserted = false;
            }

            return wasInserted;
        }

    }
}
