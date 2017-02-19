using HGroupBadge.Enums;
using HGroupBadge.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGroupBadge
{
    public class GroupBadge : List<BadgePart>
    {
        private const string HotelUrl = "https://www.habbo.";
        private const string BadgeImagingPath = "/habbo-imaging/badge/";
        private const string InvalidUrlMessage = "Given argument is not a valid badge URL";

        public GroupBadge()
        { }

        public string GetStructure()
        {
            StringBuilder sb = new StringBuilder();
            ForEach(bp => sb.Append(bp.ToString()));
            return StructureHashingHelper.GetHashedStructure(sb.ToString());
        }

        public string GetUrl(string hotel = "com")
            => HotelUrl + hotel + BadgeImagingPath + GetStructure();

        public override string ToString()
            => GetStructure();

        public static GroupBadge FromStructure(string structure)
            => StructureParseHelper.ParseFromStructure(structure.ToLower());

        public static GroupBadge FromUrl(string url)
        {
            url = url.ToLower();

            if (!url.Contains(BadgeImagingPath)) throw new ArgumentException(InvalidUrlMessage);
            url = url.Split('/').Last();
            url = url.Contains(".") ? url.Split('.')[0] : url;

            return FromStructure(url);
        }
    }
}
