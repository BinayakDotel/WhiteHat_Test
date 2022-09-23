using System.Collections.Generic;
using UnityEngine;

public class DynamicRendering : MonoBehaviour
{
    [SerializeField] List<GameObject> ground_floor_props, first_floor_props;

    [SerializeField] Transform player;
    [SerializeField] float current_position;
    [SerializeField] float threshold = 1f;
    [SerializeField] bool in_ground_floor, prev = true;
    [SerializeField] PlayerMovement player_movement;

    private void Start()
    {
        DetermineFloor();
        prev = !in_ground_floor;
    }
    private void Update()
    {
        DetermineFloor();

        //To prevent the rendering function to be called everytime on each frame
        if (in_ground_floor != prev)
        {
            prev = in_ground_floor;
            print($"UPDATE NOW");
            UpdateRendering();
        }
    }
    void UpdateRendering()
    {
        if (in_ground_floor)
        {
            foreach (GameObject prop in ground_floor_props)
            {
                prop.SetActive(true);
            }
            foreach (GameObject prop in first_floor_props)
            {
                prop.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject prop in ground_floor_props)
            {
                prop.SetActive(false);
            }
            foreach (GameObject prop in first_floor_props)
            {
                prop.SetActive(true);
            }
        }
    }
    void DetermineFloor()
    {
        current_position = player.position.y;
        in_ground_floor = current_position < threshold;
    }
}
