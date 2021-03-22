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
        internal static string BrandAdded;
        internal static string BrandDeleted;
        internal static List<Brand> CategoryListed;
        internal static string BrandUpdated;
        internal static string ColorAdded;
        internal static string ColorDeleted;
        internal static string ColorsListed;
        internal static string ColorUpdated;
        internal static string CustomerDeleted;
        internal static string CustomerUpdated;
        internal static string RentalDeleted;
        internal static string RentalUpdated;
    }
}
