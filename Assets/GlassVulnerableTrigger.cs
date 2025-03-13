using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassVulnerableTrigger : MonoBehaviour
{
    public GameObject glassZoneObject;
    public GlassZone glassZone;

    public GameObject ballObject;
    public Ball activeBall;


    // Start is called before the first frame update
    void Start()
    {
        glassZoneObject = GameObject.Find("GlassZone");
        glassZone = glassZoneObject.GetComponent<GlassZone>();

        ballObject = GameObject.Find("Ball");
        activeBall = ballObject.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject == ballObject)
        {

            ballObject = col.gameObject;


            if(glassZone.isVulnerable == false)
            {
                glassZone.SetGlassVulnerability(true);
            }
        }

    }
}
