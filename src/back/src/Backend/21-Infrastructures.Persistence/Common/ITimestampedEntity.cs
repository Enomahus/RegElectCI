namespace Infrastructures.Persistence.Common
{
    public interface ITimestampedEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset ModifiedAt { get; set; }
    }
}
