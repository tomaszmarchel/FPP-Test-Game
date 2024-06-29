using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float multiplier;

    [SerializeField] private float xSens = 100f;
    [SerializeField] private float ySens = 100f;
    private float xRot, yRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float xMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens * multiplier;
        float yMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens * multiplier;

        yRot += xMouse;
        xRot -= yMouse;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);

    }
}
