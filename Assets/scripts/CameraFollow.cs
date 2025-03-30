using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // อ้างอิงถึงรถ
    public Vector3 offset;    // ระยะห่างของกล้องจากรถ
    public float smoothSpeed = 0.125f;  // ความลื่นไหลในการตามกล้อง
    public float rotationSpeed = 5f;  // ความเร็วในการหมุนกล้อง

    private void LateUpdate()
    {
        // คำนวณตำแหน่งกล้องใหม่
        Vector3 desiredPosition = target.position + offset;

        // คำนวณตำแหน่งกล้องที่ลื่นไหล
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // อัพเดตตำแหน่งกล้อง
        transform.position = smoothedPosition;

        // คำนวณทิศทางการหมุนของกล้อง
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        
        // ถ้ารถกำลังถอยหลัง (ตรวจสอบทิศทางการเคลื่อนที่)
        //if (Vector3.Dot(target.forward, target.GetComponent<Rigidbody>().velocity) < 0)
        //{
            // ถ้ารถถอยหลัง หมุนกล้องในทิศทางตรงข้าม
            //targetRotation = Quaternion.LookRotation(transform.position - target.position);
        //}

        // หมุนกล้องไปในทิศทางที่ต้องการ
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
