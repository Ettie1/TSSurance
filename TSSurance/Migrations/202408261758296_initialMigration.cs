namespace TSSurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        PolicyHolderId = c.Int(nullable: false),
                        AddressType = c.String(),
                        Addr1 = c.String(),
                        Addr2 = c.String(),
                        Addr3 = c.String(),
                        Addr4 = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Username = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        PolicyHolderId = c.Int(nullable: false),
                        PolicyNumber = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PremiumAmount = c.Double(nullable: false),
                        CoverageAmount = c.Double(nullable: false),
                        Agent_AgentId = c.Int(),
                        PolicyType_PolicyTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.PolicyHolders", t => t.PolicyHolderId, cascadeDelete: true)
                .ForeignKey("dbo.Agents", t => t.Agent_AgentId)
                .ForeignKey("dbo.PolicyTypes", t => t.PolicyType_PolicyTypeId)
                .Index(t => t.PolicyHolderId)
                .Index(t => t.Agent_AgentId)
                .Index(t => t.PolicyType_PolicyTypeId);
            
            CreateTable(
                "dbo.Beneficiaries",
                c => new
                    {
                        BeneficiaryId = c.Int(nullable: false, identity: true),
                        PolicyId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Relationship = c.String(nullable: false, maxLength: 50),
                        AllocationPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BeneficiaryId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.PolicyHolders",
                c => new
                    {
                        PolicyHolderId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        IDNo = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Username = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        ConfirmPassword = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PolicyHolderId);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        PolicyId = c.Int(nullable: false),
                        DateOfClaim = c.DateTime(nullable: false),
                        ReasonForClaim = c.String(nullable: false, maxLength: 200),
                        ClaimAmount = c.Double(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovalDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PolicyId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        PaymentMethod = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.PolicyTypes",
                c => new
                    {
                        PolicyTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.PolicyTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "PolicyType_PolicyTypeId", "dbo.PolicyTypes");
            DropForeignKey("dbo.Payments", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Claims", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Policies", "Agent_AgentId", "dbo.Agents");
            DropForeignKey("dbo.Policies", "PolicyHolderId", "dbo.PolicyHolders");
            DropForeignKey("dbo.Beneficiaries", "PolicyId", "dbo.Policies");
            DropIndex("dbo.Payments", new[] { "PolicyId" });
            DropIndex("dbo.Claims", new[] { "PolicyId" });
            DropIndex("dbo.Beneficiaries", new[] { "PolicyId" });
            DropIndex("dbo.Policies", new[] { "PolicyType_PolicyTypeId" });
            DropIndex("dbo.Policies", new[] { "Agent_AgentId" });
            DropIndex("dbo.Policies", new[] { "PolicyHolderId" });
            DropTable("dbo.PolicyTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Claims");
            DropTable("dbo.PolicyHolders");
            DropTable("dbo.Beneficiaries");
            DropTable("dbo.Policies");
            DropTable("dbo.Agents");
            DropTable("dbo.Address");
        }
    }
}
