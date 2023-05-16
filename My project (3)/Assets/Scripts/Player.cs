using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset movedelta
        moveDelta = new Vector3(x, y, 0);

        //Karakterin gitti�i tarafa do�ru d�nmesini sa�la
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one; //Vector3(1,1,1)
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        //wasd y�nlerinin unityde 1,0,-1 say�lar�na e�itliklerinden dolay� lokasyonunu de�i�tirerek karakteri d�nd�r�yor


        //actor layerinin blocking layerinin �zerine ��kmas�n� engelleyen kod -- y ekseninde engelliyor
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            //Hareket
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //actor layerinin blocking layerinin �zerine ��kmas�n� engelleyen kod -- x ekseninde engelliyor
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Hareket
            transform.Translate(moveDelta.x * Time.deltaTime, 0 , 0);
        }

    }
}
