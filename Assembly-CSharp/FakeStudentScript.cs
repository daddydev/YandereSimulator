using UnityEngine;

// Token: 0x020000B9 RID: 185
public class FakeStudentScript : MonoBehaviour {

  // Token: 0x060002CD RID: 717 RVA: 0x00035BF5 File Offset: 0x00033FF5
  private void Start() {
    this.targetRotation = base.transform.rotation;
    this.Student.Club = this.Club;
  }

  // Token: 0x060002CE RID: 718 RVA: 0x00035C1C File Offset: 0x0003401C
  private void Update() {
    if (!this.Student.Talking && this.Rotate) {
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      this.RotationTimer += Time.deltaTime;
      if (this.RotationTimer > 1f) {
        this.RotationTimer = 0f;
        this.Rotate = false;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f && !this.Yandere.Chased) {
      this.Yandere.TargetStudent = this.Student;
      this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)this.Student.Club, 4f);
      this.DialogueWheel.ClubLeader = true;
      this.StudentManager.DisablePrompts();
      this.DialogueWheel.HideShadows();
      this.DialogueWheel.Show = true;
      this.DialogueWheel.Panel.enabled = true;
      this.Student.Talking = true;
      this.Student.TalkTimer = 0f;
      this.Yandere.ShoulderCamera.OverShoulder = true;
      this.Yandere.WeaponMenu.KeyboardShow = false;
      this.Yandere.Obscurance.enabled = false;
      this.Yandere.WeaponMenu.Show = false;
      this.Yandere.YandereVision = false;
      this.Yandere.CanMove = false;
      this.Yandere.Talking = true;
      this.Rotate = true;
    }
  }

  // Token: 0x040008E7 RID: 2279
  public StudentManagerScript StudentManager;

  // Token: 0x040008E8 RID: 2280
  public DialogueWheelScript DialogueWheel;

  // Token: 0x040008E9 RID: 2281
  public SubtitleScript Subtitle;

  // Token: 0x040008EA RID: 2282
  public YandereScript Yandere;

  // Token: 0x040008EB RID: 2283
  public StudentScript Student;

  // Token: 0x040008EC RID: 2284
  public PromptScript Prompt;

  // Token: 0x040008ED RID: 2285
  public Quaternion targetRotation;

  // Token: 0x040008EE RID: 2286
  public float RotationTimer;

  // Token: 0x040008EF RID: 2287
  public bool Rotate;

  // Token: 0x040008F0 RID: 2288
  public ClubType Club;
}