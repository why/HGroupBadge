using HGroupBadge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGroupBadge.Helpers
{
    public static class StructureFormatHelper
    {
        private const int MinWithoutLeadingZero = 10;
        private const int MaxTypeValue = 99;

        public static string GetPrefix<T>(T type)
        {
            if (!(typeof(T).Name == "SymbolType" || typeof(T).Name == "BaseType"))
                throw new ArgumentException("T must be of type SymbolType or BaseType");

            int iType = Convert.ToInt32(type as Enum);
            return type is BaseType ? "b" : iType > MaxTypeValue ? "t" : "s";
        }

        public static string FormatType<T>(T type)
        {
            if (!(typeof(T).Name == "SymbolType" || typeof(T).Name == "BaseType"))
                throw new ArgumentException("T must be of type SymbolType or BaseType");

            int iType = Convert.ToInt32(type as Enum);
            return iType > MaxTypeValue ? iType.ToString().Remove(0, 1) : iType < MinWithoutLeadingZero ? "0" + iType : iType.ToString();
        }

        public static string FormatColor(BadgeColor color)
        {
            return (int)color < MinWithoutLeadingZero ? "0" + (int)color : ((int)color).ToString();
        }

        public static string FormatPosition(BadgePosition position)
        {
            return ((int)position).ToString();
        }
    }
}
