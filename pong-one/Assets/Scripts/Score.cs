using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class UnityEventWithArgs : UnityEvent<GameObject> { }

public class Score : MonoBehaviour
{
    private TMP_Text text;
    internal int score;

    // events
    public UnityEventWithArgs OnWin_E;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        resetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void scoreGoal()
    {
        // Add 1 to the score
        score += 1;
        Debug.Log("Score: " + this.name + " " + score);
        updateText();
        if (score == 11)
        {
            // emit Win event
            OnWin_E?.Invoke(this.gameObject);
        }
    }

    internal void resetScore()
    {
        // Set score back to 0
        score = 0;
        updateText();
    }

    void updateText()
    {
        text.text = score.ToString();
    }
}
