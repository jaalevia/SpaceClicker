using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject apple;
    [SerializeField]
    GameObject panel1;
    [SerializeField]
    GameObject panel2;
    //float x, y;
    [SerializeField]
    Transform parentApple;
    public PlayerScript healthCheck;

    public float Radius = 1;

    [SerializeField] GameObject deathPanel;

    public List<GameObject> appleList = new List<GameObject>();
    

    void Start()
    {

        StartCoroutine(AppleSpawn());
    }

    IEnumerator AppleSpawn()
    {

        while (healthCheck.currentHealth > 0 && appleList.Count < 10)
        {

            /*x = Random.Range(spawnZone.transform.position.x - Random.Range(0, spawnZone.bounds.extents.x), spawnZone.transform.position.x + Random.Range(0, spawnZone.bounds.extents.x));
            y = Random.Range(spawnZone.transform.position.y - Random.Range(0, spawnZone.bounds.extents.y), spawnZone.transform.position.x + Random.Range(0, spawnZone.bounds.extents.x));*/
            Vector2 ran = Random.insideUnitCircle * Radius;
            appleList.Add(Instantiate(apple, ran, Quaternion.identity, parentApple));
            yield return new WaitForSeconds(1);
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

    void Update()
    {
        if (appleList.Count == 10)
        {
            deathPanel.SetActive(true);
            panel1.SetActive(false);
            panel2.SetActive(false);

        }
            
    }

}
