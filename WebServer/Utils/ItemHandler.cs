using System.Globalization;
using System.IO;
using CsvHelper;
using System.Linq;
using WebServer.Model;

public class ItemHandler
{
    private readonly string _csvPath;

    public ItemHandler(string csvPath)
    {
        _csvPath = csvPath;
    }

    public Item GetItemById(int itemId)
    {
        using (var reader = new StreamReader(_csvPath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Item>().ToList();
            var record = records.FirstOrDefault(r => r.ItemId == itemId);
            return record;
        }
    }
}
