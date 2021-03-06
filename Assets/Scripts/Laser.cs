﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class LaserColor
{
    public Color color;
    public string name;
}


public class Laser : MonoBehaviour
{
    public LaserColorScriptable laserColors;
    private Panel panel;
    public SelectionPanel colorSelection;
    public Button shoot;
    public bool toggle = false;

    public Sprite toggleOn;
    public Sprite toggleOff;
    public Image toggleImage;

    public GameObject CrossHairPrefab;
    public HiveBehaviour hive;

    public List<GameObject> crossHairs;
    Queue<int> freeCrossHairs;
    Queue<int> usedCrossHairs;


    public GameObject laserExplosion;
    public AudioClip laserAudio;

    void Start()
    {
        freeCrossHairs = new Queue<int>();
        usedCrossHairs = new Queue<int>();
        crossHairs = new List<GameObject>();
        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

        hive = FindObjectOfType<HiveBehaviour>();

        colorSelection.SetList(laserColors.GetNames());
        shoot.onClick.AddListener(ToggleShoot);

        for(int i = 0; i < 50; ++i)
        {
            freeCrossHairs.Enqueue(i);
            crossHairs.Add(Instantiate(CrossHairPrefab));
            crossHairs[crossHairs.Count - 1].transform.SetParent(transform);
            crossHairs[crossHairs.Count - 1].SetActive(false);
        }
        toggleImage.sprite = toggleOff;
    }

    public void ToggleShoot()
    {
        toggle = !toggle;
        if (toggle)
        {
            toggleImage.sprite = toggleOn;
            ToggleCrossOn();
        }
        else
        {
            toggleImage.sprite = toggleOff;
            ToggleCrossOff();
        }
    }

    public void ToggleCrossOn()
    {
        foreach(BaseCreature creature in hive.creatures)
        {
            int idx = freeCrossHairs.Dequeue();
            usedCrossHairs.Enqueue(idx);
  
            crossHairs[idx].transform.position = creature.transform.position;
            crossHairs[idx].GetComponent<TrackObject>().trackedObject = creature.transform;
            crossHairs[idx].SetActive(true);
        }
    }

    public void ToggleCrossOff()
    {
        while(usedCrossHairs.Count>0)
        {
            int indx = usedCrossHairs.Dequeue();
            freeCrossHairs.Enqueue(indx);
            crossHairs[indx].SetActive(false);
        }
    }



    void UpdateDisplay()
    {

    }

    void UpdateMe()
    {
        
    }


    public void ShootLaser (TrackObject tracker)
    {
        Transform trackedObj = tracker.trackedObject;

        SoundManager.Instance.Play(laserAudio);
        GameObject explosion = Instantiate(laserExplosion);
        trackedObj.GetComponent<BaseCreature>().HitByLaser(explosion);
        tracker.gameObject.SetActive(false); //Remove crosshair
    }
}
