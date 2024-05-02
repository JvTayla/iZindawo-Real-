using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void CameraPosJuan()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
    public void CameraPosDos()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 120f);
    }
    public void CameraPosTres()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 240f);
    }
}
