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
        // Libraries without suffixes (use IconSet)
        new("akar-icons", "Akar Icons", "#f97316", () => global::NgIcons.AkarIcons.Icons.Instance.PreloadAll(), global::NgIcons.AkarIcons.Icons.Instance.Suffixes, _ => global::NgIcons.AkarIcons.Icons.Instance.PreloadAll()),
        new("bootstrap-icons", "Bootstrap Icons", "#7952b3", () => global::NgIcons.BootstrapIcons.Icons.Instance.PreloadAll(), global::NgIcons.BootstrapIcons.Icons.Instance.Suffixes, _ => global::NgIcons.BootstrapIcons.Icons.Instance.PreloadAll()),
        new("circum-icons", "Circum Icons", "#38bdf8", () => global::NgIcons.CircumIcons.Icons.Instance.PreloadAll(), global::NgIcons.CircumIcons.Icons.Instance.Suffixes, _ => global::NgIcons.CircumIcons.Icons.Instance.PreloadAll()),
        new("cssgg", "css.gg", "#8b5cf6", () => global::NgIcons.CssGg.Icons.Instance.PreloadAll(), global::NgIcons.CssGg.Icons.Instance.Suffixes, _ => global::NgIcons.CssGg.Icons.Instance.PreloadAll()),
        new("dripicons", "Dripicons", "#eab308", () => global::NgIcons.Dripicons.Icons.Instance.PreloadAll(), global::NgIcons.Dripicons.Icons.Instance.Suffixes, _ => global::NgIcons.Dripicons.Icons.Instance.PreloadAll()),
        new("feather", "Feather Icons", "#fb923c", () => global::NgIcons.FeatherIcons.Icons.Instance.PreloadAll(), global::NgIcons.FeatherIcons.Icons.Instance.Suffixes, _ => global::NgIcons.FeatherIcons.Icons.Instance.PreloadAll()),
        new("game", "Game Icons", "#a855f7", () => global::NgIcons.GameIcons.Icons.Instance.PreloadAll(), global::NgIcons.GameIcons.Icons.Instance.Suffixes, _ => global::NgIcons.GameIcons.Icons.Instance.PreloadAll()),
        new("huge-icons", "Huge Icons", "#f97316", () => global::NgIcons.HugeIcons.Icons.Instance.PreloadAll(), global::NgIcons.HugeIcons.Icons.Instance.Suffixes, _ => global::NgIcons.HugeIcons.Icons.Instance.PreloadAll()),
        new("iconoir", "Iconoir", "#22d3ee", () => global::NgIcons.Iconoir.Icons.Instance.PreloadAll(), global::NgIcons.Iconoir.Icons.Instance.Suffixes, _ => global::NgIcons.Iconoir.Icons.Instance.PreloadAll()),
        new("ionicons", "Ionicons", "#64748b", () => global::NgIcons.Ionicons.Icons.Instance.PreloadAll(), global::NgIcons.Ionicons.Icons.Instance.Suffixes, _ => global::NgIcons.Ionicons.Icons.Instance.PreloadAll()),
        new("jam-icons", "Jam Icons", "#0ea5e9", () => global::NgIcons.JamIcons.Icons.Instance.PreloadAll(), global::NgIcons.JamIcons.Icons.Instance.Suffixes, _ => global::NgIcons.JamIcons.Icons.Instance.PreloadAll()),
        new("lucide", "Lucide", "#f59e0b", () => global::NgIcons.Lucide.Icons.Instance.PreloadAll(), global::NgIcons.Lucide.Icons.Instance.Suffixes, _ => global::NgIcons.Lucide.Icons.Instance.PreloadAll()),
        new("radix-icons", "Radix Icons", "#10b981", () => global::NgIcons.RadixIcons.Icons.Instance.PreloadAll(), global::NgIcons.RadixIcons.Icons.Instance.Suffixes, _ => global::NgIcons.RadixIcons.Icons.Instance.PreloadAll()),
        new("remixicon", "Remix Icon", "#f97316", () => global::NgIcons.Remixicon.Icons.Instance.PreloadAll(), global::NgIcons.Remixicon.Icons.Instance.Suffixes, _ => global::NgIcons.Remixicon.Icons.Instance.PreloadAll()),
        new("simple-icons", "Simple Icons", "#3b82f6", () => global::NgIcons.SimpleIcons.Icons.Instance.PreloadAll(), global::NgIcons.SimpleIcons.Icons.Instance.Suffixes, _ => global::NgIcons.SimpleIcons.Icons.Instance.PreloadAll()),
        new("svgl", "SVGL", "#7c3aed", () => global::NgIcons.Svgl.Icons.Instance.PreloadAll(), global::NgIcons.Svgl.Icons.Instance.Suffixes, _ => global::NgIcons.Svgl.Icons.Instance.PreloadAll()),
        new("tdesign", "TDesign Icons", "#0f766e", () => global::NgIcons.TdesignIcons.Icons.Instance.PreloadAll(), global::NgIcons.TdesignIcons.Icons.Instance.Suffixes, _ => global::NgIcons.TdesignIcons.Icons.Instance.PreloadAll()),
        new("typicons", "Typicons", "#ea580c", () => global::NgIcons.Typicons.Icons.Instance.PreloadAll(), global::NgIcons.Typicons.Icons.Instance.Suffixes, _ => global::NgIcons.Typicons.Icons.Instance.PreloadAll()),
        new("ux-aspects", "UX Aspects", "#0ea5e9", () => global::NgIcons.UxAspects.Icons.Instance.PreloadAll(), global::NgIcons.UxAspects.Icons.Instance.Suffixes, _ => global::NgIcons.UxAspects.Icons.Instance.PreloadAll()),

        // Libraries with suffixes (use IconSetWithSuffixes)
        new("boxicons", "Boxicons", "#0ea5e9", () => global::NgIcons.Boxicons.Icons.Instance.PreloadAll(), global::NgIcons.Boxicons.Icons.Instance.Suffixes, s => global::NgIcons.Boxicons.Icons.Instance.PreloadAll(s)),
        new("crypto", "Cryptocurrency Icons", "#22c55e", () => global::NgIcons.CryptocurrencyIcons.Icons.Instance.PreloadAll(), global::NgIcons.CryptocurrencyIcons.Icons.Instance.Suffixes, s => global::NgIcons.CryptocurrencyIcons.Icons.Instance.PreloadAll(s)),
        new("devicon", "Devicon", "#14b8a6", () => global::NgIcons.Devicon.Icons.Instance.PreloadAll(), global::NgIcons.Devicon.Icons.Instance.Suffixes, s => global::NgIcons.Devicon.Icons.Instance.PreloadAll(s)),
        new("flags", "Flag Icons", "#ef4444", () => global::NgIcons.FlagIcons.Icons.Instance.PreloadAll(), global::NgIcons.FlagIcons.Icons.Instance.Suffixes, s => global::NgIcons.FlagIcons.Icons.Instance.PreloadAll(s)),
        new("fontawesome", "Font Awesome", "#0ea5e9", () => global::NgIcons.FontAwesome.Icons.Instance.PreloadAll(), global::NgIcons.FontAwesome.Icons.Instance.Suffixes, s => global::NgIcons.FontAwesome.Icons.Instance.PreloadAll(s)),
        new("heroicons", "Heroicons", "#06b6d4", () => global::NgIcons.Heroicons.Icons.Instance.PreloadAll(), global::NgIcons.Heroicons.Icons.Instance.Suffixes, s => global::NgIcons.Heroicons.Icons.Instance.PreloadAll(s)),
        new("iconsax", "Iconsax", "#22c55e", () => global::NgIcons.Iconsax.Icons.Instance.PreloadAll(), global::NgIcons.Iconsax.Icons.Instance.Suffixes, s => global::NgIcons.Iconsax.Icons.Instance.PreloadAll(s)),
        new("lets-icons", "Lets Icons", "#38bdf8", () => global::NgIcons.LetsIcons.Icons.Instance.PreloadAll(), global::NgIcons.LetsIcons.Icons.Instance.Suffixes, s => global::NgIcons.LetsIcons.Icons.Instance.PreloadAll(s)),
        new("material-file-icons", "Material File Icons", "#6366f1", () => global::NgIcons.MaterialFileIcons.Icons.Instance.PreloadAll(), global::NgIcons.MaterialFileIcons.Icons.Instance.Suffixes, s => global::NgIcons.MaterialFileIcons.Icons.Instance.PreloadAll(s)),
        new("material-icons", "Material Icons", "#2563eb", () => global::NgIcons.MaterialIcons.Icons.Instance.PreloadAll(), global::NgIcons.MaterialIcons.Icons.Instance.Suffixes, s => global::NgIcons.MaterialIcons.Icons.Instance.PreloadAll(s)),
        new("material-symbols", "Material Symbols", "#dc2626", () => global::NgIcons.MaterialSymbols.Icons.Instance.PreloadAll(), global::NgIcons.MaterialSymbols.Icons.Instance.Suffixes, s => global::NgIcons.MaterialSymbols.Icons.Instance.PreloadAll(s)),
        new("mynaui", "Mynaui", "#0f172a", () => global::NgIcons.Mynaui.Icons.Instance.PreloadAll(), global::NgIcons.Mynaui.Icons.Instance.Suffixes, s => global::NgIcons.Mynaui.Icons.Instance.PreloadAll(s)),
        new("octicons", "Octicons", "#0a84ff", () => global::NgIcons.Octicons.Icons.Instance.PreloadAll(), global::NgIcons.Octicons.Icons.Instance.Suffixes, s => global::NgIcons.Octicons.Icons.Instance.PreloadAll(s)),
        new("phosphor", "Phosphor Icons", "#f472b6", () => global::NgIcons.PhosphorIcons.Icons.Instance.PreloadAll(), global::NgIcons.PhosphorIcons.Icons.Instance.Suffixes, s => global::NgIcons.PhosphorIcons.Icons.Instance.PreloadAll(s)),
        new("solar-icons", "Solar Icons", "#22d3ee", () => global::NgIcons.SolarIcons.Icons.Instance.PreloadAll(), global::NgIcons.SolarIcons.Icons.Instance.Suffixes, s => global::NgIcons.SolarIcons.Icons.Instance.PreloadAll(s)),
        new("tabler-icons", "Tabler Icons", "#2563eb", () => global::NgIcons.TablerIcons.Icons.Instance.PreloadAll(), global::NgIcons.TablerIcons.Icons.Instance.Suffixes, s => global::NgIcons.TablerIcons.Icons.Instance.PreloadAll(s))
    };
}
