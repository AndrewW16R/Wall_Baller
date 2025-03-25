using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.aspect = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
