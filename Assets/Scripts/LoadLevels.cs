using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

    public GameObject Menu;
    public GameObject EasyLevel;
    public GameObject MediumLevel;
    public GameObject HardLevel;
    public GameObject DynamicLevel;


   /* public void LoadingScene()
    {
        if (GetKeyCodeDown)

        FlowController.instance.SetFlowState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */

    void Update()
    {
        if (Input.GetKeyDown("1")) { 
            Menu.SetActive(true);
            EasyLevel.SetActive(false);
            MediumLevel.SetActive(false);
            HardLevel.SetActive(false);
            DynamicLevel.SetActive(false);
            Debug.Log("Menu loaded.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown("2"))
        {
                Menu.SetActive(false);
                EasyLevel.SetActive(true);
                MediumLevel.SetActive(false);
                HardLevel.SetActive(false);
                DynamicLevel.SetActive(false);
                Debug.Log("Easy level loaded.");
        }

        if (Input.GetKeyDown("3"))
        {
            Menu.SetActive(false);
            EasyLevel.SetActive(false);
            MediumLevel.SetActive(true);
            HardLevel.SetActive(false);
            DynamicLevel.SetActive(false);
            Debug.Log("Medium level loaded.");
        }

        if (Input.GetKeyDown("4"))
        {
            Menu.SetActive(false);
            EasyLevel.SetActive(false);
            MediumLevel.SetActive(false);
            HardLevel.SetActive(true);
            DynamicLevel.SetActive(false);
            Debug.Log("Hard level loaded.");
        }

        if (Input.GetKeyDown("5"))
        {
            Menu.SetActive(false);
            EasyLevel.SetActive(false);
            MediumLevel.SetActive(false);
            HardLevel.SetActive(false);
            DynamicLevel.SetActive(true);
            Debug.Log("Dynamic level loaded.");
        }
    }
        
}
