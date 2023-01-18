using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;

public class CurrentPowerUI : MonoBehaviour
{
	public GameObject CurrentPowerText;
	private TMP_Text m_TextComponent;
	
    void Awake()
    {
	m_TextComponent = CurrentPowerText.GetComponent<TMP_Text>();	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
        PowerSourceScript.ActionPowerUI += CurrentPowerTextUpd;
    }

    private void OnDisable()
    {
        PowerSourceScript.ActionPowerUI -= CurrentPowerTextUpd;
    }
	
	 private void CurrentPowerTextUpd()
    {
	m_TextComponent.text = "CURRENT: " +  StaticValues._CurrentPower.ToString() + "W";
    }
}
