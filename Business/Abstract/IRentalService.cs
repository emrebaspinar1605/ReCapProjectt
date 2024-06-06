using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetRentalByID(int id);
        IDataResult<List<Rental>> GetRentalByCarID(int carId);
        IDataResult<List<Rental>> GetRentalByCustomerID(int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
