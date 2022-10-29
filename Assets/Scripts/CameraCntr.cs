using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntr : MonoBehaviour
{
    public PlrCntr target;
    private float offsetx;
    private float offsety;
    private float offsetz;
    void Awake()
    {
        offsetx = transform.position.x - target.transform.position.x;
        offsety = transform.position.y - target.transform.position.y;
        offsetz = transform.position.z - target.transform.position.z;
    }

    void Update()
    {
        Vector3 currentPos = transform.position;
        currentPos.x = target.transform.position.x + offsetx;
        currentPos.y = target.transform.position.y + offsety;
        currentPos.z = target.transform.position.z + offsetz;
        transform.position = currentPos;
    }
}
