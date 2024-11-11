using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{

    public int HP = 10;

    private void Update()
    {
        if (HP == 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            HP--;
        }
    }
}
        

        
