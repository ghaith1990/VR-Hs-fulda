using UnityEngine;
using System.Collections;

public class Read : MonoBehaviour {

	// Use this for initialization
	private UdpReceive udpRec;
	
	
	void Start () 
	{
		Application.runInBackground = true;
		//using find //
		udpRec = GameObject.Find("MaxSendRev").GetComponent(typeof(UdpReceive)) as UdpReceive;
	}
	
	
	
	// Update is called once per frame
	void Update () 
	{
		
		if (udpRec.maxValues.Length <= 0) {
			return;
		}
		
		
		float scaleX = udpRec.MaxValue(3);
		float scaleY = udpRec.MaxValue(4);
		float scaleZ = udpRec.MaxValue(5);
		
		transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
		
		float rotX = ClampAngle(udpRec.MaxValue(0));
		float rotY = ClampAngle(udpRec.MaxValue(1));
		float rotZ = ClampAngle(udpRec.MaxValue(2));
		
		transform.localEulerAngles = new Vector3(rotX, rotY, rotZ);
		
	}
	
	public static float ClampAngle(float angle)
	{
		if(angle < -360f)
		angle += 360f;
		if(angle > 360)
		angle -= 360;
		
		return Mathf.Clamp(angle, -360f, 360f);
	} 
		
}
