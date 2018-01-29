using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000D RID: 13
[Serializable]
public class InvBaseItem {

  // Token: 0x040000E9 RID: 233
  public int id16;

  // Token: 0x040000EA RID: 234
  public string name;

  // Token: 0x040000EB RID: 235
  public string description;

  // Token: 0x040000EC RID: 236
  public InvBaseItem.Slot slot;

  // Token: 0x040000ED RID: 237
  public int minItemLevel = 1;

  // Token: 0x040000EE RID: 238
  public int maxItemLevel = 50;

  // Token: 0x040000EF RID: 239
  public List<InvStat> stats = new List<InvStat>();

  // Token: 0x040000F0 RID: 240
  public GameObject attachment;

  // Token: 0x040000F1 RID: 241
  public Color color = Color.white;

  // Token: 0x040000F2 RID: 242
  public UIAtlas iconAtlas;

  // Token: 0x040000F3 RID: 243
  public string iconName = string.Empty;

  // Token: 0x0200000E RID: 14
  public enum Slot {

    // Token: 0x040000F5 RID: 245
    None,

    // Token: 0x040000F6 RID: 246
    Weapon,

    // Token: 0x040000F7 RID: 247
    Shield,

    // Token: 0x040000F8 RID: 248
    Body,

    // Token: 0x040000F9 RID: 249
    Shoulders,

    // Token: 0x040000FA RID: 250
    Bracers,

    // Token: 0x040000FB RID: 251
    Boots,

    // Token: 0x040000FC RID: 252
    Trinket,

    // Token: 0x040000FD RID: 253
    _LastDoNotUse
  }
}