using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Brand brand1 = new Brand() {BrandName = "BMW" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.GetAll();
            /*foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Brand Name : "+brand.BrandName);
            }*/
        }
    }
}
