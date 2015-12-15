using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {


    // Use this for initialization

   //if exit condition is met
    void OnTriggerEnter(Collider other)
    {
        //check name of collider
        if (other.gameObject.name == "Player")
            print("Got level end");
            //dummy scene
            Application.LoadLevel("endscene");
    }
	
}
