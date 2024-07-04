using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

ICarService carService = new CarManager(new EfCarDal());
IColorService colorService = new ColorManager(new EfColorDal());
IBrandService brandService = new BrandManager(new EfBrandDal());
IUserService userService = new UserManager(new EfUserDal());
ICustomerService customerService = new CustomerManager(new EfCustomerDal());
IRentalService rentalService = new RentalManager(new EfRentalDal());

RentalTest1(rentalService);

//CustomerTest1(customerService);

//UserTest1(userService);

//CarTest1(carService);

//Console.WriteLine();

//Console.WriteLine("--------------------------");

//Console.WriteLine();

//CarTest2(carService);

//Console.WriteLine();
//Console.WriteLine("--------------------------");
//Console.WriteLine();

//ColorTest1(colorService);

//Console.WriteLine();
//Console.WriteLine("--------------------------");
//Console.WriteLine();
//BrandTest1(brandService);
static void BrandTest1(IBrandService brandService)
{
    foreach (var brand in brandService.GetAll().Data)
    {
        Console.WriteLine(brand.BrandName);
    }
    Console.WriteLine("---------------------");
    Console.WriteLine(brandService.GetAll().Message);
}

static void CarTest1(ICarService carService)
{
    foreach (var car in carService.GetCarDetails().Data)
    {
        Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
    }
    Console.WriteLine("---------------------");
    Console.WriteLine(carService.GetAll().Message);
}

static void CarTest2(ICarService carService)
{
    foreach (var car in carService.GetCarsByBrandID(1).Data)
    {
        Console.WriteLine(car.Description);
    }
    Console.WriteLine("---------------------");
    Console.WriteLine(carService.GetAll().Message);
}

static void ColorTest1(IColorService colorService)
{
    foreach (var color in colorService.GetAll().Data)
    {
        Console.WriteLine(color.ColorName);
    }
    Console.WriteLine("---------------------");
    Console.WriteLine(colorService.GetAll().Message);
}



static void CustomerTest1(ICustomerService customerService)
{
    customerService.Add(new Customer { UserId = 1, CompanyName = "EmBa" });
    foreach (var customer in customerService.GetAll().Data)
    {
        Console.WriteLine(customer.CompanyName);
    }
    foreach (var custo in customerService.GetCustomerDetail().Data)
    {
        Console.WriteLine(custo.FirstName + "-" + custo.LastName + "-" + custo.Email + "-" + custo.CompanyName);
    }
}

static void RentalTest1(IRentalService rentalService)
{
    foreach (var rental in rentalService.GetRentalDetails().Data)
    {

        Console.WriteLine(rental.CarName + " " + rental.BrandName + " " + rental.ColorName + " " + rental.DailyPrice + " " + rental.DailyPrice + " " + rental.RentDate + " " + rental.ReturnDate + " " + rental.FirstName + " " + rental.LastName + " " + rental.CompanyName + " " + rental.Email);
    }
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine(rentalService.GetRentalDetails().Message);
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine(rentalService.GetRentalByID(2).Data);
    Console.WriteLine("-----------------------------------------");
    foreach (var rental in rentalService.GetRentalByCustomerID(1).Data)
    {
        Console.WriteLine(rental.CustomerId + " " + rental.RentDate + " " + rental.ReturnDate);
    }
    Console.WriteLine("-----------------------------------------");
}