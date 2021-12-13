using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Configurations
{
    public class BookingOfficeConfig : IEntityTypeConfiguration<BookingOffice>
    {
        public void Configure(EntityTypeBuilder<BookingOffice> builder)
        {
            builder.ToTable("Offices");
            builder.HasKey(x => x.OfficeId);
            builder.Property(x => x.OfficeId).UseIdentityColumn();
            builder.HasOne(x => x.Trip).WithMany(x => x.BookingOffices).HasForeignKey(x => x.TripId);

        }
    }
}
