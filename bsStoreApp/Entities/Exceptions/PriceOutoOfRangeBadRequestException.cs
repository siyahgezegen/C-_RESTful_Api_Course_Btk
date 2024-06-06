namespace Entities.Exceptions
{
    public class PriceOutoOfRangeBadRequestException : BadRequestException
    {
        public PriceOutoOfRangeBadRequestException():base("max price 1000 den fazla olamaz")
        {
        }
    }
}
