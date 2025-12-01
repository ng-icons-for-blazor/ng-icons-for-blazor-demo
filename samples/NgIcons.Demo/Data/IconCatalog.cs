using System;
using System.Collections.Generic;
using NgIcons.Core;

namespace NgIcons.Demo.Data;

public sealed class IconLibraryEntry
{
    private IconLibrary? _library;
    private readonly Func<IReadOnlyDictionary<string, IconDefinition>> _iconsFactory;

    public IconLibraryEntry(string key, string displayName, string accent, Func<IReadOnlyDictionary<string, IconDefinition>> iconsFactory)
    {
        Key = key;
        DisplayName = displayName;
        Accent = accent;
        _iconsFactory = iconsFactory;
    }

    public string Key { get; }
    public string DisplayName { get; }
    public string Accent { get; }

    public IconLibrary Library => _library ??= new IconLibrary(DisplayName, _iconsFactory());
}

public static class IconCatalog
{
    public static IReadOnlyList<IconLibraryEntry> Libraries { get; } = new List<IconLibraryEntry>
    {
        new("akar-icons", "Akar Icons", "#f97316", () => global::NgIcons.AkarIcons.IconSet.All),
        new("bootstrap-icons", "Bootstrap Icons", "#7952b3", () => global::NgIcons.BootstrapIcons.IconSet.All),
        new("boxicons", "Boxicons", "#0ea5e9", () => global::NgIcons.Boxicons.IconSet.All),
        new("circum-icons", "Circum Icons", "#38bdf8", () => global::NgIcons.CircumIcons.IconSet.All),
        new("core", "ng-icons Core", "#475569", () => global::NgIcons.Core.IconSet.All),
        new("crypto", "Cryptocurrency Icons", "#22c55e", () => global::NgIcons.CryptocurrencyIcons.IconSet.All),
        new("cssgg", "css.gg", "#8b5cf6", () => global::NgIcons.CssGg.IconSet.All),
        new("devicon", "Devicon", "#14b8a6", () => global::NgIcons.Devicon.IconSet.All),
        new("dripicons", "Dripicons", "#eab308", () => global::NgIcons.Dripicons.IconSet.All),
        new("feather", "Feather Icons", "#fb923c", () => global::NgIcons.FeatherIcons.IconSet.All),
        new("flags", "Flag Icons", "#ef4444", () => global::NgIcons.FlagIcons.IconSet.All),
        new("fontawesome", "Font Awesome", "#0ea5e9", () => global::NgIcons.FontAwesome.IconSet.All),
        new("game", "Game Icons", "#a855f7", () => global::NgIcons.GameIcons.IconSet.All),
        new("heroicons", "Heroicons", "#06b6d4", () => global::NgIcons.Heroicons.IconSet.All),
        new("huge-icons", "Huge Icons", "#f97316", () => global::NgIcons.HugeIcons.IconSet.All),
        new("iconoir", "Iconoir", "#22d3ee", () => global::NgIcons.Iconoir.IconSet.All),
        new("iconsax", "Iconsax", "#22c55e", () => global::NgIcons.Iconsax.IconSet.All),
        new("ionicons", "Ionicons", "#64748b", () => global::NgIcons.Ionicons.IconSet.All),
        new("jam-icons", "Jam Icons", "#0ea5e9", () => global::NgIcons.JamIcons.IconSet.All),
        new("lets-icons", "Lets Icons", "#38bdf8", () => global::NgIcons.LetsIcons.IconSet.All),
        new("lucide", "Lucide", "#f59e0b", () => global::NgIcons.Lucide.IconSet.All),
        new("material-file-icons", "Material File Icons", "#6366f1", () => global::NgIcons.MaterialFileIcons.IconSet.All),
        new("material-icons", "Material Icons", "#2563eb", () => global::NgIcons.MaterialIcons.IconSet.All),
        new("material-symbols", "Material Symbols", "#dc2626", () => global::NgIcons.MaterialSymbols.IconSet.All),
        new("mynaui", "Mynaui", "#0f172a", () => global::NgIcons.Mynaui.IconSet.All),
        new("octicons", "Octicons", "#0a84ff", () => global::NgIcons.Octicons.IconSet.All),
        new("phosphor", "Phosphor Icons", "#f472b6", () => global::NgIcons.PhosphorIcons.IconSet.All),
        new("radix-icons", "Radix Icons", "#10b981", () => global::NgIcons.RadixIcons.IconSet.All),
        new("remixicon", "Remix Icon", "#f97316", () => global::NgIcons.Remixicon.IconSet.All),
        new("schematics", "Schematics", "#1e293b", () => global::NgIcons.Schematics.IconSet.All),
        new("simple-icons", "Simple Icons", "#3b82f6", () => global::NgIcons.SimpleIcons.IconSet.All),
        new("solar-icons", "Solar Icons", "#22d3ee", () => global::NgIcons.SolarIcons.IconSet.All),
        new("svgl", "SVGL", "#7c3aed", () => global::NgIcons.Svgl.IconSet.All),
        new("tabler-icons", "Tabler Icons", "#2563eb", () => global::NgIcons.TablerIcons.IconSet.All),
        new("tdesign", "TDesign Icons", "#0f766e", () => global::NgIcons.TdesignIcons.IconSet.All),
        new("typicons", "Typicons", "#ea580c", () => global::NgIcons.Typicons.IconSet.All),
        new("ux-aspects", "UX Aspects", "#0ea5e9", () => global::NgIcons.UxAspects.IconSet.All)
    };
}
