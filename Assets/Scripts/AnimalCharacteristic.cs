using UnityEngine;

[CreateAssetMenu(fileName = "AnimalCharacteristic", menuName = "Characteristics/Animal")]
public class AnimalCharacteristic : ScriptableObject, ICharacteristic
{
    public int id;
    public string characteristicName;
    public Texture animalTexture; 

    public int Id => id;
    public string Name => characteristicName;
}
