using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleTMP;
    [SerializeField]
    private TextMeshProUGUI descriptionTMP;
    [SerializeField]
    private TextMeshProUGUI progressTMP; 
    [SerializeField]
    private Slider progressSlider;

    private Achievement ach;

    public void SetAchievement(Achievement ach)
    {
        this.ach = ach;
        OnUpdate();
    }

    public void OnUpdate()
    {
        titleTMP.text = ach.title;
        descriptionTMP.text = ach.description;
        progressTMP.text = ach.progress.GetProgressInfo();
        progressSlider.value = ach.progress.GetNormalizedProgress();
    }
}
