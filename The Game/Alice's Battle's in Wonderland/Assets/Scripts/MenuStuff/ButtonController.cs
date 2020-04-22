using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public string lastScene;
    public string nextScene;

    public void BackButton()
    {
        SceneManager.LoadScene(lastScene);
    }

    public void NextButton()
    {
        SceneManager.LoadScene(nextScene);
    }
}
