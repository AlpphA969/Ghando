using System.Data;
using FluentMigrator;

namespace Ghando.Migrations;

[Migration(202611251832)]
public class InitGhandoTables : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Categories")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey("PK_Categories")
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().Nullable();

        Create.Table("Products")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey("PK_Products")
            .WithColumn("Name").AsString(200).NotNullable()
            .WithColumn("Description").AsString(4000).Nullable()
            .WithColumn("ImageUrl").AsString(2048).Nullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().Nullable();

        Create.Table("ProductCategories")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey("PK_ProductCategories")
            .WithColumn("ProductId").AsGuid().NotNullable()
                .ForeignKey("FK_ProductCategories_Products", "Products", "Id")
                .OnDelete(Rule.Cascade)
            .WithColumn("CategoryId").AsGuid().NotNullable()
                .ForeignKey("FK_ProductCategories_Categories", "Categories", "Id")
                .OnDelete(Rule.Cascade)
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().Nullable();

        Create.Table("Comments")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey("PK_Comments")
            .WithColumn("ProductId").AsGuid().NotNullable()
                .ForeignKey("FK_Comments_Products", "Products", "Id")
                .OnDelete(Rule.Cascade)
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("LastName").AsString(100).NotNullable()
            .WithColumn("Text").AsString(2000).NotNullable()
            .WithColumn("Status").AsString(20).NotNullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().Nullable();

        Create.Table("RequestForms")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey("PK_RequestForms")
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("LastName").AsString(100).NotNullable()
            .WithColumn("PhoneNumber").AsString(20).NotNullable()
            .WithColumn("Subject").AsString(200).NotNullable()
            .WithColumn("Text").AsString(4000).NotNullable()
            .WithColumn("Status").AsString(20).NotNullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().Nullable();

        // Blocks duplicate product-category links; leading ProductId also serves FK lookups by product.
        Create.Index("UX_ProductCategories_ProductId_CategoryId")
            .OnTable("ProductCategories")
            .OnColumn("ProductId").Ascending()
            .OnColumn("CategoryId").Ascending()
            .WithOptions().Unique();

        // FluentMigrator doesn't auto-index FKs (EF migrations do), so add the uncovered ones.
        Create.Index("IX_ProductCategories_CategoryId")
            .OnTable("ProductCategories")
            .OnColumn("CategoryId").Ascending();

        Create.Index("IX_Comments_ProductId")
            .OnTable("Comments")
            .OnColumn("ProductId").Ascending();
    }

    public override void Down()
    {
        Delete.Table("ProductCategories");
        Delete.Table("Comments");
        Delete.Table("RequestForms");
        Delete.Table("Products");
        Delete.Table("Categories");
    }
}