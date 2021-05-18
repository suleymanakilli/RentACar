using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilites.Interceptors;
using Core.Utilites.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarManager>().SingleInstance(); //Birisi constructure ' da ICarManager isterse ona CarManager ver.
            //SingleInstance dememizin sebebi biz bunların data tutmadığını sadece operasyon çağırmak için kullandığımızı biliyoruz. Bu yüzden 100 kullanıcımız olsa
            //100 instance oluşturmak yerine bir tane oluşturuyoruz ve bunu herkese veriyoruz.
            //Controller bunu istiyor ama bide bizim Business katmanımız var burada ise ICarDal'a ihtiyacımız var.
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();//Onuda böyle veriyoruz.

            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandManager>().SingleInstance();

            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorManager>().SingleInstance();

            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerManager>().SingleInstance();

            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalManager>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageManager>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<CreditCardManager>().As<ICreditCardManager>().SingleInstance();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthManager>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
