using HGroupBadge.Enums;
using HGroupBadge.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGroupBadge
{
    public class BadgeSymbol : BadgePart
    {
        public SymbolType Type { get; set; }

        public BadgeSymbol(SymbolType type, BadgeColor color, BadgePosition position)
        {
            Type = type;
            Color = color;
            Position = position;
        }

        public override string ToString()
        {
            return $"{StructureFormatHelper.GetPrefix(Type)}" +
                   $"{StructureFormatHelper.FormatType(Type)}" +
                   $"{StructureFormatHelper.FormatColor(Color)}" +
                   $"{StructureFormatHelper.FormatPosition(Position)}";
        }
    }
}
