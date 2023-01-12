using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

using TMPro; 

public class UIDoorButtonChange : MonoBehaviour, IPointerClickHandler
{
	public GameObject ButtonCommandText;
	private TMP_Text m_TextComponent;
	private bool CommandFlag = false;
	
    void Start()
    {
	m_TextComponent = ButtonCommandText.GetComponent<TMP_Text>();	
		
     
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		
	if (CommandFlag == false)
	{
	m_TextComponent.text="CLOSE";	
	CommandFlag = true;
	}
	else
	{
	m_TextComponent.text="OPEN";	
	CommandFlag = false;
	}
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
