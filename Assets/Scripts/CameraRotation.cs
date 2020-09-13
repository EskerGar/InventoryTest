using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100;
    [SerializeField] private Transform player;
    
    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        var x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _xRotation -= y;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        player.Rotate(Vector3.up * x); 
    }
}
