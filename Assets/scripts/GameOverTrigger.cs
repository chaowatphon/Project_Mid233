using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverUI;  // UI ที่จะแสดงเมื่อเกมจบ
    public string obstacleTag = "Obstacle";  // Tag ของสิ่งกีดขวางที่ต้องการให้ตรวจจับ

    void Start()
    {
        // ซ่อน UI ตั้งแต่เริ่มเกม
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            TriggerGameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);  // แสดง UI Game Over
        }

        Time.timeScale = 0f;  // หยุดเกม
    }

    // ฟังก์ชันเล่นใหม่
    public void RestartGame()
    {
        Debug.Log("Restart Button Clicked!"); // เช็คว่าเรียกฟังก์ชันได้ไหม
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
