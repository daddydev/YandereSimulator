using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
[Serializable]
public abstract class Entity {

  // Token: 0x06000295 RID: 661 RVA: 0x00034378 File Offset: 0x00032778
  public Entity(GenderType gender) {
    this.gender = gender;
    this.deathType = DeathType.None;
  }

  // Token: 0x17000048 RID: 72
  // (get) Token: 0x06000296 RID: 662 RVA: 0x0003438E File Offset: 0x0003278E
  public GenderType Gender {
    get {
      return this.gender;
    }
  }

  // Token: 0x17000049 RID: 73
  // (get) Token: 0x06000297 RID: 663 RVA: 0x00034396 File Offset: 0x00032796
  // (set) Token: 0x06000298 RID: 664 RVA: 0x0003439E File Offset: 0x0003279E
  public DeathType DeathType {
    get {
      return this.deathType;
    }
    set {
      this.deathType = value;
    }
  }

  // Token: 0x1700004A RID: 74
  // (get) Token: 0x06000299 RID: 665
  public abstract EntityType EntityType { get; }

  // Token: 0x04000884 RID: 2180
  [SerializeField]
  private GenderType gender;

  // Token: 0x04000885 RID: 2181
  [SerializeField]
  private DeathType deathType;
}