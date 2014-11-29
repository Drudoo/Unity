using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPSend : MonoBehaviour {

	private UdpClient udpClient;
	private string address;
	private IPEndPoint ipEndPoint;
	private byte[] sendBytes;
	private byte[] zero = Encoding.ASCII.GetBytes("0");

	// Use this for initialization
	void Start () {

		udpClient = new UdpClient();
		address = "127.0.0.1";
		ipEndPoint = new IPEndPoint(IPAddress.Parse(address), 2814);
		sendBytes = Encoding.ASCII.GetBytes("1");

		udpClient.Connect(ipEndPoint);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			try {
				udpClient.Send(sendBytes, sendBytes.Length);
			} catch (Exception e) {
				Debug.Log("Something went wrong: " + e);
			}
		}
	}
}
