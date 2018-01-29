using UnityEngine;

// Token: 0x0200003A RID: 58
public class AudioSoftwareScript : MonoBehaviour {

  // Token: 0x060000D8 RID: 216 RVA: 0x0000FFBB File Offset: 0x0000E3BB
  private void Start() {
    this.Screen.SetActive(false);
  }

  // Token: 0x060000D9 RID: 217 RVA: 0x0000FFCC File Offset: 0x0000E3CC
  private void Update() {
    if (this.ConversationRecorded && this.Yandere.Inventory.RivalPhone) {
      if (!this.Prompt.enabled) {
        this.Prompt.enabled = true;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.enabled = false;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_01");
      this.Yandere.MyController.radius = 0.1f;
      this.Yandere.CanMove = false;
      base.GetComponent<AudioSource>().Play();
      this.ChairCollider.enabled = false;
      this.Screen.SetActive(true);
      this.Editing = true;
    }
    if (this.Editing) {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Screen.transform.position.x, this.Yandere.transform.position.y, this.Screen.transform.position.z) - this.Yandere.transform.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(this.SitSpot.position);
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        this.EventSubtitle.text = "Okay, how 'bout that boy from class 3-2? What do you think of him?";
      }
      if (this.Timer > 7f) {
        this.EventSubtitle.text = "He's just my childhood friend.";
      }
      if (this.Timer > 9f) {
        this.EventSubtitle.text = "Is he your boyfriend?";
      }
      if (this.Timer > 11f) {
        this.EventSubtitle.text = "What? HIM? Ugh, no way! That guy's a total creep! I wouldn't date him if he was the last man alive on earth! He can go jump off a cliff for all I care!";
      }
      if (this.Timer > 22f) {
        this.Yandere.MyController.radius = 0.2f;
        this.Yandere.CanMove = true;
        this.ChairCollider.enabled = false;
        this.EventSubtitle.text = string.Empty;
        this.Screen.SetActive(false);
        this.AudioDoctored = true;
        this.Editing = false;
        this.Prompt.enabled = false;
        this.Prompt.Hide();
        base.enabled = false;
      }
    }
  }

  // Token: 0x04000309 RID: 777
  public YandereScript Yandere;

  // Token: 0x0400030A RID: 778
  public PromptScript Prompt;

  // Token: 0x0400030B RID: 779
  public Quaternion targetRotation;

  // Token: 0x0400030C RID: 780
  public Collider ChairCollider;

  // Token: 0x0400030D RID: 781
  public UILabel EventSubtitle;

  // Token: 0x0400030E RID: 782
  public GameObject Screen;

  // Token: 0x0400030F RID: 783
  public Transform SitSpot;

  // Token: 0x04000310 RID: 784
  public bool ConversationRecorded;

  // Token: 0x04000311 RID: 785
  public bool AudioDoctored;

  // Token: 0x04000312 RID: 786
  public bool Editing;

  // Token: 0x04000313 RID: 787
  public float Timer;
}