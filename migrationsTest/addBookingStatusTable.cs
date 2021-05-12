using FluentMigrator;

namespace migrationsTest
{
    [Migration(1)]
    public class AddBookingStatusTable : Migration
    {
        public override void Up()
        {
            Create.Table("bookingStatus")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("bookingStatus").AsBoolean();
        }

        public override void Down()
        {
            Delete.Table("bookingStatus");
        }
    }
}