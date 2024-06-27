using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensivity = 2f;

    private Vector2 mouseMoveVector;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseMoveVector.x += Input.GetAxis("Mouse X") * sensivity;
        mouseMoveVector.y += Input.GetAxis("Mouse Y") * sensivity;

        transform.localRotation = Quaternion.Euler(-mouseMoveVector.y, mouseMoveVector.x, 0);

        if (transform.localRotation.y > 70f)
            transform.localRotation = Quaternion.Euler(70, mouseMoveVector.x, 0);
    }
}
