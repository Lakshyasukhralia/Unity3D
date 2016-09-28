using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
       
        
        if(other.gameObject.tag=="block")
        {
            Destroy(other.gameObject);
        }

        GameObject hit = other.gameObject;

        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(100);
        }
        
    }

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
