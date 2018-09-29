// using System;
// using System.Collections.Generic;
// using Concepts;

// namespace Read.StaffUsers.Models
// {
//     public class DataVerifier : BaseUser
//     {
//         public DataVerifier(Guid id, string fullName, string displayName,
//             string email, DateTimeOffset registrationDate, int birthYear, Sex sex,
//             Guid nationalSociety, Language preferredLanguage, Location location) 
//             : base(id, fullName, displayName, email, registrationDate)
//         {
//             BirthYear = birthYear;
//             Sex = sex;
//             NationalSociety = nationalSociety;
//             PreferredLanguage = preferredLanguage;
//             Location = location;

//             PhoneNumbers = new List<PhoneNumber>();
//             AssignedNationalSocieties = new List<Guid>();
//         }
        
//         public int BirthYear { get; set; }
//         public Sex Sex { get; set; }
//         public Guid NationalSociety { get; set; }
//         public Language PreferredLanguage { get; set; }
//         public Location Location { get; set; }

//         public List<PhoneNumber> PhoneNumbers { get; set; }
//         public List<Guid> AssignedNationalSocieties { get; set; }
//     }
// }