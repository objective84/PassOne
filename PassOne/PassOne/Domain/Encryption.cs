using System;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

[Serializable]
public class Encryption
{
    // Change these keys
    private  byte[] _key;
    private  byte[] _vector;



    public Encryption()
    {
        _key = GenerateEncryptionKey();
        _vector = GenerateEncryptionVector();
    }

    public Encryption(byte[] key, byte[] vector)
    {
        _key = key;
        _vector = vector;
    }

    /// -------------- Two Utility Methods -----------
    /// Generates an encryption key.
    static public byte[] GenerateEncryptionKey()
    {
        //Generate a Key.
        var rm = new RijndaelManaged();
        rm.GenerateKey();
        return rm.Key;
    }

    /// Generates a unique encryption vector
    static public byte[] GenerateEncryptionVector()
    {
        //Generate a Vector
        var rm = new RijndaelManaged();
        rm.GenerateIV();
        return rm.IV;
    }


    /// ----------- The commonly used methods ------------------------------    
    /// Encrypt some text and return a string suitable for passing in a URL.
    public string EncryptToString(string textValue)
    {
        return ByteArrToString(Encrypt(textValue));
    }

    /// Encrypt some text and return an encrypted byte array.
    public byte[] Encrypt(string textValue)
    {
        var rm = new RijndaelManaged();
        var encryptorTransform = rm.CreateEncryptor(_key, _vector);
        var utfEncoder = new System.Text.UTF8Encoding();

        //Translates our text value into a byte array.
        var bytes = utfEncoder.GetBytes(textValue);

        //Used to stream the data in and out of the CryptoStream.
        var memoryStream = new MemoryStream();

        /*
         * We will have to write the unencrypted bytes to the stream,
         * then read the encrypted result back from the stream.
         */
        #region Write the decrypted value to the encryption stream
        var cs = new CryptoStream(memoryStream, encryptorTransform, CryptoStreamMode.Write);
        cs.Write(bytes, 0, bytes.Length);
        cs.FlushFinalBlock();
        #endregion

        #region Read encrypted value back out of the stream
        memoryStream.Position = 0;
        var encrypted = new byte[memoryStream.Length];
        memoryStream.Read(encrypted, 0, encrypted.Length);
        #endregion

        //Clean up.
        cs.Close();
        memoryStream.Close();
        var myString = encrypted.Aggregate(string.Empty, (current, b) => current + (b + ", "));
        Clipboard.Clear();
        Clipboard.SetText(myString);
        return encrypted;
    }

    /// The other side: Decryption methods
    public string DecryptString(string encryptedString)
    {
        return Decrypt(StrToByteArray(encryptedString));
    }

    /// Decryption when working with byte arrays.    
    public string Decrypt(byte[] encryptedValue)
    {
        var rm = new RijndaelManaged();
        var utfEncoder = new System.Text.UTF8Encoding();
        var decryptorTransform = rm.CreateDecryptor(_key, _vector);
        #region Write the encrypted value to the decryption stream

        var encryptedStream = new MemoryStream();
        var decryptStream = new CryptoStream(encryptedStream, decryptorTransform, CryptoStreamMode.Write);
        decryptStream.Write(encryptedValue, 0, encryptedValue.Length);
        decryptStream.FlushFinalBlock();
        #endregion

        #region Read the decrypted value from the stream.
        encryptedStream.Position = 0;
        var decryptedBytes = new Byte[encryptedStream.Length];
        encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
        encryptedStream.Close();
        #endregion
        return utfEncoder.GetString(decryptedBytes);
    }

    /// Convert a string to a byte array.  NOTE: Normally we'd create a Byte Array from a string using an ASCII encoding (like so).
    //      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    //      return encoding.GetBytes(str);
    // However, this results in character values that cannot be passed in a URL.  So, instead, I just
    // lay out all of the byte values in a long string of numbers (three per - must pad numbers less than 100).
    public static byte[] StrToByteArray(string str)
    {
        if (str.Length == 0)
            throw new Exception("Invalid string value in StrToByteArray");

        var byteArr = new byte[str.Length / 3];
        int i = 0;
        int j = 0;
        do
        {
            byte val = byte.Parse(str.Substring(i, 3));
            byteArr[j++] = val;
            i += 3;
        }
        while (i < str.Length);
        return byteArr;
    }

    // Same comment as above.  Normally the conversion would use an ASCII encoding in the other direction:
    //      System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
    //      return enc.GetString(byteArr);    
    public static string ByteArrToString(byte[] byteArr)
    {
        string tempStr = "";
        for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
        {
            byte val = byteArr[i];
            if (val < 10)
                tempStr += "00" + val.ToString();
            else if (val < 100)
                tempStr += "0" + val.ToString();
            else
                tempStr += val.ToString();
        }
        return tempStr;
    }

    public override string ToString()
    {
        return "Key: " + ByteArrToString(_key) +
               "/nVector: " + ByteArrToString(_vector);
    }
}