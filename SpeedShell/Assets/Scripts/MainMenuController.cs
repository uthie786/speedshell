using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void LoadLevelSelection()
    {
        SFXManager.instance.PlaySound("Click");
        SceneManager.LoadScene("Level Selection");
    }

    public void LoadCheckpointRace()
    {
        SFXManager.instance.PlaySound("Click");
        SceneManager.LoadScene("Checkpoint Race Dialogue");
    }

    public void LoadBeginnerRace()
    {
        SFXManager.instance.PlaySound("Click");
        SceneManager.LoadScene("Beginner Race Dialogue");
    }
    public void LoadAdvancedRace()
    {
        SFXManager.instance.PlaySound("Click");
        SceneManager.LoadScene("Advanced Race Dialogue");
    }
    public void Quit()
    {
        Application.Quit();
    }

}