namespace Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Produtoes", new[] { "UsuarioID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtoes");
        }
    }
}
