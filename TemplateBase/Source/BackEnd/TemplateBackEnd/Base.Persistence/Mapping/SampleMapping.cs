using Base.Domain.Entities;
using Base.Persistence.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.Mapping
{
    public class SampleMapping : EntityTypeConfiguration<Sample>, IMapping
    {
        public SampleMapping()
        {
            this.ToTable("Sample");
            this.HasKey(x => x.SampleId);
            this.Property(x => x.SampleId);
            this.Property(x => x.Name).IsRequired().HasMaxLength(255);
            this.Property(x => x.Description).HasMaxLength(1024);
        }
    }
}
