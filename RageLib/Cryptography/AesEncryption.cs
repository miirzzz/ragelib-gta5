﻿/*
    Copyright(c) 2015 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using System.Security.Cryptography;

namespace RageLib.Cryptography
{
    /// <summary>
    /// Represents an AES encryption algorithm.
    /// </summary>
    public class AesEncryption : IEncryptionAlgorithm
    {
        public byte[] Key { get; set; }
        public int Rounds { get; set; }

        public AesEncryption(byte[] key, int rounds = 1)
        {
            this.Key = key;
            this.Rounds = rounds;
        }

        /// <summary>
        /// Encrypts data.
        /// </summary>
        public byte[] Encrypt(byte[] data)
        {
            return EncryptData(data, Key, Rounds);
        }

        /// <summary>
        /// Decrypts data.
        /// </summary>
        public byte[] Decrypt(byte[] data)
        {
            return DecryptData(data, Key, Rounds);
        }

        /// <summary>
        /// Encrypts data.
        /// </summary>
        public static byte[] EncryptData(byte[] data, byte[] key, int rounds = 1)
        {
            var rijndael = Rijndael.Create();
            rijndael.KeySize = 256;
            rijndael.Key = key;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.None;

            var buffer = (byte[])data.Clone();
            var length = data.Length - data.Length % 16;

            // encrypt...
            if (length > 0)
            {
                var encryptor = rijndael.CreateEncryptor();
                for (var roundIndex = 0; roundIndex < rounds; roundIndex++)
                    encryptor.TransformBlock(buffer, 0, length, buffer, 0);
            }

            return buffer;
        }

        /// <summary>
        /// Decrypts data.
        /// </summary>
        public static byte[] DecryptData(byte[] data, byte[] key, int rounds = 1)
        {
            var rijndael = Rijndael.Create();
            rijndael.KeySize = 256;
            rijndael.Key = key;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.None;

            var buffer = (byte[])data.Clone();
            var length = data.Length - data.Length % 16;

            // decrypt...
            if (length > 0)
            {
                var decryptor = rijndael.CreateDecryptor();
                for (var roundIndex = 0; roundIndex < rounds; roundIndex++)
                    decryptor.TransformBlock(buffer, 0, length, buffer, 0);
            }

            return buffer;
        }
    }
}