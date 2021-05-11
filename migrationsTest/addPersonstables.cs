using FluentMigrator;

namespace migrationsTest
{
    [Migration(1)]
    public class AddPersonsTables : Migration
    {
        public override void Up()
        {
            Create.Table("person")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("firstName").AsString().NotNullable()
                .WithColumn("lastName").AsString().NotNullable();

            Create.Table("customer")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("phone").AsInt64().NotNullable()
                .WithColumn("email").AsInt64().NotNullable()
                .WithColumn("addressId").AsInt64().NotNullable()
                .WithColumn("personId").AsInt64().NotNullable()
                .WithColumn("userId").AsInt64().NotNullable();

            Create.ForeignKey("customer_personId_person_id")
                .FromTable("customer").ForeignColumn("personId")
                .ToTable("person").PrimaryColumn("id");

            Create.Table("employee")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("personId").AsInt64().NotNullable();

            Create.ForeignKey("employee_personId_person_id")
                .FromTable("employee").ForeignColumn("personId")
                .ToTable("person").PrimaryColumn("id");
        }

        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}