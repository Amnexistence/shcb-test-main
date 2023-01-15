using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;

public class CurrentPowerUI : MonoBehaviour
{
	//public GameObject PowerSource;
	public GameObject CurrentPowerText;
	private TMP_Text m_TextComponent;
	//PowerSourceScript _pss;
	
    // Start is called before the first frame update
    void Awake()
    {
    //_pss = PowerSource.GetComponent<PowerSourceScript>();
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
