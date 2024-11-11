using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerShooting : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public Transform ShootingPoint;
    public GameObject Bullet;
    public float ShootingCoolDown;
    private float time;
    
    
    public ScoreScript scorescript;

    private void Update()
    {
        time += Time.deltaTime;
    }

    
    void OnFire()
    {
        if (time > ShootingCoolDown)
        {
            Instantiate(Bullet, ShootingPoint.position, transform.rotation);
            time = 0;
        }
    }
}