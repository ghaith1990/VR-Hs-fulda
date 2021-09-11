using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Zone1DistanceUDP : MonoBehaviour
{
    private static int localPort;

    // prefs
    private string IP;  // define in init
    public int port;  // define in init

    // “connection” things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    // gui
    string strMessage = "";

    // call it from shell (as program)
    private static void Main()
    {
        Zone1DistanceUDP sendObj = new Zone1DistanceUDP();
        sendObj.init();
    }
    // start from unity3d
    public void Start()
    {
        init();
    }

    // init
    public void init()
    {
        // Define end point , from which the messages are sent.
        print("UDPSend.init()");

        // define
        IP = "127.0.0.1";
        port = 7470;

        // Send
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

        // status
        print("Sending to " +IP + " : " +port);
        print("Testing: nc - lu " +IP + " : " +port);
        sendString("jt");
    }

    // inputFromConsole
    private void inputFromConsole()
    {
        try
        {
            string text;
            do
            {
                text = Console.ReadLine();

                // Send the text to the remote client .
                if (text != "")
                {
                    // Encode data using the UTF8 encoding to binary format.
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    // Send the text to the remote client.
                    client.Send(data, data.Length, remoteEndPoint);
                }
            } while (text != "");
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    // sendData
    private void sendString(string message)
    {
        try
        {
            //if (message != “”)
            //{
            // Encode data using the UTF8 encoding to binary format.
            byte[] data = Encoding.UTF8.GetBytes(message);

            // Send the message to the remote client.
            client.Send(data, data.Length, remoteEndPoint);
            //}
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print (Distance.Zone1Distance);
         sendString("Distance.Zone1Distance");
    }
}
