using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    private float SPEED;
    //private KeyCode heldKey;

    private Paddle PaddleScript;

    // Start is called before the first frame update
    void Start()
    {
        PaddleScript = GetComponent<Paddle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            PaddleScript.PaddleUp();
        }

        if (Input.GetKey(downKey))
        {
            PaddleScript.PaddleDown();
        }
    }
}
