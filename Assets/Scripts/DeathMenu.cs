using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathOccurs()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
        deathMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }
}
