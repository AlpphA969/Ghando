namespace Ghando.Entity;

public class Comment : Abstract.Entity
{
    public string Text { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;


    public Status Status { get; set; } = default!;

    public Product Product { get; set; } = default!;

}

public enum Status
{
    Approved,
    Rejected ,
    Pending
}