using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public float tapForce = 10;
    public float tiltsmooth = 5;
    public Vector3 startPos;
    public float myfloat;
    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion fowardRotation;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -70);
        fowardRotation = Quaternion.Euler(0, 0, 35);
    
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            transform.rotation = fowardRotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltsmooth * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "ScoreZone") {
            //register a score event
            //play a sound
        }

        if (col.gameObject.tag == "DeadZone") {
            rigidbody.simulated = false;
            //register a dead event
            //play a sound
        }
    }
}
