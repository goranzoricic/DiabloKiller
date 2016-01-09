using UnityEngine;
using System.Collections.Generic;

public class AbilityController {
    private Dictionary<string, Ability> abilities;
    private Character owner;

    public AbilityController(Character owningCharacter) {
        owner = owningCharacter;
        abilities = new Dictionary<string, Ability>();
    }

    // Update is called once per frame
    public void Update() {
    }

    public void UseAbility(string abilityName) {
        Ability ability = abilities[abilityName];
        if (ability == null) {
            Debug.LogErrorFormat("[AbilityController.UseAbility] Character attemted to use an ability it doesn't have: {0}", abilityName);
            return;
        }
        ability.Start();
    }

    public void OnDeath() {
    }

};
