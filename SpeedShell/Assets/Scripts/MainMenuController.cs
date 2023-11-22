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
        SceneManager.LoadScene("Level Selection");
    }

    public void LoadCheckpointRace()
    {
        SceneManager.LoadScene("Checkpoint Race Dialogue");
    }

    public void LoadBeginnerRace()
    {
        SceneManager.LoadScene("Beginner Race Dialogue");
    }
    public void LoadAdvancedRace()
    {
        SceneManager.LoadScene("Advanced Race Dialogue");
    }
    public void Quit()
    {
        Application.Quit();
    }

}