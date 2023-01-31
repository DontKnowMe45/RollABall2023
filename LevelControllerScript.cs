using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControllerScript : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void LvlT()
    {
        SceneManager.LoadScene("title");
    }
}