using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string CompanyName{ get; set; }
        public string Email{ get; set; }
    }
    public class RentalDetailDto : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}
