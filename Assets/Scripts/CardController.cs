using UnityEngine;

public class CardController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private float zCoord;

    public int damage = 10;
    public Color cardColor = Color.green;

    [HideInInspector]
    public Vector3 initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = cardColor;
        }
        initialPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zCoord;
            offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zCoord;
            Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos) + offset;
            transform.position = newPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging && Input.GetMouseButtonDown(1))
        {
            isDragging = false;
            TurnManager.Instance.CancelCardSelection(this);
        }
    }

    //void OnMouseUp()
    //{
    //    if (isDragging && Input.GetMouseButtonUp(0))
    //    {
    //        isDragging = false;

    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out RaycastHit hit))
    //        {
    //            if (hit.collider.CompareTag("CardTable"))
    //            {

    //                transform.position = hit.point;
    //                TurnManager.Instance.PlaceCardOnTable(this);
    //                return;
    //            }
    //        }

    //        transform.position = initialPosition;
    //    }
    //}

    void OnMouseUp()
    {
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            int layerMask = ~(1 << LayerMask.NameToLayer("Card"));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                if (hit.collider.CompareTag("CardTable"))
                {
                    transform.position = hit.point;
                    TurnManager.Instance.PlaceCardOnTable(this);
                    return;
                }
            }

            transform.position = initialPosition;
        }
    }

}
