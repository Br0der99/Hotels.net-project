using FluentMigrator;

namespace migrationsTest
{
    [Migration(1)]
    public class AddAddressTables : Migration
    {
        public override void Up()
        {
            Create.Table("city")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("name").AsString().Unique();

            Create.Table("cityZipcode")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("cityId").AsInt64().Unique()
                .WithColumn("zipCode").AsInt32().Unique();

            Create.ForeignKey("cityZipode_cityId_city_id")
                .FromTable("cityZipcode").ForeignColumn("cityId")
                .ToTable("city").PrimaryColumn("id");

            Create.Table("street")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("name").AsString().NotNullable().Unique();

            Create.Table("streetNumber")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("streetId").AsInt64().Unique()
                .WithColumn("streetNumber").AsInt64().Unique();

            Create.ForeignKey("streetNumber_streetId_street_id")
                .FromTable("streetNumber").ForeignColumn("streetId")
                .ToTable("street").PrimaryColumn("id");

            Create.Table("address")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("streetNumberId").AsInt64().Unique()
                .WithColumn("cityZipId").AsInt64().Unique();

            Create.ForeignKey("address_streetNumberId_streetNumber")
                .FromTable("address").ForeignColumn("streetNumberId")
                .ToTable("streetNumber").PrimaryColumn("id");

            Create.ForeignKey("address_cityZipId_cityZipcode_id")
                .FromTable("address").ForeignColumn("cityZipId")
                .ToTable("cityZipcode").PrimaryColumn("id");
        }

        public override void Down()
        {
            
        }
    }
}