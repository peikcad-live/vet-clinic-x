namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IRepository
{
    IUnitOfWork Uow { get; }
}