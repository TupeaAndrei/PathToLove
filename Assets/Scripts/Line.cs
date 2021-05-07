using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineren;
    public EdgeCollider2D edgecol;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousepos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousepos);
            return;
        }

        //check if touch has moved enough to insert new point
        //if it has insert point at touchposition
        if (Vector2.Distance(points.Last(), mousepos) > .1f)
        {
            SetPoint(mousepos);
        }
    }

    public void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineren.positionCount = points.Count;
        lineren.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            edgecol.points = points.ToArray();
        }
    }
}
