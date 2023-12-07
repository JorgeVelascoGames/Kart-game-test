using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(SphereCollider))]
public class Coin : MonoBehaviour
{
    public static Action CoinCollected;

    [Tooltip("Sound to for the pick up")]
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        GetComponent<SphereCollider>().enabled = false;

        if (CoinCollected != null)
            CoinCollected();

        AudioUtility.CreateSFX(collectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);

        Destroy(gameObject);
    }
}
