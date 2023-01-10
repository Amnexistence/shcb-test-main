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

    // Update is called once per frame
    void Update()
    {
        
    }
}
