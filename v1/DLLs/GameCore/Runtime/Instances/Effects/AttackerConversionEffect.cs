using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Interfaces;

namespace GameCore.Runtime.Instances.Effects
{
    public class AttackerConversionEffect : IEffect
    {
        public AttackerConversionEffectData EffectData { get; private set; }

        public AttackerConversionEffect(AttackerConversionEffectData effectData)
        {
            EffectData = effectData;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            foreach (var partyMember in effectContext.PartymemberToConvert)
            {
                if (partyMember.Data.Class == EffectData.FromClass)
                {
                    IAttackAbility newAbility = null;

                    switch (EffectData.ToClass)
                    {
                        case PartymemberClass.Warrior:
                            newAbility = effectContext.GameContext.AbilityFactory.CreateAttackAbilityInstance("AttackAllGoblins");
                            break;
                        case PartymemberClass.Mage:
                            newAbility = effectContext.GameContext.AbilityFactory.CreateAttackAbilityInstance("AttackAllOozes");
                            break;
                    }

                    var abilityVorhanden = partyMember.AttackAbilities.Any(a => a.AbilityId == newAbility.AbilityId);

                    if (!abilityVorhanden)
                    {
                        partyMember.AttackAbilities.Add(newAbility);

                    }
                }
            }
        }
    }
}
