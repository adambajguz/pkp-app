namespace TrainsOnline.Desktop.Domain.ValueObjects.TicketComponents
{
    using System.Collections.Generic;
    using TrainsOnline.Desktop.Domain.ValueObjects.Base;

    public class NewTicket : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            //yield return Id;
            //yield return CreatedOn;
        }
    }
}
