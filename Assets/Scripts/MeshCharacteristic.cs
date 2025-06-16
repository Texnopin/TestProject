using UnityEngine;

[CreateAssetMenu(fileName = "MeshCharacteristic", menuName = "Characteristics/Mesh")]
public class MeshCharacteristic : ScriptableObject, ICharacteristic
{
    public int id;
    public string characteristicName;
    public Mesh mesh;

    public int Id => id;
    public string Name => characteristicName;
}
