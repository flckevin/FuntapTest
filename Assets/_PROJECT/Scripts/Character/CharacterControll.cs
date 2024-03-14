using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public LayerMask _layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot() 
    {
        if (GameManager.Instance._isPausing == true) return;
        //if there is touch
        if (Input.touchCount > 0)
        {
            //get first touch
            Touch _currentTouch = Input.GetTouch(0);
            //get touch position
            Vector2 _touchPos = Camera.main.ScreenToWorldPoint(_currentTouch.position);
            //look at touched position
            transform.up = _touchPos - new Vector2(this.transform.position.x, this.transform.position.y);

            RaycastHit2D _ray2D = Physics2D.Raycast(this.transform.position, _touchPos, Mathf.Infinity, _layer);

            if (_ray2D.collider != null) 
            {
                _ray2D.transform.GetComponent<EntityCore>().DealDamage(1);
            }
        }

    }

}
