using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public string mainMenuScene = "MainMenuScene"; // กลับหน้าเมนูหลัก
    public string SampleScene = "SampleScene"; // เล่นใหม่

    public void RestartGame()
    {
        SceneManager.LoadScene(SampleScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}