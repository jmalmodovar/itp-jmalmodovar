using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private float _zoomSpeed = 10f;
    [SerializeField]
    private float _marginPercentage = 0.15f;

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float screenMarginWidth = screenWidth * _marginPercentage;
        float screenMarginHeight = screenHeight * _marginPercentage;


        //Keyboard WASD
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }

        // Mouse Margins
        if (Input.mousePosition.x < screenMarginWidth)
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
        else if (Input.mousePosition.x > screenWidth - screenMarginWidth)
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.y < screenMarginHeight)
        {
            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        }
        else if (Input.mousePosition.y > screenHeight - screenMarginHeight)
        {
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }

        // Mouse Zoom
        transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed);
    }
}
