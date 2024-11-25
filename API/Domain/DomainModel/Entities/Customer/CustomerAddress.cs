using System.ComponentModel.DataAnnotations.Schema;
using DomainModel.Entities.Base;

namespace DomainModel.Entities.Customer
{
    [Table("CustomerAddresses")]
    public class CustomerAddress : EntityBase
    {
        public long CustomerId { get; set; }                        // Bu adresin ait olduğu müşteri ID'si
        public Customer Customer { get; set; } = null!;             // Müşteri ile ilişkilendirilmiş müşteri nesnesi
        public string FullName { get; set; } = string.Empty;        // Adres sahibinin tam adı
        public string PhoneNumber { get; set; } = string.Empty;     // Adres sahibinin telefon numarası
        public string AddressLine1 { get; set; } = string.Empty;    // Adresin birinci satırı
        public string AddressLine2 { get; set; } = string.Empty;    // Adresin ikinci satırı 
        public string City { get; set; } = string.Empty;            // Şehir adı
        public string Country { get; set; } = string.Empty;         // Ülke adı
        public string PostalCode { get; set; } = string.Empty;      // Posta kodu
    }
}
