using GameCore.Abilities.Effects;
using GameCore.Interfaces;

namespace GameCore.Abilities.AttackAbility
{
    public class AttackAbilityInstance : IAbility
    {
        public AbilityData Data { get; set; }
        public List<IEffect> Effects { get; set; }

        public AttackAbilityInstance(AbilityData data, List<IEffect> effectData)
        {
            Data = data;
            Effects = effectData;
        }

        public void ExecuteAbility()
        {
            Console.WriteLine($"Executing attack with ability: {Data.AbilityId}");

            foreach (var effect in Effects)
            {
                effect.ApplyEffect();
            }
        }
    }
}
