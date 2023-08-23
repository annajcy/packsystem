public class ItemData
{
    public int ID;
    public string Name;
    public int Type;
    public string Description;
    public int StoreCount;
    public int ItemCount;
    public int TimeLimit;

    public bool IsStoreInfinity() { return StoreCount == -1; }
    public bool IsItemInfinity() { return ItemCount == -1; }
    public bool IsTimeInfinity() { return TimeLimit == -1; }
    
}