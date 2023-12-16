using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuObject;

    [SerializeField]
    private GameObject characterObject;

    [SerializeField]
    private GameObject achievementsObject;

    [SerializeField]
    private AchievementList achievementList;

    public void SetMenuScreen()
    {
        characterObject.SetActive(false);
        achievementsObject.SetActive(false);
        menuObject.SetActive(true);
    }

    public void SetAchievementsScreen()
    {
        characterObject.SetActive(false);
        achievementsObject.SetActive(true);
        menuObject.SetActive(false);

        achievementList.OnUpdate();
    }

    public void SetCharacterScreen()
    {
        characterObject.SetActive(true);
        achievementsObject.SetActive(false);
        menuObject.SetActive(false);
    }
}
