using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerController player2Controller;
    private bool player1Active = true;
    void Start()
    {
        // playerController = GetComponent<PlayerController>();
        // player2Controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        if(player1Active)
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            player1Active = false;
        }
        else
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player1Active = true;
        }
    }
}
