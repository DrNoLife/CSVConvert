using CSVConvert.Models;

namespace CSVConvert.Converters;

internal class TableToCsv
{
    private readonly string _html;
    private readonly List<string> _headers;

    public TableToCsv(string html, List<string> headers)
    {
        _html = html;
        _headers = headers;
    }

    public CsvModel Convert()
    {
        throw new NotImplementedException();
    }
}
