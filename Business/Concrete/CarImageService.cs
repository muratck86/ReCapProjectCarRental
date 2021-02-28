using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.FileIO;
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
            string fileName = GenerateFileNameForCarId(carImage);
            carImage.ImagePath = @"..\Entities\Images\" + fileName; ;
            carImage.Date = DateTime.Now;

            var check = CheckImageCountForCar(_carImageDal, carImage);
            if (check)
            {
                var dalResult = Add(carImage);
                if (dalResult.Success)
                {
                    FileOperations.SaveFile(carImage.ImagePath, image);
                    return new SuccessResult(Messages.ImageSavedAndAdded);
                }
                return new ErrorResult(dalResult.Message);
            }
            return new ErrorResult(Messages.MaxImageForACar);

        }

        public IResult Add(CarImage entity)
        {
            _carImageDal.Add(entity);
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
                    ImagePath = @"..\Entities\Images\Nophoto.jpg"
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

        public static string GenerateFileNameForCarId(CarImage carImage)
        {
            var extension = new FileInfo(carImage.ImagePath).Extension;
            string randomName = Guid.NewGuid().ToString().Substring(0, 25);
            return carImage.CarId + "_" + randomName + extension;
        }

        private static bool CheckImageCountForCar(ICarImageDal carImageDal, CarImage carImage)
        {
            return carImageDal.GetAll(im => im.CarId == carImage.CarId).Count < 5;
        }

        private static bool CheckFileType(CarImage carImage)
        {
            var extension = new FileInfo(carImage.ImagePath).Extension;
            return (extension == ".jpg" || extension == ".jpeg" || extension == "png");
        }

    }
}
