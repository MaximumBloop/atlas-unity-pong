using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EventHandler : MonoBehaviour
{
    public Ball ball;
    public Paddle playerOne;
    public Paddle playerTwo;
    public Canvas WinCanvas;
    public TMP_Text WinText;
    // Start is called before the first frame update
    void Start()
    {
        Score[] scoreEvents = FindObjectsOfType<Score>();
        foreach (Score source in scoreEvents)
        {
            source.OnWin_E.AddListener(showWin);
        }
    }

    private void showWin(GameObject triggeringObject)
    {
        // disable Paddle scripts
        playerOne.enabled = false;
        playerTwo.enabled = false;

        // reset ball
        ball.resetBallPosition();
        ball.resetBallVelocity(0);
        ball.rb.isKinematic = true;

        // disable Ball script
        ball.enabled = false;

        // show WinScreen canvas
        WinCanvas.gameObject.SetActive(true);
        if (GameObject.ReferenceEquals(triggeringObject, GameObject.Find("Player One_Score")))
        {
            WinText.text = triggeringObject.name.Substring(0, 10) + " Wins!";
        }
    }

    void OnDestroy()
    {
        Score[] scoreEvents = FindObjectsOfType<Score>();

        foreach (Score source in scoreEvents)
        {
            source.OnWin_E.RemoveListener(showWin);
        }
    }
}
