using System;
using System.Collections.Generic;
using NgIcons.Core;

namespace NgIcons.Demo.Data;

public sealed class IconLibraryEntry
{
    private readonly Dictionary<string, IconLibrary> _libraryCache = new();
    private readonly Func<IReadOnlyDictionary<string, IconDefinition>> _iconsFactory;
    private readonly Func<string, IReadOnlyDictionary<string, IconDefinition>> _iconsBySuffixFactory;

    public IconLibraryEntry(
        string key,
        string displayName,
        string accent,
        Func<IReadOnlyDictionary<string, IconDefinition>> iconsFactory,
        IReadOnlyList<string> suffixes,
        Func<string, IReadOnlyDictionary<string, IconDefinition>> iconsBySuffixFactory)
    {
        Key = key;
        DisplayName = displayName;
        Accent = accent;
        _iconsFactory = iconsFactory;
        Suffixes = suffixes;
        _iconsBySuffixFactory = iconsBySuffixFactory;
    }

    public string Key { get; }
    public string DisplayName { get; }
    public string Accent { get; }
    public IReadOnlyList<string> Suffixes { get; }
    public bool HasSuffixes => Suffixes.Count > 0;

    public IconLibrary Library => GetLibrary(Suffixes.Count > 0 ? Suffixes[0] : "");

    public IconLibrary GetLibrary(string suffix)
    {
        if (!_libraryCache.TryGetValue(suffix, out var library))
        {
            var icons = string.IsNullOrEmpty(suffix) && Suffixes.Count == 0
                ? _iconsFactory()
                : _iconsBySuffixFactory(suffix);
            library = new IconLibrary(DisplayName, icons);
            _libraryCache[suffix] = library;
        }
        return library;
    }
}

