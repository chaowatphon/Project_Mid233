using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 20f; // ความเร็วสูงสุด
    public float acceleration = 10f; // การเร่งความเร็ว
    public float turnSpeed = 10f; // ความเร็วในการหมุน
    public float brakeForce = 50f; // แรงเบรก
    public PhysicMaterial tireFriction; // ฟิสิกส์ของยาง (Friction)

    private Rigidbody rb;

    void Start()
    {
        // รับ Rigidbody ของรถยนต์
        rb = GetComponent<Rigidbody>();

        // กำหนดให้ยางมีแรงเสียดทาน
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (var col in colliders)
        {
            if (col.material != null)
            {
                col.material = tireFriction; // ใช้ PhysicMaterial ที่มีแรงเสียดทาน
            }
        }
    }

    void Update()
    {
        // การควบคุมรถยนต์
        float moveInput = Input.GetAxis("Vertical"); // การเร่ง
        float turnInput = Input.GetAxis("Horizontal"); // การหมุน

        // คำนวณแรงที่ใช้ในการเร่ง
        Vector3 force = transform.right * moveInput * acceleration; // ใช้ transform.right แทน transform.forward
        rb.AddForce(force, ForceMode.Force);

        // จำกัดความเร็วของรถยนต์
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // การหมุนรถยนต์
        // ใช้การหมุนที่แกน Y เท่านั้น (ไม่หมุนแกน X หรือ Z)
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f); // หมุนในแกน Y
        rb.MoveRotation(rb.rotation * turnRotation); // ใช้ MoveRotation เพื่อให้การหมุนสมจริงและไม่ทำให้รถตีลังกา

        // ระบบเบรก
        if (Input.GetKey(KeyCode.Space))
        {
            // เบรกใช้แรงที่คำนวณจากมวลและความเร็ว
            Vector3 brakeForceVector = -rb.velocity.normalized * brakeForce;
            rb.AddForce(brakeForceVector, ForceMode.Force);
        }
    }
}
