using System;
using _project.Scripts;
using UnityEngine;


public enum SmashPower
{
    Weak,
    Medium,
    Strong
}
public enum SmashDirection
{
    North,
    South
}

public class Contestant : MonoBehaviour
{
    [SerializeField] private InputReader inputs;
    
    public SmashPower CurrentPower { get; set; }
    public SmashDirection CurrentDirection { get; set; }
    private ContestantController _playerInputs;

    private CircleCollider2D _hitbox;


    
    
    
    private void Awake()
    {
        _playerInputs = GetComponent<ContestantController>();
        _playerInputs.Constructor(this, inputs);
        _hitbox = GetComponent<CircleCollider2D>();

    }

    public void Smash(SmashDirection direction)
    {
        CurrentDirection = direction;
        _hitbox.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Ball>().SmashIntensity(CurrentDirection, CurrentPower);
    }
}