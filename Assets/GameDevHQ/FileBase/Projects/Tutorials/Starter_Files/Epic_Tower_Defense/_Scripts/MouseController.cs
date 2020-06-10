using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _zoomSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float screenMarginWidth = screenWidth * 0.2f;
        float screenMarginHeight = screenHeight * 0.2f;


        if (Input.mousePosition.x < screenMarginWidth)
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
        else if(Input.mousePosition.x > screenWidth - screenMarginWidth)
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

        transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed);

    }
}
