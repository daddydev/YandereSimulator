using UnityEngine;

// Token: 0x0200005E RID: 94
public class ChangingBoothScript : MonoBehaviour {

  // Token: 0x06000152 RID: 338 RVA: 0x00015EC2 File Offset: 0x000142C2
  private void Start() {
    this.CheckYandereClub();
  }

  // Token: 0x06000153 RID: 339 RVA: 0x00015ECC File Offset: 0x000142CC
  private void Update() {
    if (!this.Occupied && this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.EmptyHands();
      this.Yandere.CanMove = false;
      this.YandereChanging = true;
      this.Occupied = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Occupied) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.OccupyTimer == 0f) {
        if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f) {
          component.clip = this.CurtainSound;
          component.Play();
        }
      } else if (this.OccupyTimer > 1f && this.Phase == 0) {
        if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f) {
          component.clip = this.ClothSound;
          component.Play();
        }
        this.Phase++;
      }
      this.OccupyTimer += Time.deltaTime;
      if (this.YandereChanging) {
        if (this.OccupyTimer < 2f) {
          this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
          this.Curtains.SetBlendShapeWeight(0, this.Weight);
          this.Yandere.MoveTowardsTarget(base.transform.position);
        } else if (this.OccupyTimer < 3f) {
          this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
          this.Curtains.SetBlendShapeWeight(0, this.Weight);
          if (this.Phase < 2) {
            component.clip = this.CurtainSound;
            component.Play();
            if (!this.Yandere.ClubAttire) {
              this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
            }
            this.Yandere.ChangeClubwear();
            this.Phase++;
          }
          this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, base.transform.rotation, 10f * Time.deltaTime);
          this.Yandere.MoveTowardsTarget(this.ExitSpot.position);
        } else {
          this.YandereChanging = false;
          this.Yandere.CanMove = true;
          this.Prompt.enabled = true;
          this.Occupied = false;
          this.OccupyTimer = 0f;
          this.Phase = 0;
        }
      } else if (this.OccupyTimer < 2f) {
        this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
        this.Curtains.SetBlendShapeWeight(0, this.Weight);
      } else if (this.OccupyTimer < 3f) {
        this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
        this.Curtains.SetBlendShapeWeight(0, this.Weight);
        if (this.Phase < 2) {
          if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f) {
            component.clip = this.CurtainSound;
            component.Play();
          }
          this.Student.ChangeClubwear();
          this.Phase++;
        }
      } else {
        this.Occupied = false;
        this.OccupyTimer = 0f;
        this.Student = null;
        this.Phase = 0;
        this.CheckYandereClub();
      }
    }
  }

  // Token: 0x06000154 RID: 340 RVA: 0x00016398 File Offset: 0x00014798
  public void CheckYandereClub() {
    if (this.Yandere.Bloodiness == 0f && !this.CannotChange && this.Yandere.Schoolwear > 0) {
      if (!this.Occupied) {
        if (ClubGlobals.Club != this.ClubID) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        } else {
          this.Prompt.enabled = true;
        }
      } else {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }

  // Token: 0x04000413 RID: 1043
  public YandereScript Yandere;

  // Token: 0x04000414 RID: 1044
  public StudentScript Student;

  // Token: 0x04000415 RID: 1045
  public PromptScript Prompt;

  // Token: 0x04000416 RID: 1046
  public SkinnedMeshRenderer Curtains;

  // Token: 0x04000417 RID: 1047
  public Transform ExitSpot;

  // Token: 0x04000418 RID: 1048
  public Transform[] WaitSpots;

  // Token: 0x04000419 RID: 1049
  public bool YandereChanging;

  // Token: 0x0400041A RID: 1050
  public bool CannotChange;

  // Token: 0x0400041B RID: 1051
  public bool Occupied;

  // Token: 0x0400041C RID: 1052
  public AudioClip CurtainSound;

  // Token: 0x0400041D RID: 1053
  public AudioClip ClothSound;

  // Token: 0x0400041E RID: 1054
  public float OccupyTimer;

  // Token: 0x0400041F RID: 1055
  public float Weight;

  // Token: 0x04000420 RID: 1056
  public ClubType ClubID;

  // Token: 0x04000421 RID: 1057
  public int Phase;
}