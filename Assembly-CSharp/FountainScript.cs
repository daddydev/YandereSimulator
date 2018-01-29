using UnityEngine;

// Token: 0x020000C2 RID: 194
public class FountainScript : MonoBehaviour {

  // Token: 0x060002E6 RID: 742 RVA: 0x000375B3 File Offset: 0x000359B3
  private void Start() {
    this.SpraySFX.volume = 0.1f;
    this.DropsSFX.volume = 0.1f;
  }

  // Token: 0x060002E7 RID: 743 RVA: 0x000375D8 File Offset: 0x000359D8
  private void Update() {
    if (this.StartTimer < 1f) {
      this.StartTimer += Time.deltaTime;
      if (this.StartTimer > 1f) {
        this.SpraySFX.gameObject.SetActive(true);
        this.DropsSFX.gameObject.SetActive(true);
      }
    }
    if (this.Drowning) {
      if (this.Timer == 0f && this.EventSubtitle.transform.localScale.x < 1f) {
        this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
        this.EventSubtitle.text = "Hey, what are you -";
        base.GetComponent<AudioSource>().Play();
      }
      this.Timer += Time.deltaTime;
      if (this.Timer > 3f && this.EventSubtitle.transform.localScale.x > 0f) {
        this.EventSubtitle.transform.localScale = Vector3.zero;
        this.EventSubtitle.text = string.Empty;
        this.Splashes.Play();
      }
      if (this.Timer > 9f) {
        this.Drowning = false;
        this.Splashes.Stop();
        this.Timer = 0f;
      }
    }
  }

  // Token: 0x0400093F RID: 2367
  public ParticleSystem Splashes;

  // Token: 0x04000940 RID: 2368
  public UILabel EventSubtitle;

  // Token: 0x04000941 RID: 2369
  public Collider[] Colliders;

  // Token: 0x04000942 RID: 2370
  public bool Drowning;

  // Token: 0x04000943 RID: 2371
  public AudioSource SpraySFX;

  // Token: 0x04000944 RID: 2372
  public AudioSource DropsSFX;

  // Token: 0x04000945 RID: 2373
  public float StartTimer;

  // Token: 0x04000946 RID: 2374
  public float Timer;
}