using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    
    [SerializeField] private GameObject _radInterface;

    private towerScript towerScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _radInterface.SetActive(false);
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitNew = Physics2D.Raycast(mousePoint, Vector2.zero);
            
            if (hitNew)
            {
                towerScript = hitNew.collider.GetComponentInParent<towerScript>();
                if (towerScript == null)
                    towerScript = hitNew.collider.GetComponent<towerScript>();
                if (towerScript != null)
                {
                    _radInterface.SetActive(true);
                    GlobalEventManager.SendSetRadInterface(towerScript);
                    _radInterface.transform.position = hitNew.transform.position;
                    
                }
            }
        }
    }
}
