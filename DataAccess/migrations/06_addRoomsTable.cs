using FluentMigrator;

namespace DataAccess.migrations
{
    [Migration(6)]
    public class AddRoomsTable : Migration
    {
        public override void Up()
        {
            Create.Table("rooms")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("roomNumber").AsInt64().NotNullable()
                .WithColumn("roomImage").AsString().NotNullable()
                .WithColumn("roomTypeId").AsInt64().NotNullable()
                .WithColumn("roomPrice").AsInt64().NotNullable()
                .WithColumn("bookingStatusId").AsInt64().NotNullable()
                .WithColumn("roomCapacity").AsInt64().NotNullable()
                .WithColumn("roomDescription").AsString().NotNullable()
                .WithColumn("isActive").AsBoolean().NotNullable();
                

            Create.ForeignKey("rooms_roomTypeId_roomTypes_id")
                .FromTable("rooms").ForeignColumn("roomTypeId")
                .ToTable("roomTypes").PrimaryColumn("id");


            Create.ForeignKey("rooms_bookingStatusId_bookingStatus_id")
                .FromTable("rooms").ForeignColumn("bookingStatusId")
                .ToTable("bookingStatus").PrimaryColumn("id");
            
            Create.ForeignKey("booking_roomId_room_id")
                .FromTable("booking").ForeignColumn("roomId")
                .ToTable("rooms").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.ForeignKey("rooms_bookingStatusId_bookingStatus_id");
            Delete.ForeignKey("rooms_roomTypeId_roomTypes_id");
            Delete.Table("rooms");
        }
    }
}