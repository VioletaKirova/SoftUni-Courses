namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(pm => pm.CreditCard)
                .WithOne(c => c.PaymentMethod);

            builder.HasOne(pm => pm.BankAccount)
                .WithOne(ba => ba.PaymentMethod);
        }
    }
}
