namespace SurisCodeTest.Api.Models
{
    public class NewReserveRequest
    {

        public DateOnly Date { get; set; }
        public string Client { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ServiceWorkingTimeId { get; set; }

    }
}
