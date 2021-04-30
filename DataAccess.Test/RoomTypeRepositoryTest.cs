using System.Linq;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class RoomTypeRepositoryTest
    {
        private IRoomTypeRepository _repository;
        private RoomType _roomType;
        
        [SetUp]
        public void SetUp()
        {
            _repository = new RoomTypeRepository(Config.Instance);
        }

        [Test]
        public async Task GetAllRoomTypesTest()
        {
            //Arrange
            var expectedResult = 2;
            
            //Act
            var result = await _repository.GetAllRoomTypes();

            //Assert
            Assert.AreEqual(expectedResult, result.Count());
        }
        
        [Test]
        [Order(1)]
        public async Task AddRoomTypeTest()
        {
            //Arrange
            _roomType = new RoomType()
            {
                Name = "SingleBed"
            };

            //Act
            await _repository.AddRoomType(_roomType);

            //Assert
            Assert.AreNotEqual(0, _roomType.Id);
        }
        
        [Test]
        [Order(2)]
        public async Task DeleteRoomTypeTest()
        {
            //Arrange
            var roomTypeId = _roomType.Id;
            
            //Act
            var result = await _repository.DeleteRoomType(roomTypeId);
            
            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        [Order(2)]
        public async Task DeleteRoomTypeTestFail()
        {
            //Arrange
            var roomTypeId = 99999;
            
            //Act
            var result = await _repository.DeleteRoomType(roomTypeId);
            
            //Assert
            Assert.IsFalse(result);
        }
    }
}