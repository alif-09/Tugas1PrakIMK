using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Pastikan gerakan tetap di bidang horizontal (XZ)
        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        controller.Move(move * speed * Time.deltaTime);
    }
}
