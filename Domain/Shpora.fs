namespace Domain.Shpora
open System
open System.Xml.Serialization

type Person = 
        {
        Name: string;
        Surname: string;
        Age: int;
        }
        member this.With(name) = { this with Name = name }
        member this.SayName() = Console.WriteLine(this.Name)


type Mentor = Mentor of Person
    
type ShporunStatus = 
          | HasInterview of DateTime
          | HasMentor of Mentor
          | None

type Shporun = 
        {
        [<XmlAttribute>]
        Person: Person
        Status: ShporunStatus
        }

type Shpora = {
     Year: int
     Mentors: Mentor[]
     Shporuns: Shporun array
     }


module Test = 
    let m = Mentor.Mentor {Name = ""; Surname="";Age= 3}





(*
type Person = {
        Name: string
        Surname: string
        Age: int
        Origin: Origin
        }                  
and  Origin = | Shpora of int 
              | HighSchool of string
              | HR of Person

type Shporun = Shporun of Person

type Mentor = Mentor of Person

 type Shpora = {
     Year: int
     Shporuns: Shporun[]
     Mentors: Mentor[]
     }
*)