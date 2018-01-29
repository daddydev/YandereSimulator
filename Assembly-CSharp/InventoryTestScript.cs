using UnityEngine;

// Token: 0x02000115 RID: 277
public class InventoryTestScript : MonoBehaviour {

  // Token: 0x06000548 RID: 1352 RVA: 0x0004A49B File Offset: 0x0004889B
  private void Start() {
    this.RightGrid.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    this.LeftGrid.localScale = new Vector3(0.7f, 0.7f, 0.7f);
  }

  // Token: 0x06000549 RID: 1353 RVA: 0x0004A4DC File Offset: 0x000488DC
  private void Update() {
    if (Input.GetButtonDown("A")) {
      this.Open = !this.Open;
    }
    AnimationState animationState = this.Character.GetComponent<Animation>()["f02_inventory_00"];
    AnimationState animationState2 = this.InverseSkirt.GetComponent<Animation>()["InverseSkirtOpen"];
    if (this.Open) {
      this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
      this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 0.5f, Time.deltaTime * 2.5f));
      animationState.speed = 1f;
      animationState2.speed = 1f;
    } else {
      this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
      this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 1f, Time.deltaTime * 2.5f));
      animationState.speed = -1f;
      animationState2.speed = -1f;
    }
    if (animationState.time > animationState.length) {
      animationState.time = animationState.length;
    }
    if (animationState.time < 0f) {
      animationState.time = 0f;
    }
    if (animationState2.time > animationState2.length) {
      animationState2.time = animationState2.length;
    }
    if (animationState2.time < 0f) {
      animationState2.time = 0f;
    }
  }

  // Token: 0x04000CD4 RID: 3284
  public GameObject Character;

  // Token: 0x04000CD5 RID: 3285
  public GameObject InverseSkirt;

  // Token: 0x04000CD6 RID: 3286
  public Transform RightGrid;

  // Token: 0x04000CD7 RID: 3287
  public Transform LeftGrid;

  // Token: 0x04000CD8 RID: 3288
  public bool Open = true;
}