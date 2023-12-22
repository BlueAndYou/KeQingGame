using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    private List<PropSO> propList;
    private void Start()
    {
        propList = BagManager.Instance.GetPropSOList();
        PlayerInput.Instance.OnOpenBag += PlayerInput_OnOpenBag;
        BagManager.Instance.OnPropUsedUp += BagManager_OnPropUsedUp;
        UpdateBag();
        Hide();

    }

    private void BagManager_OnPropUsedUp(object sender, System.EventArgs e)
    {
        UpdateBag();
    }

    public void UpdateBag() 
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < propList.Count; i++)
        {
            Transform propTransform = Instantiate(propList[i].Prefabs, parent);
            if (propTransform.GetComponent<Prop>().GetNumber() <= 0)
            {
                BagManager.Instance.GetPropSOList().Remove(propList[i]);
                Destroy(propTransform.gameObject);
            }
        }
    }
    private void PlayerInput_OnOpenBag(object sender, System.EventArgs e)
    {
        if (gameObject.activeSelf)
        {
            Hide();
        }
        else 
        {
            Show();
        }
    }

    private void Hide() 
    {
        gameObject.SetActive(false);
        Player.Instance.GetComponent<vThirdPersonController>().enabled = true;
        Player.Instance.GetComponent<vThirdPersonInput>().enabled = true;
        Player.Instance.GetComponent<PlayerAnimation>().enabled = true;
   
    }
    private void Show() 
    {
        gameObject.SetActive(true);
        Player.Instance.GetComponent<vThirdPersonController>().enabled = false;
        Player.Instance.GetComponent<vThirdPersonInput>().enabled = false;
        Player.Instance.GetComponent<PlayerAnimation>().enabled = false;
        Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PropContentUI.Instance.Hide();


    }
}
