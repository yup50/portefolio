using System.Collections;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float distance = 10f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float grappleSpeed = 3f;
    [SerializeField] private GameObject playerHand;

    private DistanceJoint2D joint;
    private Vector3 grapplePoint;
    private RaycastHit2D hit;

    private bool isGrappling = false;

    private void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGrappling)
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(playerHand.transform.position, targetPos - playerHand.transform.position, distance, mask);

            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                StartCoroutine(ShootGrapple());
            }
        }

        // Hou de lijn up-to-date
        if (joint.enabled)
        {
            line.SetPosition(0, playerHand.transform.position);
            line.SetPosition(1, grapplePoint);

            // Trek speler binnen
            float step = grappleSpeed * Time.deltaTime;
            joint.distance = Mathf.Max(0.5f, joint.distance - step);

            // Automatisch loskoppelen
            if (joint.distance <= 0.6f)
            {
                ReleaseGrapple();
            }
        }

        // Handmatig loslaten
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseGrapple();
        }
    }

    private IEnumerator ShootGrapple()
    {
        isGrappling = true;
        line.enabled = true;

        Vector3 start = playerHand.transform.position;
        Vector3 end = grapplePoint;

        float duration = 0.2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            Vector3 currentPoint = Vector3.Lerp(start, end, t);
            line.SetPosition(0, playerHand.transform.position);
            line.SetPosition(1, currentPoint);

            yield return null;
        }

        // Pas verbinden na animatie
        joint.enabled = true;
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint;
        joint.connectedBody = null;
        joint.distance = Vector2.Distance(playerHand.transform.position, grapplePoint);

        line.SetPosition(0, playerHand.transform.position);
        line.SetPosition(1, grapplePoint);

        isGrappling = false;
    }

    private void ReleaseGrapple()
    {
        joint.enabled = false;
        line.enabled = false;
    }
}
