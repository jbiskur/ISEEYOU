using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    MonoBehaviour unit;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public bool lockMouse       = true;
    private bool interacting    = false;
    public bool MouseVisible    = true;
    public bool GamePaused      = false;
    public bool Crouching       = false;
    public float CrouchSpeed    = 3f;

    // Use this for initialization
    void Start () {
        unit = (GetComponent("FirstPersonController") as MonoBehaviour);
        controller = GameObject.FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
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

            //SET KOTU FYRI PAUSU HER!
        }
        else {
            unit.enabled = true;
        }
    }

    public void Crouch(bool pos) {
        Crouching = pos;
        controller.m_WalkSpeed =3f;

        if (pos) {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        else { 
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        
    }


    // Update is called once per frame
    void Update () {
        //toggle Pause menu
        if (Input.GetKeyDown(KeyCode.LeftControl) && !Crouching) {
            Crouch(true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && Crouching) {
            Crouch(false);
        }

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
