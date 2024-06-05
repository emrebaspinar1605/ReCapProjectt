using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;

ICarService carService = new CarManager(new EfCarDal());
IColorService colorService = new ColorManager(new EfColorDal());
IBrandService brandService = new BrandManager(new EfBrandDal());

CarTest1(carService);
Console.WriteLine();
Console.WriteLine("--------------------------");
Console.WriteLine();
CarTest2(carService);

Console.WriteLine();
Console.WriteLine("--------------------------");
Console.WriteLine();

ColorTest1(colorService);

Console.WriteLine();
Console.WriteLine("--------------------------");
Console.WriteLine();
BrandTest1(brandService);
static void BrandTest1(IBrandService brandService)
{
    foreach (var brand in brandService.GetAll())
    {
        Console.WriteLine(brand.BrandName);
    }
}

static void CarTest1(ICarService carService)
{
    foreach (var car in carService.GetCarDetails())
    {
        Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
    }
}

static void CarTest2(ICarService carService)
{
    foreach (var car in carService.GetCarsByBrandID(1))
    {
        Console.WriteLine(car.Description);
    }
}

static void ColorTest1(IColorService colorService)
{
    foreach (var color in colorService.GetAll())
    {
        Console.WriteLine(color.ColorName);
    }
}