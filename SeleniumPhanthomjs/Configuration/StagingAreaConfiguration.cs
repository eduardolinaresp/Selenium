using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace SeleniumPhanthomjs.Configuration
{
    public class StagingAreaConfiguration : EntityTypeConfiguration<StagingArea>
    {

        public StagingAreaConfiguration()
        {

            this.ToTable("Tb_StageWebScraping2");

            this.HasKey<int>(s => s.Id);

            this.Property(p => p.Fecha);

            this.Property(p => p._id);

            this.Property(p => p.item);

            this.Property(p => p.detalle);
            //.HasMaxLength(800);

            this.Property(p => p.unidad);
            //.HasMaxLength(800);

            this.Property(p => p.valor);

        }
    }
}