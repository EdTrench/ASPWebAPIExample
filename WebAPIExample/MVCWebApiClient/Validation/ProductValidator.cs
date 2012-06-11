using System;
using System.Linq;
using FluentValidation;
using MVCWebApiClient.Models;

namespace MVCWebApiClient
{
 public class ProductValidator : AbstractValidator<Product>, IValidator
 {
  public ProductValidator()
  {
   RuleFor(x => x.Name).NotEmpty().WithMessage("A name must be specified");
   RuleFor(x => x.Price).GreaterThan(0).WithMessage("The price must be greater than zero");
  }
 }
}