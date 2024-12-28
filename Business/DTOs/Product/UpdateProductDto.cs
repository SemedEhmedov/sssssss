using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public List<int>? TagIds { get; set; }
    }
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull();
        }
    }
}
