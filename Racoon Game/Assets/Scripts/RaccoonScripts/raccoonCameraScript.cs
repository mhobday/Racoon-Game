using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raccoonCameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;
    void Update()
    {
        transform.position = target.position + Offset;
    }
}
