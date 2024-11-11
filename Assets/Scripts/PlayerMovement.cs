using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    public float movespeed;
    float InputP;
    Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue inputValue) {
        inputValue.Get<Vector2>();

        rb.velocity = inputValue.Get<Vector2>() * movespeed; 
    }
}