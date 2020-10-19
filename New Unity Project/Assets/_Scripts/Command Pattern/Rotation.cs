using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MyTransform
{
    Vector3 selectedObjectVec;

    public void xUp(GameObject obj)
    {
        float tempX = 0.0f;
        if (obj.transform.localRotation.x >= 0)
        {
            tempX = Mathf.Floor(obj.transform.localRotation.x);
        }
        else
        {
            tempX = Mathf.Ceil(obj.transform.localRotation.x);
        }

        selectedObjectVec = new Vector3(tempX + 18.0f, 0.0f, 0.0f);
        obj.transform.Rotate(selectedObjectVec);
    }
    public void xDown(GameObject obj)
    {
        float tempX = 0.0f;
        if (obj.transform.localRotation.x >= 0)
        {
            tempX = Mathf.Floor(obj.transform.localRotation.x);
        }
        else
        {
            tempX = Mathf.Ceil(obj.transform.localRotation.x);
        }

        selectedObjectVec = new Vector3(tempX - 18.0f, 0.0f, 0.0f);
        obj.transform.Rotate(selectedObjectVec);
    }

    public void yUp(GameObject obj)
    {
        float tempY = 0.0f;
        if (obj.transform.localRotation.x >= 0)
        {
            tempY = Mathf.Floor(obj.transform.localRotation.y);
        }
        else
        {
            tempY = Mathf.Ceil(obj.transform.localRotation.y);
        }

        selectedObjectVec = new Vector3(0.0f, tempY + 18.0f, 0.0f);
        obj.transform.Rotate(selectedObjectVec);
    }
    public void yDown(GameObject obj)
    {
        float tempY = 0.0f;
        if (obj.transform.localRotation.x >= 0)
        {
            tempY = Mathf.Floor(obj.transform.localRotation.y);
        }
        else
        {
            tempY = Mathf.Ceil(obj.transform.localRotation.y);
        }

        selectedObjectVec = new Vector3(0.0f, tempY - 18.0f, 0.0f);
        obj.transform.Rotate(selectedObjectVec);
    }

    public void zUp(GameObject obj)
    {
        float tempZ = 0.0f;
        if (obj.transform.localRotation.x >= 0)
        {
            tempZ = Mathf.Floor(obj.transform.localRotation.z);
        }
        else
        {
            tempZ = Mathf.Ceil(obj.transform.localRotation.z);
        }

        selectedObjectVec = new Vector3(0.0f, 0.0f, tempZ + 18.0f);
        obj.transform.Rotate(selectedObjectVec);
    }
    public void zDown(GameObject obj)
    {
        float tempZ = 0.0f;
        if (obj.transform.localRotation.x >= 0)
        {
            tempZ = Mathf.Floor(obj.transform.localRotation.z);
        }
        else
        {
            tempZ = Mathf.Ceil(obj.transform.localRotation.z);
        }

        selectedObjectVec = new Vector3(0.0f, 0.0f, tempZ - 18.0f);
        obj.transform.Rotate(selectedObjectVec);
    }
}
