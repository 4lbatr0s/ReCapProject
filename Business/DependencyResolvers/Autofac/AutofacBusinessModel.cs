using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    //AutofacBusinessModel is an Autofac module, not a Reflect'on model.
    public class AutofacBusinessModel:Module 
    {
        protected override void Load(ContainerBuilder builder) //first function to get invoked (dockerization, IES etc..)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageService >().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();





            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //From the executed program

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //find the implemented interfaces which are above (IProduct,ICategory etc..)
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {               //AspectInterceptorSelector works before every class declaration. It assess if there are any aspects for that class [...] is an Aspect, it is an attribute. 
                    Selector = new AspectInterceptorSelector() //Have AspectInterceptorSelector executed for the implemented interfaces. 
                }).SingleInstance();
        }


    }
}
