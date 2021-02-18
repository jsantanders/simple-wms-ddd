using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Api.Configurations.Validations
{
    public class BusinessRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule broken";
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Message;
            Type = "https://somedomain/business-rule-validation-error";
        }
    }
}
