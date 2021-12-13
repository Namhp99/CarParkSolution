using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Configurations
{
    public class ParkinglotConfig : IEntityTypeConfiguration<Parkinglot>
    {
        public void Configure(EntityTypeBuilder<Parkinglot> builder)
        {
            builder.ToTable("Parkinglots");
            builder.HasKey(x => x.ParkId);
            builder.Property(x => x.ParkId).UseIdentityColumn();
        }
    }
}
