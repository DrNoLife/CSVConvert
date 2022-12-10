using CSVConvert.Converters;
using CSVConvert.FluentInterfaces;
using CSVConvert.Models;

namespace CSVConvert; 

/// <summary>
/// Entry point for the library. <br/>
/// Use the provided methods to select the input data type, and potential meta data, then proceed with converting to csv.
/// </summary>
public class CsvConverter : ICsvConverter, IDataInputStage, IMetaDataStage, IConvertStage
{
    private FromTypes? _from = null;
    private string _inputData = String.Empty;
    private List<List<string>> _inputList = new List<List<string>>();
    private List<string> _headers = new List<string>();

    public CsvConverter() { }

    // This is from the interface.
    IDataInputStage ICsvConverter.From()
    {
        return From();
    }

    // This is our implementation that yeets out a new object.
    public static IDataInputStage From()
    {
        return new CsvConverter();
    }

    public IMetaDataStage Table(string html)
    {
        _from = FromTypes.HtmlTable;
        _inputData = html;
        return this;
    }

    public IMetaDataStage ListOfStrings(List<List<string>> input)
    {
        _from = FromTypes.ListOfStrings;
        _inputList = input;
        return this;
    }

    public IMetaDataStage WithHeader(string header)
    {
        _headers.Add(header);
        return this;
    }

    public IMetaDataStage WithHeaders(List<string> headers)
    {
        _headers.AddRange(headers);
        return this;
    }

    public CsvModel Convert()
    {
        CsvModel result = _from switch
        {
            FromTypes.HtmlTable => new TableToCsv(_inputData, _headers).Convert(),
            FromTypes.ListOfStrings => new MultiListToCsv(_inputList, _headers).Convert(),
            _ => throw new NotSupportedException()
        };

        return result;
    }
}