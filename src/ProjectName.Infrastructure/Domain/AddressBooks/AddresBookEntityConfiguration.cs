using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.Entities.AddressBookAggregate;

namespace ProjectName.Infrastructure.Domain.AddressBooks
{
    public class AddresBookEntityConfiguration : IEntityTypeConfiguration<AddressBook>
    {
        public void Configure(EntityTypeBuilder<AddressBook> builder)
        {
            builder.ToTable("AddressBook");
            builder.HasKey(b => b.Id);
        }
    }
}