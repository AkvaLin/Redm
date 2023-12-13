using System;
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
    [SerializeField]
    private Button upgradeButton;

    private Skill skill = BaseSkill.UNDEFINED;
    private Action onUpgrade;


    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        UpdateView();
    }

    public void SetOnUpgradeButton(Action action)
    {
        onUpgrade = action;
    }

    public void UpdateView()
    {
        titleTMP.text = skill.GetName();
        if (descriptionTMP != null)
            descriptionTMP.text = skill.GetDescription();
        if (progressTMP != null)
            progressTMP.text = $"{skill.GetLevel()}/{skill.GetMaxLevel()}";
        if (progressSlider != null)
        {
            progressSlider.maxValue = skill.GetMaxLevel();
            progressSlider.value = skill.GetLevel();
        }

        if (upgradeButton != null)
        {
            upgradeButton.interactable = SkillManager.Instance.CanLevelUpSkill(skill.GetId());
            upgradeButton.onClick.RemoveAllListeners();
            upgradeButton.onClick.AddListener(UpgradeSkill);
        }
    }

    public int GetSkillId() { return skill.GetId(); }

    private void UpgradeSkill()
    {
        SkillManager.Instance.LevelUpSkill(skill.GetId());

        if (onUpgrade != null) onUpgrade.Invoke();
    }
}
