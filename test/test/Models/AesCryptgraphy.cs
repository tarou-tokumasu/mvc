using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace test.Models
{

    public class AesCryptgraphy
    {
        /// <summary>
        /// AesCryptgraphy クラスのインスタンスを初期化します。
        /// </summary>
        public AesCryptgraphy()
        {
            this.BlockSize = 128;
            this.KeySize = 256;
        }

        /// <summary>
        /// キー長を指定して AesCryptgraphy クラス のインスタンスを初期化します。
        /// </summary>
        /// <param name="keySize"></param>
        public AesCryptgraphy(int keySize)
        {
            this.BlockSize = 128;
            this.KeySize = KeySize;
        }

        /// <summary>
        /// ブロック長を取得または設定します。
        /// ※値は 128bit 固定です。
        /// </summary>
        public int BlockSize { get; set; }

        /// <summary>
        /// キー長を取得または設定します。
        /// ※値は 128 / 192 / 256 bit から選択します。
        /// </summary>
        public int KeySize { get; set; }

        /// <summary>
        /// 共通鍵（IV, キー）を自動生成します。
        /// </summary>
        /// <param name="iv">IV</param>
        /// <param name="key">キー</param>
        public void CreateKey(out string iv, out string key)
        {
            // AES暗号サービスを生成
            var csp = new AesCryptoServiceProvider();
            csp.BlockSize = this.BlockSize;
            csp.KeySize = this.KeySize;
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;

            // IV および 鍵 を自動生成
            csp.GenerateIV();
            csp.GenerateKey();

            // 鍵を出力；
            iv = Convert.ToBase64String(csp.IV);
            key = Convert.ToBase64String(csp.Key);
        }

        /// <summary>
        /// 共通鍵を派生させるパスワードを指定して共通鍵（IV, キー）を生成します。
        /// </summary>
        /// <param name="ivPassword">IVを派生させるパスワード</param>
        /// <param name="iv">IV</param>
        /// <param name="keyPassword">キーを派生させるパスワード</param>
        /// <param name="key">キー</param>
        public void CreateKey(string ivPassword, out string iv, string keyPassword, out string key)
        {
            // IV を生成
            var rfcBlock = new Rfc2898DeriveBytes(ivPassword, this.BlockSize / 8);
            var arrBlock = rfcBlock.GetBytes(this.BlockSize / 8);
            iv = Convert.ToBase64String(arrBlock);

            // Key を生成
            var rfcKey = new Rfc2898DeriveBytes(keyPassword, this.KeySize / 8);
            var arrKey = rfcKey.GetBytes(this.BlockSize / 8);
            key = Convert.ToBase64String(arrKey);
        }

        /// <summary>
        /// IV、キーを指定して文字列の暗号化を行います。
        /// </summary>
        /// <param name="plainText">暗号化したい文字列</param>
        /// <param name="iv">IV</param>
        /// <param name="key">キー</param>
        /// <returns>暗号化された文字列</returns>
        public string Encrypt(string plainText, string iv, string key)
        {
            var cipherText = string.Empty;

            var csp = new AesCryptoServiceProvider();
            csp.BlockSize = this.BlockSize;
            csp.KeySize = this.KeySize;
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;
            csp.IV = Convert.FromBase64String(iv);
            csp.Key = Convert.FromBase64String(key);

            using (var outms = new MemoryStream())
            using (var encryptor = csp.CreateEncryptor())
            using (var cs = new CryptoStream(outms, encryptor, CryptoStreamMode.Write))
            {
                using (var writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                }
                cipherText = Convert.ToBase64String(outms.ToArray());
            }

            return cipherText;
        }

        /// <summary>
        /// IV、キーを指定して暗号化された文字列の複合を行います。
        /// </summary>
        /// <param name="cipherText">暗号化された文字列</param>
        /// <param name="iv">IV</param>
        /// <param name="key">キー</param>
        /// <returns>復号された文字列</returns>
        public string Decrypt(string cipherText, string iv, string key)
        {
            var plainText = string.Empty;

            var csp = new AesCryptoServiceProvider();
            csp.BlockSize = this.BlockSize;
            csp.KeySize = this.KeySize;
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;
            csp.IV = Convert.FromBase64String(iv);
            csp.Key = Convert.FromBase64String(key);

            using (var inms = new MemoryStream(Convert.FromBase64String(cipherText)))
            using (var decryptor = csp.CreateDecryptor())
            using (var cs = new CryptoStream(inms, decryptor, CryptoStreamMode.Read))
            using (var reader = new StreamReader(cs))
            {
                plainText = reader.ReadToEnd();
            }

            return plainText;
        }
    }
}