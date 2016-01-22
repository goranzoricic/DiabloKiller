using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiabloKiller {

    public interface HUDView {

        void TakeDamage(long damageTaken, long currentHealth);
        void ReceiveHealth(long healthRecieved, long currentHealth);
        void AddMana(long manaAdded, long currentMana);
        void SpendMana(long manaSpent, long currentMana);

    }
}
