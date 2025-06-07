using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetUiElementToSelectOnInteraction : MonoBehaviour
{
    //Setup
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Selectable elementToSelect; //Button that will be automatically hovered over once this button is pressed

    //Visualization
    [SerializeField] private bool showVisualization; //Toggle to show gizmo UI connection line of the button in question
    [SerializeField] private Color navigationColor = Color.cyan; //Sets color of Gizmo
    
    private void OnDrawGizmos()
    {
        if (!showVisualization) //showVisualization set to false
        {
            return;
        }

        if(elementToSelect == null) //elementToSelect is not set
        {
            return;
        }

        Gizmos.color = navigationColor;
        Gizmos.DrawLine(gameObject.transform.position, elementToSelect.gameObject.transform.position);
    }

    private void Reset()//this is called only when the script component is initially attached to the game object
    {
        eventSystem = FindObjectOfType<EventSystem>();

        if (eventSystem == null)
        {
            Debug.Log("Did not find an Event System in your scene.", context: this);
        }
    }

    public void JumpToElement()
    {
        if(eventSystem == null)
        {
            Debug.Log("This item has no event system referenced yet.", context: this);
        }

        if (elementToSelect == null)
        {
            Debug.Log("This should jump where?", context: this);
        }

        eventSystem.SetSelectedGameObject(elementToSelect.gameObject);
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
