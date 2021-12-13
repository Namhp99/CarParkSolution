using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Configurations
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(x => x.TicketId);
            builder.Property(x => x.TicketId).UseIdentityColumn();
            builder.HasOne(x => x.Trip).WithMany(x => x.Tickets).HasForeignKey(x => x.TripId);
            builder.HasOne(x => x.Car).WithMany(x => x.Tickets).HasForeignKey(x => x.LicensePlate);
        }
    }
}