public static class IconCatalog
{
    public static IReadOnlyList<IconLibraryEntry> Libraries { get; } = new List<IconLibraryEntry>
    {
        new("akar-icons", "Akar Icons", "#f97316", () => global::NgIcons.AkarIcons.IconSet.All, global::NgIcons.AkarIcons.IconSet.Suffixes, global::NgIcons.AkarIcons.IconSet.GetBySuffix),
        new("bootstrap-icons", "Bootstrap Icons", "#7952b3", () => global::NgIcons.BootstrapIcons.IconSet.All, global::NgIcons.BootstrapIcons.IconSet.Suffixes, global::NgIcons.BootstrapIcons.IconSet.GetBySuffix),
        new("boxicons", "Boxicons", "#0ea5e9", () => global::NgIcons.Boxicons.IconSet.All, global::NgIcons.Boxicons.IconSet.Suffixes, global::NgIcons.Boxicons.IconSet.GetBySuffix),
        new("circum-icons", "Circum Icons", "#38bdf8", () => global::NgIcons.CircumIcons.IconSet.All, global::NgIcons.CircumIcons.IconSet.Suffixes, global::NgIcons.CircumIcons.IconSet.GetBySuffix),
        new("core", "ng-icons Core", "#475569", () => global::NgIcons.Core.IconSet.All, global::NgIcons.Core.IconSet.Suffixes, global::NgIcons.Core.IconSet.GetBySuffix),
        new("crypto", "Cryptocurrency Icons", "#22c55e", () => global::NgIcons.CryptocurrencyIcons.IconSet.All, global::NgIcons.CryptocurrencyIcons.IconSet.Suffixes, global::NgIcons.CryptocurrencyIcons.IconSet.GetBySuffix),
        new("cssgg", "css.gg", "#8b5cf6", () => global::NgIcons.CssGg.IconSet.All, global::NgIcons.CssGg.IconSet.Suffixes, global::NgIcons.CssGg.IconSet.GetBySuffix),
        new("devicon", "Devicon", "#14b8a6", () => global::NgIcons.Devicon.IconSet.All, global::NgIcons.Devicon.IconSet.Suffixes, global::NgIcons.Devicon.IconSet.GetBySuffix),
        new("dripicons", "Dripicons", "#eab308", () => global::NgIcons.Dripicons.IconSet.All, global::NgIcons.Dripicons.IconSet.Suffixes, global::NgIcons.Dripicons.IconSet.GetBySuffix),
        new("feather", "Feather Icons", "#fb923c", () => global::NgIcons.FeatherIcons.IconSet.All, global::NgIcons.FeatherIcons.IconSet.Suffixes, global::NgIcons.FeatherIcons.IconSet.GetBySuffix),
        new("flags", "Flag Icons", "#ef4444", () => global::NgIcons.FlagIcons.IconSet.All, global::NgIcons.FlagIcons.IconSet.Suffixes, global::NgIcons.FlagIcons.IconSet.GetBySuffix),
        new("fontawesome", "Font Awesome", "#0ea5e9", () => global::NgIcons.FontAwesome.IconSet.All, global::NgIcons.FontAwesome.IconSet.Suffixes, global::NgIcons.FontAwesome.IconSet.GetBySuffix),
        new("game", "Game Icons", "#a855f7", () => global::NgIcons.GameIcons.IconSet.All, global::NgIcons.GameIcons.IconSet.Suffixes, global::NgIcons.GameIcons.IconSet.GetBySuffix),
        new("heroicons", "Heroicons", "#06b6d4", () => global::NgIcons.Heroicons.IconSet.All, global::NgIcons.Heroicons.IconSet.Suffixes, global::NgIcons.Heroicons.IconSet.GetBySuffix),
        new("huge-icons", "Huge Icons", "#f97316", () => global::NgIcons.HugeIcons.IconSet.All, global::NgIcons.HugeIcons.IconSet.Suffixes, global::NgIcons.HugeIcons.IconSet.GetBySuffix),
        new("iconoir", "Iconoir", "#22d3ee", () => global::NgIcons.Iconoir.IconSet.All, global::NgIcons.Iconoir.IconSet.Suffixes, global::NgIcons.Iconoir.IconSet.GetBySuffix),
        new("iconsax", "Iconsax", "#22c55e", () => global::NgIcons.Iconsax.IconSet.All, global::NgIcons.Iconsax.IconSet.Suffixes, global::NgIcons.Iconsax.IconSet.GetBySuffix),
        new("ionicons", "Ionicons", "#64748b", () => global::NgIcons.Ionicons.IconSet.All, global::NgIcons.Ionicons.IconSet.Suffixes, global::NgIcons.Ionicons.IconSet.GetBySuffix),
        new("jam-icons", "Jam Icons", "#0ea5e9", () => global::NgIcons.JamIcons.IconSet.All, global::NgIcons.JamIcons.IconSet.Suffixes, global::NgIcons.JamIcons.IconSet.GetBySuffix),
        new("lets-icons", "Lets Icons", "#38bdf8", () => global::NgIcons.LetsIcons.IconSet.All, global::NgIcons.LetsIcons.IconSet.Suffixes, global::NgIcons.LetsIcons.IconSet.GetBySuffix),
        new("lucide", "Lucide", "#f59e0b", () => global::NgIcons.Lucide.IconSet.All, global::NgIcons.Lucide.IconSet.Suffixes, global::NgIcons.Lucide.IconSet.GetBySuffix),
        new("material-file-icons", "Material File Icons", "#6366f1", () => global::NgIcons.MaterialFileIcons.IconSet.All, global::NgIcons.MaterialFileIcons.IconSet.Suffixes, global::NgIcons.MaterialFileIcons.IconSet.GetBySuffix),
        new("material-icons", "Material Icons", "#2563eb", () => global::NgIcons.MaterialIcons.IconSet.All, global::NgIcons.MaterialIcons.IconSet.Suffixes, global::NgIcons.MaterialIcons.IconSet.GetBySuffix),
        new("material-symbols", "Material Symbols", "#dc2626", () => global::NgIcons.MaterialSymbols.IconSet.All, global::NgIcons.MaterialSymbols.IconSet.Suffixes, global::NgIcons.MaterialSymbols.IconSet.GetBySuffix),
        new("mynaui", "Mynaui", "#0f172a", () => global::NgIcons.Mynaui.IconSet.All, global::NgIcons.Mynaui.IconSet.Suffixes, global::NgIcons.Mynaui.IconSet.GetBySuffix),
        new("octicons", "Octicons", "#0a84ff", () => global::NgIcons.Octicons.IconSet.All, global::NgIcons.Octicons.IconSet.Suffixes, global::NgIcons.Octicons.IconSet.GetBySuffix),
        new("phosphor", "Phosphor Icons", "#f472b6", () => global::NgIcons.PhosphorIcons.IconSet.All, global::NgIcons.PhosphorIcons.IconSet.Suffixes, global::NgIcons.PhosphorIcons.IconSet.GetBySuffix),
        new("radix-icons", "Radix Icons", "#10b981", () => global::NgIcons.RadixIcons.IconSet.All, global::NgIcons.RadixIcons.IconSet.Suffixes, global::NgIcons.RadixIcons.IconSet.GetBySuffix),
        new("remixicon", "Remix Icon", "#f97316", () => global::NgIcons.Remixicon.IconSet.All, global::NgIcons.Remixicon.IconSet.Suffixes, global::NgIcons.Remixicon.IconSet.GetBySuffix),
        new("schematics", "Schematics", "#1e293b", () => global::NgIcons.Schematics.IconSet.All, global::NgIcons.Schematics.IconSet.Suffixes, global::NgIcons.Schematics.IconSet.GetBySuffix),
        new("simple-icons", "Simple Icons", "#3b82f6", () => global::NgIcons.SimpleIcons.IconSet.All, global::NgIcons.SimpleIcons.IconSet.Suffixes, global::NgIcons.SimpleIcons.IconSet.GetBySuffix),
        new("solar-icons", "Solar Icons", "#22d3ee", () => global::NgIcons.SolarIcons.IconSet.All, global::NgIcons.SolarIcons.IconSet.Suffixes, global::NgIcons.SolarIcons.IconSet.GetBySuffix),
        new("svgl", "SVGL", "#7c3aed", () => global::NgIcons.Svgl.IconSet.All, global::NgIcons.Svgl.IconSet.Suffixes, global::NgIcons.Svgl.IconSet.GetBySuffix),
        new("tabler-icons", "Tabler Icons", "#2563eb", () => global::NgIcons.TablerIcons.IconSet.All, global::NgIcons.TablerIcons.IconSet.Suffixes, global::NgIcons.TablerIcons.IconSet.GetBySuffix),
        new("tdesign", "TDesign Icons", "#0f766e", () => global::NgIcons.TdesignIcons.IconSet.All, global::NgIcons.TdesignIcons.IconSet.Suffixes, global::NgIcons.TdesignIcons.IconSet.GetBySuffix),
        new("typicons", "Typicons", "#ea580c", () => global::NgIcons.Typicons.IconSet.All, global::NgIcons.Typicons.IconSet.Suffixes, global::NgIcons.Typicons.IconSet.GetBySuffix),
        new("ux-aspects", "UX Aspects", "#0ea5e9", () => global::NgIcons.UxAspects.IconSet.All, global::NgIcons.UxAspects.IconSet.Suffixes, global::NgIcons.UxAspects.IconSet.GetBySuffix)
    };
}
