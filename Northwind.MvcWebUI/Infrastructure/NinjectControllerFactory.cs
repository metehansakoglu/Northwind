using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Northwind.Bll.Concrete;
using Northwind.CrossCuttingConcer.Logging;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
           

            AddServiceBindings();
        }

        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IProductService>().To<ProductManager>()
                .WithConstructorArgument("productDal",new EfProductDal());

            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>()
                .WithConstructorArgument("categoryDal", new EfCategoryDal());

            _ninjectKernel.Bind<IAuthenticationService>().To<AuthanticationManager>()
                .WithConstructorArgument("authenticationDal", new EfAuthenticationDal());

            _ninjectKernel.Intercept(p => (true)).With(new LoggingInterceptor());

        }

        public void AddServiceBindings()
        {
            _ninjectKernel.Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());

            _ninjectKernel.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());

            _ninjectKernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)
                _ninjectKernel.Get(controllerType);
        }
    }
}