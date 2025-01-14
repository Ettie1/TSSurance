﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace TSSurance.Lib
{
    public class Security
    {
        public static string GetSalt(int size)
        {
            byte[] buff = new byte[size];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static byte[] Hash(string password, string salt)
        {
            byte[] _password = Encoding.UTF8.GetBytes(password);
            byte[] _salt = Encoding.UTF8.GetBytes(salt);
            byte[] saltedPasswd = _password.Concat(_salt).ToArray();
            return new SHA256Managed().ComputeHash(saltedPasswd);
        }
        public static bool ConfirmPassword(string password, string passwdInDb, string salt)
        {
            byte[] newpasswd = Hash(password, salt);
            return newpasswd.SequenceEqual(Encoding.UTF8.GetBytes(passwdInDb));
        }

    }
}