using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public class Messages
    {
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarDescriptionInvalid = "Araba açıklaması gerekir";
        public static string CarDeleted = "Araba başarıyla silindi";
        public static string CarUpdated = "Araba başarıyla güncellendi";
        public static string CarListed = "Arabalar başarıyla listelendi";
        public static string CustomerAdded = "Müşteri başarıyla eklendi";
        public static string RentalAdded = "Başarıyla kiralandı";
        public static string RentalError = "Araba kiralanamadı. Teslim Edilmemiş olabilir.";
        public static string ImageLimitExceeded = "Bu araba için resim limiti aşılmıştır";
        public static string AuthorizationDenied = "Giriş Reddedildi";
        public static string UserRegistered = "Kullanıcı kaydoldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "şifre hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı zaten var";
        public static string AccessTokenCreated = "erişim oluşturuldu";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string CategoryListed = "Kategoriler listelendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
    }
}
