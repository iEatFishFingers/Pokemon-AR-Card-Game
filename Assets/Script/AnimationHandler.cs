using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;


public class AnimationHandler : MonoBehaviour
{
    public static AnimationHandler AH;

    void awake()
    {
        AH = this;
    }

    public PokemonBase Attacker;
    public PokemonBase Enemy;
    public Animator Lucario;
    public Dictionary<string, float> cliptime;



    void GetClipTimes()
    {
        AnimationClip[] Clips = Lucario.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in Clips)
            if (!cliptime.ContainsKey(clip.name))
                cliptime.Add(clip.name, clip.length);
    }
    public void Attack(string attack)
    {
        AttackAnimation(attack);
    }
    private IEnumerator AttackAnimation(string attack)
    {
        //set anim to true
        Lucario.SetBool("Attacking", true);
        yield return new WaitForSeconds(cliptime[attack]);
        Lucario.SetBool("Attacking", false);
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
