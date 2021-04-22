using NUnit.Framework;

namespace TestService
{
    public class Tests
    {
       

        [Test]
        public void CreateRoomTest()
        {
            //Arrange
            // In the Arrange phase, we create and set up a system under test.
            // A system under test could be a method, a single object, or a graph of connected objects.
            // It is OK to have an empty Arrange phase, for example if we are testing a static method -

            Room room1 = new Room;
            string size;
            int RoomNo;
           
           //Act
            // The Act phase is where we poke the system under test, usually by invoking a method.
            // If this method returns something back to us, we want to collect the result to ensure it was correct.
            // Or, if method doesn't return anything, we want to check whether it produced the expected side effects.
            private void RoomCreationTest (string size, int RoomNo, int RoomID) 
            {
                room = new Room(size, RoomNo,RoomID);

            }
            //Assert
            // The Assert phase makes our unit test pass or fail.
            // Here we check that the method's behavior is consistent with expectations.
            return RoomCreationTest();

            
        }

        [Test]
        public void GetRooms() 
            {
            Program p = new Program();
            int result = p.GetRoomDetails(1);
            }
        public int GetRoomDetails(string name, int roomID) 
            {
            string info = string.Format("roomID: {0}", size);
            return info;
            }
    }
}