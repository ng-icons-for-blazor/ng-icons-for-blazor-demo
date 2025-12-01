#nullable enable
using System.Collections.Generic;

namespace NgIcons.Core;

public sealed record IconDefinition(string Name, string Svg)
{
    public string WithSize(int? size) => size.HasValue ? Svg.Replace("<svg ", $"<svg width=\"{size}\" height=\"{size}\" ") : Svg;
}

public sealed class IconLibrary
{
    public IconLibrary(string name, IReadOnlyDictionary<string, IconDefinition> icons)
    {
        Name = name;
        Icons = icons;
    }

    public string Name { get; }

    public IReadOnlyDictionary<string, IconDefinition> Icons { get; }
}
