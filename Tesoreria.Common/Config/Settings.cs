using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.Common.Config
{
    public class Settings
    {
        
        private const string userEmail = "userEmail";
        private const string userPassword = "userPassword";
        private const string isRemember = "isRemember";
        private const string user = "user";
        private static readonly string stringDefault = string.Empty;
        private static readonly bool boolDefault = false;
        private static ISettings AppSettings => CrossSettings.Current;

        public static string User
        {
            get => AppSettings.GetValueOrDefault(user, stringDefault);
            set => AppSettings.AddOrUpdateValue(user, value);
        }
        public static string UserEmail
        {
            get => AppSettings.GetValueOrDefault(userEmail, stringDefault);
            set => AppSettings.AddOrUpdateValue(userEmail, value);
        }

        public static string UserPassword
        {
            get => AppSettings.GetValueOrDefault(userPassword, stringDefault);
            set => AppSettings.AddOrUpdateValue(userPassword, value);
        }

        public static bool IsRemember
        {
            get => AppSettings.GetValueOrDefault(isRemember, boolDefault);
            set => AppSettings.AddOrUpdateValue(isRemember, value);
        }

    }
}
