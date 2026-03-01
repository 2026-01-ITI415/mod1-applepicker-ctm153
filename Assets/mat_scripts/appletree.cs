using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject   applePrefab;

    // Speed at which the AppleTree moves
    public float        speed = 1f;

    // Distance where AppleTree turns around
    public float        leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float        changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float        appleDropDelay = 1f;

void Start () {
    InvokeRepeating("DropApple", 2f, appleDropDelay);
}

void DropApple() {
    GameObject apple = Instantiate<GameObject>( applePrefab );
    apple.transform.position = transform.position;
}

void Update () {
    Vector3 pos = transform.position;
    pos.x += speed * Time.deltaTime;
    transform.position = pos;

    if ( pos.x < -leftAndRightEdge ) {
        speed = Mathf.Abs( speed );
    } else if ( pos.x > leftAndRightEdge ) {
        speed = -Mathf.Abs( speed );
    }

    // Random direction change moved here, where Time.deltaTime applies
    if ( Random.value < changeDirChance * Time.deltaTime ) {
        speed *= -1;
    }
}
}