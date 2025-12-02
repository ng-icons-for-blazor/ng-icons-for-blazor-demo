#nullable enable
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace NgIcons.Core;

/// <summary>
/// Lazy-loading icon set without suffix/variant support.
/// Icons are loaded individually on first access, reducing memory usage.
/// </summary>
public class IconSet
{
    private readonly ConcurrentDictionary<string, IconDefinition> _cache = new(StringComparer.OrdinalIgnoreCase);
    private readonly Lazy<IReadOnlyList<string>> _iconNames;
    private readonly Assembly _assembly;
    private readonly string _namespace;

    /// <summary>
    /// Initializes the icon set with the assembly and namespace to load resources from.
    /// </summary>
    public IconSet(Assembly assembly, string resourceNamespace)
    {
        _assembly = assembly;
        _namespace = resourceNamespace;
        _iconNames = new Lazy<IReadOnlyList<string>>(() => LoadIndexInternal(""));
    }

    /// <summary>Available icon variants (empty for single-variant libraries).</summary>
    public IReadOnlyList<string> Suffixes => Array.Empty<string>();

    /// <summary>List of all available icon names.</summary>
    public IReadOnlyList<string> IconNames => _iconNames.Value;

    /// <summary>Gets an icon by name, loading it on first access.</summary>
    public IconDefinition Get(string name) => GetOrLoadInternal(name);

    /// <summary>Tries to get an icon by name.</summary>
    public bool TryGet(string name, [NotNullWhen(true)] out IconDefinition? icon)
    {
        if (!_iconNames.Value.Contains(name))
        {
            icon = null;
            return false;
        }
        icon = GetOrLoadInternal(name);
        return true;
    }

    /// <summary>Preloads all icons into memory. Use sparingly - defeats the purpose of lazy loading.</summary>
    public IReadOnlyDictionary<string, IconDefinition> PreloadAll()
    {
        foreach (var name in _iconNames.Value)
        {
            GetOrLoadInternal(name);
        }
        return _cache;
    }

    /// <summary>Gets or loads an icon by name (for use by generated static properties).</summary>
    public IconDefinition GetOrLoad(string name) => GetOrLoadInternal(name);

    private IconDefinition GetOrLoadInternal(string name)
    {
        return _cache.GetOrAdd(name, n =>
        {
            var resourceName = $"{_namespace}.Icons.{n}.svg";

            // Try exact match first, then case-insensitive match
            // (Windows file system is case-insensitive, so duplicate icon names with different casing
            // may result in only one file existing)
            var stream = _assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                // Find resource with case-insensitive match
                var allResources = _assembly.GetManifestResourceNames();
                var matchingResource = Array.Find(allResources, r =>
                    string.Equals(r, resourceName, StringComparison.OrdinalIgnoreCase));
                if (matchingResource != null)
                {
                    stream = _assembly.GetManifestResourceStream(matchingResource);
                }
            }

            if (stream == null)
            {
                throw new KeyNotFoundException($"Icon '{n}' not found. Resource: {resourceName}");
            }

            using (stream)
            using (var reader = new StreamReader(stream))
            {
                return new IconDefinition(n, reader.ReadToEnd());
            }
        });
    }

    private IReadOnlyList<string> LoadIndexInternal(string suffix)
    {
        var resourceName = string.IsNullOrEmpty(suffix)
            ? $"{_namespace}.Icons.index.json"
            : $"{_namespace}.Icons.{suffix}.index.json";

        using var stream = _assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Index resource '{resourceName}' not found.");
        using var reader = new StreamReader(stream);
        return JsonSerializer.Deserialize<string[]>(reader.ReadToEnd()) ?? Array.Empty<string>();
    }
}

/// <summary>
/// Lazy-loading icon set with suffix/variant support (e.g., outline, solid).
/// Icons are loaded individually on first access, reducing memory usage.
/// </summary>
public class IconSetWithSuffixes
{
    private readonly ConcurrentDictionary<(string suffix, string name), IconDefinition> _cache = new();
    private readonly ConcurrentDictionary<string, IReadOnlyList<string>> _indexCache = new();
    private readonly Lazy<IReadOnlyList<string>> _defaultIconNames;
    private readonly Assembly _assembly;
    private readonly string _namespace;
    private readonly string _defaultSuffix;
    private readonly IReadOnlyList<string> _suffixes;

    /// <summary>
    /// Initializes the icon set with the assembly, namespace, default suffix, and available suffixes.
    /// </summary>
    public IconSetWithSuffixes(Assembly assembly, string resourceNamespace, string defaultSuffix, IReadOnlyList<string> suffixes)
    {
        _assembly = assembly;
        _namespace = resourceNamespace;
        _defaultSuffix = defaultSuffix;
        _suffixes = suffixes;
        _defaultIconNames = new Lazy<IReadOnlyList<string>>(() => LoadIndexInternal(_defaultSuffix));
    }

