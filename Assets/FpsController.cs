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
        // Oculta y bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Rotación con el Mouse (Mirar)
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f); // Evita dar la vuelta completa

        camaraJugador.transform.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // 2. Movimiento con Teclado (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;
        controller.Move(movimiento * velocidadCaminar * Time.deltaTime);
    }
}