using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class udpScriptSimple : MonoBehaviour
{

    // Simple version of UDP sending script
    // Hardcode IP and port of receiver, no error checking on send
    // Sample string and number list messages you can send with keystrokes, for testing

    IPEndPoint remoteEndPoint;
    UdpClient client;

    string strMessage1 = "hello world";
    string strMessage2 = "how are you";
    int[] numberMessage = { 0, 10, 50, 100, 150, 200, 250, 255 };

    void Start()
    {
        // IP and port
        remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
        client = new UdpClient();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.U)) // U for "UDP", single message
        {
            sendString(strMessage1);
        }
        if (Input.GetKey(KeyCode.C)) // C for "Continuous" messages, one per frame while key held down
        {
            sendString(strMessage2);
        }
        if (Input.GetKey(KeyCode.N)) // N for "Number" messages, one per frame while key held down
        {
            sendNumberList(numberMessage);
        }
    }

    // Method to send string messages
    public void sendString(string message)
    {
        byte[] stringList = Encoding.UTF8.GetBytes(message);
        client.Send(stringList, stringList.Length, remoteEndPoint);
        print("message " + message + " sent to " + remoteEndPoint);
    }

    // Method to send an int[] array, like texture RGB values, etc
    public void sendNumberList(int[] message)
    {
        byte[] intList = new byte[message.Length];

        // There may be a way to convert the whole int array at once instead of looping through it
        // Tried Buffer.blockCopy, but haven't gotten it to work yet
        // https://forum.unity.com/threads/convert-int-array-to-byte-array-all-at-once.1077113/#post-6947678
        for (int i = 0; i < message.Length; i++)
        {
            intList[i] = ((byte)message[i]);
        }

        client.Send(intList, intList.Length, remoteEndPoint);
        print("message " + message + " sent to " + remoteEndPoint);
    }
}
