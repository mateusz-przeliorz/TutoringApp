using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool Empty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
