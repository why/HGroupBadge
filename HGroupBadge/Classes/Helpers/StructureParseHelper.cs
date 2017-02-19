using HGroupBadge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HGroupBadge.Helpers
{
    static class StructureParseHelper
    {
        private const string InvalidStructureMessage = "Given argument is not a valid badge structure";
        private const string StructureParsePattern = @"(?<Type>[b|s|t])(?<PartType>\d{2})(?<Color>\d{2})(?<Position>\d)";
        private const int HashLength = 32;
        private const int BadgePartLength = 6;

        private static string StripHash(string structure)
            => EndsWithHash(structure) ? structure.Remove(structure.Length - HashLength) : structure;

        private static bool VerifyStructureLength(string structure)
            => !(structure.Length % BadgePartLength != 0 && (structure.Length - HashLength) % BadgePartLength != 0);

        private static bool EndsWithHash(string structure)
            => (structure.Length % BadgePartLength != 0 && (structure.Length - HashLength) % BadgePartLength == 0);

        private static bool VerifyStructureSyntax(string structure)
            => Regex.Matches(StripHash(structure), StructureParsePattern).Count == StripHash(structure).Length / BadgePartLength;

        private static bool VerifyHash(string structure)
            => structure == StructureHashingHelper.GetHashedStructure(StripHash(structure));

        private static bool VerifyStructure(string structure)
        {
            if (!VerifyStructureLength(structure)) return false;
            if (!VerifyStructureSyntax(structure)) return false;
            if (EndsWithHash(structure))
                return VerifyHash(structure);
            else return true;
        }

        public static GroupBadge ParseFromStructure(string structure)
        {
            if (!VerifyStructure(structure)) throw new ArgumentException(InvalidStructureMessage);

            MatchCollection matches = Regex.Matches(StripHash(structure), StructureParsePattern);
            GroupBadge badge = new GroupBadge();

            foreach (Match match in matches)
            {
                switch (match.Groups["Type"].Value)
                {
                    case "b":
                    badge.Add(new BadgeBase(
                        (BaseType)int.Parse(match.Groups["PartType"].Value),
                        (BadgeColor)int.Parse(match.Groups["Color"].Value),
                        (BadgePosition)int.Parse(match.Groups["Position"].Value)));
                    break;
                    case "s":
                    badge.Add(new BadgeSymbol(
                        (SymbolType)int.Parse(match.Groups["PartType"].Value),
                        (BadgeColor)int.Parse(match.Groups["Color"].Value),
                        (BadgePosition)int.Parse(match.Groups["Position"].Value)));
                    break;
                    case "t":
                    badge.Add(new BadgeSymbol(
                        (SymbolType)int.Parse(match.Groups["PartType"].Value) + 100,
                        (BadgeColor)int.Parse(match.Groups["Color"].Value),
                        (BadgePosition)int.Parse(match.Groups["Position"].Value)));
                    break;
                }
            }

            return badge;
        }
    }
}
