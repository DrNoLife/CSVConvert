namespace CSVConvert.Models;

public class CsvModel
{
    /// <summary>
    /// Headers used for generating the csv formatted string.
    /// </summary>
    public List<string> Headers { get; init; }

    /// <summary>
    /// The csv formatted string, based on the input.
    /// </summary>
    public string CsvData { get; init; }

    public CsvModel(List<string> headers, string csvData)
    {
        Headers = headers;
        CsvData = csvData;
    }
}
