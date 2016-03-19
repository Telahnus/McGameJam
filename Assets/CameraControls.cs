using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    private Vector3 pos;
    public float zoom;
    public float spacing;
    public float speed;

    public float zoomSpeed;
    public Camera minimap;

    // Use this for initialization
    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))pos.z += spacing;
        if (Input.GetKeyDown(KeyCode.S))pos.z -= spacing;
        if (Input.GetKeyDown(KeyCode.A))pos.x -= spacing;
        if (Input.GetKeyDown(KeyCode.D))pos.x += spacing;
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            minimap.orthographicSize -= Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
       
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

    }
}
