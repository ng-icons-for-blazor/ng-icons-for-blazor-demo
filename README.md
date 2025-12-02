# ngIcons for Blazor

A collection of 76,000+ icons from [ng-icons](https://ng-icons.github.io/ng-icons) packaged as .NET libraries for Blazor applications.

## Overview

This project extracts SVG icons from the popular [ng-icons](https://ng-icons.github.io/ng-icons) Angular library and makes them available for Blazor developers. You can either:

1. **Install NuGet packages** - Reference icon libraries as dependencies in your Blazor project
2. **Copy individual icons** - Use the [demo site](https://ng-icons-for-blazor.github.io/ng-icons-for-blazor-demo) to browse and copy icon markup directly into your components

## Available Icon Libraries

| Library | NuGet Package |
|---------|---------------|
| Akar Icons | `NgIcons.AkarIcons` |
| Bootstrap Icons | `NgIcons.BootstrapIcons` |
| Boxicons | `NgIcons.Boxicons` |
| Circum Icons | `NgIcons.CircumIcons` |
| Cryptocurrency Icons | `NgIcons.CryptocurrencyIcons` |
| CSS.gg | `NgIcons.CssGg` |
| Devicon | `NgIcons.Devicon` |
| Dripicons | `NgIcons.Dripicons` |
| Feather Icons | `NgIcons.FeatherIcons` |
| Flag Icons | `NgIcons.FlagIcons` |
| Font Awesome | `NgIcons.FontAwesome` |
| Game Icons | `NgIcons.GameIcons` |
| Heroicons | `NgIcons.Heroicons` |
| Huge Icons | `NgIcons.HugeIcons` |
| Iconoir | `NgIcons.Iconoir` |
| Iconsax | `NgIcons.Iconsax` |
| Ionicons | `NgIcons.Ionicons` |
| Jam Icons | `NgIcons.JamIcons` |
| Lets Icons | `NgIcons.LetsIcons` |
| Lucide | `NgIcons.Lucide` |
| Material File Icons | `NgIcons.MaterialFileIcons` |
| Material Icons | `NgIcons.MaterialIcons` |
| Material Symbols | `NgIcons.MaterialSymbols` |
| Mynaui | `NgIcons.Mynaui` |
| Octicons | `NgIcons.Octicons` |
| Phosphor Icons | `NgIcons.PhosphorIcons` |
| Radix Icons | `NgIcons.RadixIcons` |
| Remixicon | `NgIcons.Remixicon` |
| Simple Icons | `NgIcons.SimpleIcons` |
| Solar Icons | `NgIcons.SolarIcons` |
| SVGL | `NgIcons.Svgl` |
| Tabler Icons | `NgIcons.TablerIcons` |
| TDesign Icons | `NgIcons.TdesignIcons` |
| Typicons | `NgIcons.Typicons` |
| UX Aspects | `NgIcons.UxAspects` |

## Usage

### Using NuGet Packages

Install the icon library you need:

```bash
dotnet add package NgIcons.Heroicons
```

Then use icons in your Blazor components:

```csharp
@using NgIcons.Heroicons

@if (IconSet.TryGet("heroArrowRight", out var icon))
{
    @((MarkupString)icon.Svg)
}
```

### Copying Icons Directly

Visit the [demo site](https://ng-icons-for-blazor.github.io/ng-icons-for-blazor-demo) to:

1. Browse all available icon libraries
2. Search for icons by name
3. Click on any icon to copy the SVG markup
4. Paste directly into your Blazor component

## Contributing

### Updating Icons

Icons are extracted from the ng-icons npm packages using the `extract-icons.ts` script. To update the icons:

#### Prerequisites

- Node.js (v18 or later)
- npm

#### Steps

1. Install dependencies:
   ```bash
   npm install
   ```

2. Update ng-icons packages to the latest version (optional):
   ```bash
   npm update
   ```

3. Run the extraction script:
   ```bash
   npm run extract-icons
   ```

### How the Extraction Script Works

The `scripts/extract-icons.ts` script performs the following:

1. **Reads each ng-icons npm package** - Iterates through all configured icon libraries in the `libraries` array

2. **Extracts icon data** - Loads the exported icon SVG strings from each package

3. **Generates .NET files** for each library:
   - `Icons.json` - A JSON file containing all icon names and their SVG content, embedded as a resource
   - `Icons.g.cs` - A C# class (`IconSet`) that provides:
     - `All` property - Returns all icons as `IReadOnlyDictionary<string, IconDefinition>`
     - `TryGet(name, out icon)` method - Retrieves a specific icon by name

4. **Updates the .csproj file** - Syncs the package version with the npm package version and ensures `Icons.json` is embedded as a resource

5. **Updates the demo page title** - Reflects the total icon count in the demo application

### Adding a New Icon Library

To add support for a new ng-icons library:

1. Install the npm package:
   ```bash
   npm install @ng-icons/new-library
   ```

2. Add an entry to the `libraries` array in `scripts/extract-icons.ts`:
   ```typescript
   { npm: '@ng-icons/new-library', project: 'NgIcons.NewLibrary' }
   ```

3. Create a new .NET project:
   ```bash
   dotnet new classlib -n NgIcons.NewLibrary -o src/NgIcons.NewLibrary
   ```

4. Add a reference to `NgIcons.Core` in the new project

5. Run the extraction script:
   ```bash
   npm run extract-icons
   ```

## License

Icons are sourced from [ng-icons](https://github.com/ng-icons/ng-icons) and retain their original licenses. Please refer to each icon library's license for usage terms.
