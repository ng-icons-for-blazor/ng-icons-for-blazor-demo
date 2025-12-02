#nullable enable
using System.Collections.Generic;

namespace NgIcons.Core;

/// <summary>
/// Represents an SVG icon definition with its name and SVG content.
/// </summary>
public sealed record IconDefinition(string Name, string Svg)
{
    /// <summary>
    /// Returns the SVG with explicit width and height attributes.
    /// </summary>
    public string WithSize(int? size) => size.HasValue ? Svg.Replace("<svg ", $"<svg width=\"{size}\" height=\"{size}\" ") : Svg;
}

/// <summary>
/// Represents a collection of icons (legacy class, kept for compatibility).
/// </summary>
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
