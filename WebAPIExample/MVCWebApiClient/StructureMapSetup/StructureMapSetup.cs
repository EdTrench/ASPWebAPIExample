using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Serializer;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MVCWebApiClient
{
 public class StructureMapContainerSetup
 {
  public static void SetUp()
  {
   ObjectFactory.Initialize(x => x.AddRegistry<StructureMapRegistry>());
   DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
  }
 }

 public class StructureMapRegistry : Registry
 {
  public StructureMapRegistry()
  {
   For<ISerialization>().Use<JsonNetSerialization>();
   For<ProductsRepository>().Use<ProductsRepository>();
   For<ProductValidator>().Use<ProductValidator>();
  }
 }

 public class StructureMapDependencyResolver : IDependencyResolver
 {
  private readonly IContainer _container;

  public StructureMapDependencyResolver(IContainer container)
  {
   _container = container;
  }

  public object GetService(System.Type serviceType)
  {
   object instance = _container.TryGetInstance(serviceType);

   if (instance == null && !serviceType.IsAbstract)
   {
    _container.Configure(c => c.AddType(serviceType, serviceType));
    instance = _container.TryGetInstance(serviceType);
   }

   return instance;
  }

  public IEnumerable<object> GetServices(Type serviceType)
  {
   foreach (var component in _container.GetAllInstances(serviceType))
   {
    yield return component;
   }
  }
 }
}