using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string victorySceneName = "VictoryScene"; // ใส่ชื่อฉากหน้าชนะ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // เช็คว่าตัวที่ชนเป็นรถของผู้เล่นหรือไม่
        {
            Debug.Log("ถึงเส้นชัย!");
            SceneManager.LoadScene(victorySceneName);
        }
    }
}
