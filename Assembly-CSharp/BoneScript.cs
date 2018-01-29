using UnityEngine;

// Token: 0x02000048 RID: 72
public class BoneScript : MonoBehaviour {

  // Token: 0x06000101 RID: 257 RVA: 0x00011A7C File Offset: 0x0000FE7C
  private void Start() {
    base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, UnityEngine.Random.Range(0f, 360f), base.transform.eulerAngles.z);
    this.Origin = base.transform.position.y;
    base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.9f, 1.1f);
  }

  // Token: 0x06000102 RID: 258 RVA: 0x00011B04 File Offset: 0x0000FF04
  private void Update() {
    if (!this.Drop) {
      if (base.transform.position.y < this.Origin + 2f - 0.0001f) {
        base.transform.position = new Vector3(base.transform.position.x, Mathf.Lerp(base.transform.position.y, this.Origin + 2f, Time.deltaTime * 10f), base.transform.position.z);
      } else {
        this.Drop = true;
      }
    } else {
      this.Height -= Time.deltaTime;
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + this.Height, base.transform.position.z);
      if (base.transform.position.y < this.Origin - 2.155f) {
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
  }

  // Token: 0x06000103 RID: 259 RVA: 0x00011C54 File Offset: 0x00010054
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (component != null) {
        component.DeathType = DeathType.EasterEgg;
        component.BecomeRagdoll();
        Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
        rigidbody.isKinematic = false;
        rigidbody.AddForce(base.transform.up);
      }
    }
  }

  // Token: 0x0400035E RID: 862
  public float Height;

  // Token: 0x0400035F RID: 863
  public float Origin;

  // Token: 0x04000360 RID: 864
  public bool Drop;
}