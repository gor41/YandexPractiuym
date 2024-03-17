using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEscape : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        EscProverka();
        
    }
    private void EscProverka()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
