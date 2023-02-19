namespace CardOrganizer.Domain.Exceptions;

public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException(): base()
    {
        
    }
    
    public ObjectNotFoundException(string message): base(message)
    {
        
    }
}