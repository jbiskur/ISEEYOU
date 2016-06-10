using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    MonoBehaviour unit;

    public bool lockMouse = true;
    private bool interacting = false;
    public bool MouseVisible = true;
    public bool GamePaused = false;
    // Use this for initialization
    void Start () {
        unit = (GetComponent("FirstPersonController") as MonoBehaviour);
    }

    void FixedUpdate() {
        if (lockMouse) {
            Cursor.visible = MouseVisible;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //pause menu show
        if (GamePaused) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            unit.enabled = false;

            //finnist sikkurt ein betri loysn.
            //set músuna í miðuna á skýggjanum
            /*
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
            */

        }
        else {
            unit.enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {


        //toggle Pause menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GamePaused ^= true;
        }


        //um klikk, finn hvar, um robot, drep?
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                float distance = Vector3.Distance(transform.position, hit.transform.position);

                if (hit.transform.gameObject.name == "robot_player_thing" && distance <= 1.7f) {
                    //kill
                }
            }
        }
    }
}
