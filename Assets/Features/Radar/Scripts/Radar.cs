using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private GameObject radarPingPrefab;
    private Transform pulseSpriteTransform;
    private Transform radarBackgroundTransform;

    private float range;
    private float rangeMax = 4f;
    private float rangeSpeed;

    private HashSet<Collider> alreadyHitColliders;

    private void Awake()
    {
        pulseSpriteTransform = transform.Find("Head/Pulse");
        radarBackgroundTransform = transform.Find("Head/Background");

        rangeSpeed = rangeMax * 0.75f;

        alreadyHitColliders = new HashSet<Collider>();
    }
    
    void Update()
    {
        range += rangeSpeed * Time.deltaTime;
        if(range > rangeMax)
        {
            range = 0f;
            alreadyHitColliders.Clear();
        }

        float scaleRate = radarBackgroundTransform.localScale.x / rangeMax;
        pulseSpriteTransform.localScale = new Vector2(range * scaleRate, range * scaleRate);

        Collider[] hits = Physics.OverlapSphere(transform.position, range, 1 << 6);

        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                if (alreadyHitColliders.Add(hit))
                {
                    GameObject newPing = Instantiate(radarPingPrefab, Vector3.zero, Quaternion.identity);
                    
                    newPing.transform.parent = radarBackgroundTransform;
                    newPing.transform.localPosition = rescalePositionOntoRadar(hit.transform.position);
                    newPing.transform.localRotation = Quaternion.identity;
                    newPing.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
                }
            }
        }
    }

    private Vector2 rescalePositionOntoRadar(Vector3 worldPosition)
    {
        Vector3 radarCenter = transform.position;
        Vector3 offset = worldPosition - radarCenter;
        Vector3 localOffset = Quaternion.Inverse(transform.rotation) * offset;
        Vector2 normalizedOffset = new Vector2(localOffset.x / rangeMax, localOffset.z / rangeMax);

        float clampedX = Mathf.Clamp(normalizedOffset.x, -0.5f, 0.5f);
        float clampedY = Mathf.Clamp(normalizedOffset.y, -0.5f, 0.5f);
        // 0.5f: pings are instantiated as child of radar background, so we need them to be in [-0.5f, 0.5f]

        return new Vector2(clampedX, clampedY);
    }
}
