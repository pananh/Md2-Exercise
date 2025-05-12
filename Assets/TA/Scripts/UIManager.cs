using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private TextMeshProUGUI gameTimeText;
    public void SetGameTimeText(string value, bool show)
    {
        UIManager.Instance.gameTimeText.gameObject.SetActive(show);
        gameTimeText.text = value;
    }

    [SerializeField] private TextMeshProUGUI countTimeText;
    public void SetCountTimeText(string value, bool show)
    {
        UIManager.Instance.countTimeText.gameObject.SetActive(show);
        gameTimeText.text = value;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        UIManager.Instance.gameTimeText.gameObject.SetActive(true);
        UIManager.Instance.countTimeText.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }


}
