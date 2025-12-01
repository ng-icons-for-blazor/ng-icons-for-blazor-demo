using System.Collections.Generic;
using NgIcons.Core;

namespace NgIcons.Demo.Data;

public sealed record IconLibraryEntry(string Key, string DisplayName, string Accent, IconLibrary Library);

public static class IconCatalog
{
    public static IReadOnlyList<IconLibraryEntry> Libraries { get; } = new List<IconLibraryEntry>
    {
        new("akar-icons", "Akar Icons", "#f97316", new IconLibrary("Akar Icons", global::NgIcons.AkarIcons.IconSet.All)),
        new("bootstrap-icons", "Bootstrap Icons", "#7952b3", new IconLibrary("Bootstrap Icons", global::NgIcons.BootstrapIcons.IconSet.All)),
        new("boxicons", "Boxicons", "#0ea5e9", new IconLibrary("Boxicons", global::NgIcons.Boxicons.IconSet.All)),
        new("circum-icons", "Circum Icons", "#38bdf8", new IconLibrary("Circum Icons", global::NgIcons.CircumIcons.IconSet.All)),
        new("core", "ng-icons Core", "#475569", new IconLibrary("ng-icons Core", global::NgIcons.Core.IconSet.All)),
        new("crypto", "Cryptocurrency Icons", "#22c55e", new IconLibrary("Cryptocurrency Icons", global::NgIcons.CryptocurrencyIcons.IconSet.All)),
        new("cssgg", "css.gg", "#8b5cf6", new IconLibrary("css.gg", global::NgIcons.CssGg.IconSet.All)),
        new("devicon", "Devicon", "#14b8a6", new IconLibrary("Devicon", global::NgIcons.Devicon.IconSet.All)),
        new("dripicons", "Dripicons", "#eab308", new IconLibrary("Dripicons", global::NgIcons.Dripicons.IconSet.All)),
        new("feather", "Feather Icons", "#fb923c", new IconLibrary("Feather Icons", global::NgIcons.FeatherIcons.IconSet.All)),
        new("flags", "Flag Icons", "#ef4444", new IconLibrary("Flag Icons", global::NgIcons.FlagIcons.IconSet.All)),
        new("fontawesome", "Font Awesome", "#0ea5e9", new IconLibrary("Font Awesome", global::NgIcons.FontAwesome.IconSet.All)),
        new("game", "Game Icons", "#a855f7", new IconLibrary("Game Icons", global::NgIcons.GameIcons.IconSet.All)),
        new("heroicons", "Heroicons", "#06b6d4", new IconLibrary("Heroicons", global::NgIcons.Heroicons.IconSet.All)),
        new("huge-icons", "Huge Icons", "#f97316", new IconLibrary("Huge Icons", global::NgIcons.HugeIcons.IconSet.All)),
        new("iconoir", "Iconoir", "#22d3ee", new IconLibrary("Iconoir", global::NgIcons.Iconoir.IconSet.All)),
        new("iconsax", "Iconsax", "#22c55e", new IconLibrary("Iconsax", global::NgIcons.Iconsax.IconSet.All)),
        new("ionicons", "Ionicons", "#64748b", new IconLibrary("Ionicons", global::NgIcons.Ionicons.IconSet.All)),
        new("jam-icons", "Jam Icons", "#0ea5e9", new IconLibrary("Jam Icons", global::NgIcons.JamIcons.IconSet.All)),
        new("lets-icons", "Lets Icons", "#38bdf8", new IconLibrary("Lets Icons", global::NgIcons.LetsIcons.IconSet.All)),
        new("lucide", "Lucide", "#f59e0b", new IconLibrary("Lucide", global::NgIcons.Lucide.IconSet.All)),
        new("material-file-icons", "Material File Icons", "#6366f1", new IconLibrary("Material File Icons", global::NgIcons.MaterialFileIcons.IconSet.All)),
        new("material-icons", "Material Icons", "#2563eb", new IconLibrary("Material Icons", global::NgIcons.MaterialIcons.IconSet.All)),
        new("material-symbols", "Material Symbols", "#dc2626", new IconLibrary("Material Symbols", global::NgIcons.MaterialSymbols.IconSet.All)),
        new("mynaui", "Mynaui", "#0f172a", new IconLibrary("Mynaui", global::NgIcons.Mynaui.IconSet.All)),
        new("octicons", "Octicons", "#0a84ff", new IconLibrary("Octicons", global::NgIcons.Octicons.IconSet.All)),
        new("phosphor", "Phosphor Icons", "#f472b6", new IconLibrary("Phosphor Icons", global::NgIcons.PhosphorIcons.IconSet.All)),
        new("radix-icons", "Radix Icons", "#10b981", new IconLibrary("Radix Icons", global::NgIcons.RadixIcons.IconSet.All)),
        new("remixicon", "Remix Icon", "#f97316", new IconLibrary("Remix Icon", global::NgIcons.Remixicon.IconSet.All)),
        new("schematics", "Schematics", "#1e293b", new IconLibrary("Schematics", global::NgIcons.Schematics.IconSet.All)),
        new("simple-icons", "Simple Icons", "#3b82f6", new IconLibrary("Simple Icons", global::NgIcons.SimpleIcons.IconSet.All)),
        new("solar-icons", "Solar Icons", "#22d3ee", new IconLibrary("Solar Icons", global::NgIcons.SolarIcons.IconSet.All)),
        new("svgl", "SVGL", "#7c3aed", new IconLibrary("SVGL", global::NgIcons.Svgl.IconSet.All)),
        new("tabler-icons", "Tabler Icons", "#2563eb", new IconLibrary("Tabler Icons", global::NgIcons.TablerIcons.IconSet.All)),
        new("tdesign", "TDesign Icons", "#0f766e", new IconLibrary("TDesign Icons", global::NgIcons.TdesignIcons.IconSet.All)),
        new("typicons", "Typicons", "#ea580c", new IconLibrary("Typicons", global::NgIcons.Typicons.IconSet.All)),
        new("ux-aspects", "UX Aspects", "#0ea5e9", new IconLibrary("UX Aspects", global::NgIcons.UxAspects.IconSet.All))
    };
}
