namespace SeleniumPhanthomjs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_StageWebScraping2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _id = c.String(),
                        item = c.String(),
                        detalle = c.String(),
                        unidad = c.String(),
                        valor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_StageWebScraping2");
        }
    }
}
