using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace DiabloKiller {

    public enum LootTableType  { Easy = 0, Medium = 1, Hard = 3 }

    public class LootManager : Updateable
    {

        public TextAsset textAsset = (TextAsset)Resources.Load("LootTable");
        private List<LootTable> lootTables;

        //private float spawnTime = -1.0f;
        private Vector3 spawnTarget = new Vector3(0, 0, -5);
        //GameObject healthPrefab = null;

        public static LootManager Instance {
            get { return Singleton<LootManager>.Instance; }
            private set { }
        }

        public LootManager() {
            //healthPrefab = (GameObject)Resources.Load("Prefabs/Pickups/HealthPickup");
            //EventManager.Instance.AddEventListener("EnemyDied", OnEnemyDied);

            lootTables = LoadLootTables();
        }

        // Update is called once per frame
        public override void Update()
        {
            ////Debug.Log("[LootManager.Update] update executed");
            //if (spawnTime >= 0.0f && spawnTime < Time.time)
            //{
            //    GameObject.Instantiate(healthPrefab, spawnTarget, Quaternion.identity);
            //    spawnTime = -1.0f;
            //}
        }

        public void QueueLoot(Transform target)
        {
            //spawnTime = Time.time;
            //spawnTarget = target.position + new Vector3(10, 0, 10);

            LootTableType lootTableType = ((EnemyCharacter)target.gameObject.GetComponent("EnemyCharacter")).lootTableType;
            //Debug.LogFormat("(EnemyCharacter)target.gameObject " + lootTableType.ToString());

            ProcessLootTables( lootTableType, target );
        }

        //public void OnEnemyDied(EventData eventData) {
        //    spawnTime = 3.0f;
        //}


        private void ProcessLootTables(LootTableType lootTableType, Transform target)
        {
            foreach (LootTable lootTable in lootTables)
            {
                //Debug.LogFormat(" Processing loot table: " + lootTable.name );

                if (lootTable.name == lootTableType.ToString())
                {
                    foreach (Loot loot in lootTable.lootCollection)
                    {
                        //Debug.LogFormat(" Processing loot : table " + lootTable.name + " loot: " + loot.gameObject);

                        float lootChance = Random.Range(0, 100);
                        Debug.LogFormat(" Loot chance roll: " + loot.gameObject + " (" + lootChance.ToString() + ")");
                        if (lootChance <= loot.chance)
                        {
                            // drop loot
                            for (int i = 1; i <= loot.quantity; i++)
                            {
                                Debug.LogFormat(" Dropping loot: " + i + "    " + loot.gameObject);

                                GameObject lootDrop = (GameObject)Resources.Load(loot.gameObject);
                                spawnTarget = target.position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
                                GameObject.Instantiate(lootDrop, spawnTarget, Quaternion.identity);
                            }
                        }
                    }
                }
            }
        }

        private List<LootTable> LoadLootTables()
        {
            List<LootTable> lootTables = new List<LootTable>();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(textAsset.text);

            XmlNode root = xmldoc.DocumentElement;
            //Debug.LogFormat("root name " + root.Name); // LootTables

            foreach (XmlNode lootTableNode in root) // gets loot tables : Easy,Medium,Hard
            {
                LootTable lootTable = new LootTable();
                lootTable.name = lootTableNode.Attributes["name"].Value;
                lootTable.lootCollection = new List<Loot>();

                //Debug.LogFormat("lootTableNode " + lootTableNode.Attributes["name"].Value); // Easy/Medium/Hard

                foreach (XmlNode lootNode in lootTableNode) // Loot nodes containing loot info
                {
                    //Debug.LogFormat("lootNode " + lootNode.Name); // Node

                    Loot loot = new Loot();

                    foreach (XmlNode lootInfo in lootNode)
                    {
                        //Debug.LogFormat("lootInfo: " + lootInfo.Name + " " + lootInfo.InnerText); // loot info

                        switch (lootInfo.Name.ToUpper())
                        {
                            case "CHANCE": loot.chance = int.Parse(lootInfo.InnerText); break;
                            case "QUANTITY": loot.quantity = int.Parse(lootInfo.InnerText); break;
                            case "GAMEOBJECT": loot.gameObject = lootInfo.InnerText; break;
                        }
                    }

                    lootTable.lootCollection.Add(loot);
                }

                lootTables.Add(lootTable);
            }

            return lootTables;
        }

    }

    public class LootTable : MonoBehaviour
    {
        public string name;
        public List<Loot> lootCollection;
    }

    public class Loot : MonoBehaviour
    {
        public int chance;
        public int quantity;
        public string gameObject;
    }

}
