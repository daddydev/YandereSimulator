using UnityEngine;

// Token: 0x0200004B RID: 75
public class BrokenScript : MonoBehaviour {

  // Token: 0x0600010A RID: 266 RVA: 0x00011F6C File Offset: 0x0001036C
  private void Start() {
    this.HairPhysics[0].enabled = false;
    this.HairPhysics[1].enabled = false;
    this.PermanentAngleR = this.TwintailR.eulerAngles;
    this.PermanentAngleL = this.TwintailL.eulerAngles;
    this.Subtitle = GameObject.Find("EventSubtitle").GetComponent<UILabel>();
    this.Yandere = GameObject.Find("YandereChan");
  }

  // Token: 0x0600010B RID: 267 RVA: 0x00011FDC File Offset: 0x000103DC
  private void Update() {
    if (!this.Done) {
      float num = Vector3.Distance(this.Yandere.transform.position, base.transform.root.position);
      if (num < 5f) {
        if (!this.Hunting) {
          this.Timer += Time.deltaTime;
          if (this.VoiceClip == null) {
            this.Subtitle.text = string.Empty;
          }
          if (this.Timer > 5f) {
            this.Timer = 0f;
            this.Subtitle.text = this.MutterTexts[this.ID];
            AudioClipPlayer.PlayAttached(this.Mutters[this.ID], base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.ID++;
            if (this.ID == this.Mutters.Length) {
              this.ID = 1;
            }
          }
        } else if (!this.Began) {
          if (this.VoiceClip != null) {
            UnityEngine.Object.Destroy(this.VoiceClip);
          }
          this.Subtitle.text = "Do it.";
          AudioClipPlayer.PlayAttached(this.DoIt, base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
          this.Began = true;
        } else if (this.VoiceClip == null) {
          this.Subtitle.text = "...kill...kill...kill...";
          AudioClipPlayer.PlayAttached(this.KillKillKill, base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
        }
        float num2 = Mathf.Abs((num - 5f) * 0.2f);
        num2 = ((num2 <= 1f) ? num2 : 1f);
        this.Subtitle.transform.localScale = new Vector3(num2, num2, num2);
      } else {
        this.Subtitle.transform.localScale = Vector3.zero;
      }
    }
    Vector3 eulerAngles = this.TwintailR.eulerAngles;
    Vector3 eulerAngles2 = this.TwintailL.eulerAngles;
    eulerAngles.x = this.PermanentAngleR.x;
    eulerAngles.z = this.PermanentAngleR.z;
    eulerAngles2.x = this.PermanentAngleL.x;
    eulerAngles2.z = this.PermanentAngleL.z;
    this.TwintailR.eulerAngles = eulerAngles;
    this.TwintailL.eulerAngles = eulerAngles2;
  }

  // Token: 0x04000387 RID: 903
  public DynamicBone[] HairPhysics;

  // Token: 0x04000388 RID: 904
  public string[] MutterTexts;

  // Token: 0x04000389 RID: 905
  public AudioClip[] Mutters;

  // Token: 0x0400038A RID: 906
  public Vector3 PermanentAngleR;

  // Token: 0x0400038B RID: 907
  public Vector3 PermanentAngleL;

  // Token: 0x0400038C RID: 908
  public Transform TwintailR;

  // Token: 0x0400038D RID: 909
  public Transform TwintailL;

  // Token: 0x0400038E RID: 910
  public AudioClip KillKillKill;

  // Token: 0x0400038F RID: 911
  public AudioClip Stab;

  // Token: 0x04000390 RID: 912
  public AudioClip DoIt;

  // Token: 0x04000391 RID: 913
  public GameObject VoiceClip;

  // Token: 0x04000392 RID: 914
  public GameObject Yandere;

  // Token: 0x04000393 RID: 915
  public UILabel Subtitle;

  // Token: 0x04000394 RID: 916
  public bool Hunting;

  // Token: 0x04000395 RID: 917
  public bool Stabbed;

  // Token: 0x04000396 RID: 918
  public bool Began;

  // Token: 0x04000397 RID: 919
  public bool Done;

  // Token: 0x04000398 RID: 920
  public float SuicideTimer;

  // Token: 0x04000399 RID: 921
  public float Timer;

  // Token: 0x0400039A RID: 922
  public int ID = 1;
}