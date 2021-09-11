using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour {


    /// <summary>
    /// this script is to know who the cube will be eaten 
    /// i added layermask which is the layer of the cube i want to cut so if i have a yellow saber 
    /// the i need to cut the yellow cube and the rosa also the same 
    /// what i have done is to check every frame if my saber is cutting using a Raycast 
    /// which is starting from the ends going forward and have a length of 1 
    /// the Rica's will be the layer of the cube upon it 
    /// i will check the velocity of a saber using transorm.position- the previous position
    /// with the cube transform.up which is the direction want to eat it and if the direction is less than 130
    /// it means that we are eating the cube in the right direction and only then we can destory it 
    /// </summary>
    public LayerMask layer;
    private Vector3 previousPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,1,layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
            }
            else
                GameOver.fault++;

        }
        previousPos = transform.position;
	}
}
