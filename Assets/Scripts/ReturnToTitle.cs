using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{

    // Use this for initialization
    public void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}