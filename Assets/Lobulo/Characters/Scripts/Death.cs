using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _drop;
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private string deathSceneName = "DeathScene";

    private CharacterController _characterController;
    private PlayerAimRotation _playerAimRotation;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAimRotation = TryGetComponent(out PlayerAimRotation playerAimRotation) ? playerAimRotation : null;
    }

    public void DeathFunctionality()
    {
        if(_drop != null) Instantiate(_drop, transform.position, transform.rotation);
        
        if(_playerAimRotation) _playerAimRotation.enabled = false;
        _characterController.enabled = false;

        ChangeLayerToDeath();
        Disarmament();
    }

    private void ChangeLayerToDeath()
    {
        gameObject.layer = LayerMask.NameToLayer("Death");
        foreach (Collider collider in _colliders)
        {
            collider.gameObject.layer = LayerMask.NameToLayer("Death");
        }
    }

    private void Disarmament()
    {
        foreach (Collider collider in _colliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(250f, transform.position, 3f);
        }
    }

    public void DeathScene()
    {
        if (!string.IsNullOrEmpty(deathSceneName))
        {
            Debug.Log("Muriendo");
            SceneManager.LoadScene(deathSceneName);

            PlayerPrefs.SetInt("LastSceneBeforeDeath", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
    }
}
