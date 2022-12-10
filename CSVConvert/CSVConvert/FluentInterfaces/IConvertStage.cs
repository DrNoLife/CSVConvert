using CSVConvert.Models;

namespace CSVConvert.FluentInterfaces;

public interface IConvertStage
{
    /// <summary>
    /// Converts the provided data, to a csv file.
    /// </summary>
    /// <returns></returns>
    public CsvModel Convert();
}
