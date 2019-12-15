using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{

    public Camera _camera;
    Vector3 n;
    Vector3 a;

    protected Touch input;

    public bool mouseOn = false;

    // Start is called before the first frame update
    protected void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    protected void Update()
    {
        input = Input.GetTouch(0);
        if (mouseOn && input.phase == TouchPhase.Moved) {
            n = _camera.ScreenToWorldPoint(new Vector3(input.position.x, input.position.y, 0.0f));
            n.x = Mathf.Clamp(n.x, -2.0f, 2.0f);
            n.y = Mathf.Clamp(n.y, -1.5f, 1.5f);
            n.x += a.x;
            n.y += a.y;
            this.transform.position = new Vector3(n.x, n.y, this.transform.position.z);
        }
    }

    protected void OnMouseOver() {
        input = Input.GetTouch(0);
        if (input.phase == TouchPhase.Began) {
            mouseOn = true;
            a = transform.position - _camera.ScreenToWorldPoint(new Vector3(input.position.x, input.position.y, 0.0f));
        }
        if (input.phase == TouchPhase.Ended) {
            mouseOn = false;
        }
    }

}
