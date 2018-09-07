using System;
using System.Security.Cryptography;
// <copyright file="SecureRandom.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Sorokin Dmitrii</author>
// <date>08/30/2018 12:10:53 AM </date>
// <summary>Realize secure random method</summary>
namespace Life
{
    public static class SecureRandom
    {
        private const int INT_SIZE = 4;
        private const int INT64_SIZE = 8;

        private static RandomNumberGenerator _Random;
        static SecureRandom()
        {
            _Random = new RNGCryptoServiceProvider();
        }
        public static Int32 Next()
        {
            byte[] data = new byte[INT_SIZE];
            Int32[] result = new Int32[1];

            _Random.GetBytes(data);
            Buffer.BlockCopy(data, 0, result, 0, INT_SIZE);

            return result[0];
        }
        public static Int32 Next(Int32 MaxValue)
        {
            Int32 result = 0;

            do
            {
                result = Next();
            } while (result > MaxValue);

            return result;
        }
    }
}
