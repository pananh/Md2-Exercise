using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S6_7_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public static S6_7_UI instance;
    [SerializeField] private TextMeshProUGUI statusText;
   
    public string StatusText
    {
        get { return statusText.text; }
        set { statusText.text = value; }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        statusText.text = "Waiting for Raycast hit...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
