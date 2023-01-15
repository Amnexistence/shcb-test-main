using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneResetScript : MonoBehaviour, IPointerClickHandler
{
	
	public static event Action ActionSceneReset;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnPointerClick(PointerEventData eventData)
{
ActionSceneReset?.Invoke();
}
	
}
