using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSourse : MonoBehaviour
{
    public Transform tragetPoint;
    public Camera cameraLink;

    // Start is called before the first frame update
    private void Start()
    {
            
    }

    // Update is called once per frame
    private void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            tragetPoint.position = hit.point;
        }
        
        transform.LookAt(tragetPoint.position);
    }
}
