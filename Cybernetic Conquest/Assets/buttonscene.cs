using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscene : MonoBehaviour
{
    public string sceneName;

    public GameObject workshop;
    public GameObject robots;
    public GameObject army;
    public GameObject science;

    public void OnClick()
    {
        if (sceneName == "Workshop Scene")
        {
            robots.SetActive(false);
            army.SetActive(false);
            science.SetActive(false);
            workshop.SetActive(true);
        }
        if (sceneName == "Robots Scene")
        {
            workshop.SetActive(false);
            army.SetActive(false);
            science.SetActive(false);
            robots.SetActive(true);
        }
        if (sceneName == "Army Scene")
        {
            workshop.SetActive(false);
            robots.SetActive(false);
            science.SetActive(false);
            army.SetActive(true);
        }
        if (sceneName == "Science Scene")
        {
            workshop.SetActive(false);
            robots.SetActive(false);
            army.SetActive(false);
            science.SetActive(true);
        }
    }
}
