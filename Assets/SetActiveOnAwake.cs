using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnAwake : MonoBehaviour
{

    public bool setActiveOnAwake;

    void Awake()
    {
        gameObject.SetActive(setActiveOnAwake);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
