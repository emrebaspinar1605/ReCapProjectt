using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepository<Color, ReCapContext>, IColorDal
    {

        
    }
}
