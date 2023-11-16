using UnityEngine;

public class AchievementList : MonoBehaviour
{
    [SerializeField]
    private GameObject scrollViewContent;
    [SerializeField]
    private GameObject achievementViewPrefab;

    void Start()
    {
        var allAchievements = AchievementsManager.Instance.GetAllAchievements();
    
        foreach (var achievement in allAchievements)
        {
            var view = Instantiate(achievementViewPrefab, scrollViewContent.transform);
            view.GetComponent<AchievementView>().SetAchievement(achievement);
        }
    }
}
