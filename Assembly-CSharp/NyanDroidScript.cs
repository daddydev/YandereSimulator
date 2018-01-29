using UnityEngine;

// Token: 0x02000144 RID: 324
public class NyanDroidScript : MonoBehaviour {

  // Token: 0x06000608 RID: 1544 RVA: 0x00055100 File Offset: 0x00053500
  private void Start() {
    this.OriginalPosition = base.transform.position;
  }

  // Token: 0x06000609 RID: 1545 RVA: 0x00055114 File Offset: 0x00053514
  private void Update() {
    if (!this.Pathfinding.canSearch) {
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Label[0].text = "     Stop";
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
      }
    } else {
      if (base.transform.position.y < 0f) {
        base.transform.position = new Vector3(base.transform.position.x, 0.001f, base.transform.position.z);
      }
      if (Input.GetButtonDown("RB")) {
        base.transform.position = this.OriginalPosition;
      }
      if (Vector3.Distance(base.transform.position, this.Pathfinding.target.position) <= 1f) {
        this.Character.CrossFade("ND_Idle");
        this.Pathfinding.speed = 0f;
      } else if (Vector3.Distance(base.transform.position, this.Pathfinding.target.position) <= 2f) {
        this.Character.CrossFade("ND_Walk");
        this.Pathfinding.speed = 0.5f;
      } else {
        this.Character.CrossFade("ND_Run");
        this.Pathfinding.speed = 5f;
      }
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Label[0].text = "     Follow";
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Character.CrossFade("ND_Idle");
        this.Pathfinding.canSearch = false;
        this.Pathfinding.canMove = false;
      }
    }
  }

  // Token: 0x04000E7A RID: 3706
  public Animation Character;

  // Token: 0x04000E7B RID: 3707
  public PromptScript Prompt;

  // Token: 0x04000E7C RID: 3708
  public AIPath Pathfinding;

  // Token: 0x04000E7D RID: 3709
  public Vector3 OriginalPosition;
}