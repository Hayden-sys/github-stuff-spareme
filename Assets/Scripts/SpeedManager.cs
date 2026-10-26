using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // for Image Definition
using UnityEngine.InputSystem;
//this is a copy I'm using to set everything up in a 2D enviorment, just to make everything easier for me
public class SpeedManager : MonoBehaviour
{
[SerializeField] private float baseInput;
[SerializeField] private float baseOutput;
//Changeable to account for different reciepes.
[SerializeField] private TextMeshProUGUI inputCounter;
    [SerializeField] private TextMeshProUGUI outputCounter;
[SerializeField] private TextMeshProUGUI speedCounter;
[SerializeField] private TextMesh inputCounter1;
[SerializeField] private TextMesh outputCounter1;

//sets textboxs
[SerializeField] private GameObject canvas;
        private float inputRate;
private float outputRate;
private float clockSpeed;
//initilaizes floats
    // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;

    // Start is called before the first frame update
    
    void Awake()
    {
                clockSpeed = 1;
inputRate = baseInput;
outputRate = baseOutput;
//sets variables to their intended settings
        //Debug.Log("Input: " + Input);
        actions.FindActionMap("UI").FindAction("raiseRate").performed += OnRaise;
        actions.FindActionMap("UI").FindAction("lowerRate").performed += OnLower;
        
    }
    void Start()
    {
inputCounter.text = "Items per min: " + inputRate;
outputCounter.text = "Items per min: " + outputRate;
speedCounter.text = "Clock Speed: " + clockSpeed.ToString("P0");
inputCounter1.text = "Items per min: " + inputRate;
outputCounter1.text = "Items per min: " + outputRate;
//sets up the text boxs, changes them to base variables
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Increase()
    {
 
 if (clockSpeed <= 2.5) { //checks if max value
    clockSpeed += .01f; //adds 1%
changeRates(); //starts new function
 }
    }
    public void Decrease()
    {
        if (clockSpeed > .01) { //checks if min value
 clockSpeed -= .01f; //subtracts 1%
changeRates(); //starts new function
        }
    }
     private void OnRaise(InputAction.CallbackContext context)
    {
        
        Increase();
        
    }
     private void OnLower(InputAction.CallbackContext context)
    {
        
        Decrease();
    }
//i cant figure out how to make so that holding down either the input or the ui button keeps it changing for now
    void changeRates() //function exists to save memory and so I don't have to change both increase and decrease methods in case of an error-does this count as avoiding the inhertiance trap?
    {
inputRate = baseInput * clockSpeed;
outputRate = baseOutput * clockSpeed;
//changes item rates
inputCounter.text = "Items per min: " + inputRate;
outputCounter.text = "Items per min: " + outputRate;
speedCounter.text = "Clock Speed: " + clockSpeed.ToString("P0");
inputCounter1.text = "Items per min: " + inputRate;
outputCounter1.text = "Items per min: " + outputRate;
//updates text

    }
    public void close()
    {
    canvas.SetActive(false); 
    }
}
