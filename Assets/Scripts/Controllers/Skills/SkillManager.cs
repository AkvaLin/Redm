using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    private int xp;
    private Dictionary<int, Skill> skills = new Dictionary<int, Skill>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<Skill> GetSkills() => skills.Values.ToList();

    private void AddSkill(Skill skill)
    {
        if (skill.GetId() < 0)
            throw new System.Exception("Скилл не может иметь id ниже нуля");
        if (!skills.TryAdd(skill.GetId(), skill))
            throw new System.Exception("Скилл с таким id уже существует");
    }

    private Skill GetSkillOrNull(int id) => skills.GetValueOrDefault(id, null);

    public bool CanLevelUpSkill(int id)
    {
        var skill = skills.GetValueOrDefault(id, null);
        if (skill == null) return false;

        return skill.GetLevel() < skill.GetMaxLevel() && xp > 0;
    }

    public bool LevelUpSkill(int id)
    {
        var skill = skills.GetValueOrDefault(id, null);
        if (skill == null) return false;

        var level = skill.GetLevel();
        if (level < skill.GetMaxLevel() && xp > 0)
        {
            skill.SetLevel(level + 1);
            xp--;
            return true;
        }

        return false;
    }

    enum ID
    {
        HP_BOOST,
        LUCK,    
        SLOW_MO, 
        ATTACK,  
    }

    public SkillManager()
    {
        var skillList = new List<Skill>
        {
            new BaseSkill(
                (int)ID.HP_BOOST, 0, 5,
                "Здоровье",
                "Добавляет по единице здоровья"
            ),
            new BaseSkill(
                (int)ID.LUCK, 0, 5,
                "Удача",
                "Добавляет удачу к получению XP"
            ),
            new BaseSkill(
                (int)ID.SLOW_MO, 0, 5,
                "Слоу-мо",
                "Добавляет возможность замедлить время"
            ),
            new BaseSkill(
                (int)ID.ATTACK, 0, 5,
                "Атака",
                "Прокачивает наносимый урон"
            ),
        };

        foreach (var sk in skillList)
        {
            AddSkill(sk);
        }
    }
}
