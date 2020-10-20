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
    Stack<CommandInvoker> undoList = new Stack<CommandInvoker>();
    Stack<CommandInvoker> redoList = new Stack<CommandInvoker>();

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
                    MyTransform trans = new Translation();
                    xUpTrans xUpCommand = new xUpTrans(trans);
                    xDownTrans xDownCommand = new xDownTrans(trans);
                    yUpTrans yUpCommand = new yUpTrans(trans);
                    yDownTrans yDownCommand = new yDownTrans(trans);
                    zUpTrans zUpCommand = new zUpTrans(trans);
                    zDownTrans zDownCommand = new zDownTrans(trans);
                    CommandInvoker onUse = null;

                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        //+X
                        onUse = new CommandInvoker(xUpCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.J))
                    {
                        //-X
                        onUse = new CommandInvoker(xDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.I))
                    {
                        //+Y
                        onUse = new CommandInvoker(yUpCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.K))
                    {
                        //-Y
                        onUse = new CommandInvoker(yDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.O))
                    {
                        //-Z moves forward/further towards the camera
                        onUse = new CommandInvoker(zDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.U))
                    {
                        //+Z moves backwards/further away from the camera
                        onUse = new CommandInvoker(zUpCommand);
                    }
                    else if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            if (undoList.Count > 0)
                            {
                                redoList.Push(undoList.Peek());
                                undoList.Pop().undo(selected);
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            if (redoList.Count > 0)
                            {
                                undoList.Push(redoList.Peek());
                                redoList.Pop().use(selected);
                            }
                        }
                    }

                    if (onUse != null)
                    {
                        onUse.use(selected);
                        redoList.Clear();
                        undoList.Push(onUse);
                    }
                }

                //Selected object rotation
                if (selectedState == 2)
                {
                    MyTransform rot = new Rotation();
                    xUpRot xUpCommand = new xUpRot(rot);
                    xDownRot xDownCommand = new xDownRot(rot);
                    yUpRot yUpCommand = new yUpRot(rot);
                    yDownRot yDownCommand = new yDownRot(rot);
                    zUpRot zUpCommand = new zUpRot(rot);
                    zDownRot zDownCommand = new zDownRot(rot);
                    CommandInvoker onUse = null;

                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        //+X
                        onUse = new CommandInvoker(xUpCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.J))
                    {
                        //-X
                        onUse = new CommandInvoker(xDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.I))
                    {
                        //+Y
                        onUse = new CommandInvoker(yUpCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.K))
                    {
                        //-Y
                        onUse = new CommandInvoker(yDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.O))
                    {
                        //-Z moves forward/further towards the camera
                        onUse = new CommandInvoker(zDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.U))
                    {
                        //+Z moves backwards/further away from the camera
                        onUse = new CommandInvoker(zUpCommand);
                    }
                    else if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            if (undoList.Count > 0)
                            {
                                redoList.Push(undoList.Peek());
                                undoList.Pop().undo(selected);
                            }
                        }

                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            if (redoList.Count > 0)
                            {
                                undoList.Push(redoList.Peek());
                                redoList.Pop().use(selected);
                            }
                        }
                    }

                    if (onUse != null)
                    {
                        onUse.use(selected);
                        redoList.Clear();
                        undoList.Push(onUse);
                    }
                }

                //Selected object scale
                if (selectedState == 3)
                {
                    MyTransform scale = new Scale();
                    xUpScale xUpCommand = new xUpScale(scale);
                    xDownScale xDownCommand = new xDownScale(scale);
                    yUpScale yUpCommand = new yUpScale(scale);
                    yDownScale yDownCommand = new yDownScale(scale);
                    zUpScale zUpCommand = new zUpScale(scale);
                    zDownScale zDownCommand = new zDownScale(scale);
                    CommandInvoker onUse = null;

                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        //+X
                        onUse = new CommandInvoker(xUpCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.J))
                    {
                        //-X
                        onUse = new CommandInvoker(xDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.I))
                    {
                        //+Y
                        onUse = new CommandInvoker(yUpCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.K))
                    {
                        //-Y
                        onUse = new CommandInvoker(yDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.O))
                    {
                        //-Z moves forward/further towards the camera
                        onUse = new CommandInvoker(zDownCommand);
                    }
                    else if (Input.GetKeyDown(KeyCode.U))
                    {
                        //+Z moves backwards/further away from the camera
                        onUse = new CommandInvoker(zUpCommand);
                    }
                    else if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            if (undoList.Count > 0)
                            {
                                redoList.Push(undoList.Peek());
                                undoList.Pop().undo(selected);
                            }
                        }

                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            if (redoList.Count > 0)
                            {
                                undoList.Push(redoList.Peek());
                                redoList.Pop().use(selected);
                            }
                        }
                    }

                    if (onUse != null)
                    {
                        onUse.use(selected);
                        redoList.Clear();
                        undoList.Push(onUse);
                    }
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
