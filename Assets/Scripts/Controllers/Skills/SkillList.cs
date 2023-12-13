using TMPro;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    [SerializeField]
    private GameObject scrollViewContent;
    [SerializeField]
    private GameObject skillViewPrefab;
    [SerializeField]
    private GameObject containerToHide;
    [SerializeField]
    private TextMeshProUGUI xpText;
    [SerializeField]
    private bool isHidden = true;

    void Start()
    {
        var allSkills = SkillManager.Instance.GetSkills();

        foreach (var skill in allSkills)
        {
            var view = Instantiate(skillViewPrefab, scrollViewContent.transform);
            var skillView = view.GetComponent<SkillView>();
            skillView.SetSkill(skill);
            skillView.SetOnUpgradeButton(OnUpdate);
        }

        OnUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Toggle();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SkillManager.Instance.AddXP(5);
            OnUpdate();
        }
    }

    void Show()
    {
        isHidden = false;
        OnUpdate();
    }

    void Hide()
    {
        isHidden = true;
        OnUpdate();
    }

    void Toggle()
    {
        if (isHidden)
        {
            Show();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Hide();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnUpdate()
    {
        containerToHide.SetActive(!isHidden);
        if (isHidden) return;

        xpText.text = $"XP: {SkillManager.Instance.GetXP()}";

        var views = scrollViewContent.GetComponentsInChildren<SkillView>();

        foreach (var v in views)
        {
            v.UpdateView();
        }
    }
}
