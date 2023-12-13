public interface Skill
{
    int GetId();
    int GetLevel();
    int GetMaxLevel();
    string GetName();
    string GetDescription();

    void SetLevel(int level);
}

public class BaseSkill : Skill
{
    private int id = -1;
    private int level = 0;
    private int maxLevel = 0;
    private string name = "Undefined";
    private string desc = "Undefined";

    public int GetId() { return id; }
    public int GetLevel() { return level; }
    public int GetMaxLevel() { return maxLevel; }
    public string GetName() { return name; }
    public string GetDescription() { return desc; }

    public BaseSkill(int id, int level, int maxLevel, string name, string desc)
    {
        this.id = id;
        this.level = level;
        this.maxLevel = maxLevel;
        this.name = name;
        this.desc = desc;
    }

    private BaseSkill() { }

    public void SetLevel(int value) { level = value; }

    public static BaseSkill UNDEFINED = new BaseSkill();
}
