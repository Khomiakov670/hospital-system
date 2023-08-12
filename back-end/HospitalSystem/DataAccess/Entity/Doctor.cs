namespace DataAccess.Entity
{
    public class Doctor: User
    {
        public virtual List<Record> Records { get; set; } = null!;
        public string Specialization { get; set; } = null!;
    }
}
