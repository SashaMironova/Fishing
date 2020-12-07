using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    public void Pickup()
    {
        StartCoroutine(PickupCoroutine());
    }

    private IEnumerator PickupCoroutine()
    {
        _animator.SetBool("Picked", true);
        yield return new WaitForSeconds(.4f);
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        SceneController sceneController = FindObjectOfType<SceneController>();
        if (sceneController != null && sceneController.reload == false )
        {
            sceneController.CreateCookie();
        }
    }
}
