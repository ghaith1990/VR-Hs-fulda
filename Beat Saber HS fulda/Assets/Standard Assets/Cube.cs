using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// we need the cube to be moving forwards so we need to initiailization 
/// </summary>
public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /// move the cube forward using the speed of two by muldtiplying the position by time.deltatime
        /// so the cube will spwan and then go forward and moving at a velocity of 2 meter per seconds now 
        /// that so we instantiate them randomly , so the spawner will be far from the player
        transform.position += Time.deltaTime * transform.forward * 2;
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameOver.fault++;
        Destroy(gameObject);
    }
}
