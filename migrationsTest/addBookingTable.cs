using FluentMigrator;

namespace migrationsTest
{
    [Migration(1)]
    public class AddBookingTable : Migration
    {
        public override void Up()
        {
            Create.Table("bookingStatus")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("bookingStatus").AsBoolean();

            Create.Table("booking")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("bookingFrom").AsDate().NotNullable()
                .WithColumn("bookingTo").AsDate().NotNullable()
                .WithColumn("customerId").AsInt64().NotNullable()
                .WithColumn("noOfMembers").AsInt32().NotNullable()
                .WithColumn("totalAmount").AsInt64().NotNullable()
                .WithColumn("roomId").AsInt64().NotNullable();

            Create.ForeignKey("booking_customerId_customer_id")
                .FromTable("booking").ForeignColumn("customerId")
                .ToTable("customer").PrimaryColumn("id");

            Create.ForeignKey("booking_roomId_room_id")
                .FromTable("booking").ForeignColumn("roomId")
                .ToTable("rooms").PrimaryColumn("id");
        }

        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}