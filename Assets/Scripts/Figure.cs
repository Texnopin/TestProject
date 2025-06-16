using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public int UniqueId;

    public AnimalCharacteristic AnimalCharacteristic;
    public ColorCharacteristic ColorCharacteristic;
    public MeshCharacteristic MeshCharacteristic;

    private MeshCollider meshCollider;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    public void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetCharacteristics(AnimalCharacteristic animalCharacteristic, ColorCharacteristic colorCharacteristic, MeshCharacteristic meshCharacteristic)
    {
        AnimalCharacteristic = animalCharacteristic;
        ColorCharacteristic = colorCharacteristic;
        MeshCharacteristic = meshCharacteristic;

        UniqueId = int.Parse($"{AnimalCharacteristic.Id}{ColorCharacteristic.Id}{MeshCharacteristic.Id}");

        meshFilter.mesh = MeshCharacteristic.mesh;
        meshCollider.sharedMesh = MeshCharacteristic.mesh;

        Material[] mats = meshRenderer.materials;

        mats[0].color = ColorCharacteristic.color;

        mats[2].mainTexture = AnimalCharacteristic.animalTexture;

        meshRenderer.materials = mats;
    }

}
