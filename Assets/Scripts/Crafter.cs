using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private TextMesh storage;
    SpeedManager targeter = null;
    private bool isCrafting = false;
    //sets up script to script communication
 public float input = 0f;
 public float output = 0f;
    // Start is called before the first frame update
    void Start()
    {
        targeter = target.GetComponent<SpeedManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetValue = targeter.inputRate;
        if (input >= targetValue && !isCrafting)
        {
            isCrafting = true;
            Crafting();
        }
    }
    public void adder(float a)
    {
        input += a;
    }
    public void Crafting()
    {
        input -= targeter.inputRate;
        output += targeter.outputRate;
        storage.text = "Items stored: " + output;
        isCrafting = false;
    }
}
