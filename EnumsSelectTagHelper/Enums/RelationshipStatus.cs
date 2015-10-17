using System.ComponentModel.DataAnnotations;

namespace EnumsSelectTagHelper.Enums
{
    public enum RelationshipStatus
    {
      Single,
      [Display(Name = "It is complicated")]
      Complicated,
      [Display(Name = "In an open relationship")]
      Open,
      [Display(Name = "In a relationship")]
      Relationship,
      Engaged,
      Married,
      [Display(Name = "In a Civil Union")]
      CivilUnion,
      Separated,
      Divorced,
      Widowed
    }
}
