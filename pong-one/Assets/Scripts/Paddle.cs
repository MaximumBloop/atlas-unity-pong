using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Screen boundaries for clamping Paddle's position
    private float upperBound;
    private float lowerBound;

    // Class properties
    private RectTransform rectTransform;

    public float SPEED;
    // Start is called before the first frame update
    void Start()
    {
        upperBound = Screen.height;
        lowerBound = 0;

        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PaddleUp()
    {
        if (transform.position.y + rectTransform.rect.height / 2 < upperBound)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + SPEED,
                transform.position.z);
        }
    }

    public void PaddleDown()
    {
        if (transform.position.y - rectTransform.rect.height / 2 > lowerBound)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - SPEED,
                transform.position.z);
        }
    }
}
