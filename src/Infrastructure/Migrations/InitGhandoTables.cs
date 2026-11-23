using FluentMigrator;
using FluentMigrator.Builders;

namespace Migrations;
[Migration(202611232151)]
public class InitGhandoTables : Migration
{
    public override void Up()
    {
        Create.Table("Products")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Description").AsString()
            .WithColumn("ImageUrl").AsString()
            .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable()
            .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable();

        Create.Table("Categories")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("createdAt").AsDateTimeOffset().NotNullable()
            .WithColumn("updatedAt").AsDateTimeOffset().NotNullable();

        Create.Table("ProductCategories")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            
            .WithColumn("ProductId").AsGuid().NotNullable()
            .ForeignKey("FK_ProductCategories_Products", "Products", "Id")

            .WithColumn("CategoryId").AsGuid().NotNullable()
            .ForeignKey("FK_ProductCategories_Categories", "Categories", "Id");

        Create.Table("RequestForms")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("PhoneNumber").AsString().NotNullable()
            .WithColumn("Status").AsString().NotNullable()
            .WithColumn("CreatedAt").AsDateTimeOffset().NotNullable()
            .WithColumn("UpdatedAt").AsDateTimeOffset().NotNullable()
            .WithColumn("Text").AsString().NotNullable()
            .WithColumn("Subject").AsString().NotNullable();

        Create.Table("Comments")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("Status").AsString().NotNullable()
            .WithColumn("Text").AsString().NotNullable();





    }

    public override void Down()
    {
        Delete.Table("Comment");
        Delete.Table("RequestForm");
        Delete.Table("ProductCategory");
        Delete.Table("Category");
        Delete.Table("Product");

    }
}