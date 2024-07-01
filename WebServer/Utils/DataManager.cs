public class DataManager
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
            }
            return instance;
        }
    }

    public ItemHandler itemHandler = new ItemHandler("Resources/ShopItem.csv");
    public MessageHandler messageHandler = new MessageHandler("Resources/MessagesInfo.csv");

    public void Init()
    {
        Console.WriteLine(this.ToString()+ "Init Complete");
    }
}

