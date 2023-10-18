using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    private bool inRange;
    [SerializeField] private TextAsset inkJson;

    private void Update() {
        if (inRange) {
            if (Input.GetButtonDown("Interact")) {
                Debug.Log(inkJson);
            }
        }
    }

    private void Awake() {
        inRange = false;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            inRange = false;
        }
    }
}
