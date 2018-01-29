using UnityEngine;

// Token: 0x02000123 RID: 291
public class LightSwitchScript : MonoBehaviour {

  // Token: 0x0600059A RID: 1434 RVA: 0x0004CC41 File Offset: 0x0004B041
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
  }

  // Token: 0x0600059B RID: 1435 RVA: 0x0004CC58 File Offset: 0x0004B058
  private void Update() {
    if (this.Flicker) {
      this.FlickerTimer += Time.deltaTime;
      if (this.FlickerTimer > 0.1f) {
        this.FlickerTimer = 0f;
        this.BathroomLight.SetActive(!this.BathroomLight.activeInHierarchy);
      }
    }
    if (!this.Panel.useGravity) {
      if (this.Yandere.Armed) {
        this.Prompt.HideButton[3] = (this.Yandere.EquippedWeapon.WeaponID != 6);
      } else {
        this.Prompt.HideButton[3] = true;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.BathroomLight.activeInHierarchy) {
        this.Prompt.Label[0].text = "     Turn On";
        this.BathroomLight.SetActive(false);
        component.clip = this.Flick[1];
        component.Play();
        if (this.ToiletEvent.EventActive && (this.ToiletEvent.EventPhase == 2 || this.ToiletEvent.EventPhase == 3)) {
          this.ReactionID = UnityEngine.Random.Range(1, 4);
          AudioClipPlayer.Play(this.ReactionClips[this.ReactionID], this.ToiletEvent.EventStudent.transform.position, 5f, 10f, out this.ToiletEvent.VoiceClip);
          this.ToiletEvent.EventSubtitle.text = this.ReactionTexts[this.ReactionID];
          this.SubtitleTimer += Time.deltaTime;
        }
      } else {
        this.Prompt.Label[0].text = "     Turn Off";
        this.BathroomLight.SetActive(true);
        component.clip = this.Flick[0];
        component.Play();
      }
    }
    if (this.SubtitleTimer > 0f) {
      this.SubtitleTimer += Time.deltaTime;
      if (this.SubtitleTimer > 3f) {
        this.ToiletEvent.EventSubtitle.text = string.Empty;
        this.SubtitleTimer = 0f;
      }
    }
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      this.Prompt.HideButton[3] = true;
      this.Wires.localScale = new Vector3(this.Wires.localScale.x, this.Wires.localScale.y, 1f);
      this.Panel.useGravity = true;
      this.Panel.AddForce(0f, 0f, 10f);
    }
  }

  // Token: 0x04000D4E RID: 3406
  public ToiletEventScript ToiletEvent;

  // Token: 0x04000D4F RID: 3407
  public YandereScript Yandere;

  // Token: 0x04000D50 RID: 3408
  public PromptScript Prompt;

  // Token: 0x04000D51 RID: 3409
  public Transform ElectrocutionSpot;

  // Token: 0x04000D52 RID: 3410
  public GameObject BathroomLight;

  // Token: 0x04000D53 RID: 3411
  public GameObject Electricity;

  // Token: 0x04000D54 RID: 3412
  public Rigidbody Panel;

  // Token: 0x04000D55 RID: 3413
  public Transform Wires;

  // Token: 0x04000D56 RID: 3414
  public AudioClip[] ReactionClips;

  // Token: 0x04000D57 RID: 3415
  public string[] ReactionTexts;

  // Token: 0x04000D58 RID: 3416
  public AudioClip[] Flick;

  // Token: 0x04000D59 RID: 3417
  public float SubtitleTimer;

  // Token: 0x04000D5A RID: 3418
  public float FlickerTimer;

  // Token: 0x04000D5B RID: 3419
  public int ReactionID;

  // Token: 0x04000D5C RID: 3420
  public bool Flicker;
}