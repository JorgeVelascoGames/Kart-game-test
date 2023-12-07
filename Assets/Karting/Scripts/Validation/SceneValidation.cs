using Arch.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script prevents issues with the DataManager and potential bugs when loading the game.
// It also facilitates playtesting in the Unity editor.
public class SceneValidation : MonoBehaviour
{
    IEnumerator Start()
    {
        //To prevent problems
        yield return new WaitForSeconds(0.2f);

        if (DataManager.Instance == null)
            SceneManager.LoadScene("IntroMenu");

    }
}
