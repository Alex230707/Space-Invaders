using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHolder : MonoBehaviour
{
    public static CanvasHolder Instance;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}