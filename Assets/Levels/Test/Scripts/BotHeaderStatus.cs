using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BotHeaderStatus : MonoBehaviour
{
	
	public GameObject HeaderStateText;
	private TMP_Text m_TextComponent;
	public bool StateFlag = true;
	public string HeaderVariantOn;
	public string HeaderVariantOff;
	
    // Start is called before the first frame update
    void Start()
    {
    m_TextComponent = HeaderStateText.GetComponent<TMP_Text>();	    
    }

	public void ChangeStatus()
	{
	/*
	if (StateFlag == false)
	{
	m_TextComponent.text = HeaderVariantOn;	
	StateFlag = true;
	}
	else
	{
	m_TextComponent.text = HeaderVariantOff;	
	StateFlag = false;	
	}
	*/
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
