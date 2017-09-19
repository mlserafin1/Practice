namespace Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiddleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MiddleName");
        }
    }
}
