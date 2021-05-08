using FluentMigrator;

namespace migrationsTest
{
    [Migration(2)]
    public class AddRoomTable : Migration
    {
        public override void Up()
        {
            Create.Table("RoomType")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("roomType").AsString().Unique();


            Create.Table("Room")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("numberOfBeds").AsInt64().NotNullable()
                .WithColumn("price").AsInt64().NotNullable()
                .WithColumn("roomTypeId").AsInt64().NotNullable();

            Create.ForeignKey("fk_Room_roomTypeId_RoomType_Id")
                .FromTable("Room").ForeignColumn("roomTypeId")
                .ToTable("RoomType").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("Room");
            Delete.Table("RoomType");
        }
    }
}