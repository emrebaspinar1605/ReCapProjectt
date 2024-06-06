using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            catch 
            {

                return new ErrorResult(Messages.UserInvalid);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.UserInvalid);
            }
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
           
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.UserInvalid);
            }
        }
    }
}
