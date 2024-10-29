using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        FireRay();
    }

    void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData))
        {
            Debug.Log($"Item: {hitData.collider.name} Distance: {hitData.distance}");
        }
    }
}
