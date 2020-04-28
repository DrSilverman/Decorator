using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PNJ : MonoBehaviour
{

    [SerializeField] private string[] _msgs = null;
    [SerializeField] private string _completedMsg = null;
    [SerializeField] private TextMeshProUGUI _box = null;
    [SerializeField] private GameObject _text = null;

    private int _index = 0;

    private bool _ended = false;
    private bool _completed = false;

    public bool Ended
    {

        get
        {

            return _ended;

        }
        set
        {

            _ended = value;

        }

    }

    public bool Completed
    {

        get
        {

            return _completed;

        }
        set
        {

            _completed = value;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<EquippedFaux>())
        {

            Engage();

        }

        if (other.GetComponent<RealMove>())
        {

            InputManager.Submit += Engage;

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<RealMove>())
        {

            InputManager.Submit -= Engage;

        }

    }

    private void Engage()
    {

        _text.SetActive(true);

        _index = 0;

        ShowText();

        InputManager.Blockinput = true;

        InputManager.Submit += PassToNext;

        InputManager.ResetPlayer();

        InputManager.Submit -= Engage;

    }

    private void ShowText()
    {
        if (!_completed)
            _box.text = _msgs[_index];
        else
            _box.text = _completedMsg;

    }

    private void PassToNext()
    {

        if (!_completed)
        {

            _index++;

            if (_index >= _msgs.Length)
            {

                _text.SetActive(false);
                InputManager.Submit -= PassToNext;
                InputManager.Blockinput = false;

                InputManager.Submit += Engage;

                print("caca");

                _ended = true;

            }
            else
            {

                ShowText();

            }

        }
        else
        {

            _text.SetActive(false);
            InputManager.Submit -= PassToNext;
            InputManager.Blockinput = false;

        }


    }

}
