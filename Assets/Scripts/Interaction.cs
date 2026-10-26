using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    // The message displayed to the player when looking at the object
    string InteractionPrompt { get; }

    // The logic executed when the interaction occurs
    void Interact();
}

public class Interaction : MonoBehaviour, IInteractable
{
    
    private string promptMessage = "Right Click to check clock speed";
    public GameObject targetObject;
     public string InteractionPrompt => promptMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Interact() 
     {
targetObject.SetActive(true);

     }
}
