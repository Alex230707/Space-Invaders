using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float Speed;
    public float EnemyAdvancement;
    bool IsFacingRight = true;
    private void Start()
    {
        EnemyAdvancement = EnemyAdvancement * 0.1f;
        Speed = Speed * 0.1f;

    }
    void Update() {
        if (IsFacingRight == true)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }

        else if (IsFacingRight == false) {
            transform.Translate(Vector2.right * -Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChangerPoint" && IsFacingRight == true)
        {
            IsFacingRight = false;
            gameObject.transform.position -= new Vector3(0,EnemyAdvancement,0);
        }

        else if (collision.gameObject.tag == "ChangerPoint" && IsFacingRight == false)
        {
            IsFacingRight = true;
            gameObject.transform.position -= new Vector3(0,EnemyAdvancement,0);
        }
    }
}
