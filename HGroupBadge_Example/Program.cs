using HGroupBadge;
using HGroupBadge.Enums;
using System;

class C
{
    static void Main(string[] a)
    {
        GroupBadge badge = new GroupBadge();
        badge.Add(new BadgeBase(BaseType.Shield, BadgeColor.Pink, BadgePosition.BottomCenter));
        badge.Add(new BadgeSymbol(SymbolType.Snowstorm, BadgeColor.Red, BadgePosition.MiddleCenter));

        GroupBadge b = GroupBadge.FromUrl(badge.GetUrl());
        Console.ReadLine();
    }
}