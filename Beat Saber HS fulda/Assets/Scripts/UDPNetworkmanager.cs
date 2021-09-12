using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class UDPNetworkmanager : MonoBehaviour
{


    IPEndPoint ep;
    //Socket client;
    UdpClient client;
    //using this for anitialızation 

    // Use this for initialization
    void Start()
    {


        //port and IP Data for socket Client

        string IP = "127.0.0.1";
        int port = 80;



        ep = new IPEndPoint(IPAddress.Parse(IP), port);

        //socket that allows sendang data
        //client = new SocketAddressFamily. InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        client = new UdpClient();
    }

    // Update is called once per frame
    void Update()
    {

       // UDPNetworkmanager.GetInstance().SendMessage(transform.position.ToString());
        ///        client.Send(packetData, packetData.Length, ep);


    }
}

   
