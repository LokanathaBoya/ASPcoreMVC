using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

public class StudentMetadata
{
    //DataAnnotation is works , but if we change the database changes and we have to re-scaffold our elements everything will get reset
    [Display(Name ="First Name")]
    public string FirstName { get; set; } = null!;
    [Display(Name ="Last Name")]
    public string LastName { get; set; } = null!;
   [Display(Name ="Date Of Birth")]
    public DateTime? DateOfBirth { get; set; }
}

[ModelMetadataType(typeof(StudentMetadata))]
public partial class Student{}