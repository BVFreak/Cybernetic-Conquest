using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscene : MonoBehaviour
{
    public string sceneName;

    public ParticleSystem particles_workshop;
    public ParticleSystem particles_robots;
    public ParticleSystem particles_army;
    public ParticleSystem particles_science;

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
            particles_workshop.Play(true);
        }
        if (sceneName == "Robots Scene")
        {
            workshop.SetActive(false);
            army.SetActive(false);
            science.SetActive(false);
            robots.SetActive(true);
            particles_robots.Play(true);
        }
        if (sceneName == "Army Scene")
        {
            workshop.SetActive(false);
            robots.SetActive(false);
            science.SetActive(false);
            army.SetActive(true);
            particles_army.Play(true);
        }
        if (sceneName == "Science Scene")
        {
            workshop.SetActive(false);
            robots.SetActive(false);
            army.SetActive(false);
            science.SetActive(true);
            particles_science.Play(true);
        }
    }
}
