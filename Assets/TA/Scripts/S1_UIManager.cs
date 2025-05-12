using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S1_UIManger : MonoBehaviour
{
    private static S1_UIManger instance;
    public static S1_UIManger Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private TextMeshProUGUI gameTimeText;
    public void SetGameTimeText(string value, bool show)
    {
        S1_UIManger.Instance.gameTimeText.gameObject.SetActive(show);
        gameTimeText.text = value;
    }

    [SerializeField] private TextMeshProUGUI countTimeText;
    public void SetCountTimeText(string value, bool show)
    {
        S1_UIManger.Instance.countTimeText.gameObject.SetActive(show);
        countTimeText.text = value;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        S1_UIManger.Instance.gameTimeText.gameObject.SetActive(true);
        S1_UIManger.Instance.countTimeText.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }


}
