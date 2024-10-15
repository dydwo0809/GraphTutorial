using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Dot[] dots;
    public Dot dotPrefab;

    public GameObject canvasObject;

    public Vector2 start;
    public Vector2 end;
    public Vector2 v;
    
    private int density = 200;
    private float radius2 = 6000;

    public void Awake()
    {
        canvasObject = GameObject.Find("Canvas");
    }

    public void Start()
    {
        dots = new Dot[density + 1];

        for (int i = 0; i < density + 1; i++)
        {
            Dot dot = Instantiate(dotPrefab, canvasObject.transform);
            dots[i] = dot;
            dots[i].setPos(-965f, -535f);
        }
    }

    public void SetStart(float x, float y)
    {
        start = new Vector2(x, y);
    }

    public void SetEnd(float x, float y)
    {
        end = new Vector2(x, y);
    }

    public void SetV()
    {
        v = new Vector2(end.x - start.x, end.y - start.y);
    }

    private float dist2(Vector2 p, float x, float y)
    {
        return (x - p.x) * (x - p.x) + (y - p.y) * (y - p.y);
    }

    public void DrawLine()
    {
        for (int i = 0; i < density + 1; i++)
        {
            float x = start.x + v.x * i / (float)density;
            float y = start.y + v.y * i / (float)density;
            float d1 = dist2(start, x, y);
            float d2 = dist2(end, x, y);
            if (d1 >= radius2 && d2 >= radius2)
            {
                dots[i].setPos(x, y);
            }
        }
    }

}
