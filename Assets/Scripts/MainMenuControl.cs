using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{

    public GameObject pressspace;
    public GameObject tablepoints;
    public GameObject scoreui;
    bool ready=false;
    public float cooldown;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressspace.SetActive(false);
            tablepoints.SetActive(true);
            scoreui.SetActive(true);
            cooldown = Time.time;
            if (cooldown > 1)
            {
                ready = true;
            }
        }
        if(ready == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
