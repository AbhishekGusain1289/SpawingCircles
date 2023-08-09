using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Circle : MonoBehaviour
{   public static Circle instance;
    SpriteRenderer spriteRenderer;
    Tween myTween;
    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        Killing();
    }

    public void Killing()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (myRigidbody.IsTouchingLayers(LayerMask.GetMask("line"))&&this!=null)
            {
                Color color = new Color(255, 0, 0, 0);
                spriteRenderer.DOColor(color, 0.3f);

                Invoke("Destroying", 1f);
            }
            else
                return;

        
        }
    }

    void Destroying()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        DOTween.Kill(spriteRenderer);
    }

}
