using CSVConvert.FluentInterfaces;

namespace CSVConvert;

public interface ICsvConverter
{
    /// <summary>
    /// Initialize the convertion phase.<br />
    /// </summary>
    /// <returns></returns>
    IDataInputStage From();
}
