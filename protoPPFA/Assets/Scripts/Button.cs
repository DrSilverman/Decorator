using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    [SerializeField] private GameObject[] _buttons = null;

    private void Awake()
    {

        for (int i = 0; i < PlayerManager.Instance.NbTotem; i++)
        {

            _buttons[i].SetActive(true);

        }

    }

    public void PutRespawn(int index)
    {

        PlayerManager.Instance.RespawnPosition = PlayerManager.Instance._respawnPlaces[index - 1];

        PlayerManager.Instance.CanRespawn = true;

        SceneManager.UnloadSceneAsync("Death");

    }

}
