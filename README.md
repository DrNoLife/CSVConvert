# CSVConvert

Easily convert HTML table to a CSV file.

## Get Started

To use the library, either directly reference the ICsvConverter with the implementation of CsvConverter, or use dependency injection.

```csharp
services.AddCsvConverter();
```

## Examples

The library uses fluent API to guide the user through the usage.

Some examples of this can be seen here.

```csharp
var csv = _csvConverter
            .From()
            .ListOfStrings(data)
            .WithHeaders(headers)
            .Convert();
```

```csharp
var csv = _csvConverter
            .From()
            .ListOfStrings(listOfTestData)
            .WithHeader("Test header")
            .WithHeader("Test header 2")
            .WithHeader("Last header")
            .Convert();
```

## Roadmap

So far it currently only works on ```List<List<string>>``` but I want it to work with a ```string``` containing a full HTML table. But that's a job for future me.