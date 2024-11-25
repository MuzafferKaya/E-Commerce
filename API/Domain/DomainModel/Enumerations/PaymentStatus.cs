namespace DomainModel.Enumerations
{
    public enum PaymentStatus
    {
        Pending,        // Bekliyor
        Completed,      // Tamamlandı
        Failed,         // Başarısız
        Cancelled,      // İptal
        Refunded        // İade
    }
}
