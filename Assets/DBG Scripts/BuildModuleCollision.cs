using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModuleCollision : MonoBehaviour
{
	//below we link to the components we need
	private Rigidbody _rb;
	private ParticleSystem _ps;
	
    // Start is called before the first frame update
    void Start()
    {
    _rb = GetComponent<Rigidbody>();
	_ps = GetComponent<ParticleSystem>();
    }

	
	void OnCollisionEnter(Collision collision)
    {
	if (transform.parent.parent.GetComponent<BuildGen>().isFall == true)
	 {
	  //enable physics all objects when the root object is marked isFall
	  _rb.isKinematic = false;  
     }	
		
	if ((collision.gameObject.tag) == "Player" )
	 {
	 //set bool "isFall" when it collides with the player and delete all objects
	 transform.parent.parent.GetComponent<BuildGen>().isFall = true;
	 Destroy(transform.parent.parent.gameObject, 5);
     }
	 
	 if ((collision.gameObject.tag) == "Ground" )
	 {
	 //play particles when object collides with ground
	 _ps.Play(true);
	 }
	 
	}
}
