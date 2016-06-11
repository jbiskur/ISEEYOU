using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class IpText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = Network.player.ipAddress;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
