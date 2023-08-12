namespace DataAccess.Entity
{
    public class Tenant: Entity
    {
        public virtual Apparatus? Apparatus { get; set; }
        public virtual Ward Ward { get; set; } = null!;
        public int WardId { get; set; }
    }
}
