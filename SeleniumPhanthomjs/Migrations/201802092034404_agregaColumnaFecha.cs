namespace SeleniumPhanthomjs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregaColumnaFecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_StageWebScraping2", "Fecha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_StageWebScraping2", "Fecha");
        }
    }
}
