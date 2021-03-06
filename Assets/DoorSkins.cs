﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSkins : MonoBehaviour
{
    public GameObject panel;
    private bool inDoor = false;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            panel.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.gameObject.SetActive(false);
        inDoor = false;
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected","Frog");
        ResetPlayerSkin();
    }

    public void SetPlayerMaskDude()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskDude");
        ResetPlayerSkin();
    }

    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        ResetPlayerSkin();


    }

    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
        ResetPlayerSkin();
    }
    void ResetPlayerSkin()
    {
        panel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }



}
