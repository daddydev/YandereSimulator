using UnityEngine;

// Token: 0x020000CB RID: 203
public class GentlemanScript : MonoBehaviour {

  // Token: 0x06000305 RID: 773 RVA: 0x00039A58 File Offset: 0x00037E58
  private void Update() {
    if (Input.GetButtonDown("RB")) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (!component.isPlaying) {
        component.clip = this.Clips[UnityEngine.Random.Range(0, this.Clips.Length - 1)];
        component.Play();
        this.Yandere.Sanity += 10f;
      }
    }
  }

  // Token: 0x040009A0 RID: 2464
  public YandereScript Yandere;

  // Token: 0x040009A1 RID: 2465
  public AudioClip[] Clips;
}