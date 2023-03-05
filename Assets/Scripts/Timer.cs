using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;

    UIController uIController = null;
    PlayerShip player = null;

    private void Awake()
    {
        uIController = FindObjectOfType<UIController>();
        player = FindObjectOfType<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            if (uIController != null)
                uIController.ShowWinText();
            if (player != null)
                player.DisableDeathObjects();
            GameObject.Destroy(this.gameObject);
        }
    }
}
