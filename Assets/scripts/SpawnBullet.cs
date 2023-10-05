using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public static SpawnBullet instance { get; private set; }
    public GameObject bullet, player, chargeUp;
    public Transform SpawnSpot;
    public PlayerMechanics playerMech;

    bool canShoot = true;
    private float shootCD = 1;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }
        playerMech = player.GetComponent<PlayerMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true && playerMech.inRange == true)
        {
            StartCoroutine(Spawn(shootCD));
        }
        else if (playerMech.inRange == false)
            StopCoroutine(Spawn(shootCD));
    }
    IEnumerator Spawn(float CD)
    {

        canShoot = false;
        chargeUp.SetActive(true);
        yield return new WaitForSeconds(1);
        Instantiate(bullet, SpawnSpot.position, Quaternion.identity);
        chargeUp.SetActive(false);
        yield return new WaitForSeconds(CD);

        canShoot = true;
    }

}
