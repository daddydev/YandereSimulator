using System;

// Token: 0x02000013 RID: 19
[Serializable]
public class InvStat {

  // Token: 0x0600005E RID: 94 RVA: 0x0000A073 File Offset: 0x00008473
  public static string GetName(InvStat.Identifier i) {
    return i.ToString();
  }

  // Token: 0x0600005F RID: 95 RVA: 0x0000A084 File Offset: 0x00008484
  public static string GetDescription(InvStat.Identifier i) {
    switch (i) {
      case InvStat.Identifier.Strength:
        return "Strength increases melee damage";

      case InvStat.Identifier.Constitution:
        return "Constitution increases health";

      case InvStat.Identifier.Agility:
        return "Agility increases armor";

      case InvStat.Identifier.Intelligence:
        return "Intelligence increases mana";

      case InvStat.Identifier.Damage:
        return "Damage adds to the amount of damage done in combat";

      case InvStat.Identifier.Crit:
        return "Crit increases the chance of landing a critical strike";

      case InvStat.Identifier.Armor:
        return "Armor protects from damage";

      case InvStat.Identifier.Health:
        return "Health prolongs life";

      case InvStat.Identifier.Mana:
        return "Mana increases the number of spells that can be cast";

      default:
        return null;
    }
  }

  // Token: 0x06000060 RID: 96 RVA: 0x0000A0F8 File Offset: 0x000084F8
  public static int CompareArmor(InvStat a, InvStat b) {
    int num = (int)a.id;
    int num2 = (int)b.id;
    if (a.id == InvStat.Identifier.Armor) {
      num -= 10000;
    } else if (a.id == InvStat.Identifier.Damage) {
      num -= 5000;
    }
    if (b.id == InvStat.Identifier.Armor) {
      num2 -= 10000;
    } else if (b.id == InvStat.Identifier.Damage) {
      num2 -= 5000;
    }
    if (a.amount < 0) {
      num += 1000;
    }
    if (b.amount < 0) {
      num2 += 1000;
    }
    if (a.modifier == InvStat.Modifier.Percent) {
      num += 100;
    }
    if (b.modifier == InvStat.Modifier.Percent) {
      num2 += 100;
    }
    if (num < num2) {
      return -1;
    }
    if (num > num2) {
      return 1;
    }
    return 0;
  }

  // Token: 0x06000061 RID: 97 RVA: 0x0000A1CC File Offset: 0x000085CC
  public static int CompareWeapon(InvStat a, InvStat b) {
    int num = (int)a.id;
    int num2 = (int)b.id;
    if (a.id == InvStat.Identifier.Damage) {
      num -= 10000;
    } else if (a.id == InvStat.Identifier.Armor) {
      num -= 5000;
    }
    if (b.id == InvStat.Identifier.Damage) {
      num2 -= 10000;
    } else if (b.id == InvStat.Identifier.Armor) {
      num2 -= 5000;
    }
    if (a.amount < 0) {
      num += 1000;
    }
    if (b.amount < 0) {
      num2 += 1000;
    }
    if (a.modifier == InvStat.Modifier.Percent) {
      num += 100;
    }
    if (b.modifier == InvStat.Modifier.Percent) {
      num2 += 100;
    }
    if (num < num2) {
      return -1;
    }
    if (num > num2) {
      return 1;
    }
    return 0;
  }

  // Token: 0x04000118 RID: 280
  public InvStat.Identifier id;

  // Token: 0x04000119 RID: 281
  public InvStat.Modifier modifier;

  // Token: 0x0400011A RID: 282
  public int amount;

  // Token: 0x02000014 RID: 20
  public enum Identifier {

    // Token: 0x0400011C RID: 284
    Strength,

    // Token: 0x0400011D RID: 285
    Constitution,

    // Token: 0x0400011E RID: 286
    Agility,

    // Token: 0x0400011F RID: 287
    Intelligence,

    // Token: 0x04000120 RID: 288
    Damage,

    // Token: 0x04000121 RID: 289
    Crit,

    // Token: 0x04000122 RID: 290
    Armor,

    // Token: 0x04000123 RID: 291
    Health,

    // Token: 0x04000124 RID: 292
    Mana,

    // Token: 0x04000125 RID: 293
    Other
  }

  // Token: 0x02000015 RID: 21
  public enum Modifier {

    // Token: 0x04000127 RID: 295
    Added,

    // Token: 0x04000128 RID: 296
    Percent
  }
}