using Types;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
public class RogueData : CharacterData {

    public RogueStrategyType strategyType;
    public RogueWpnType wpnType;

}
