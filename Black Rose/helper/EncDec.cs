using Microsoft.Extensions.Configuration;
using NETCore.Encrypt;
using Npgsql;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Rose.helper
{
    public class EncDec
    {
        private IConfiguration configuration;
        private string key;
        private string constring;
        public EncDec(IConfiguration iconfig)
        {
            configuration = iconfig;
            key = configuration.GetSection("Settings").GetSection("aeskey").Value;
            constring = configuration.GetSection("Settings").GetSection("constring").Value;
        }

        public string enc(string text)
        {
            string encText = EncryptProvider.AESEncrypt(text, key);

            return encText;
        }

        public string dec (string text)
        {
            string decText = EncryptProvider.AESDecrypt(text, key);
            return decText;
        }

        public IDatabase Connection
        {
            get
            {
                return new Database(constring, DatabaseType.PostgreSQL, NpgsqlFactory.Instance);
            }
        }
    }
}
