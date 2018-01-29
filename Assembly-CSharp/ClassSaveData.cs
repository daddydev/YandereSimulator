using System;

// Token: 0x0200018D RID: 397
[Serializable]
public class ClassSaveData {

  // Token: 0x0600071A RID: 1818 RVA: 0x0006C740 File Offset: 0x0006AB40
  public static ClassSaveData ReadFromGlobals() {
    return new ClassSaveData {
      biology = ClassGlobals.Biology,
      biologyBonus = ClassGlobals.BiologyBonus,
      biologyGrade = ClassGlobals.BiologyGrade,
      chemistry = ClassGlobals.Chemistry,
      chemistryBonus = ClassGlobals.ChemistryBonus,
      chemistryGrade = ClassGlobals.ChemistryGrade,
      language = ClassGlobals.Language,
      languageBonus = ClassGlobals.LanguageBonus,
      languageGrade = ClassGlobals.LanguageGrade,
      physical = ClassGlobals.Physical,
      physicalBonus = ClassGlobals.PhysicalBonus,
      physicalGrade = ClassGlobals.PhysicalGrade,
      psychology = ClassGlobals.Psychology,
      psychologyBonus = ClassGlobals.PsychologyBonus,
      psychologyGrade = ClassGlobals.PsychologyGrade
    };
  }

  // Token: 0x0600071B RID: 1819 RVA: 0x0006C7FC File Offset: 0x0006ABFC
  public static void WriteToGlobals(ClassSaveData data) {
    ClassGlobals.Biology = data.biology;
    ClassGlobals.BiologyBonus = data.biologyBonus;
    ClassGlobals.BiologyGrade = data.biologyGrade;
    ClassGlobals.Chemistry = data.chemistry;
    ClassGlobals.ChemistryBonus = data.chemistryBonus;
    ClassGlobals.ChemistryGrade = data.chemistryGrade;
    ClassGlobals.Language = data.language;
    ClassGlobals.LanguageBonus = data.languageBonus;
    ClassGlobals.LanguageGrade = data.languageGrade;
    ClassGlobals.Physical = data.physical;
    ClassGlobals.PhysicalBonus = data.physicalBonus;
    ClassGlobals.PhysicalGrade = data.physicalGrade;
    ClassGlobals.Psychology = data.psychology;
    ClassGlobals.PsychologyBonus = data.psychologyBonus;
    ClassGlobals.PsychologyGrade = data.psychologyGrade;
  }

  // Token: 0x040011FE RID: 4606
  public int biology;

  // Token: 0x040011FF RID: 4607
  public int biologyBonus;

  // Token: 0x04001200 RID: 4608
  public int biologyGrade;

  // Token: 0x04001201 RID: 4609
  public int chemistry;

  // Token: 0x04001202 RID: 4610
  public int chemistryBonus;

  // Token: 0x04001203 RID: 4611
  public int chemistryGrade;

  // Token: 0x04001204 RID: 4612
  public int language;

  // Token: 0x04001205 RID: 4613
  public int languageBonus;

  // Token: 0x04001206 RID: 4614
  public int languageGrade;

  // Token: 0x04001207 RID: 4615
  public int physical;

  // Token: 0x04001208 RID: 4616
  public int physicalBonus;

  // Token: 0x04001209 RID: 4617
  public int physicalGrade;

  // Token: 0x0400120A RID: 4618
  public int psychology;

  // Token: 0x0400120B RID: 4619
  public int psychologyBonus;

  // Token: 0x0400120C RID: 4620
  public int psychologyGrade;
}