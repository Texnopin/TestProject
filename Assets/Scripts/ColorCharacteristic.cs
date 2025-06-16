using UnityEngine;

[CreateAssetMenu(fileName = "ColorCharacteristic", menuName = "Characteristics/Color")]
public class ColorCharacteristic : ScriptableObject, ICharacteristic
{
    public int id;
    public string characteristicName;
    public Color color;

    public int Id => id;
    public string Name => characteristicName;
}
