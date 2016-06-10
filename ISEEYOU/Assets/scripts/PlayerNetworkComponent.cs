using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkComponent : NetworkBehaviour {

    public float updateTimer = 0.2f;
    public float smoothRate = 4f;
    
    Vector3 position;
    Transform playerTransform;

	// Use this for initialization
	void Start () {
        playerTransform = transform;
	    if (isLocalPlayer)
        {
            GetComponent<TestNetworkMovement>().enabled = true;

            StartCoroutine(SyncPlayerPosition());
        }
	}

    void LerpPosition()
    {
        if (isLocalPlayer)
        {
            return;
        }

        playerTransform.position = Vector3.Lerp(playerTransform.position, position, Time.deltaTime * smoothRate);
    }

    IEnumerator SyncPlayerPosition()
    {
        while (enabled)
        {
            CmdUpdatePosition(position);
            yield return new WaitForSeconds(updateTimer);
        }
    }

    [Command]
    void CmdUpdatePosition(Vector3 newPosition)
    {
        position = newPosition;
        RpcRecievedPosition(newPosition);
    }

    [ClientRpc]
    void RpcRecievedPosition(Vector3 newPosition)
    {
        position = newPosition;
    }

    // Update is called once per frame
    void Update() {
        LerpPosition();
    }
}
