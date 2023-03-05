using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text loseTextUI = null;
    [SerializeField] Text winTextUI = null;
    [SerializeField] Text timeTextUI = null;
    [SerializeField] Timer timer = null;
    [SerializeField] AudioClip _winSFX = null;

    AudioSource _audioSource = null;

    void Start()
    {
        HideText();
        _audioSource = GetComponent<AudioSource>();
    }

    public void HideText()
    {
        winTextUI.text = "You Win!";
        winTextUI.gameObject.SetActive(false);

        loseTextUI.text = "You Lose!";
        loseTextUI.gameObject.SetActive(false);
    }

    public void ShowWinText()
    {
        winTextUI.gameObject.SetActive(true);
        if (_winSFX != null)
        {
            _audioSource.PlayOneShot(_winSFX, _audioSource.volume);
        }
    }

    public void ShowLoseText()
    {
        loseTextUI.gameObject.SetActive(true);
        timer.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        timeTextUI.text = Mathf.FloorToInt(timer.timeRemaining).ToString();
    }
}
