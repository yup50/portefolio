using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Fighter fighter;
    private Mover mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        fighter = GetComponentInChildren<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickToFight()) return;
        if (ClickToMove()) return;

        print("nothing going on");
    }



    
    bool ClickToMove()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetRay(), out hit);
        if (hasHit)
        {
            if (Input.GetMouseButton(0) && !GetComponent<Health>().IsDead())
            {
                fighter.Cancel();
                mover.Move(hit.point);
            }
            return true;
        }
        return false;
    }

    private bool ClickToFight()
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(GetRay());
        foreach (RaycastHit hit in raycastHits)
        {
            CombatTarget target = hit.transform.GetComponent<CombatTarget>();
            if (target == null) continue;
            if (Input.GetMouseButtonDown(0))
            {
                fighter.Attack(target);
            }
            return true;
        }
        return false;
    }

    private static Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            mover.Move(hit.point);
        }

    }

    void OnDrawGizmos()
    {
        Ray ray = GetRay();
        RaycastHit hit;
        Gizmos.color = Color.red; // Kies een kleur voor de Raycast lijn

        // Als de Raycast iets raakt, teken dan een lijn tot het hitpunt
        if (Physics.Raycast(ray, out hit))
        {
            Gizmos.DrawLine(ray.origin, hit.point);
            Gizmos.DrawSphere(hit.point, 0.1f); // Dit tekent een bol op het hitpunt
        }
        else
        {
            // Als er niets geraakt wordt, teken de lijn naar een ver punt
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 100);
        }
    }
}
