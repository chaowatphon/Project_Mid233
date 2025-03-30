using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  
using System.Collections;

public class EndCredit : MonoBehaviour
{
    public TMP_Text creditText; // อ้างอิงถึง UI Text
    public float scrollSpeed = 25f; // ความเร็วในการเลื่อนข้อความ
    //public float endDelay = 1f; // ระยะเวลาหลังจากเครดิตจบก่อนกลับหน้าเมนู
    
    private Vector3 startPos;
    private float screenHeight;
    private void Start()
    {
        // ตั้งข้อความเครดิต
        creditText.text = "End Credit\n\n";
        creditText.text += "Developed by: Chaowat Phonmak as Developer\n";
        creditText.text += "                        Phonsavanh Phanthilath as \n";
        creditText.text += "Music by: SUNO AI\n";
        creditText.text += "Special Thanks to: Dr.Wiyada Thitimajshima\n";
        creditText.text += "\nPress ESC to exit.";

        // เก็บตำแหน่งเริ่มต้นของข้อความ
        startPos = creditText.transform.position;
        screenHeight = Screen.height;
        
        // เริ่ม Coroutine เพื่อให้ข้อความเลื่อนขึ้น
        StartCoroutine(ScrollCredits());
    }

    private IEnumerator ScrollCredits()
    {
        while (true)
        {
            // เลื่อนข้อความขึ้น
            creditText.transform.position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
            yield return null;
        }
        
        // รอเวลาสักพักก่อนกลับไปหน้าเมนู
        //yield return new WaitForSeconds(endDelay);
        //SceneManager.LoadScene("MainMenuScene"); // เปลี่ยนเป็นชื่อ Scene ที่เป็นหน้าเมนูของคุณ
    }

    private void Update()
    {
        // ถ้าผู้เล่นกด ESC ให้กลับไปยัง Scene ก่อนหน้า
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // คุณสามารถใช้คำสั่งนี้ในการไปที่ Scene ที่ต้องการ
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene"); // หรือชื่อ Scene ที่ต้องการ
        }
    }
}
