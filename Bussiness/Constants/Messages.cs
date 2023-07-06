using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Constants
{
    public class Messages
    {
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string AccessTokenCreated="Token oluşturuldu.";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string PasswordError="Parola hatası";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string UserRegistered="kayıt oldu";
    }
}
