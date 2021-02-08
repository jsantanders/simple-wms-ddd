using System;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Domain.Entities.AddressBook
{
    public enum EmailType
    {
        /// <summary>
        /// Unknow email type.
        /// </summary>
        Unknow,

        /// <summary>
        /// Personal email.
        /// </summary>
        Personal,

        /// <summary>
        /// Work email
        /// </summary>
        Work
    }

    public class Email : ValueObject
    {
        private const string ValidEmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        [IgnoreMember]
        public EmailType Type { get; }

        public string EmailValue { get; }

        private Email(EmailType type, string emailValue)
        {
            Type = type;
            EmailValue = emailValue;
        }

        public static Email Create(EmailType type, string emailValue)
        {
            emailValue = Guard.Against.NullOrEmpty(emailValue, nameof(emailValue)).Trim();
            bool isValidEmail = Regex.Match(emailValue, ValidEmailPattern).Success;
            if (!isValidEmail)
            {
                throw new ArgumentException("The email format is invalid");
            }

            return new Email(type, emailValue);
        }
    }
}
