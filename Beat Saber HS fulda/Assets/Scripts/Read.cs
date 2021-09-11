using UnityEngine;
using System.Collections;

public class Send : MonoBehaviour
{

    private UdpReceive udpRec;
    public GameObject LeftHandAnchor;
    public GameObject RightHandAnchor;
    public GameObject TrackingSpace;

    void Start()
    {
        Application.runInBackground = true;
        //using find //
        // THIS FIND A SPECIFIC GAME OBJECT THAT THE RECEIVE SCRIPT IS ATTACHED TO BUT THE ACTUAL MANIPULATION HAPPENS
        // TO AN OBJECT THAT THE READ SCRIPT IS ATTACHED TO..
        udpRec = GameObject.Find("MaxSendRev").GetComponent(typeof(UdpReceive)) as UdpReceive;

        // FIND THE RELEVANT GAMEOBJECTS..
        LeftHandAnchor = GameObject.Find("LeftHandAnchor");
        RightHandAnchor = GameObject.Find("RightHandAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        if (udpRec.maxValues.Length <= 0)
        {
            return;
        }

        // COORDS TO ROTATE THE HANDLE..
        float rotHX = ClampAngle(udpRec.MaxValue(0));
        float rotHY = ClampAngle(udpRec.MaxValue(1));
        float rotHZ = ClampAngle(udpRec.MaxValue(2));

        // COORDS TO ROTATE THE DOOR..
        float rotDX = ClampAngle(udpRec.MaxValue(3));
        float rotDY = ClampAngle(udpRec.MaxValue(4));
        float rotDZ = ClampAngle(udpRec.MaxValue(5));

        // ROTATE THE HANDLE..
        RightHandAnchor.transform.localEulerAngles = new Vector3(rotHX, rotHY, rotHZ);
        // ROTATE THE DOOR..
        LeftHandAnchor.transform.localEulerAngles = new Vector3(rotDX, rotDY, rotDZ);
    }

    public static float ClampAngle(float angle)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, -360f, 360f);
    }
}
