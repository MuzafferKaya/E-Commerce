namespace DomainModel.Enumerations
{
    public enum OrderStatus
    {
        Pending,    //Beklemede
        Processing, //İşleniyor
        Shipped,    //Kargoda
        Completed,  //Tamamlandı
        Cancelled   //İptal Edildi
    }
}
