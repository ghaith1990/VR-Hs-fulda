using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    //  add the cube prefab and add some points where the cube will be instantiated 
    // the beat will be there where the cube is instantiated
    // timer will count the time remaining between two beats and between spawn of the cube 
    // in my project i am randomly selecting our cube so the cube will be either yellow or rosa  
    // instantiated the cube position randomly 
    // i added also a rotation to cube so the cube will be rotated randomly either right left up down 
    // at the end i will update our timer and add time.deltatime for every frame 
    public GameObject[] cubes;
    public Transform[] points;
    // i use an external website to measure the BPM which is the beats per minute
    // https://songbpm.com/@mbb/island
    // so to know how many beats or many seconds between two  beat i divided the Bpm to 60 seconds 
    public float beat = (60/107)*2;
    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timer>beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;
        }

        timer += Time.deltaTime;
	}
}
