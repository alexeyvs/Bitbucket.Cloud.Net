﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
    public class PermissionsConverter : JsonEnumConverter<Permissions>
    {
        private static readonly Dictionary<Permissions, string> s_map = new Dictionary<Permissions, string>
        {
            [Permissions.Admin] = "admin",
            [Permissions.Write] = "write",
            [Permissions.Read] = "read"
        };

        protected override string ConvertToString(Permissions value)
        {
            if (!s_map.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown permission: {value}");
            }

            return result;
        }

        protected override Permissions ConvertFromString(string s)
        {
            var pair = s_map.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<Permissions, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown permission: {s}");
            }

            return pair.Key;
        }
    }
}