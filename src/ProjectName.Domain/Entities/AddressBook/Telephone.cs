using System;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBook
{
    public enum TelephoneType
    {
        /// <summary>
        /// Unknow type.
        /// </summary>
        Unknow,

        /// <summary>
        /// Home phone.
        /// </summary>
        Home,

        /// <summary>
        /// Work phone.
        /// </summary>
        Work,

        /// <summary>
        /// Mobile phone.
        /// </summary>
        Mobile
    }

    public class Telephone : ValueObject
    {
        private const string ValidPhonePattern = @"^\+\d{5,15}$";

        [IgnoreMember]
        public TelephoneType Type { get; }

        public string PhoneNumber { get; }

        private Telephone(TelephoneType type, string phoneNumber)
        {
            Type = type;
            PhoneNumber = phoneNumber;
        }

        public static Telephone Create(TelephoneType type, string phoneNumber)
        {
            phoneNumber = Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber)).Trim();
            bool isValidPhoneNumber = Regex.Match(phoneNumber, ValidPhonePattern).Success;
            if (!isValidPhoneNumber)
            {
                throw new ArgumentException("The phone number format is invalid");
            }

            return new Telephone(type, phoneNumber);
        }
    }
}
