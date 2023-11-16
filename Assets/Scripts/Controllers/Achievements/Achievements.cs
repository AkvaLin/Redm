using System;
using UnityEngine;

public class Achievement
{
    public int id { private set; get; }
    public string title { private set; get; }
    public string description { private set; get; }
    public AchievementProgress progress { private set; get; }
    public AchievementsManager manager { private set; get; }

    public Achievement(
        int id,
        string title,
        string description,
        AchievementProgress progress,
        AchievementsManager manager
    ) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.progress = progress;
        this.manager = manager;

        progress.SetParent(this);
    }

    public void OnAchievementCompleted()
    {
        manager.OnAchievementCompleted(this);
    }
}

public interface AchievementProgress
{
    /// <summary>
    /// Возвращает прогресс ачивки в виде [0..1]
    /// </summary>
    public float GetNormalizedProgress();

    /// <summary>
    /// Инфа о прогрессе, аля "42/100" или "Не выполнено"
    /// </summary>
    public string GetProgressInfo();

    /// <summary>
    /// Выполнена ли ачивка
    /// </summary>
    public bool IsCompleted();

    /// <summary>
    /// Сбрасывает прогресс
    /// </summary>
    public void Reset();

    /// <summary>
    /// Назначает владельца прогресса
    /// </summary>
    public void SetParent(Achievement parent);
}

/// <summary>
/// Базовый вид прогресса, покрывает 99% юзкейсов.
/// Имеет макс значение и текущее значение - оба инты.
/// </summary>
public class BaseAchievementProgress: AchievementProgress {
    /// <summary>
    /// Текущее значение прогресса
    /// </summary>
    private int current = 0;

    /// <summary>
    /// Цель, конечная точка прогресса.
    /// </summary>
    public int target { private set; get; }

    private bool completionTriggered = false;

    private Achievement parent = null;

    public BaseAchievementProgress(int target)
    {
        this.target = target;
    }

    public void SetParent(Achievement parent)
    {
        this.parent = parent;
    }

    public void SetProgress(int current)
    {
        this.current = current;
        if (current >= target && !completionTriggered)
        {
            completionTriggered = true;
            parent?.OnAchievementCompleted();
        }
    }

    public int GetProgress() => current;

    public float GetNormalizedProgress() => Mathf.Clamp((float) current / target, 0f, 1f);
    public string GetProgressInfo() => $"{Math.Min(current, target)}/{target}";
    public bool IsCompleted() => current >= target;
    public void Reset() { current = 0; completionTriggered = false; }
}

/// <summary>
/// Прогресс-флаг.
/// Имеет один флаг - выполнено ли.
/// </summary>
public class FlagAchievementProgress: AchievementProgress {
    private bool done = false;

    private Achievement parent;

    private bool completionTriggered = false;

    public void SetParent(Achievement parent)
    {
        this.parent = parent;
    }

    public void SetProgress(bool done)
    {
        this.done = done;
        if (done && !completionTriggered)
        {
            completionTriggered = true;
            parent.OnAchievementCompleted();
        }
    }

    public bool GetProgress() => done;

    public float GetNormalizedProgress() {
        if (done) return 1f;
        else return 0f;
    }
    public string GetProgressInfo() {
        if (done) return DONE;
        else return NOT_DONE;
    }
    public bool IsCompleted() => done;
    public void Reset() { done = false; }

    const string DONE = "Выполнено";
    const string NOT_DONE = "Не выполнено";
}