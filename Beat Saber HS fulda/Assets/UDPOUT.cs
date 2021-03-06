
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using UnityEngine;


public class UdpOUT : MonoBehaviour

{

    private UdpClient maxClient = new UdpClient();
    private ASCIIEncoding byteEncoder = new ASCIIEncoding();

    void Start()
    {
        // Adress and Port
        maxClient.Connect("127.0.0.1", 7470);
    }


    // sends an int value to Max

    public void Sendint(string routeString, int val)
    {
        string message = routeString + ' ' + val;
        byte[] messageBytes = byteEncoder.GetBytes(message);
        SendBytes(messageBytes);
    }

    private void SendBytes(byte[] message)
    {
        try
        {
            maxClient.Send(message, message.Length);
        }
        catch (SocketException e)
        {
            Debug.Log("Max does not respond" + e);
        }
    }
}


