using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ServQuest : MonoBehaviour
{

    private PNJ _pnj = null;

    [SerializeField] private string[] _questions = new string[3];

    [SerializeField] private GameObject _demand = null;
    [SerializeField] private TextMeshProUGUI _question = null;
    [SerializeField] private TextMeshProUGUI _1 = null;
    [SerializeField] private TextMeshProUGUI _2 = null;

    private CameraBehaviour _triggerRoom = null;

    private bool _done = false;

    private void Awake()
    {

        _pnj = GetComponent<PNJ>();

    }

    private void Update()
    {

        if (_triggerRoom != null && !_triggerRoom.Triggered && _pnj.Completed)
        {

            Destroy(gameObject);

        }
        
        if (_pnj.Ended && PlayerManager.Instance.HasMap)
        {

            InputManager.Blockinput = true;

            InputManager.Submit += GiveMap;
            InputManager.Cancel += Cancel;

            _demand.SetActive(true);

            _question.text = _questions[0];
            _1.text = _questions[1];
            _2.text = _questions[2];

            _pnj.Ended = false;
            _pnj.Completed = true;

        }
        else
        {

            _pnj.Ended = false;

        }

    }

    private void GiveMap()
    {

        PlayerManager.Instance.Maps -= 1;

        _demand.SetActive(false);

        InputManager.Submit -= GiveMap;
        InputManager.Cancel -= Cancel;

        InputManager.Blockinput = false;

    }

    private void Cancel()
    {

        _demand.SetActive(false);

        InputManager.Submit -= GiveMap;
        InputManager.Cancel -= Cancel;

        InputManager.Blockinput = false;

        _pnj.Ended = false;

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.GetComponent<CameraBehaviour>() && !_done)
        {

            _triggerRoom = other.GetComponent<CameraBehaviour>();

            _done = true;

        }

    }

}
