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

    bool cursorVisible = false;
    int selectedState = 0;
    float xRotation = 0f;
    float yRotation = 0f;
    GameObject selected;
    GameObject prevSelected;

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
            cursorVisible = !cursorVisible;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            selectedState = 0;
            if (selected != null)
            {
                selected.GetComponent<MeshRenderer>().material.color = new Color(selected.GetComponent<MeshRenderer>().material.color.r,
                    selected.GetComponent<MeshRenderer>().material.color.b, selected.GetComponent<MeshRenderer>().material.color.g, 1.0f);
                selected = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            selectedState = 1;
        } 
        if (Input.GetKeyDown(KeyCode.R))
        {
            selectedState = 2;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            selectedState = 3;
        }

        if (cursorVisible)
        {
            showCursor();
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitinfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitinfo);
                if (hit)
                {
                    Debug.Log("Hit " + hitinfo.transform.gameObject.name);

                    if (selected != null)
                    {
                        selected.GetComponent<MeshRenderer>().material.color = new Color(selected.GetComponent<MeshRenderer>().material.color.r,
                            selected.GetComponent<MeshRenderer>().material.color.b, selected.GetComponent<MeshRenderer>().material.color.g, 1.0f);
                    }

                    selected = hitinfo.transform.gameObject;
                    prevSelected = hitinfo.transform.gameObject;
                    hideCursor();
                }
                else
                {
                    selected = null;
                }
            }
        }
        else if (!cursorVisible)
        {
            hideCursor();

            //Camera movement
            {
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

            if (selected != null)
            {
                selected.GetComponent<MeshRenderer>().material.color = new Color(selected.GetComponent<MeshRenderer>().material.color.r,
                        selected.GetComponent<MeshRenderer>().material.color.b, selected.GetComponent<MeshRenderer>().material.color.g, 0.25f);
                //Selected object transform
                if (selectedState == 1)
                {
                    Vector3 selectedObjectVec = new Vector3(0.0f, 0.0f, 0.0f);

                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        //+Z
                        selectedObjectVec = new Vector3(0.0f, 0.0f, 1.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.J))
                    {
                        //-X
                        selectedObjectVec = new Vector3(-1.0f, 0.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.L))
                    {
                        //-Z
                        selectedObjectVec = new Vector3(0.0f, 0.0f, -1.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.U))
                    {
                        //+X
                        selectedObjectVec = new Vector3(1.0f, 0.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.K))
                    {
                        //-Y
                        selectedObjectVec = new Vector3(0.0f, -1.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.I))
                    {
                        //+Y
                        selectedObjectVec = new Vector3(0.0f, 1.0f, 0.0f);
                    }

                    selected.transform.position += selectedObjectVec;
                }

                //Selected object rotation
                if (selectedState == 2)
                {
                    Vector3 selectedObjectVec = new Vector3(0.0f, 0.0f, 0.0f);

                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        //+Z
                        selectedObjectVec = new Vector3(0.0f, 0.0f, 1.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.J))
                    {
                        //-X
                        selectedObjectVec = new Vector3(selected.transform.localRotation.x - 1.0f, 0.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.L))
                    {
                        //-Z
                        selectedObjectVec = new Vector3(0.0f, 0.0f, selected.transform.localRotation.z - 1.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.U))
                    {
                        //+X
                        selectedObjectVec = new Vector3(selected.transform.localRotation.x + 1.0f, 0.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.K))
                    {
                        //-Y
                        selectedObjectVec = new Vector3(0.0f, selected.transform.localRotation.y - 1.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.I))
                    {
                        //+Y
                        selectedObjectVec = new Vector3(0.0f, selected.transform.localRotation.y + 1.0f, 0.0f);
                    }

                    selected.transform.Rotate(selectedObjectVec);
                }

                //Selected object scale
                if (selectedState == 3)
                {
                    Vector3 selectedObjectVec = new Vector3(0.0f, 0.0f, 0.0f);

                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        //+Z
                        selectedObjectVec = new Vector3(0.0f, 0.0f, 1.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.J))
                    {
                        //-X
                        selectedObjectVec = new Vector3(selected.transform.localRotation.x - 1.0f, 0.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.L))
                    {
                        //-Z
                        selectedObjectVec = new Vector3(0.0f, 0.0f, selected.transform.localRotation.z - 1.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.U))
                    {
                        //+X
                        selectedObjectVec = new Vector3(selected.transform.localRotation.x + 1.0f, 0.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.K))
                    {
                        //-Y
                        selectedObjectVec = new Vector3(0.0f, selected.transform.localRotation.y - 1.0f, 0.0f);
                    }
                    else if (Input.GetKeyDown(KeyCode.I))
                    {
                        //+Y
                        selectedObjectVec = new Vector3(0.0f, selected.transform.localRotation.y + 1.0f, 0.0f);
                    }

                    selected.transform.localScale += selectedObjectVec;
                }
            }
        }
    }

    void hideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorVisible = false;
    }

    void showCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        cursorVisible = true;
    }

    public bool cursorState()
    {
        return cursorVisible;
    }

    public GameObject returnSelected()
    {
        return prevSelected;
    }
}
