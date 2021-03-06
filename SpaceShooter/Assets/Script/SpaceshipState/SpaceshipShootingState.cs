using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShootingState : SpaceshipBaseState
{
    private float attack_Timer = 2f;
    private float current_Attack_Timer;
    private bool canAttack;
    public override void EnterState(SpaceshipStateControl spaceship)
    {
        current_Attack_Timer = attack_Timer;
    }

    public override void UpdateState(SpaceshipStateControl spaceship)
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }
        if (canAttack)
        {
            canAttack = false;
            attack_Timer = 0f;
            spaceship.Shoot();
        }
        SwitchState(spaceship);
    }

    private void SwitchState(SpaceshipStateControl spaceship)
    {
        if (Input.GetMouseButton(0))
        {
            spaceship.SwitchState(spaceship.movingState);
        }
        else
        {
            spaceship.SwitchState(spaceship.idleState);
        }
    }
}
