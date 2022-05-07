using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public void Destroy()
    {
        SceneManager.LoadScene("Defeat");
    }
}
