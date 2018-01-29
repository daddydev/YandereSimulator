using UnityEngine;

// Token: 0x02000044 RID: 68
public class BloodyScreamScript : MonoBehaviour {

  // Token: 0x060000FB RID: 251 RVA: 0x00011974 File Offset: 0x0000FD74
  private void Start() {
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.Screams[UnityEngine.Random.Range(0, this.Screams.Length)];
    component.Play();
  }

  // Token: 0x0400034D RID: 845
  public AudioClip[] Screams;
}