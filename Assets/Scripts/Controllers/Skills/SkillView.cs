using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleTMP;
    [SerializeField]
    private TextMeshProUGUI descriptionTMP;
    [SerializeField]
    private TextMeshProUGUI progressTMP;
    [SerializeField]
    private Slider progressSlider;

    private Skill skill = BaseSkill.UNDEFINED;
    
    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        UpdateView();
    }

    public void UpdateView()
    {
        titleTMP.text = skill.GetName();
        if (descriptionTMP != null)
            descriptionTMP.text = skill.GetDescription();
        progressTMP.text = $"{skill.GetLevel()}/{skill.GetMaxLevel()}";
        progressSlider.maxValue = skill.GetMaxLevel();
        progressSlider.value = skill.GetLevel();
    }

    public int GetSkillId() { return skill.GetId(); }
}
