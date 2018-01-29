using UnityEngine;

// Token: 0x02000173 RID: 371
public class RandomSoundScript : MonoBehaviour {

  // Token: 0x060006E1 RID: 1761 RVA: 0x00069BCC File Offset: 0x00067FCC
  private void Start() {
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.Clips[UnityEngine.Random.Range(1, this.Clips.Length)];
    component.Play();
  }

  // Token: 0x04001145 RID: 4421
  public AudioClip[] Clips;
}