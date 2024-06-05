using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfColorDal : EfEntityRepository<Color, ReCapContext>, IColorDal
    {

        
    }
}
