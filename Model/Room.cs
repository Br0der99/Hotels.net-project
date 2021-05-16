namespace Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomImage { get; set; }
        public decimal RoomPrice { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }

    }
}