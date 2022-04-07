using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class AnimationHandler : MonoBehaviour
{
    public static AnimationHandler AH;

    void awake()
    {
        AH = this;
        GetClipTimes();
        Debug.Log("non" + cliptime);
    }

    public PokemonBase Attacker;
    public PokemonBase Enemy;
    public Animator Lucario;
    public Dictionary<string, float> cliptime;



    public void GetClipTimes()
    {
        AnimationClip[] Clips = Lucario.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in Clips)
            if (!cliptime.ContainsKey(clip.name))
            {
                cliptime.Add(clip.name, clip.length);
                Debug.Log(clip.name);
            }

    }
    public void Attack(string attack)
    {
        AttackAnimation(attack); Debug.Log("attack launched");

    }
    private IEnumerator AttackAnimation(string attack)
    {
        //set anim to true
        Lucario.SetBool("Attacking", true); Debug.Log("attack set to true");
        yield return new WaitForSeconds(cliptime[attack]); Debug.Log("animation under way");
        Lucario.SetBool("Attacking", false); Debug.Log("animation off");
    }
    public void run()
    {
        StartCoroutine(RunAnimation()); //await async 

    }
    private IEnumerator RunAnimation()
    {
        //set anim to true
        Lucario.SetBool("Running", true);
        yield return new WaitForSeconds(cliptime["RUNNING"]);
        Lucario.SetBool("Running", false);

    }
    public void GetHit()
    {
        GetHitAnimation();
    }
    private IEnumerator GetHitAnimation()
    {
        Lucario.SetBool("Running", true);
        yield return new WaitForSeconds(cliptime["RUNNING"]);
        Lucario.SetBool("Running", false);
    }


}
