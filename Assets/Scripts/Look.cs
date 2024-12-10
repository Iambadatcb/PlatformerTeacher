using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;

public class Look : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var mousPos = Input.mousePosition;
        var worldPos = cam.ScreenToWorldPoint(mousPos);
        worldPos.z=0;
        var direction = worldPos - transform.position;
        direction.Normalize(); //makes the vetor have values between -1 and 1
        var angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
