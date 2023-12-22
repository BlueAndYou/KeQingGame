using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PropContentUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI contentText;
    [SerializeField]
    private Image selectImage;

    private Prop prop;
    [SerializeField]
    private Button button;

    public static PropContentUI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        button.onClick.AddListener(UseProp);
    }
 
    public void UpdateContent(Prop prop) 
    {
        this.prop = prop;
        contentText.text = prop.GetDescription();
        selectImage.sprite = prop.GetPropSO().sprite;
    }
    public void UseProp() 
    {
        prop.UseProp();

        if (prop.GetNumber() <= 0) prop.UsedUp();
        else prop.HandleUseProp();
    }
    public void Hide() 
    {
        gameObject.SetActive(false);
    }
    public void Show() 
    {
        gameObject.SetActive(true);
    }
}
