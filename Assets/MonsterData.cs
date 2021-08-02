[System.Serializable]
public class MonsterData
{
    public string Name;
    public float Hp;
    public float Atk;
    public float Def;

    public override string ToString()
    {
        return $"������{Name}��HpΪ{(int)Hp},AtkΪ{(int)Atk},DefΪ{((int)Def)}";
    }
}
