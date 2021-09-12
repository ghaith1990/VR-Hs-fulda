using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;


public class UDPstartup : MonoBehaviour
{

    IPEndPoint ep;
    //Socket client;
    UdpClient client;
    //using this for anitialızation 

    void Start()
    {
        //port and IP Data for socket Client

        string IP = "127.0.0.1";
        int port = 81;

        ep = new IPEndPoint(IPAddress.Parse(IP), port);

        //socket that allows sendang data
        //client = new SocketAddressFamily. InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        client = new UdpClient();

    }
    // update is called once per frame 
    void Update()
    {
        // convert string in to byte array 
        byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes(Time.realtimeSinceStartup.ToString());
        client.Send(packetData, packetData.Length, ep);
    }


    void OnApplicationQuit()
    {

        //convert string into byte array
        byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes("unityappclosed");
        client.Send(packetData, packetData.Length, ep);
    }

}



