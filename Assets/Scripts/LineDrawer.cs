using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineDrawer : MonoBehaviour
{
    LineRenderer LineDraw;
    EdgeCollider2D EdgeCollider;
    Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        LineDraw = GetComponent<LineRenderer>();
        EdgeCollider = GetComponent<EdgeCollider2D>();
        LineDraw.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Drawing();
        AddCollider();
    }

    void Drawing()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 startPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineDraw.SetPosition(0, new Vector3(startPos.x,startPos.y,0));
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineDraw.SetPosition(1,new Vector3(mousepos.x,mousepos.y,0));
        }


    }


    void AddCollider()
    {
        List<Vector2> edges = new List<Vector2>();

        for (int i = 0; i < LineDraw.positionCount; i++)
        {
            Vector3 lineRendererPoint = LineDraw.GetPosition(i);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
        EdgeCollider.SetPoints(edges);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
