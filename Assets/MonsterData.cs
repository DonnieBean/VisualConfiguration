[System.Serializable]
public class MonsterData
{
    public string Name;
    public float Hp;
    public float Atk;
    public float Def;

    public override string ToString()
    {
        return $"名字是{Name}，Hp为{(int)Hp},Atk为{(int)Atk},Def为{((int)Def)}";
    }
}
