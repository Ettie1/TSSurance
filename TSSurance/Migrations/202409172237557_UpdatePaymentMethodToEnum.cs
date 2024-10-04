namespace TSSurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePaymentMethodToEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String(maxLength: 50));
        }
    }
}
