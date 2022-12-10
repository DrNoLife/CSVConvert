using CSVConvert.Models;
using System.Text;

namespace CSVConvert.Converters;

internal class MultiListToCsv
{
    private List<List<string>> _inputData;
	private List<string> _headers;

	private bool _headersWasNotInInput => _headers.Count == 0;

	public MultiListToCsv(List<List<string>> inputData, List<string> headers)
	{
		_inputData = inputData;
		_headers = headers;
	}

	public CsvModel Convert()
	{
        // Check headers.
        GetHeaders();

		// Convert.
		StringBuilder csv = new StringBuilder();
        csv.AppendLine(CombineHeadersToString());

		foreach(var item in _inputData)
		{
			csv.AppendLine(CombineListItemsToString(item));
		}

		string csvString = csv.ToString().Trim();

        // Return.
        return new(_headers, csvString);
    }

	private void GetHeaders() 
	{
		if(_headersWasNotInInput)
		{
			// Need to get them from input.
			_headers = _inputData[0];
			_inputData.RemoveAt(0);
		}
	}

	private string CombineHeadersToString()
	{
		StringBuilder headers = new();
        _headers.ForEach(x => headers.Append($"{x},"));
		headers.Length -= 1;
		return headers.ToString();
    }

	private string CombineListItemsToString(List<string> data)
	{
		StringBuilder combined = new();
        foreach (var item in data)
        {
			string itemToAdd = item.Contains(',') ? $"\"{item}\"," : $"{item},";
			combined.Append(itemToAdd);
        }

		// Remove the ', ' at the end.
		combined.Length -= 1;

		return combined.ToString();
    }

	private string ValidityCheck()
	{
		throw new NotImplementedException();
	}
}
