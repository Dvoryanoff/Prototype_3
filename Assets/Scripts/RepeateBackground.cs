using UnityEngine;

public class RepeateBackground : MonoBehaviour {

    private Vector3 startPos;
    private float repeateWidth;
    void Start() {
        startPos = transform.position;
        repeateWidth = GetComponent<BoxCollider>().size.x / 2;

    }

    void Update() {
        if (transform.position.x < startPos.x - repeateWidth) {
            transform.position = startPos;

        }
    }
}
