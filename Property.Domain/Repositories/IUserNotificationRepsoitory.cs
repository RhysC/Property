using Property.DomainContracts.Dtos;

namespace Property.Domain.Repositories
{
    //is this s repository? like a repos that handles domain objects or just a reporting service that throws DTOs over the wire??
    public interface IUserNotificationRepsoitory
    {
        UserNotification[] GetNotificationsFor(IUser user);
    }
}