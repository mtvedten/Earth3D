using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    public GameObject planet;
    public GameObject centerOfGravity;
    public GameObject satellite;

   public ConstantForce gravity; 
    private Vector3 direction = new Vector3();
    public Vector3 startBoost = new Vector3(-4f, 0f, 0f);
    const float G = 6.6f;
	// Use this for initialization
	void Start () {
        gravity = satellite.GetComponent<ConstantForce>();
        satellite.GetComponent<Rigidbody>().AddForce(startBoost, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

  float distance = Vector3.Distance(centerOfGravity.transform.position, satellite.transform.position);
        float g = G * ((planet.GetComponent<Rigidbody>().mass * satellite.GetComponent<Rigidbody>().mass) / distance*distance);
        direction = satellite.transform.position + centerOfGravity.transform.position;
      
        gravity.force = -direction * G;
        Debug.Log(distance);
        //Vector3 speed = new Vector3(0f, 0.01f, 0f);
  
        //gameObject.transform.SetPositionAndRotation(speed, gameObject.transform.rotation);
	}
}
