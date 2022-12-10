namespace CSVConvert.FluentInterfaces;

public interface IDataInputStage
{
    /// <summary>
    /// Convert to csv from an HTML table.
    /// </summary>
    /// <param name="html">full html of the table, including the <table></table> tags.</param>
    /// <returns></returns>
    public IMetaDataStage Table(string html);

    /// <summary>
    /// Converts to csv from a list containing lists of strings.
    /// </summary>
    /// <param name="input">List containing the elements that should be converted to csv.</param>
    /// <returns></returns>
    public IMetaDataStage ListOfStrings(List<List<string>> input);
}
