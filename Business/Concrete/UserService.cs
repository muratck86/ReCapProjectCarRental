using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            try
            {
                _userDal.Add(entity);
                return new SuccessResult(Messages.UserAdded);
            } catch (Exception e)
            {
                return new ErrorResult(e.InnerException.Message);
            }
            
        }

        public IDataResult<User> GetByEMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> Get(User entity)
        {
            return GetById(entity.Id);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.Get(b => b.Id == id);
            if (user == null)
                return new ErrorDataResult<User>(Messages.NoSuchUser);
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IResult Remove(User entity)
        {
            try
            {
                var user = _userDal.Get(u => u.Email == entity.Email);
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            } catch(Exception e)
            {
                return new ErrorResult(e.InnerException == null ? e.Message : e.InnerException.Message);
            }

        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
