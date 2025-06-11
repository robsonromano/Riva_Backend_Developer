using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;

namespace IntelSyncStarter.Business.Implementations
{
    /// <summary>
    /// Simple implementation of a token validator for Token.
    /// Validates whether the user contains a valid CRM token.
    /// Implements the <see cref="ISyncValidator{T}"/> interface.
    /// </summary>
    public class SimpleTokenValidator : ISyncValidator<CrmUser>
    {
        /// <summary>
        /// Validates the CRM token of a given user.
        /// </summary>
        /// <param name="user">The CRM user to validate.</param>
        /// <returns>
        /// A <see cref="TokenValidationResult"/> indicating success if the token exists and is not empty;
        /// otherwise, a failure result with an error message.
        /// </returns>
        public TokenValidationResult Validate(CrmUser user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.CrmToken))
                return TokenValidationResult.Fail("Missing CRM token");
            
            return TokenValidationResult.Success();
        }
    }
}
