using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.ViewEngines.Razor;

namespace B2CDemo
{
  public class B2CBootstrapper: DefaultNancyBootstrapper
  {
    protected override IEnumerable<Type> ViewEngines
    {
      get { yield return typeof(RazorViewEngine); }
    }

   
  }
}