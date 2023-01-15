using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    UnityEngine.SceneManagement.SceneManager.LoadScene("Level_test_Env",LoadSceneMode.Additive);
	UnityEngine.SceneManagement.SceneManager.LoadScene("Level_test_Lights",LoadSceneMode.Additive);
	UnityEngine.SceneManagement.SceneManager.LoadScene("Level_test_Nav",LoadSceneMode.Additive);
	UnityEngine.SceneManagement.SceneManager.LoadScene("Level_test_UI",LoadSceneMode.Additive);
    }
	
	private void Restart()
	{
	UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	//поскольку наш менеджер находится в активной сцене 0, то и остальные сцены перезагружаются, из-за вызова Start() при её загрузке
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
        SceneResetScript.ActionSceneReset += Restart;

    }

    private void OnDisable()
    {
        SceneResetScript.ActionSceneReset -= Restart;
    }
	
}
