using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TimeScript : MonoBehaviour
{
	DateTime StartTime;
	TimeSpan Span;
	private string NowTime;
	public float MyTimeScale;
	private TMP_Text m_TextComponent;
	
    // Start is called before the first frame update
    void Start()
    {
	Time.timeScale = MyTimeScale;
    m_TextComponent = gameObject.GetComponent<TMP_Text>();    
	StartTime = System.DateTime.Now;
    }

	public void ScaleChange()
	{
	Time.timeScale = MyTimeScale;	
	}

    // Update is called once per frame
    void Update()
    {
	Span = TimeSpan.FromSeconds((double)(new decimal(Time.deltaTime)));
	StartTime = StartTime + Span;
    m_TextComponent.text = StartTime.ToString();
		 
    }
}
