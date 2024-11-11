using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public LayerMask layerhitted;
    public Transform EnemyShootingPoint;
    public GameObject EnemyBullet;
    public bool Shooted;
    float ShootCooldown;
    public int PointsEarned;
    public PlayerLife PL;
    public EnemyCounter EnemyCounter;
    public ScoreScript scorescript;
    
    private float time;
    private float nextshoot;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ShootCooldown = Random.Range(6f,10f);
        Shooted = false;
    }

    void Update()
    {
        time+=Time.deltaTime;
        
        RaycastHit2D hit = Physics2D.Raycast(EnemyShootingPoint.transform.position, Vector2.down, 1000f, layerhitted);

        if (hit == false)
        {
            if (Shooted==false)
            {
                
                ShootingCoolDown(ShootCooldown, time);
                
            }
            if (Shooted == true && time > ShootCooldown) {
                ShootingCoolDown(ShootCooldown, time);
            }
        }
    }

    void ShootingCoolDown(float shootcooldown, float Time)
    {
        if(Time>shootcooldown)
        {
            Instantiate(EnemyBullet, EnemyShootingPoint.position, transform.rotation);
            time = 0;
            Shooted=true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {

            scorescript.AddScore(PointsEarned);
            Destroy(gameObject);
            EnemyCounter.EnemyCounterRefresh();
        
        }
    }
}