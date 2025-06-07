using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetUiButtonSelectedOnStart : MonoBehaviour
{
    public Button button;
    public EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (button != null && eventSystem != null)
        {
            eventSystem.SetSelectedGameObject(button.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
