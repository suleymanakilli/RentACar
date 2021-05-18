using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Success="İşlem başarılı";
        public static string Error = "İşlem başarısız";
        public static string Added = "Başarıyla eklendi";
        public static string AddedError = "Ekleme işlemi başarısız";
        public static string Deleted = "Başarıyla silindi";
        public static string DeletedError = "Silme işlemi başarısız";
        public static string Updated = "Başarıyla güncellendi";
        public static string UpdatedError = "Güncelleme işlemi başarısız";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre hatalı";
        public static string UserAlreadyExists ="Kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string CarImageLimitExceeded="Her arabanın en fazla 5 resmi olabilir";
        public static string ReturnDateIsNull="Araba henüz teslim edilmemiş";
        public static string CarIsNotAvailable="Araba seçilen tarih aralığında müsait değil";
    }
}
