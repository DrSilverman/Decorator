using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{

    [SerializeField] private GameObject _wheat = null;
    [SerializeField] private GameObject _toActivate = null;
    [SerializeField] private GameObject _FX = null;
    [SerializeField] private GameObject _pin = null;
    [SerializeField] private float _ascendSpeed = 0f;

    [SerializeField] private Transform _origin = null;
    [SerializeField] private Transform _target = null;
    
    private Animator _anim = null;
    private AudioSource _audio = null;

    private float _t = 0f;

    private bool _canAscend = false;

    private void Awake()
    {

        _anim = GetComponentInChildren<Animator>();
        _audio = GetComponentInChildren<AudioSource>();

    }

    private void Update()
    {

        if (_canAscend)
            AscendTotem();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<RealMove>())
        {//player enter the wheat

            _anim.SetBool("_isCrossed", true);

            _audio.Play();

        }

        if (other.GetComponent<EquippedFaux>())
        {

            _pin.SetActive(true);

            _wheat.SetActive(false);

            _toActivate.SetActive(true);

            CanAscend();

            Destroy(GetComponent<BoxCollider2D>());

        }

    }

    private void CanAscend()
    {

        _canAscend = true;

        PlayerManager.Instance.NbTotem++;

        PlayerManager.Instance._respawnPlaces.Add(transform.position);

    }

    private void AscendTotem()
    {

        _toActivate.transform.position = Vector3.Lerp(_origin.position, _target.position, _t);

        _t += Time.deltaTime * _ascendSpeed;

        if (_toActivate.transform.position.y >= _target.position.y)
        {

            _canAscend = false;

            _FX.SetActive(true);

        }

    }

}
