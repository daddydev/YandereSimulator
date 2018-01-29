using UnityEngine;

// Token: 0x02000174 RID: 372
public class RandomStabScript : MonoBehaviour {

  // Token: 0x060006E3 RID: 1763 RVA: 0x00069C0C File Offset: 0x0006800C
  private void Start() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.Biting) {
      component.clip = this.Stabs[UnityEngine.Random.Range(0, this.Stabs.Length)];
      component.Play();
    } else {
      component.clip = this.Bite;
      component.pitch = UnityEngine.Random.Range(0.5f, 1f);
      component.Play();
    }
  }

  // Token: 0x04001146 RID: 4422
  public AudioClip[] Stabs;

  // Token: 0x04001147 RID: 4423
  public AudioClip Bite;

  // Token: 0x04001148 RID: 4424
  public bool Biting;
}