namespace TSSurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeSaltingInAgent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "Salt");
        }
    }
}
