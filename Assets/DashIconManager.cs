using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashIconManager : MonoBehaviour
{

    public GameObject dashIconRecharging;
    public GameObject dashIconReady;
    public GameObject dashIconOk;

    public GameObject playerObject;
    public PlayerMovement playerMovement;

    public float iconDisplayDuration;

    public UnityEvent onDashReadyEvent;
    public UnityEvent onDashChargingEvent;

    // Start is called before the first frame update
    void Start()
    {
        dashIconRecharging.SetActive(false);
        dashIconReady.SetActive(false);
        dashIconOk.SetActive(false);

        playerObject = GameObject.Find("Player");
        playerMovement = playerObject.GetComponent<PlayerMovement>();

        if (onDashReadyEvent == null)
        {
            onDashReadyEvent = new UnityEvent();
        }

        if (onDashChargingEvent == null)
        {
            onDashChargingEvent = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDashAvailable()
    {
        onDashReadyEvent.Invoke();
        StartCoroutine(DashReadyDisplayProcess());
    }

    public void DisplayDashRecharging()
    {
        onDashChargingEvent.Invoke();
        StartCoroutine(DashRechargingDisplayProcess());
    }



    private IEnumerator DashRechargingDisplayProcess()//Icon tht indicates that the ability to dash is not ready is displayed above player character
    {
        dashIconReady.SetActive(false);
        dashIconOk.SetActive(false);
        dashIconRecharging.SetActive(true);
        yield return new WaitForSeconds(iconDisplayDuration);
        dashIconRecharging.SetActive(false);
    }

    private IEnumerator DashReadyDisplayProcess()//Icon tht indicates that the ability to dash is not ready is displayed above player character
    {
        dashIconRecharging.SetActive(false);
        dashIconReady.SetActive(true);
        dashIconOk.SetActive(true);
        yield return new WaitForSeconds(iconDisplayDuration);
        dashIconReady.SetActive(false);
        dashIconOk.SetActive(false);
    }
}
