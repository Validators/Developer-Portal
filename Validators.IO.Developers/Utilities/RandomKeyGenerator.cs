using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Validators.IO.Developers.Utilities
{
	public class RandomKeyGenerator
	{
		public static string GetUniqueKey(int size)
		{
			char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
			byte[] data = new byte[size];

			using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
			{
				crypto.GetBytes(data);
			}

			var result = new StringBuilder(size);
			foreach (byte b in data)
			{
				result.Append(chars[b % (chars.Length)]);
			}
			return result.ToString();
		}
	}
}
