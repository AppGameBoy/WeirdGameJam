using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;
    public GameObject instructionScreen;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        instructionScreen.SetActive(true);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);

    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(firstLevel);
        instructionScreen.SetActive(false);

    }

    public void QuiteGame()
    {
        Application.Quit();
        Debug.Log("QUITTING");
    }
}
