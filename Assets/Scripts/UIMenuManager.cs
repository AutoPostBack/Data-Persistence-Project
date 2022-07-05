using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMenuManager : MonoBehaviour
{

    [SerializeField] TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //xx = nameField.text
        Debug.Log(nameField.text);
        SingletonClass.Instance.playerName = nameField.text;
        SceneManager.LoadScene(1);
    }
}
