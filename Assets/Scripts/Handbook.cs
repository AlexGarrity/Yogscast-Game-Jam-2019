using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handbook : Moveable
{
    public GameObject largeHandbook;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    new void OnMouseOver() {
        input = Input.GetTouch(0);
        if (input.tapCount == 1 && input.phase == TouchPhase.Ended) {
            largeHandbook.SetActive(!largeHandbook.activeInHierarchy); 
        }
        
    }
}
