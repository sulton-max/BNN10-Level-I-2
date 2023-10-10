// ma'lumotlarni deffered usulda olish - query va delegate

// behavior - behavior larni deffered usulda ishlatish

// update - skill  - javascript, typescript, python

//

using Delegates.Example;
using Delegates.Example.Extensions;

var usersA = new List<User>
{
    new(Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "john", "doe"),
    new(Guid.Parse("A2DAD52F-639D-4EDC-AD5A-530C280A1017"), "jonibek", "doe")
};

var usersB = new List<User>
{
    new(Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "johnson", "doe"),
    new(Guid.Parse("D0BAE6A0-9446-4561-8C39-3EA5EB4AE810"), "jane", "doe")
};

// var users = usersA.ZipIntersectBy(usersB, user => user.Id);
//
// foreach (var (userA, userB) in users)
// {
//     Console.WriteLine($"{userA.FirstName} {userA.LastName} - {userB.FirstName} {userB.LastName}");
// }

// 5 va 7
// usersA.Zip(usersB,
//     (userA, userB) => new
//     {
//         userA,
//         userB
//     });

// See https://aka.ms/new-console-template for more information

var skillsA = new List<TalentSkill>
{
    new(Guid.Parse("859F84D8-B4A6-434B-8C67-58D8061497E5"),
        Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"),
        "Javascript",
        SkillLevel.Intermediate),
    new(Guid.Parse("092D9252-34BF-4E68-BE97-8B714A5DC3A4"), Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "Typescript", SkillLevel.Beginner),
    new(Guid.Parse("1949ACA1-2FA2-474C-A967-5910EE08BC70"), Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "CSharp", SkillLevel.Advanced),
};

var skillsB = new List<TalentSkill>
{
    new(Guid.Parse("092D9252-34BF-4E68-BE97-8B714A5DC3A4"), Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "TS", SkillLevel.Intermediate),
    new(Guid.Parse("1949ACA1-2FA2-474C-A967-5910EE08BC70"), Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "CS", SkillLevel.Intermediate),
    new(Guid.Parse("859F84D8-B4A6-434B-8C67-58D8061497E5"), Guid.Parse("99E3BA84-B062-4132-A691-6EA6C720E3FB"), "JS", SkillLevel.Intermediate),
};

var oldPost = new object();
var updatedPost = new object();

// topics - string[]
// Topic - Id, Name

var intersectedTopics = oldPost.Topics.ZipIntersectBy(updatedPost.Topics, topic => topic.Id)


// Talent - skill []

// Post - topic []

// User - language[]

var intersectedSkills = skillsA.ZipIntersectBy(skillsB, skill => skill.Id);

// John - 3 token [] - scope []
// token[] - scope[] - Resume

foreach (var (previous, updatedSkill) in intersectedSkills)
{
    Console.WriteLine($"Skill eski qiymatlari - {previous.SkillName} : {previous.SkillLevel}");
    Console.WriteLine($"Skill yangi qiymatlari - {updatedSkill.SkillName} : {updatedSkill.SkillLevel}");
}



Console.WriteLine("Hello, World!");

namespace Delegates.Example
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public User(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public enum SkillLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public class TalentSkill
    {
        public Guid Id { get; set; }

        public Guid TalentId { get; set; }

        public string SkillName { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public TalentSkill(Guid id, Guid talentId, string skillName, SkillLevel skillLevel)
        {
            Id = id;
            TalentId = talentId;
            SkillName = skillName;
            SkillLevel = skillLevel;
        }
    }
}