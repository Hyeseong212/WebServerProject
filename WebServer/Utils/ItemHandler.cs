using System.Globalization;
using System.IO;
using CsvHelper;
using System.Linq;
using WebServer.Model;


class GameDataManager
{
}
//GameDataManager.Item.GetItemById


// 동시성 이슈가 있습니다.
public class ItemHandler
{
    private readonly string _csvPath;
    private Dictionary<int, Item> _idToItem { get; set; }
    private readonly Timer _timer;
    private DateTime _lastModified;

    public ItemHandler(string csvPath)
    {
        _csvPath = csvPath;
        _idToItem = new Dictionary<int, Item>();

        ReadFile(csvPath);

        _timer = new Timer(CheckFileChanged, null, Timeout.Infinite, Timeout.Infinite);
        _timer.Change(0, 5000);
    }

    private void ReadFile(string csvPath)
    {
        _idToItem.Clear();
        using (var reader = new StreamReader(_csvPath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Item>().ToList();
            foreach (var record in records)
            {
                _idToItem.Add(record.ItemId, record);
            }
        }

        _lastModified = File.GetLastWriteTime(csvPath);
    }

    public Item GetItemById(int itemId)
    {
        return _idToItem.TryGetValue(itemId, out var item) ? item : null;
    }

    private void CheckFileChanged(object state)
    {
        DateTime currentModified = File.GetLastWriteTime(_csvPath);
        if (currentModified != _lastModified)
        {
            ReadFile(_csvPath);
        }
    }
}
