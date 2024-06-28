using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Server.Models;
using BL.Models;
using BL;
using Dal.DalApi;
using BL.BLApi;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/credit-card")]
    public class CreditCardController : ControllerBase
    {
        ICreditCardBL card;
        public CreditCardController(BlManager bl) {
            card = bl.card;
        }
        private static readonly string EncryptionKey = "your-secret-key"; // החלף למפתח סודי משלך

        [HttpPost]
        public ActionResult<BLCreditCard> Post([FromBody] BLCreditCard data)
        {
            try
            {
                string encryptedNumber = Encrypt(data.number);
                string encryptedExpiry = Encrypt(data.expiry);
                string encryptedCVC = Encrypt(data.cvc);

                // קריאה לפונקציה חיצונית שמכניסה את הנתונים לטבלה
                BLCreditCard c= card.Post(new BLCreditCard { number = encryptedNumber, expiry = encryptedExpiry, cvc = encryptedCVC }); ;

                return c;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private static string Encrypt(string plainText)
        {
            // יצירת מפתח מאורך נכון (256 ביטים)
            byte[] key = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(EncryptionKey.PadRight(key.Length)), key, key.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = new byte[16]; // אורך ה-IV ב-AES הוא תמיד 16 בתים
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cs))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }


    }

   
}
