using System;

namespace UtilitiesMain.DataClasses
{
    //public class Person
    //{

    //    //public string firstName;
    //    //public string lastName;
    //    //public DateTime dateOfBirth;
    //    //public bool isCitizenCZ;

    //    private string firstName;
    //    private string lastName;
    //    private DateTime dateOfBirth;
    //    private bool isCitizenCZ;

    //    public Person(
    //        string firstName, string lastName,
    //        DateTime dateOfBirth, bool isCitizenCZ
    //    )
    //    {
    //        this.firstName = firstName;
    //        this.lastName = lastName;
    //        this.dateOfBirth = dateOfBirth;
    //        this.isCitizenCZ = isCitizenCZ;
    //    }

    //    //public string FirstName
    //    //{
    //    //    get { return this.firstName; }
    //    //    //set { this.firstName = value; }
    //    //}
    //    public string FirstName { get; }

    //    public string LastName
    //    {
    //        get { return this.lastName; }
    //        //set { this.lastName = value; }
    //    }

    //    public DateTime DateOfBirth
    //    {
    //        get { return this.dateOfBirth; }
    //        //set { this.dateOfBirth = value; }
    //    }

    //    public bool IsCitizenCZ
    //    {
    //        get { return this.isCitizenCZ; }
    //        set { this.isCitizenCZ = value; }
    //    }


    //    //public string GetFirstName()
    //    //{
    //    //    return this.firstName;
    //    //}
    //    //public string GetLastName()
    //    //{
    //    //    return this.lastName;
    //    //}
    //    //public DateTime GetDateOfBirth()
    //    //{
    //    //    return this.dateOfBirth;
    //    //}
    //    //public bool GetIsCitizenCZ()
    //    //{
    //    //    return this.isCitizenCZ;
    //    //}
    //    //public void SetIsCitizenCZ(bool isCitizenCZ)
    //    //{
    //    //    this.isCitizenCZ = isCitizenCZ;
    //    //}

    //}


    public class Person
    {
        //public string FirstName { get; set; }
        public string FirstName { get;  }
        //public string FirstName
        //{
        //    get
        //    {
        //        retrun
        //    }
        //    set
        //    {
        //        if (value == "Horakova")
        //        {
        //            throw new ApplicationException();
        //        }
        //    }
        //}
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsCitizenCZ { get; set; }

        public Person(string firstName, string lastName, DateTime dateOfBirth, bool isCitizenCZ)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            IsCitizenCZ = isCitizenCZ;
        }
    }
}