    /// <summary>Available icon variants.</summary>
    public IReadOnlyList<string> Suffixes => _suffixes;

    /// <summary>The default suffix used when no suffix is specified.</summary>
    public string DefaultSuffix => _defaultSuffix;

    /// <summary>List of icon names for the default suffix.</summary>
    public IReadOnlyList<string> IconNames => _defaultIconNames.Value;

    /// <summary>Gets icon names for a specific suffix.</summary>
    public IReadOnlyList<string> GetIconNames(string suffix) =>
        _indexCache.GetOrAdd(suffix, LoadIndexInternal);

    /// <summary>Gets an icon by name from the default suffix.</summary>
    public IconDefinition Get(string name) => GetOrLoadInternal(_defaultSuffix, name);

    /// <summary>Gets an icon by name and suffix.</summary>
    public IconDefinition Get(string suffix, string name) => GetOrLoadInternal(suffix, name);

    /// <summary>Tries to get an icon by name from the default suffix.</summary>
    public bool TryGet(string name, [NotNullWhen(true)] out IconDefinition? icon)
        => TryGet(_defaultSuffix, name, out icon);

    /// <summary>Tries to get an icon by name and suffix.</summary>
    public bool TryGet(string suffix, string name, [NotNullWhen(true)] out IconDefinition? icon)
    {
        var names = _indexCache.GetOrAdd(suffix, LoadIndexInternal);
        if (!names.Contains(name))
        {
            icon = null;
            return false;
        }
        icon = GetOrLoadInternal(suffix, name);
        return true;
    }

    /// <summary>Preloads all icons for a suffix. Use sparingly - defeats the purpose of lazy loading.</summary>
    public IReadOnlyDictionary<string, IconDefinition> PreloadAll(string? suffix = null)
    {
        suffix ??= _defaultSuffix;
        var names = _indexCache.GetOrAdd(suffix, LoadIndexInternal);
        var result = new Dictionary<string, IconDefinition>(StringComparer.OrdinalIgnoreCase);
        foreach (var name in names)
        {
            result[name] = GetOrLoadInternal(suffix, name);
        }
        return result;
    }

    /// <summary>Gets or loads an icon by name from the default suffix (for use by generated static properties).</summary>
    public IconDefinition GetOrLoad(string name) => GetOrLoadInternal(_defaultSuffix, name);

    /// <summary>Gets or loads an icon by suffix and name (for use by generated static properties).</summary>
    public IconDefinition GetOrLoad(string suffix, string name) => GetOrLoadInternal(suffix, name);

    private IconDefinition GetOrLoadInternal(string suffix, string name)
    {
        return _cache.GetOrAdd((suffix, name), key =>
        {
            // MSBuild converts hyphens to underscores in embedded resource names
            var normalizedSuffix = key.suffix.Replace('-', '_');
            var resourceName = string.IsNullOrEmpty(key.suffix)
                ? $"{_namespace}.Icons.{key.name}.svg"
                : $"{_namespace}.Icons.{normalizedSuffix}.{key.name}.svg";

            // Try exact match first, then case-insensitive match
            // (Windows file system is case-insensitive, so duplicate icon names with different casing
            // may result in only one file existing)
            var stream = _assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                // Find resource with case-insensitive match
                var allResources = _assembly.GetManifestResourceNames();
                var matchingResource = Array.Find(allResources, r =>
                    string.Equals(r, resourceName, StringComparison.OrdinalIgnoreCase));
                if (matchingResource != null)
                {
                    stream = _assembly.GetManifestResourceStream(matchingResource);
                }
            }

            if (stream == null)
            {
                throw new KeyNotFoundException($"Icon '{key.name}' (suffix: '{key.suffix}') not found. Resource: {resourceName}");
            }

            using (stream)
            using (var reader = new StreamReader(stream))
            {
                return new IconDefinition(key.name, reader.ReadToEnd());
            }
        });
    }

    private IReadOnlyList<string> LoadIndexInternal(string suffix)
    {
        // Index files are directly in the Icons folder, so their names preserve hyphens
        // (MSBuild only converts folder path separators to dots and hyphens to underscores in folder names)
        var resourceName = string.IsNullOrEmpty(suffix)
            ? $"{_namespace}.Icons.index.json"
            : $"{_namespace}.Icons.{suffix}.index.json";

        using var stream = _assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Index resource '{resourceName}' not found.");
        using var reader = new StreamReader(stream);
        return JsonSerializer.Deserialize<string[]>(reader.ReadToEnd()) ?? Array.Empty<string>();
    }
}
