using UnityEngine;

// Token: 0x02000040 RID: 64
public class BloodCleanerScript : MonoBehaviour {

  // Token: 0x060000E8 RID: 232 RVA: 0x00010DE0 File Offset: 0x0000F1E0
  private void Start() {
    Physics.IgnoreLayerCollision(11, 15, true);
  }

  // Token: 0x060000E9 RID: 233 RVA: 0x00010DEC File Offset: 0x0000F1EC
  private void Update() {
    if (this.Blood < 100f && this.BloodParent.childCount > 0) {
      this.Pathfinding.target = this.BloodParent.GetChild(0);
      this.Pathfinding.speed = 1f;
      if (this.Pathfinding.target.position.y < 4f) {
        this.Label.text = "1";
      } else if (this.Pathfinding.target.position.y < 8f) {
        this.Label.text = "2";
      } else if (this.Pathfinding.target.position.y < 12f) {
        this.Label.text = "3";
      } else {
        this.Label.text = "R";
      }
      if (this.Pathfinding.target != null) {
        this.Distance = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
        if (this.Distance < 0.45f) {
          this.Pathfinding.speed = 0f;
          Transform child = this.BloodParent.GetChild(0);
          if (child.GetComponent("BloodPoolScript") != null) {
            child.localScale = new Vector3(child.localScale.x - Time.deltaTime, child.localScale.y - Time.deltaTime, child.localScale.z);
            this.Blood += Time.deltaTime;
            if (this.Blood >= 100f) {
              this.Lens.SetActive(true);
            }
            if (child.transform.localScale.x < 0.1f) {
              UnityEngine.Object.Destroy(child.gameObject);
            }
          } else {
            UnityEngine.Object.Destroy(child.gameObject);
          }
        } else {
          this.Pathfinding.speed = 1f;
        }
      }
    }
  }

  // Token: 0x04000332 RID: 818
  public Transform BloodParent;

  // Token: 0x04000333 RID: 819
  public PromptScript Prompt;

  // Token: 0x04000334 RID: 820
  public AIPath Pathfinding;

  // Token: 0x04000335 RID: 821
  public GameObject Lens;

  // Token: 0x04000336 RID: 822
  public UILabel Label;

  // Token: 0x04000337 RID: 823
  public float Distance;

  // Token: 0x04000338 RID: 824
  public float Blood;
}