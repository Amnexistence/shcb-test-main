using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

using TMPro; 

public class OnOffClickHeader : MonoBehaviour, IPointerClickHandler
{
	public GameObject HeaderStateText;
	private TMP_Text m_TextComponent;
	private bool StateFlag = true;
	
    void Start()
    {
	m_TextComponent = HeaderStateText.GetComponent<TMP_Text>();	
		
     
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		
	if (StateFlag == false)
	{
	m_TextComponent.text="on";	
	StateFlag = true;
	}
	else
	{
	m_TextComponent.text="off";	
	StateFlag = false;
	}
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
