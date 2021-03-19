using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.FileIO;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageService : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageService(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddImage(IFormFile image, CarImage carImage)
        {
            string fileName = GenerateFileNameForCarId(image, carImage);
            carImage.ImagePath = @".\Images\" + fileName;
            carImage.Date = DateTime.Now;

            var check = BusinessRules.Run(CheckImageCountForCar(_carImageDal, carImage),
                CheckFileType(carImage));
            if (check.Count == 0)
            {
                var dalResult = Add(carImage);
                if (dalResult.Success)
                {
                    FileOperations.SaveFile(carImage.ImagePath, image);
                    return new SuccessResult(Messages.ImageSavedAndAdded);
                }
                return new ErrorResult(dalResult.Message);
            } else if (check.Count == 1)
            {
                return check[0];
            }

            return new ErrorDataResult<List<IResult>>(check, Messages.MultipleErrors);

        }

        public IResult Add(CarImage image)
        {
            _carImageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IDataResult<CarImage> Get(CarImage carImage)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(im => im.Id == carImage.Id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(im => im.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            List<CarImage> images = _carImageDal.GetAll(im => im.CarId == carId);
            if(images.Count == 0)
            {
                var noPic = new CarImage
                {
                    CarId = carId,
                    ImagePath = @".\Images\Nophoto.jpg"
                };
                images.Add(noPic);
            }
            return new SuccessDataResult<List<CarImage>>(images);
        }

        public IResult Remove(CarImage carImage)
        {
            var filePath = _carImageDal.Get(im => im.Id == carImage.Id).ImagePath;
            FileOperations.Delete(filePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult UpdateImage(IFormFile image, CarImage carImage)
        {
            var imageToDelete = _carImageDal.Get(im => im.Id == carImage.Id).ImagePath;
            FileOperations.Delete(imageToDelete);
            _carImageDal.Delete(carImage);
            return AddImage(image, carImage);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public static string GenerateFileNameForCarId(IFormFile image, CarImage carImage)
        {
            var extension = new FileInfo(image.FileName).Extension;
            string randomName = Guid.NewGuid().ToString().Substring(0, 25);
            return carImage.CarId + "_" + randomName + extension;
        }

        private static IResult CheckImageCountForCar(ICarImageDal carImageDal, CarImage carImage)
        {
            if (carImageDal.GetAll(im => im.CarId == carImage.CarId).Count < 5)
            {
                return new SuccessResult();
            }
                return new ErrorResult(Messages.MaxImageForACar);
        }

        private static IResult CheckFileType(CarImage carImage)
        {
            var extension = new FileInfo(carImage.ImagePath).Extension;
            var check = (extension == ".jpg" || extension == ".jpeg" || extension == "png");
            if (check)
                return new SuccessResult();
            return new ErrorResult(extension + Messages.NotValidImageFileType);
        }

    }
}
