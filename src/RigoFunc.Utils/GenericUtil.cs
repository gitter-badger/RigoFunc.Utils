// Copyright (c) RigoFunc (xuyingting). All rights reserved.

using System;
using System.Security.Cryptography;
using System.Text;

namespace RigoFunc.Utils {
    /// <summary>
    /// Represents a generic utility library.
    /// </summary>
    public static class GenericUtil {
        private static readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        /// <summary>
        /// Generates an global unique key.
        /// </summary>
        /// <param name="size">The size of the key</param>
        /// <returns>The generated unique key.</returns>
        public static string UniqueKey(int size = 8) {
            var data = new byte[size];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(data);
            var sb = new StringBuilder(size);
            foreach (byte b in data) {
                sb.Append(_chars[b % (_chars.Length - 1)]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the series number.
        /// </summary>
        /// <param name="prefix">The prefix of the seires number.</param>
        /// <returns>A new series numer.</returns>
        public static string GetSeriesNumber(string prefix = "SW") => $"{prefix}{DateTime.Now.ToString("yyyyMMddHHmmss")}{UniqueKey()}";
    }
}
