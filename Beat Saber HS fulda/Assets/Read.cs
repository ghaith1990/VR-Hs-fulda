using UnityEngine;
using System.Collections;
public class Read : MonoBehaviour {
   private UdpReceive udpRec;
   public GameObject LeftHandAnchor;

   void Start ()
   {
       Application.runInBackground = true;
       //using find //
       // THIS FIND A SPECIFIC GAME OBJECT THAT THE RECEIVE SCRIPT IS ATTACHED TO BUT THE ACTUAL MANIPULATION HAPPENS
       // TO AN OBJECT THAT THE READ SCRIPT IS ATTACHED TO..
       udpRec = GameObject.Find("MaxSendRev").GetComponent(typeof(UdpReceive)) as UdpReceive;
       // FIND THE RELEVANT GAMEOBJECTS..
       LeftHandAnchor = GameObject.Find ("LeftHandAnchor");
   }
   // Update is called once per frame
   void Update ()
   {
       if (udpRec.maxValues.Length <= 0) {
           return;
       }
       // COORDS TO TRANSLATE THE LOUDSPEAKER..
       float posZ = udpRec.MaxValue(0);
       // TRANSLATE THE LS..
       LeftHandAnchor.transform.position = new Vector3(0, 0, posZ);
   }
 
}