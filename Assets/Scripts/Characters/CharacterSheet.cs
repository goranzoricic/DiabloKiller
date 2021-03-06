using UnityEngine;
using System.Collections.Generic;

namespace DiabloKiller {

    public enum CharacterStats {
        // player only
        Strength,
        Agility,
        Inteligence,
        Vitality,
        // enemy
        Power
    };

    public enum CharacterResources {
        Health,
        Mana
    }

    public class CharacterSheet {

        private Dictionary<CharacterStats, CharacterStat> stats = new Dictionary<CharacterStats, CharacterStat>();
        private Dictionary<CharacterResources, CharacterResource> resources = new Dictionary<CharacterResources, CharacterResource>();

        // ----------------------- Public methods -------------------------
        public CharacterStat GetStat(CharacterStats stat) {
            CharacterStat result;
            stats.TryGetValue(stat, out result);
            return result;
        }

        public void AddStat(CharacterStats statKey, CharacterStat stat) {
            stats.Add(statKey, stat);
        }

        public void RemoveStat(CharacterStats statKey) {
            stats.Remove(statKey);
        }

        public CharacterResource GetResource(CharacterResources resource) {
            CharacterResource result;
            resources.TryGetValue(resource, out result);
            return result;
        }

        public void AddResource(CharacterResources resourceKey, CharacterResource resource) {
            resources.Add(resourceKey, resource);
        }

        public void RemoveResource(CharacterResources resourceKey) {
            resources.Remove(resourceKey);
        }

        public void ReceiveResource(CharacterResources resourceKey, long resourceToReceive) {
            if (resourceToReceive < 0) {
                return;
            }
            CharacterResource resource = GetResource(resourceKey);

            Debug.LogFormat("[CharacterResources.ReceiveMana] Get resource {0}  ", resourceToReceive);
            resource.CurrentAmmount += resourceToReceive;

            if (resource.CurrentAmmount > resource.MaxAmmount) {
                resource.CurrentAmmount = resource.MaxAmmount;
            }
            Debug.LogFormat("[CharacterResources.ReceiveResource] Recieving resource {0}, ammount: {0}, new current ammount: {2}", resourceKey, resourceToReceive, resource.CurrentAmmount);
        }

        public void SpendResource(CharacterResources resourceKey, long resourceToSpend) {           
            if (resourceToSpend < 0) {
                return;
            }
            CharacterResource resource = GetResource(resourceKey);

            resource.CurrentAmmount -= resourceToSpend;

            if (resource.CurrentAmmount < 0) {
                resource.CurrentAmmount = 0;
            }
            Debug.LogFormat("[CharacterResources.SpendResource] Spend resource {0}, ammount to spend: {1}, new current ammount: {2}", resourceKey, resourceToSpend, resource.CurrentAmmount);
        }

        // ----------------------- Private methods -------------------------


    }
}
