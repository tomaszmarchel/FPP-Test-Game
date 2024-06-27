using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensivity = 2f;

    private float xSens = 100f;
    private float ySens = 100f;
    private float xRot, yRot;

    public Transform orientation;


    private Vector2 mouseMoveVector;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        float xMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float yMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRot += xMouse;
        xRot -= yMouse;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);

    }
}
