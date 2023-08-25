namespace DataAccess.Entity;

public class Patient : User
{
    public virtual List<Record> Records { get; set; } = null!;
}