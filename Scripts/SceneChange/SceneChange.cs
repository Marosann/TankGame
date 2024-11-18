using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region SceneChange

        if (Input.GetKeyDown(KeyCode.Space))
        {

            SceneManager.LoadScene("Test2");
        
        }
        #endregion

        #region GameExit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        #endregion
    }
}
