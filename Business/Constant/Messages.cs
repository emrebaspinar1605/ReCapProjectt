﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {
        #region CarStrings

        public static string CarAdded = "Araba Eklendi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarDeleted = "Araba Silindi.";

        public static string CarListed = "Arabalar Listelendi.";
        public static string GetCar = "Araba Getirildi.";

        public static string CarInvalid = "Araba Bilgileri Yanlış.";




        #endregion

        #region ColorStrings

        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorUpdated = "Renk Güncellendi.";
        public static string ColorDeleted = "Renk Silindi.";

        public static string ColorListed = " Renkler Listelendi.";
        public static string GetColor = "Renk Getirildi.";

        public static string ColorInvalid = "Renk Bilgileri Yanlış.";
        #endregion

        #region BrandStrings

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string BrandDeleted = "Marka Silindi.";

        public static string BrandListed = " Markalar Listelendi.";
        public static string GetBrand = "Marka Getirildi.";

        public static string BrandInvalid = "Marka Bilgileri Yanlış.";

        #endregion
        #region UserStrings
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";

        public static string UserListed = " Kullanıcılar Listelendi.";

        public static string UserInvalid = "Kullanıcı Bilgileri Yanlış.";

        public static string PassMustContainBigLetter = "Şifre Büyük Harf İçermelidir";
        public static string PassMustContainSpecialChar = "Şifre Özel Karakter İçermelidir.";
        public static string PassMustContainLetterAndDigit = "Şifre Harf Ve Sayı İçermelidir.";
        public static string PassMustContain = "Kullanıcı Bilgileri Yanlış.";


        #endregion

        #region CustomerStrings
        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";
        public static string CustomerDeleted = "Müşteri Silindi.";

        public static string CustomerListed = " Müşteriler Listelendi.";
        public static string GetCustomer = " Müşteri Bulundu.";

        public static string CustomerInvalid = "Müşteri Bilgileri Yanlış.";
        #endregion

        #region RentalStrings

        public static string RentalAdded = "Kiralama Eklendi.";
        public static string RentalUpdated = "Kiralama Güncellendi.";
        public static string RentalDeleted = "Kiralama Silindi.";

        public static string RentalListed = " Kiralama Listelendi.";
        public static string GetRental = "Kiralama Getirildi.";
        public static string RentalNotFound = "Kiralama Bulunamadı.";

        public static string RentalInvalid = "Kiralama Bilgileri Yanlış.";
        internal static string ImageAdded = "Araba Resmi Eklendi.";
        internal static string ImageDeleted = "Araba Resmi Silindi.";
        internal static string ImageUpdated = "Araba Resmi Silindi.";
        internal static string CarImagesOverLimit = "Araba Başına Düşen Resim Limiti Aşıldı.";
        internal static string? AuthorizationDenied = "Bu İşlem İçin Yetkili Değilsiniz.";
        internal static string UserRegistered = "Kullanıcı Kayıt Edildi";
        internal static string UserNotFound = "Kullanıcı Bulunamadı.";
        internal static string PasswordError = "Şifre Hatalı.";
        internal static string SuccessfulLogin = "Giriş Başarılı.";
        internal static string UserAlreadyExists = "Kullanıcı Zaten Mevcut.";
        internal static string AccessTokenCreated = "Erişim Token'ı Oluşturuldu.";
        internal static string EmailAlreadyRegistered = "Bu Email Zaten Sisteme Kayıtlı.";

        #endregion
    }
}
