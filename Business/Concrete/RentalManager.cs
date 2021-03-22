using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRent(Rental rental)
        {
            using (RentACarContext context = new RentACarContext())
            {
                if (!(rental.ReturnDate == null || rental.ReturnDate < DateTime.Now))
                {
                    return new ErrorResult(Messages.RentalError);

                }

            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
    }
}
