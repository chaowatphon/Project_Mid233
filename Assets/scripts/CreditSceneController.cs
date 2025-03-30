using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditSceneController : MonoBehaviour
{
    public float displayTime = 10f;  // เวลาที่จะให้เครดิตแสดง
    public Image creditImage;  // ภาพเครดิต

    void Start()
    {
        // เริ่มต้นการแสดงเครดิต
        Invoke("GoToMainMenu", displayTime);  // เรียกใช้ฟังก์ชั่น GoToMainMenu หลังจาก displayTime
    }

    void GoToMainMenu()
    {
        // เปลี่ยนไปยัง Scene หลัก
        SceneManager.LoadScene("MainMenuScene");  // ให้เปลี่ยนชื่อ Scene ตามที่คุณต้องการ
    }
}
