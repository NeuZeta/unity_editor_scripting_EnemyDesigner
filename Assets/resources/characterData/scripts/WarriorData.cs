using Types;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Warrior Data", menuName = "Character Data/Warrior")]
public class WarriorData : CharacterData {

    public WarriorClassType classType;
    public WarriorWpnType wpnType;

}
