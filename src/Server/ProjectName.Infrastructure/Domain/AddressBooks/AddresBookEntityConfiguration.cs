using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.Entities.AddressBooks;

namespace ProjectName.Infrastructure.Domain.AddressBooks
{
    public class AddresBookEntityConfiguration : IEntityTypeConfiguration<AddressBook>
    {
        public void Configure(EntityTypeBuilder<AddressBook> builder)
        {
            builder.ToTable("AddressBook", "AddressBook");
            builder.HasKey(b => b.Id);

            builder.OwnsMany<Contact>("_contacts", y =>
            {
                y.WithOwner().HasForeignKey("AddressBookId");
                y.ToTable("Contact", "AddressBook");
                y.HasKey("Id");
                y.Property<ContactLabelId>("ContactLabelId");
                y.Property<DateTime?>("Birthday");
                y.Property<string>("Notes");
                y.Property<bool>("IsFavorite");

                y.OwnsOne<Address>("_address", b =>
                {
                    b.Property(x => x.Country).HasColumnName("Country");
                    b.Property(x => x.State).HasColumnName("State");
                    b.Property(x => x.City).HasColumnName("City");
                    b.Property(x => x.AddressLine1).HasColumnName("AddressLine1");
                    b.Property(x => x.AddressLine2).HasColumnName("AddressLine2");
                });

                y.OwnsOne<ContactName>("_name", b =>
                {
                    b.Property(x => x.FirstName).HasColumnName("FirstName");
                    b.Property(x => x.MiddleName).HasColumnName("MiddleName");
                    b.Property(x => x.LastName).HasColumnName("LastName");
                });

                y.OwnsOne<ContactCompany>("_company", b =>
                {
                    b.Property(x => x.CompanyName).HasColumnName("CompanyName");
                    b.Property(x => x.Title).HasColumnName("Title");
                });

                y.OwnsMany<Email>("_email", b =>
                {
                    b.WithOwner().HasForeignKey("ContactId");
                    b.ToTable("Email", "AddressBook");
                });

                y.OwnsMany<Telephone>("_telephone", b =>
                {
                    b.WithOwner().HasForeignKey("ContactId");
                    b.ToTable("Telephone", "AddressBook");
                });
            });
        }
    }
}
