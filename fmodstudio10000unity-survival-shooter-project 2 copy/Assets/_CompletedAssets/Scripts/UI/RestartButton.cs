using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CompleteProject;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
