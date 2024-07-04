using Business.Abstract;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Business.Constant;
using System.ComponentModel.DataAnnotations;
using Core.Aspect.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result != null) return new SuccessDataResult<User>(result);
            return new SuccessDataResult<User>();

        }
        #region UserRulesMethods
        
        #endregion
    }
}
