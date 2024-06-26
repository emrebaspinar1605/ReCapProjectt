using Core.Entities;

namespace Entities.DTOs
{
    public class CarImageDetailDto : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
