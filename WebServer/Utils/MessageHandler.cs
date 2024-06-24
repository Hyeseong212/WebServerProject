using System.Globalization;
using System.IO;
using CsvHelper;
using System.Linq;

public class MessageHandler
{
    private readonly string _csvPath;

    public MessageHandler(string csvPath)
    {
        _csvPath = csvPath;
    }

    public string SetMessage(string type, int messageCode)
    {
        using (var reader = new StreamReader(_csvPath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<dynamic>().ToList();
            var record = records.FirstOrDefault(r => r.TYPE == type && r.MessageCode == messageCode.ToString());
            return record != null ? record.Message : "메시지를 찾을 수 없습니다";
        }
    }
}
