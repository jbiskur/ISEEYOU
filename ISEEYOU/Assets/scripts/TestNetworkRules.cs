using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TestNetworkRules : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	    if (isLocalPlayer)
        {
            GetComponent<TestNetworkMovement>().enabled = true;
        }
	}
}
