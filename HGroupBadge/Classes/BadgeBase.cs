using HGroupBadge.Enums;
using HGroupBadge.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGroupBadge
{
    public class BadgeBase : BadgePart
    {
        public BaseType Type { get; set; }

        public BadgeBase(BaseType type, BadgeColor color, BadgePosition position = BadgePosition.UpperLeft)
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
        }//
    }
}
