using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceCountdown : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Text countdownText;
    private int time;
    void Awake()
    {
        time = 3;
        Time.timeScale = 0;
    }
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown()
    {
        countdownText.text = time.ToString();
        yield return new WaitForSeconds(1);
        time--;
        countdownText.text = time.ToString();
        yield return new WaitForSeconds(1);
        time--;
        countdownText.text = time.ToString();
        yield return new WaitForSeconds(1);
        time--;
        countdownText.text = time.ToString();
        yield return new WaitForSeconds(1);
        time--;
        countdownText.text = "START";
        Time.timeScale = 1;
    }
}
