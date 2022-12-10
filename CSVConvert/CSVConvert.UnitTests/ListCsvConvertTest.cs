namespace CSVConvert.UnitTests;

[TestClass]
public class ListCsvConvertTest
{
    private readonly ICsvConverter _csvConverter;
    
    public ListCsvConvertTest()
    {
        _csvConverter = new CsvConverter();
    }

    [TestMethod]
    public void IsNotNull()
    {
        // Arrange.
        List<List<string>> listOfTestData = new()
        {
            new()
            {
                "test",
                "test",
                "test"
            },
            new()
            {
                "test2",
                "test2",
                "test2"
            }
        };

        // Act.
        var csv = _csvConverter
            .From()
            .ListOfStrings(listOfTestData)
            .WithHeader("Test header")
            .WithHeader("Test header 2")
            .WithHeader("Last header")
            .Convert();

        // Assert.
        Assert.IsNotNull(csv);
    }

    [TestMethod]
    public void WithHeader()
    {
        // Arrange.
        List<List<string>> listOfTestData = new()
        {
            new()
            {
                "test",
                "test",
                "test"
            },
            new()
            {
                "test2",
                "test2",
                "test2"
            }
        };

        // Act.
        var csv = _csvConverter
            .From()
            .ListOfStrings(listOfTestData)
            .WithHeader("Test header")
            .WithHeader("Test header 2")
            .WithHeader("Last header")
            .Convert();

        // Assert.
        int headerCount = csv.Headers.Count();
        Assert.AreEqual(headerCount, 3);
    }

    [TestMethod]
    public void WithHeaders()
    {
        // Arrange.
        List<List<string>> listOfTestData = new()
        {
            new()
            {
                "test",
                "test",
                "test"
            },
            new()
            {
                "test2",
                "test2",
                "test2"
            }
        };

        List<string> headers = new()
        {
            "Test header",
            "Test header 2",
            "Last header"
        };

        // Act.
        var csv = _csvConverter
            .From()
            .ListOfStrings(listOfTestData)
            .WithHeaders(headers)
            .Convert();

        // Assert.
        int headerCount = csv.Headers.Count();
        Assert.AreEqual(headerCount, 3);
    }

    [TestMethod]
    public void BasicConversion()
    {
        // Arrange.
        List<List<string>> data = new()
        {
            new()
            {
                "Hu Tao",
                "Ei",
                "Keqing"
            }
        };

        List<string> headers = new()
        {
            "Cutie", "Cutie 2", "Cutie 3"
        };

        // Act.
        var csv = _csvConverter
            .From()
            .ListOfStrings(data)
            .WithHeaders(headers)
            .Convert();

        // Assert.
        Assert.AreEqual("Cutie,Cutie 2,Cutie 3\r\nHu Tao,Ei,Keqing", csv.CsvData);
    }

    [TestMethod]
    public void MultiRowConversion()
    {
        // Arrange.
        List<List<string>> data = new()
        {
            new() { "Hu Tao", "Polearm", "Yes" },
            new() { "Keqing", "Sword", "Yes" },
            new() { "Venti", "Bow", "Confusion" },
        };

        List<string> headers = new()
        {
            "Character Name", "Weapon Type", "Cutie"
        };

        // Act.
        var csv = _csvConverter.From().ListOfStrings(data).WithHeaders(headers).Convert();

        // Assert.
        Assert.AreEqual("Character Name,Weapon Type,Cutie\r\nHu Tao,Polearm,Yes\r\nKeqing,Sword,Yes\r\nVenti,Bow,Confusion", csv.CsvData);
    }

    [TestMethod]
    public void HandleCommaInData()
    {
        // Arrange.
        List<List<string>> data = new()
        {
            new() { "Hu, Tao", "Polearm", "Yes" },
            new() { "Keqing", "Sword", "Yes" },
            new() { "Venti", "Bow", "Confusion" },
        };

        List<string> headers = new()
        {
            "Character Name", "Weapon Type", "Cutie"
        };

        // Act.
        var csv = _csvConverter.From().ListOfStrings(data).WithHeaders(headers).Convert();

        // Assert.
        Console.WriteLine(csv.CsvData);
        Assert.AreEqual("Character Name,Weapon Type,Cutie\r\n\"Hu, Tao\",Polearm,Yes\r\nKeqing,Sword,Yes\r\nVenti,Bow,Confusion", csv.CsvData);
    }
}
