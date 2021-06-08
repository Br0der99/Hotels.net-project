using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using HotelService.Services;
using Model;
using Moq;
using NUnit.Framework;

namespace HotelService.Test
{
    [TestFixture]
    public class RoomServiceTest
    {
        private Mock<IRoomRepository> _repository;
        private IRoomService _service;

        [SetUp]
        public void SetUp()
        {
            // a new mock of IRoomRepository
            _repository = new Mock<IRoomRepository>();
            _service = new RoomService(_repository.Object);
        }

        [Test]
        public async Task GetAllRooms()
        {
            //Arrange
            var rooms = new List<Room>()
            {
                new Room(),
                new Room()
            };
            _repository.Setup(m => m.GetAllRooms())
                .ReturnsAsync(() => rooms);
            
            //Act
            var result = await _service.GetAllRooms();
            //Assert
            _repository.Verify(m => m.GetAllRooms(), Times.Once);
        }
    }
}