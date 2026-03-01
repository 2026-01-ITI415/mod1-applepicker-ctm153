using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    public static float bottomY = -20f;
    private ApplePicker apScript;

    void Start() {
        apScript = Camera.main.GetComponent<ApplePicker>();
    }

    void Update () {
        if ( transform.position.y < bottomY ) {
            apScript?.AppleMissed();
            Destroy( this.gameObject );
        }
    }
}