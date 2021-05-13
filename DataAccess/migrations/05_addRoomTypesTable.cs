

using FluentMigrator;

namespace DataAccess.migrations
{
    [Migration(5)]
    public class AddRoomTypesTable : Migration
    {
        public override void Up()
        {
            Create.Table("roomTypes")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("roomType").AsString().Unique();
        }

        public override void Down()
        {
            Delete.Table("roomTypes");
        }
    }
}