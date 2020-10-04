using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public float posX;
    public float posZ;
    public float posY;
    public float mouseSensitivity = 500;
    public float speed = 15.0f;

    bool cursorVisable = false;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        hideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cursorVisable = !cursorVisable;
        }

        if (cursorVisable)
        {
            showCursor();
        }
        else if (!cursorVisable)
        {
            hideCursor();
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);

            //transform.Rotate(Vector3.up * mouseY);

            //Directional Movement
            posX = Input.GetAxis("Horizontal");
            posZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * posX + transform.forward * posZ;

            Vector3 yMove = move;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                posY = 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                posY = -1;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                posY = 0;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                posY = 0;
            }

            yMove = transform.up * posY;

            move = new Vector3(move.x, yMove.y, move.z);
            transform.position += move * speed * Time.deltaTime;
        }
    }

    void hideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void showCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public bool cursorState()
    {
        return cursorVisable;
    }
}
