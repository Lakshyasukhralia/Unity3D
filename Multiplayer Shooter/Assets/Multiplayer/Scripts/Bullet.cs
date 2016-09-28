using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        
        Health health = hit.GetComponent<Health>();
        if(health!=null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
