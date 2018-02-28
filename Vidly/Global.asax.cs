using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitializeMapper();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                //Domain to Dto
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                //Dto to Domain
                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<MovieDto, Movie>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
            });
        }
    }
}
