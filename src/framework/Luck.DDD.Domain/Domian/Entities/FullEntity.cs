using Luck.Framework;

namespace Luck.DDD.Domain
{
    public abstract class FullEntity : EntityWithIdentity<string>, IUpdatable, ISoftDeletable
    {
        protected FullEntity() : base(SnowflakeId.GenerateNewStringId())
        {
        }
        public DateTimeOffset CreationTime { get; private set; }

        public DateTimeOffset? LastModificationTime { get; private set; }

        public DateTimeOffset? DeletionTime { get; private set; }


        public void UpdateCreation()
        {
            CreationTime = DateTimeOffset.UtcNow;
        }

        public void UpdateModification()
        {
            LastModificationTime = DateTimeOffset.UtcNow;
        }

        public void UpdateDeletion()
        {
            DeletionTime = DateTimeOffset.UtcNow;
        }
    }
}
