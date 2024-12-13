using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledStory {
    public class RespawnPlane : MonoBehaviour {
        [SerializeField] private Transform player;
        [SerializeField] private Transform respawnPoint;

        void OnTriggerEnter(Collider player) {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
