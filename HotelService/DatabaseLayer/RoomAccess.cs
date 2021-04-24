using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Model.Model;
using Microsoft.Extensions.Configuration;
using Model;

namespace HotelService.DatabaseLayer
{
    public class RoomAccess
    {

        //private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectMsSqlString"].ToString();

        private IConfiguration Configuration { get; set; }

        public RoomAccess(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public List<Room> GetAllRooms()
        {

            List<Room> foundRooms = null;

            string connectionString = Configuration.GetConnectionString("ConnectMsSqlString");

            // Prepare command

            /* 
             * HNV: Was 'SELECT id, xValue, yValue', must be 'SELECT id, x1Value, x2Value, y1Value, y2Value'
             * */

            string queryString = "SELECT roomNo, numberOfBeds, Price, roomTypes, FROM ROOM order by Id";

            // Get connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, conn))
            {
                if (conn != null)
                {
                    conn.Open();

                    try
                    {
                        SqlDataReader roomReader = readCommand.ExecuteReader();
                        foundRooms = GetRoomObjects(roomReader);
                    }
                    catch (Exception e)
                    {
                        string s = e.Message;
                    }



                }
            }

            //// Test stub
            //List<Line> foundLines = new List<Line>() {
            //    new Line(1, new List<Coordinate>() {
            //        new Coordinate(5,7)
            //    })
            //};

            return foundRooms;
        }

        public Room GetRoom(int roomId)
        {

            Room foundRoom = null;

            string connectionString = Configuration.GetConnectionString("ConnectMsSqlString");

            // Prepare command

            /* 
             * HNV: Was 'SELECT id, xValue, yValue', must be 'SELECT id, x1Value, x2Value, y1Value, y2Value'
             * */

            string queryString = "SELECT roomNo, numberOfBeds, Price, roomTypes, FROM ROOM where id = @RoomId";

            // Get connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, conn))
            {

                readCommand.Parameters.AddWithValue("RoomId", roomId);

                if (conn != null)
                {
                    conn.Open();

                    SqlDataReader roomReader = readCommand.ExecuteReader();
                    List<Room> foundRooms = GetRoomObjects(roomReader);
                    if (foundRooms != null && foundRooms.Count > 0)
                    {
                        foundRoom = foundRooms[0];
                    }
                }
            }

            //// Test stub
            //Line foundLine = new Line(1, new List<Coordinate>() {
            //        new Coordinate(5,7)
            //    });

            return foundRoom;
        }

       

        /* 
         * HNV: Was 'AddLine(Coordinate newCoord)', must be 'AddLine(Coordinate newCoord1, Coordinate newCoord2)'
         * */

        public bool AddRoom(Room newRoom1)//, Room newRoom2)
        {

            int numberOfRowsInserted = 0;

            string connectionString = Configuration.GetConnectionString("ConnectMsSqlString");

            // Prepare command

            /* 
             * HNV: Was 'INSERT INTO LINE(xValue, yValue) VALUES(@XVal, @YVAL)', must be 'INSERT INTO LINE(x1Value, y1Value, x2Value, y2Value) VALUES(@X1Val, @Y1VAL, @X1Val, @Y1VAL)'
             * */

            string queryString = "INSERT INTO Room(numberOfBeds, Price, roomTypes) VALUES(@numberOfBedsVAL, @PriceVAL, @roomTypesVAL)";

            // Get connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand insertCommand = new SqlCommand(queryString, conn))
            {

                insertCommand.Parameters.AddWithValue("numberOfBeds", newRoom1);
                insertCommand.Parameters.AddWithValue("Price", newRoom1);
                insertCommand.Parameters.AddWithValue("roomTypes", newRoom1);

                

                if (conn != null)
                {
                    conn.Open();

                    numberOfRowsInserted = insertCommand.ExecuteNonQuery();
                }
            }

            //// Test stub
            //int insertedId = 5;

            return (numberOfRowsInserted > 0);
        }

        private List<Room> GetRoomObjects(SqlDataReader roomReader)
        {
            List<Room> foundRooms= new List<Room>();
            Room tempRoom;
            List<Room> Rooms;
            int tempId; String numberOfBeds; int PriceVAL; int roomTypes;

            while (roomReader.Read())
            {
                tempId = roomReader.GetInt32(roomReader.GetOrdinal("id"));
                numberOfBeds = roomReader.GetString(roomReader.GetOrdinal("numberOfBeds"));
                PriceVAL = roomReader.GetInt32(roomReader.GetOrdinal("Price"));
                roomTypes = roomReader.GetInt32(roomReader.GetOrdinal("roomTypes"));
                Rooms = new List<Room>() {
                            new Room (roomNo: tempId, numberOfBeds, PriceVAL, roomTypes )
                        };
                tempRoom = new Room(tempId, Rooms);
                foundRooms.Add(tempRoom);
            }
            return foundRooms;
        }

    }
}
