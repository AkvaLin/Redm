using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchievementsManager: MonoBehaviour
{
    public static AchievementsManager Instance;

    private Dictionary<int, Achievement> achievements = new Dictionary<int, Achievement>();

    public Action<Achievement> OnAchievementCompleted;

    public Achievement GetAchievementOrNull(int id) =>
        achievements.GetValueOrDefault(id, null);

    public List<Achievement> GetAllAchievements() =>
        achievements.Values
            .ToList();

    public List<Achievement> GetCompletedAchievements() =>
        achievements.Values
            .Where(ach => ach.progress.IsCompleted())
            .ToList();

    public List<Achievement> GetUncompletedAchievements() =>
       achievements.Values
           .Where(ach => !ach.progress.IsCompleted())
           .ToList();

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

    private void AddAchievement(Achievement ach)
    {
        if (!achievements.TryAdd(ach.id, ach))
            throw new System.Exception("Достижение с таким id уже существует");
    }

    enum ID {
        TEST_ACHIEVEMENT,
        KILL_1,
        KILL_5,
        KILL_10,
        KILL_50,
        MISS_10,
        FIRST_DEATH,
    }

    public AchievementsManager()
    {
        var achievementsList = new List<Achievement>
        {
            new Achievement(
                (int) ID.TEST_ACHIEVEMENT,
                "Test Title",
                "Test Description",
                new BaseAchievementProgress(100),
                this
            ),
            new Achievement(
                (int) ID.KILL_1,
                "Первая кровь",
                "Убей первого врага",
                new BaseAchievementProgress(1),
                this
            ),
            new Achievement(
                (int) ID.KILL_5,
                "Вошёл во вкус",
                "Убей 5 врагов",
                new BaseAchievementProgress(5),
                this
            ),
            new Achievement(
                (int) ID.KILL_10,
                "Что он творит??",
                "Убей 10 врагов",
                new BaseAchievementProgress(10),
                this
            ),
            new Achievement(
                (int) ID.KILL_50,
                "Мессиво",
                "Убей 50 врагов",
                new BaseAchievementProgress(50),
                this
            ),
            new Achievement(
                (int) ID.MISS_10,
                "Лох",
                "Промахнись 10 раз",
                new BaseAchievementProgress(10),
                this
            ),
            new Achievement(
                (int) ID.FIRST_DEATH,
                "Жив хоть?",
                "Умри первый раз",
                new FlagAchievementProgress(),
                this
            ),
        };

        foreach (var a in achievementsList)
        {
            AddAchievement(a);
        }
    }
}
