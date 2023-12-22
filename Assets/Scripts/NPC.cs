using Invector.vCharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private bool selected;
    [SerializeField]
    private Transform dialogue;
    [SerializeField]
    private Transform selectedTransform;
    private void Start()
    {
        PlayerInput.Instance.OnInteraction += PlayerInput_OnInteraction;
        dialogue.gameObject.SetActive(false);
        selectedTransform.gameObject.SetActive(false);

    }

    private void PlayerInput_OnInteraction(object sender, System.EventArgs e)
    {
        if (!selected) return;
        dialogue.gameObject.SetActive(true);
        Player.Instance.GetComponent<vThirdPersonController>().enabled = false;
        Player.Instance.GetComponent<vThirdPersonInput>().enabled = false;
        Player.Instance.GetComponent<PlayerAnimation>().enabled = false;
        DialogueManager.Instance.SetGanYuMessageNum(0);
        DialogueManager.Instance.SetPlayerMessageNum(0);
        DialogueManager.Instance.ShowMessage();
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            selected = true;
            selectedTransform.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            selected = false;
            selectedTransform.gameObject.SetActive(false);

        }
    }

    public void HideDialogue() 
    {
        dialogue.gameObject.SetActive(false);
        Player.Instance.GetComponent<vThirdPersonController>().enabled = true;
        Player.Instance.GetComponent<vThirdPersonInput>().enabled = true;
        Player.Instance.GetComponent<PlayerAnimation>().enabled = true;
    }


}
    
