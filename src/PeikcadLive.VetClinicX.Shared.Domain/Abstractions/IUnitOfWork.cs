namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken = default);
}