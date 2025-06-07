using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RememberCurrentlySelectedGameObject : MonoBehaviour
{

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject lastSelectedElement;

    private void Reset()
    {
        eventSystem = FindObjectOfType<EventSystem>();

        if (!eventSystem)
        {
            Debug.Log("Did not find an Event System in this scene", context: this);
            return;
        }

        lastSelectedElement = eventSystem.firstSelectedGameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!eventSystem)
        {
            return;
        }

        if (eventSystem.currentSelectedGameObject && lastSelectedElement != eventSystem.currentSelectedGameObject) //a game object is selected/hovered over and it is different from the previous selected game object
        {
            lastSelectedElement = eventSystem.currentSelectedGameObject; //store the newly selected game object
        }

        if (!eventSystem.currentSelectedGameObject && lastSelectedElement) //if an object is not currently selected, and the last selected object is not null
        {
            eventSystem.SetSelectedGameObject(lastSelectedElement); //Set selected object to the previously select object
        }
    }
}
