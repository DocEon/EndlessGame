using System.Collections;
using UnityEngine;

public class redcontroller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
        rb.AddForce(150, 0, 150);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Walls")
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    } 
}
