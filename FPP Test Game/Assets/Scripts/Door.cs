using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int doorValue;

    [SerializeField] BoxCollider doorTrigger;

    [SerializeField] ParticleSystem fireParticle;
    [SerializeField] Transform firePoint;

    public bool doorDestroyded = false;
    public bool doorNeutralized = false;
    public bool doorCheckedAfterNeutralization = false;

    // Start is called before the first frame update
    void Start()
    {
        doorValue = Random.Range(1, 9);
        GameInput.Instance.OnInteraction += GameInput_OnInteraction;
    }

    private void GameInput_OnInteraction(object sender, System.EventArgs e)
    {
        if (!doorNeutralized || !doorCheckedAfterNeutralization || doorValue > 0)
            DestroyDoor();
        
        if (doorNeutralized && doorCheckedAfterNeutralization && doorValue == 0)
            OpenDoor();
    }

    private void OpenDoor()
    {
        GameStatistics.correctNeutralizedDoors++;
        Destroy(gameObject);
    }

    public void DestroyDoor()
    {
        doorDestroyded = true;
        Destroy(doorTrigger.gameObject);

        UIManager.Instance.HideInteractionText();
        GameStatistics.incorrentNeutralizedDoors++;
        Instantiate(fireParticle, firePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDoorValue()
    {
        Debug.Log(doorValue);
        return doorValue;
    }

    public void NeutralizeDoor()
    {
        doorValue = 0;
        doorNeutralized = true;
    }
}
