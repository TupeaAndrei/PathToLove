using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject[] linepref;
    private Line activeline;
    public int index;
    public bool candraw;

    private void Start()
    {
        index = 0;
        candraw = true;
    }
    void Update()
    {
        if (Input.touchCount > 0 && candraw)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GameObject lineGO = Instantiate(linepref[index]);
                activeline = lineGO.GetComponent<Line>();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                activeline = null;
            }

            if (activeline != null)
            {
                Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
                activeline.UpdateLine(touchpos);
            }
        }    
    }
}
