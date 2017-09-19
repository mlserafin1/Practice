namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAddressModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Addresses", "Street2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Addresses", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Addresses", "Zip", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Zip", c => c.String());
            AlterColumn("dbo.Addresses", "State", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "Street2", c => c.String());
            AlterColumn("dbo.Addresses", "Street", c => c.String());
        }
    }
}
