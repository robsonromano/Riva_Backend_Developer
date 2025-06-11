using IntelSyncStarter.Domain.Entities;

namespace IntelSyncStarter.Business.Interfaces
{
    public interface ISyncValidator<T>
    {
        TokenValidationResult Validate(T value);
    }
}
