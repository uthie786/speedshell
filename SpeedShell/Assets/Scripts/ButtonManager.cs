using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private SFXManager sfx;
    // Start is called before the first frame update
    void Start()
    {
        
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

}
