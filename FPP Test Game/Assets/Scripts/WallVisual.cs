using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisual : MonoBehaviour
{
    private Wall owner;

    private MeshRenderer meshRenderer;
    private float visibleTime = 0.5f;

    [SerializeField] Material defaultMaterial;
    [SerializeField] Material onHitCorrectMaterial;
    [SerializeField] Material onHitIncorrectMaterial;

    private Coroutine coroutine;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        owner = GetComponentInParent<Wall>();
    }

    public void MarkWallVisualization(bool correct)
    {
        CoroutineCheck();

        visibleTime = 0.5f;

        if (correct)
            coroutine = StartCoroutine(SetVisualizationMaterialForTime(onHitCorrectMaterial));
        else
            coroutine = StartCoroutine(SetVisualizationMaterialForTime(onHitIncorrectMaterial));
    }

    private void CoroutineCheck()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator SetVisualizationMaterialForTime(Material material)
    {
        while (visibleTime > 0)
        {
            visibleTime -= Time.deltaTime;

            SetMaterial(material);
            yield return null;
        }

        SetMaterial(defaultMaterial);
        yield break;
    }

    private void SetMaterial(Material material)
    {
        meshRenderer.sharedMaterial = material;
    }
}
