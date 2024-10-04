namespace TSSurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialPolicyholderLinkToPaymentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PolicyholderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Payments", "PolicyholderId");
        }
    }
}
