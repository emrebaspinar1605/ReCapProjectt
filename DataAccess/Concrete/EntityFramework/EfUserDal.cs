using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepository<User, ReCapContext>, IUserDal
    {

    }
}