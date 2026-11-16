using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miner : MonoBehaviour
{
     public float mineRate = 5f;
    [SerializeField] GameObject target;
    public Crafter targeter;
    //sets up script to script communication
    void start()
    {
       targeter = target.GetComponent<Crafter>();
       //sets up the rest of communcation
    }
     
   
    void Update()
    {
        targeter.adder(mineRate * Time.deltaTime);
        //sends objects to the crafter
    }
}