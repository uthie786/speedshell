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

    private IEnumerator TimeWait(string name)
    {
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime;

            yield return null;
        }

        SceneManager.LoadScene(name);
    }
    
    public void LoadLevelSelection()
    {
        SFXManager.instance.PlaySound("Click");
        StartCoroutine(TimeWait("Level Selection"));
        
    }

    public void LoadCheckpointRace()
    {
        StartCoroutine(TimeWait("Checkpoint Race Dialogue"));
        SFXManager.instance.PlaySound("Click");
    }

    public void LoadBeginnerRace()
    {
        StartCoroutine(TimeWait("Beginner Race Dialogue"));
        SFXManager.instance.PlaySound("Click");
    }
    public void LoadAdvancedRace()
    {
        StartCoroutine(TimeWait("Advanced Race Dialogue"));
        SFXManager.instance.PlaySound("Click");
    }
    public void Quit()
    {
        Application.Quit();
    }

}