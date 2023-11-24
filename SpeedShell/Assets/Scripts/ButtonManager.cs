using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Image snailImage;
    [SerializeField] private SFXManager sfx;
    [SerializeField] private Color inactive;
    [SerializeField] private Color active;

    private int isSpeaking;
    // Start is called before the first frame update
    void Start()
    {
        if (snailImage != null)
        {
            Debug.Log("Marvin");
            isSpeaking = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCheckpointRace()
    {
        sfx.PlaySound("button");
        StartCoroutine(TimeDelay());
        SceneManager.LoadScene("Checkpoint Race Dialogue");
       
    }
    
    public void LoadBeginnerRace()
    {
        sfx.PlaySound("button");
        StartCoroutine(TimeDelay());
        SceneManager.LoadScene("Beginner Race Dialogue");
    }
    public void LoadAdvancedRace()
    {
        sfx.PlaySound("button");
        StartCoroutine(TimeDelay());
        SceneManager.LoadScene("Advanced Race Dialogue");
    }
    public void Quit()
    {
        sfx.PlaySound("button");
        StartCoroutine(TimeDelay());
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        sfx.PlaySound("button");
        StartCoroutine(TimeDelay());
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(5f);
    }

    public void Speaker()
    {
        sfx.PlaySound("button");
        Debug.Log(isSpeaking);
        if (isSpeaking == 1 || isSpeaking == 3 || isSpeaking == 5)
        {
            snailImage.color = inactive;
        }
        else
        {
            snailImage.color = active;
        }
        isSpeaking++;
        
    }

}
