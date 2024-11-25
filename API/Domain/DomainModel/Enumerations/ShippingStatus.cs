namespace DomainModel.Enumerations
{
    public enum ShippingStatus
    {
        Pending,         // Kargo hazırlanıyor
        Shipped,         // Kargo yola çıktı
        Delivered,       // Teslim edildi
        FailedDelivery,  // Teslimat başarısız
    }
}
