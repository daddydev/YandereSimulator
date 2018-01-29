using UnityEngine;

// Token: 0x02000116 RID: 278
public class JiggleBone : MonoBehaviour {

  // Token: 0x0600054B RID: 1355 RVA: 0x0004A834 File Offset: 0x00048C34
  private void Awake() {
    Vector3 vector = base.transform.position + base.transform.TransformDirection(this.boneAxis * this.targetDistance);
    this.dynamicPos = vector;
  }

  // Token: 0x0600054C RID: 1356 RVA: 0x0004A878 File Offset: 0x00048C78
  private void LateUpdate() {
    base.transform.rotation = default(Quaternion);
    Vector3 dir = base.transform.TransformDirection(this.boneAxis * this.targetDistance);
    Vector3 vector = base.transform.TransformDirection(new Vector3(0f, 1f, 0f));
    Vector3 vector2 = base.transform.position + base.transform.TransformDirection(this.boneAxis * this.targetDistance);
    this.force.x = (vector2.x - this.dynamicPos.x) * this.bStiffness;
    this.acc.x = this.force.x / this.bMass;
    this.vel.x = this.vel.x + this.acc.x * (1f - this.bDamping);
    this.force.y = (vector2.y - this.dynamicPos.y) * this.bStiffness;
    this.force.y = this.force.y - this.bGravity / 10f;
    this.acc.y = this.force.y / this.bMass;
    this.vel.y = this.vel.y + this.acc.y * (1f - this.bDamping);
    this.force.z = (vector2.z - this.dynamicPos.z) * this.bStiffness;
    this.acc.z = this.force.z / this.bMass;
    this.vel.z = this.vel.z + this.acc.z * (1f - this.bDamping);
    this.dynamicPos += this.vel + this.force;
    base.transform.LookAt(this.dynamicPos, vector);
    if (this.SquashAndStretch) {
      float magnitude = (this.dynamicPos - vector2).magnitude;
      float x = 1f + ((this.boneAxis.x != 0f) ? (magnitude * this.frontStretch) : (-magnitude * this.sideStretch));
      float y = 1f + ((this.boneAxis.y != 0f) ? (magnitude * this.frontStretch) : (-magnitude * this.sideStretch));
      float z = 1f + ((this.boneAxis.z != 0f) ? (magnitude * this.frontStretch) : (-magnitude * this.sideStretch));
      base.transform.localScale = new Vector3(x, y, z);
    }
    if (this.debugMode) {
      Debug.DrawRay(base.transform.position, dir, Color.blue);
      Debug.DrawRay(base.transform.position, vector, Color.green);
      Debug.DrawRay(vector2, Vector3.up * 0.2f, Color.yellow);
      Debug.DrawRay(this.dynamicPos, Vector3.up * 0.2f, Color.red);
    }
  }

  // Token: 0x04000CD9 RID: 3289
  public bool debugMode = true;

  // Token: 0x04000CDA RID: 3290
  private Vector3 dynamicPos = default(Vector3);

  // Token: 0x04000CDB RID: 3291
  public Vector3 boneAxis = new Vector3(0f, 0f, 1f);

  // Token: 0x04000CDC RID: 3292
  public float targetDistance = 2f;

  // Token: 0x04000CDD RID: 3293
  public float bStiffness = 0.1f;

  // Token: 0x04000CDE RID: 3294
  public float bMass = 0.9f;

  // Token: 0x04000CDF RID: 3295
  public float bDamping = 0.75f;

  // Token: 0x04000CE0 RID: 3296
  public float bGravity = 0.75f;

  // Token: 0x04000CE1 RID: 3297
  private Vector3 force = default(Vector3);

  // Token: 0x04000CE2 RID: 3298
  private Vector3 acc = default(Vector3);

  // Token: 0x04000CE3 RID: 3299
  private Vector3 vel = default(Vector3);

  // Token: 0x04000CE4 RID: 3300
  public bool SquashAndStretch = true;

  // Token: 0x04000CE5 RID: 3301
  public float sideStretch = 0.15f;

  // Token: 0x04000CE6 RID: 3302
  public float frontStretch = 0.2f;
}