

namespace CSVConvert.FluentInterfaces;

public interface IMetaDataStage : IConvertStage
{
    /// <summary>
    /// If the provided table doesn't contain a table head, use this method to add a header.<br/>
    /// If multiple headers are added, it will be added in chronological order.
    /// </summary>
    /// <param name="header">Name of the header to add.</param>
    /// <returns></returns>
    public IMetaDataStage WithHeader(string header);

    /// <summary>
    /// If the provided table doesn't contain a table head, use this method to add multiple headers at once. <br/>
    /// Ordering will be the same in the csv file, as it is in the list.
    /// </summary>
    /// <param name="headers">List of type string, containing all headers that should be added to the csv file.</param>
    /// <returns></returns>
    public IMetaDataStage WithHeaders(List<string> headers);
}