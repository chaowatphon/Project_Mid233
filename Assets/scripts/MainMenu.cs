using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SampleScene = "SampleScene"; // ใส่ชื่อฉากเกมที่ต้องการโหลด

    public void StartGame()
    {
        Debug.Log("Loading scene: " + SampleScene);
        SceneManager.LoadScene(SampleScene);
    }

    public void ExitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}
