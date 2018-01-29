using UnityEngine;

// Token: 0x0200021B RID: 539
public class WoodChipperScript : MonoBehaviour {

  // Token: 0x06000962 RID: 2402 RVA: 0x000A3F48 File Offset: 0x000A2348
  private void Update() {
    if (this.Yandere.PickUp != null) {
      if (this.Yandere.PickUp.Bucket != null) {
        if (!this.Yandere.PickUp.Bucket.Full) {
          this.BucketPrompt.HideButton[0] = false;
          if (this.BucketPrompt.Circle[0].fillAmount == 0f) {
            this.Bucket = this.Yandere.PickUp;
            this.Yandere.EmptyHands();
            this.Bucket.transform.eulerAngles = this.BucketPoint.eulerAngles;
            this.Bucket.transform.position = this.BucketPoint.position;
            this.Bucket.GetComponent<Rigidbody>().useGravity = false;
            this.Bucket.MyCollider.enabled = false;
          }
        } else {
          this.BucketPrompt.HideButton[0] = true;
        }
      } else {
        this.BucketPrompt.HideButton[0] = true;
      }
    } else {
      this.BucketPrompt.HideButton[0] = true;
    }
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.Open) {
      this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, Time.deltaTime * 360f);
      if (this.Rotation > -36f) {
        if (this.Rotation < 0f) {
          component.clip = this.CloseAudio;
          component.Play();
        }
        this.Rotation = 0f;
      }
      this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
    } else {
      if (this.Lid.transform.localEulerAngles.x == 0f) {
        component.clip = this.OpenAudio;
        component.Play();
      }
      this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 360f);
      this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
    }
    if (!this.BloodSpray.isPlaying) {
      if (!this.Occupied) {
        if (this.Yandere.Ragdoll == null) {
          this.Prompt.HideButton[3] = true;
        } else {
          this.Prompt.HideButton[3] = false;
        }
      } else if (this.Bucket == null) {
        this.Prompt.HideButton[0] = true;
      } else if (this.Bucket.Bucket.Full) {
        this.Prompt.HideButton[0] = true;
      } else {
        this.Prompt.HideButton[0] = false;
      }
    }
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      Time.timeScale = 1f;
      if (this.Yandere.Ragdoll != null) {
        if (!this.Yandere.Carrying) {
          this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_dragIdle_00");
        } else {
          this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_carryIdleA_00");
        }
        this.Yandere.YandereVision = false;
        this.Yandere.Chipping = true;
        this.Yandere.CanMove = false;
        this.Victims++;
        this.VictimList[this.Victims] = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
        this.Open = true;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      component.clip = this.ShredAudio;
      component.Play();
      this.Prompt.HideButton[3] = false;
      this.Prompt.HideButton[0] = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Yandere.Police.Corpses--;
      if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1) {
        this.Yandere.Police.MurderScene = false;
      }
      if (this.Yandere.Police.Corpses == 0) {
        this.Yandere.Police.MurderScene = false;
      }
      this.Shredding = true;
    }
    if (this.Shredding) {
      if (this.Bucket != null) {
        this.Bucket.Bucket.UpdateAppearance = true;
      }
      this.Timer += Time.deltaTime;
      if (this.Timer >= 10f) {
        this.Prompt.enabled = true;
        this.Shredding = false;
        this.Occupied = false;
        this.Timer = 0f;
      } else if (this.Timer >= 9f) {
        if (this.Bucket != null) {
          this.Bucket.MyCollider.enabled = true;
          this.Bucket.Bucket.FillSpeed = 1f;
          this.Bucket = null;
          this.BloodSpray.Stop();
        }
      } else if (this.Timer >= 0.33333f && !this.Bucket.Bucket.Full) {
        this.BloodSpray.GetComponent<AudioSource>().Play();
        this.BloodSpray.Play();
        this.Bucket.Bucket.Bloodiness = 100f;
        this.Bucket.Bucket.FillSpeed = 0.05f;
        this.Bucket.Bucket.Full = true;
      }
    }
  }

  // Token: 0x06000963 RID: 2403 RVA: 0x000A45A0 File Offset: 0x000A29A0
  public void SetVictimsMissing() {
    foreach (int studentID in this.VictimList) {
      StudentGlobals.SetStudentMissing(studentID, true);
    }
  }

  // Token: 0x04001ADC RID: 6876
  public ParticleSystem BloodSpray;

  // Token: 0x04001ADD RID: 6877
  public PromptScript BucketPrompt;

  // Token: 0x04001ADE RID: 6878
  public YandereScript Yandere;

  // Token: 0x04001ADF RID: 6879
  public PickUpScript Bucket;

  // Token: 0x04001AE0 RID: 6880
  public PromptScript Prompt;

  // Token: 0x04001AE1 RID: 6881
  public AudioClip CloseAudio;

  // Token: 0x04001AE2 RID: 6882
  public AudioClip ShredAudio;

  // Token: 0x04001AE3 RID: 6883
  public AudioClip OpenAudio;

  // Token: 0x04001AE4 RID: 6884
  public Transform BucketPoint;

  // Token: 0x04001AE5 RID: 6885
  public Transform DumpPoint;

  // Token: 0x04001AE6 RID: 6886
  public Transform Lid;

  // Token: 0x04001AE7 RID: 6887
  public float Rotation;

  // Token: 0x04001AE8 RID: 6888
  public float Timer;

  // Token: 0x04001AE9 RID: 6889
  public bool Shredding;

  // Token: 0x04001AEA RID: 6890
  public bool Occupied;

  // Token: 0x04001AEB RID: 6891
  public bool Open;

  // Token: 0x04001AEC RID: 6892
  public int VictimID;

  // Token: 0x04001AED RID: 6893
  public int Victims;

  // Token: 0x04001AEE RID: 6894
  public int ID;

  // Token: 0x04001AEF RID: 6895
  public int[] VictimList;
}