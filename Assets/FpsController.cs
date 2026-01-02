using UnityEngine;

public class FpsController : MonoBehaviour
{
    public float velocidadCaminar = 5f;
    public float sensibilidadMouse = 2f;
    public Camera camaraJugador;

    private float rotacionVertical = 0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f); 

        camaraJugador.transform.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;
        controller.Move(movimiento * velocidadCaminar * Time.deltaTime);
    }
}