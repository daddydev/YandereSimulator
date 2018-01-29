using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000011 RID: 17
[Serializable]
public class InvGameItem {

  // Token: 0x06000055 RID: 85 RVA: 0x00009C52 File Offset: 0x00008052
  public InvGameItem(int id) {
    this.mBaseItemID = id;
  }

  // Token: 0x06000056 RID: 86 RVA: 0x00009C6F File Offset: 0x0000806F
  public InvGameItem(int id, InvBaseItem bi) {
    this.mBaseItemID = id;
    this.mBaseItem = bi;
  }

  // Token: 0x17000007 RID: 7
  // (get) Token: 0x06000057 RID: 87 RVA: 0x00009C93 File Offset: 0x00008093
  public int baseItemID {
    get {
      return this.mBaseItemID;
    }
  }

  // Token: 0x17000008 RID: 8
  // (get) Token: 0x06000058 RID: 88 RVA: 0x00009C9B File Offset: 0x0000809B
  public InvBaseItem baseItem {
    get {
      if (this.mBaseItem == null) {
        this.mBaseItem = InvDatabase.FindByID(this.baseItemID);
      }
      return this.mBaseItem;
    }
  }

  // Token: 0x17000009 RID: 9
  // (get) Token: 0x06000059 RID: 89 RVA: 0x00009CBF File Offset: 0x000080BF
  public string name {
    get {
      if (this.baseItem == null) {
        return null;
      }
      return this.quality.ToString() + " " + this.baseItem.name;
    }
  }

  // Token: 0x1700000A RID: 10
  // (get) Token: 0x0600005A RID: 90 RVA: 0x00009CF4 File Offset: 0x000080F4
  public float statMultiplier {
    get {
      float num = 0f;
      switch (this.quality) {
        case InvGameItem.Quality.Broken:
          num = 0f;
          break;

        case InvGameItem.Quality.Cursed:
          num = -1f;
          break;

        case InvGameItem.Quality.Damaged:
          num = 0.25f;
          break;

        case InvGameItem.Quality.Worn:
          num = 0.9f;
          break;

        case InvGameItem.Quality.Sturdy:
          num = 1f;
          break;

        case InvGameItem.Quality.Polished:
          num = 1.1f;
          break;

        case InvGameItem.Quality.Improved:
          num = 1.25f;
          break;

        case InvGameItem.Quality.Crafted:
          num = 1.5f;
          break;

        case InvGameItem.Quality.Superior:
          num = 1.75f;
          break;

        case InvGameItem.Quality.Enchanted:
          num = 2f;
          break;

        case InvGameItem.Quality.Epic:
          num = 2.5f;
          break;

        case InvGameItem.Quality.Legendary:
          num = 3f;
          break;
      }
      float num2 = (float)this.itemLevel / 50f;
      return num * Mathf.Lerp(num2, num2 * num2, 0.5f);
    }
  }

  // Token: 0x1700000B RID: 11
  // (get) Token: 0x0600005B RID: 91 RVA: 0x00009DF0 File Offset: 0x000081F0
  public Color color {
    get {
      Color result = Color.white;
      switch (this.quality) {
        case InvGameItem.Quality.Broken:
          result = new Color(0.4f, 0.2f, 0.2f);
          break;

        case InvGameItem.Quality.Cursed:
          result = Color.red;
          break;

        case InvGameItem.Quality.Damaged:
          result = new Color(0.4f, 0.4f, 0.4f);
          break;

        case InvGameItem.Quality.Worn:
          result = new Color(0.7f, 0.7f, 0.7f);
          break;

        case InvGameItem.Quality.Sturdy:
          result = new Color(1f, 1f, 1f);
          break;

        case InvGameItem.Quality.Polished:
          result = NGUIMath.HexToColor(3774856959u);
          break;

        case InvGameItem.Quality.Improved:
          result = NGUIMath.HexToColor(2480359935u);
          break;

        case InvGameItem.Quality.Crafted:
          result = NGUIMath.HexToColor(1325334783u);
          break;

        case InvGameItem.Quality.Superior:
          result = NGUIMath.HexToColor(12255231u);
          break;

        case InvGameItem.Quality.Enchanted:
          result = NGUIMath.HexToColor(1937178111u);
          break;

        case InvGameItem.Quality.Epic:
          result = NGUIMath.HexToColor(2516647935u);
          break;

        case InvGameItem.Quality.Legendary:
          result = NGUIMath.HexToColor(4287627519u);
          break;
      }
      return result;
    }
  }

  // Token: 0x0600005C RID: 92 RVA: 0x00009F30 File Offset: 0x00008330
  public List<InvStat> CalculateStats() {
    List<InvStat> list = new List<InvStat>();
    if (this.baseItem != null) {
      float statMultiplier = this.statMultiplier;
      List<InvStat> stats = this.baseItem.stats;
      int i = 0;
      int count = stats.Count;
      while (i < count) {
        InvStat invStat = stats[i];
        int num = Mathf.RoundToInt(statMultiplier * (float)invStat.amount);
        if (num != 0) {
          bool flag = false;
          int j = 0;
          int count2 = list.Count;
          while (j < count2) {
            InvStat invStat2 = list[j];
            if (invStat2.id == invStat.id && invStat2.modifier == invStat.modifier) {
              invStat2.amount += num;
              flag = true;
              break;
            }
            j++;
          }
          if (!flag) {
            list.Add(new InvStat {
              id = invStat.id,
              amount = num,
              modifier = invStat.modifier
            });
          }
        }
        i++;
      }
      List<InvStat> list2 = list;
      if (InvGameItem.temp == null) {
        InvGameItem.temp = new Comparison<InvStat>(InvStat.CompareArmor);
      }
      list2.Sort(InvGameItem.temp);
    }
    return list;
  }

  // Token: 0x04000105 RID: 261
  [SerializeField]
  private int mBaseItemID;

  // Token: 0x04000106 RID: 262
  public InvGameItem.Quality quality = InvGameItem.Quality.Sturdy;

  // Token: 0x04000107 RID: 263
  public int itemLevel = 1;

  // Token: 0x04000108 RID: 264
  private InvBaseItem mBaseItem;

  // Token: 0x04000109 RID: 265
  [CompilerGenerated]
  private static Comparison<InvStat> temp;

  // Token: 0x02000012 RID: 18
  public enum Quality {

    // Token: 0x0400010B RID: 267
    Broken,

    // Token: 0x0400010C RID: 268
    Cursed,

    // Token: 0x0400010D RID: 269
    Damaged,

    // Token: 0x0400010E RID: 270
    Worn,

    // Token: 0x0400010F RID: 271
    Sturdy,

    // Token: 0x04000110 RID: 272
    Polished,

    // Token: 0x04000111 RID: 273
    Improved,

    // Token: 0x04000112 RID: 274
    Crafted,

    // Token: 0x04000113 RID: 275
    Superior,

    // Token: 0x04000114 RID: 276
    Enchanted,

    // Token: 0x04000115 RID: 277
    Epic,

    // Token: 0x04000116 RID: 278
    Legendary,

    // Token: 0x04000117 RID: 279
    _LastDoNotUse
  }
}