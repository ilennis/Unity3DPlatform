using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float boostDuration = 5f; // 유효기간 5초
                                     // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            StartCoroutine(ApplySpeedBoost(player));
        }
    }

    private IEnumerator ApplySpeedBoost(PlayerController player)
    {
        player.ModifySpeed(speedMultiplier); // Increase speed
        yield return new WaitForSeconds(boostDuration); // Wait for duration
        player.ModifySpeed(1f / speedMultiplier); // Reset speed
        Destroy(gameObject); // Remove item from the world
    }
}
