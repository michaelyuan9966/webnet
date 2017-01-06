﻿using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace WebSocket4Net
{
    public static partial class Extensions
    {
        public static string GetString(this Encoding encoding, byte[] buffer)
        {
            return encoding.GetString(buffer, 0, buffer.Length);
        }

        public static string GetPathAndQuery(this Uri uri)
        {
            int pos = uri.OriginalString.IndexOf('/', uri.Scheme.Length + 3 + uri.Host.Length);

            if (pos < 0)
                return "/";

            return uri.OriginalString.Substring(pos);
        }

        public static string GetLeftPart(this Uri uri, int left)
        {
            
            int pos = uri.OriginalString.IndexOf('/', uri.Scheme.Length + 3 + uri.Host.Length);

            if (pos < 0)
                return uri.OriginalString;

            return uri.OriginalString.Substring(0, pos);
        }

        public static string[] Split(this string source, char[] spliter, int count, StringSplitOptions options)
        {
            var parts = source.Split(spliter, options);

            if (parts.Length <= count)
                return parts.ToArray();

            var partList = parts.Take(count - 1).ToList();
            partList.Add(string.Join(spliter[0].ToString(), parts, count - 1, parts.Length - count + 1));
            parts = partList.ToArray();
            return parts;
        }
    }

    public static class MD5
    {
        public static HashAlgorithm Create()
        {
            return new MD5Managed();
        }
    }


    public static class SHA1
    {
        public static HashAlgorithm Create()
        {
            return new SHA1Managed();
        }
    }

    static class UriPartial
    {
        public const byte Authority = 0;
    }
}
