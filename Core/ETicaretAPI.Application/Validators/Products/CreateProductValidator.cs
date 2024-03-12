using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Product_Create>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını boş bırakmayınız!")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5-150 karakter arası giriniz!");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen stok değerini boş geçmeyiniz!")
                .Must(s => s >= 0)
                .WithMessage("Stok değeri negatif olamaz");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen fiyat değerini boş geçmeyiniz!")
                .Must(s => s >= 0)
                .WithMessage("Fiyat değeri negatif olamaz");
        }
    }
}
