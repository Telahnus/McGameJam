using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    public float zoomSpeed;
    public Camera minimap;
    public float minzoom;
    public float maxzoom;

	void Update () {

        minimap.orthographicSize -= Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
        minimap.orthographicSize = Mathf.Clamp(minimap.orthographicSize, minzoom, maxzoom);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        float speed = minimap.orthographicSize;
        transform.Translate(movement * speed * Time.deltaTime);

    }
}
