

using MediatR;

namespace EasyPOS.Domain.Primitivies
{
    public record DomainEvent(Guid id): INotification;
}
