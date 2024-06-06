using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {

    }
}

namespace DataAccess.Concrete.EntityFramework
{
}