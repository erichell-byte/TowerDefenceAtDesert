using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private GameObject _dragSprite;

    [SerializeField] private GameObject bombPrefab;

    private bool isActive = false;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            DisableDrag();
            PlaceBomb();
        }
        
        if (isActive)
        {
            FollowMouse();
        }
    }

    public void CreateFire()
    {
        EnableDrag();
    }

    public void EnableDrag()
    {
        _dragSprite.SetActive(true);
        isActive = true;
    }
    
    public void DisableDrag()
    {
        _dragSprite.SetActive(false);
        isActive = false;
    }

    public void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        _dragSprite.transform.position = mousePosition;
    }

    public void PlaceBomb()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            GameObject Bomb = Instantiate(bombPrefab);
            Bomb.transform.position = mousePosition;
        }
        
    }
}
