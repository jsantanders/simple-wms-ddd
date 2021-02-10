using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Infrastructure.Data
{
    public class TypedIdValueConverter<TTypedIdValue> : ValueConverter<TTypedIdValue, Guid>
        where TTypedIdValue : StronglyTypedIdBase
    {
        public TypedIdValueConverter(ConverterMappingHints mappingHints = null)
            : base(id => id.Value, value => Create(value), mappingHints)
        {
        }

        private static TTypedIdValue Create(Guid id) => Activator.CreateInstance(typeof(TTypedIdValue), id) as TTypedIdValue;
    }
}