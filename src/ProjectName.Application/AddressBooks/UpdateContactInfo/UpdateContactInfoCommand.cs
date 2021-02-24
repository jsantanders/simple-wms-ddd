using System;
using System.Runtime.Serialization;
using ProjectName.Application.SeedWork.Commands;

namespace ProjectName.Application.AddressBooks.UpdateContactInfo
{
    [DataContract]
    public class UpdateContactInfoCommand : CommandBase
    {
        [DataMember]
        public Guid ContactId { get; }

        [DataMember]
        public string FirstName { get; }

        [DataMember]
        public string MiddleName { get; }

        [DataMember]
        public string LastName { get; }

        [DataMember]
        public string CompanyName { get; }

        [DataMember]
        public string CompanyTitle { get; }

        [DataMember]
        public DateTime? Birthday { get; }

        [DataMember]
        public string Notes { get; }
    }
}