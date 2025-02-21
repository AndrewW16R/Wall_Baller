using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeSaveSystem : MonoBehaviour
{
    public GameObject playerMovementObject;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementObject = GameObject.Find("Player");
        
        if (playerMovementObject != null)
        {
            playerMovement = playerMovementObject.GetComponent<PlayerMovement>();
            LoadMovementType();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovementToStable()
    {
        PlayerPrefs.SetString("MovementType","Stable");
    }

    public void SetMovementToSliding()
    {
        PlayerPrefs.SetString("MovementType", "Sliding");
    }

    public void LoadMovementType()
    {
        playerMovement.movementType = PlayerPrefs.GetString("MovementType");
    }
}
