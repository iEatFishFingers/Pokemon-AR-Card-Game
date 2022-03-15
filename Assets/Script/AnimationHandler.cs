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


    private void run()
    {
        StartCoroutine(RunAnimation()); //await async 

    }
    void GetClipTimes()
    {
        AnimationClip[] Clips = Lucario.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in Clips)
            if (!cliptime.ContainsKey(clip.name))
                cliptime.Add(clip.name, clip.length);
    }

    public IEnumerator AttackAnimation(string attack)
    {
        //set anim to true
        Lucario.SetBool(attack, true);
        yield return new WaitForSeconds(cliptime["RUNNING"]);
        Lucario.SetBool(attack, false);
    }

    private IEnumerator RunAnimation()
    {
        //set anim to true
        Lucario.SetBool("Running", true);
        yield return new WaitForSeconds(cliptime["RUNNING"]);
        Lucario.SetBool("Running", false);

    }


}
