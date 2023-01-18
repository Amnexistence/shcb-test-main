using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

using TMPro; 

public class CameraHeader : MonoBehaviour, IPointerClickHandler
{
	public GameObject HeaderStateText;
	public int CameraCount;
	private int StateCounter = 1;
	private TMP_Text m_TextComponent;
	
    void Start()
    {
	m_TextComponent = HeaderStateText.GetComponent<TMP_Text>();	
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		
	StateCounter = StateCounter + 1;

	if (StateCounter > CameraCount)
	{
	StateCounter = 1;	
	}
	
	m_TextComponent.text="Camera " + StateCounter.ToString();	
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
