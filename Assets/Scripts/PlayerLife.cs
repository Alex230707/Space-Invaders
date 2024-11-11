using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public bool IsAlive=true;
    public float RespawnCooldown;
    public int ActualLifes;
    bool Gameover = false;
    public TextMeshProUGUI LifesText;
    Coroutine DeathCooldown;
    public Image VLife1;
    public Image VLife2;
    public GameObject GameOverText;
    public PlayerMovement PM;

    void Start()
    {
        
    }

    private void Update()
    {
        PM.movespeed = 5;
        Debug.Log(IsAlive);
        if (!Gameover)
        {

            if (!IsAlive)
            {
                DeathCooldown = StartCoroutine(deathcooldown(ActualLifes, IsAlive));
                PM.movespeed = 0;
            }
        }

        else if(Gameover) {
            Time.timeScale = 0; 
        }

        LifesText.text = ActualLifes.ToString();
    }

        void PlayerKilled()
        {
            IsAlive = false;
            LoseLife();
        }

        void LoseLife()
        {
            ActualLifes --;
            if (ActualLifes == 0) {
                GameOver();
            }

            if (ActualLifes == 2) {
                VLife2.enabled = false;
            }
            if (ActualLifes == 1)
            {
                VLife1.enabled = false;
            }
            //Time.timeScale = 0;
    }

        void GameOver()
        {
            Debug.Log("GAME OVER!!!");
            Gameover = true;
            GameOverText.SetActive(true);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "EnemyBullet")
            {
                PlayerKilled();
            }
        } 
    IEnumerator deathcooldown (int life, bool state) {
        Time.timeScale = 0;
        if (life == 0) { 
            state = true;
            yield break;   
        }
        
        yield return new WaitForSecondsRealtime(RespawnCooldown);
        Time.timeScale = 1;
        IsAlive = true; 
    }
}