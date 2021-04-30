using System.Linq;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DataAccess.Test
{
    [TestFixture]
    public class RoomRepositoryTest
    {
        private IRoomRepository _repository;
        private Room _room;
        
        [SetUp]
        public void SetUp()
        {
            _repository = new RoomRepository(Config.Instance);
        }

        [Test]
        public async Task GetAllRoomsTest()
        {
            //Arrange
            var expectedResult = 3;
            
            //Act
            var result = await _repository.GetAllRooms();

            //Assert
            Assert.AreEqual(expectedResult, result.Count());
            Assert.IsNotNull(result.FirstOrDefault().RoomType);
        }

        
        [Test]
        public async Task GetRoomByIdTest()
        {
            //Arrange
            int roomId = 4;

            //Act
            var result = await _repository.GetRoomById(roomId);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RoomType);
        }
        
        [Test]
        public async Task GetRoomByIdTestFail()
        {
            //Arrange
            int roomId = 99999;

            //Act
            var result = await _repository.GetRoomById(roomId);
            
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        [Order(1)]
        public async Task AddRoomTest()
        {
            //Arrange
            _room = new Room()
            {
                NumberOfBeds = 2,
                Price = 4000,
                RoomType = new RoomType()
                {
                    Id = 1,
                    Name = "Suite"
                }
            };

            //Act
            await _repository.AddRoom(_room);

            //Assert
            Assert.AreNotEqual(0, _room.Id);
        }

        [Test]
        [Order(2)]
        public async Task DeleteRoomTest()
        {
            //Arrange
            var roomId = _room.Id;
            
            //Act
            var result = await _repository.DeleteRoom(roomId);
            
            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        [Order(2)]
        public async Task DeleteRoomTestFail()
        {
            //Arrange
            var roomId = 99999;
            
            //Act
            var result = await _repository.DeleteRoom(roomId);
            
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task UpdateRoomTest()
        {
            //Arrange
            var room = new Room()
            {
                Id = 4,
                NumberOfBeds = 2,
                Price = 4500,
                RoomType = new RoomType()
                {
                    Id = 1,
                    Name = "Suite"
                }
            };
            
            //Act
            var result = await _repository.UpdateRoom(room);

            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public async Task UpdateRoomTestFail()
        {
            //Arrange
            var room = new Room()
            {
                Id = 99999,
                NumberOfBeds = 2,
                Price = 4500,
                RoomType = new RoomType()
                {
                    Id = 1,
                    Name = "Suite"
                }
            };
            
            //Act
            var result = await _repository.UpdateRoom(room);

            //Assert
            Assert.IsFalse(result);
        }
    }
}