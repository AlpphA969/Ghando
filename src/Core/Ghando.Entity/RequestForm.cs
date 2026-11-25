namespace Ghando.Entity;

public class RequestForm : Abstract.Entity
{
    public string FirstName { set; get; } = default!;
    
    public string LastName { set; get; } = default!;
    
    public string PhoneNumber { set; get; } = default!;

    public RequestStatus Status { set; get; }

    public string Text { set; get; } = default!;

    public string Subject { set; get; } = default!;
}
public enum RequestStatus
{
    Reviewed , 
    NotReviewed ,
}