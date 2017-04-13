using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails
{
    class DataStructure
    {
    }
    class Person
    {
        private int iD;
        private int age;
        private string lastName;
        private string addressLine2;
        private string mobileNo;
        private string occupation;
        private string dateofRecord;
        private int oPDRegID;
        private string firstName;
        private string gender;
        private string city;
        private string state;
        private string country;
        private string addressLine1;
        private string religion;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegID { get => oPDRegID; set => oPDRegID = value; }
        public int Age { get => age; set => age = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Country { get => country; set => country = value; }
        public string AddressLine1 { get => addressLine1; set => addressLine1 = value; }
        public string AddressLine2 { get => addressLine2; set => addressLine2 = value; }
        public string MobileNo { get => mobileNo; set => mobileNo = value; }
        public string Religion { get => religion; set => religion = value; }
        public string Occupation { get => occupation; set => occupation = value; }
        public string DateofRecord { get => dateofRecord; set => dateofRecord = value; }
    }
    class Complaint
    {
        private int oPDRegId;
        private string pastComplian;
        private string ownSide;
        private int iD;
        private string presentComplain;
        private string historyCompalin;
        private string paternalSide;
        private string matarnalSide;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegId { get => oPDRegId; set => oPDRegId = value; }
        public string PresentComplain { get => presentComplain; set => presentComplain = value; }
        public string HistoryCompalin { get => historyCompalin; set => historyCompalin = value; }
        public string PastComplian { get => pastComplian; set => pastComplian = value; }
        public string PaternalSide { get => paternalSide; set => paternalSide = value; }
        public string MatarnalSide { get => matarnalSide; set => matarnalSide = value; }
        public string OwnSide { get => ownSide; set => ownSide = value; }
    }
    class Generalities
    {

        private int oPDRegId;
        private string intolerance;
        private string mental;
        private int iD;
        private string sentation;
        private string thermalReaction;
        private string tendencies;
        private string modalities;
        private string desire;
        private string appatite;
        private string urine;
        private string aversion;
        private string sleep;
        private string thirst;
        private string periperation;
        private string taste;
        private string discharge;
        private string stool;
        private string mensutral;
        private string salavation;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegId { get => oPDRegId; set => oPDRegId = value; }
        public string Sentation { get => sentation; set => sentation = value; }
        public string ThermalReaction { get => thermalReaction; set => thermalReaction = value; }
        public string Tendencies { get => tendencies; set => tendencies = value; }
        public string Modalities { get => modalities; set => modalities = value; }
        public string Desire { get => desire; set => desire = value; }
        public string Appatite { get => appatite; set => appatite = value; }
        public string Urine { get => urine; set => urine = value; }
        public string Aversion { get => aversion; set => aversion = value; }
        public string Intolerance { get => intolerance; set => intolerance = value; }
        public string Sleep { get => sleep; set => sleep = value; }
        public string Thirst { get => thirst; set => thirst = value; }
        public string Periperation { get => periperation; set => periperation = value; }
        public string Taste { get => taste; set => taste = value; }
        public string Discharge { get => discharge; set => discharge = value; }
        public string Stool { get => stool; set => stool = value; }
        public string Mensutral { get => mensutral; set => mensutral = value; }
        public string Salavation { get => salavation; set => salavation = value; }
        public string Mental { get => mental; set => mental = value; }
    }
    class BloodGroup
    {
        private int iD;
        private string rH;
        private string blood;

        public int ID { get => iD; set => iD = value; }
        public string Blood { get => blood; set => blood = value; }
        public string RH { get => rH; set => rH = value; }
    }
    class PhyicalExamination
    {
        private int oPDRegId;
        private string temp;
        private string pluse;
        private string neck;
        private string reportDetails;
        private int iD;
        private string bP;
        private string lymphNode;
        private string built;
        private string apperance;
        private string nutri;
        private string oedema;
        private string decubities;
        private string facies;
        private string anemia;
        private string cynosis;
        private string jaundance;
        private string clubbing;
        private string pigmentation;
        private string respiration;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegId { get => oPDRegId; set => oPDRegId = value; }
        public string BP { get => bP; set => bP = value; }
        public string Temp { get => temp; set => temp = value; }
        public string LymphNode { get => lymphNode; set => lymphNode = value; }
        public string Built { get => built; set => built = value; }
        public string Apperance { get => apperance; set => apperance = value; }
        public string Nutri { get => nutri; set => nutri = value; }
        public string Oedema { get => oedema; set => oedema = value; }
        public string Decubities { get => decubities; set => decubities = value; }
        public string Facies { get => facies; set => facies = value; }
        public string Anemia { get => anemia; set => anemia = value; }
        public string Cynosis { get => cynosis; set => cynosis = value; }
        public string Jaundance { get => jaundance; set => jaundance = value; }
        public string Clubbing { get => clubbing; set => clubbing = value; }
        public string Pluse { get => pluse; set => pluse = value; }
        public string Pigmentation { get => pigmentation; set => pigmentation = value; }
        public string Respiration { get => respiration; set => respiration = value; }
        public string Neck { get => neck; set => neck = value; }
        public string ReportDetails { get => reportDetails; set => reportDetails = value; }
    }
    class History
    {
        private int oPDRegId;
        private string sterlization;
        private int noOfChild;
        private string hobbies;
        private int iD;
        private string accomodation;
        private string addications;
        private string childAges;
        private string diet;
        private string maritalStatus;
        private string birthPlace;
        private string sexualHistory;
        private string anyMed;
        private string obes;
        private string vaccine;
        private string moutox;
        private string relationWithFamily;
        private string habbit;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegId { get => oPDRegId; set => oPDRegId = value; }
        public string Accomodation { get => accomodation; set => accomodation = value; }
        public string Addications { get => addications; set => addications = value; }
        public string ChildAges { get => childAges; set => childAges = value; }
        public string Diet { get => diet; set => diet = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public string SexualHistory { get => sexualHistory; set => sexualHistory = value; }
        public string AnyMed { get => anyMed; set => anyMed = value; }
        public string Obes { get => obes; set => obes = value; }
        public string Vaccine { get => vaccine; set => vaccine = value; }
        public string Sterlization { get => sterlization; set => sterlization = value; }
        public int NoOfChild { get => noOfChild; set => noOfChild = value; }
        public string Moutox { get => moutox; set => moutox = value; }
        public string RelationWithFamily { get => relationWithFamily; set => relationWithFamily = value; }
        public string Habbit { get => habbit; set => habbit = value; }
        public string Hobbies { get => hobbies; set => hobbies = value; }
    }
    class Invoice
    {
        private int oPDRegId;
        private int visitID;
        private float dues;
        private string remarks;
        private int iD;
        private float visitCharge;
        private float medCharge;
        private float otherCharges;
        private float paid;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegId { get => oPDRegId; set => oPDRegId = value; }
        public int VisitID { get => visitID; set => visitID = value; }
        public float VisitCharge { get => visitCharge; set => visitCharge = value; }
        public float MedCharge { get => medCharge; set => medCharge = value; }
        public float OtherCharges { get => otherCharges; set => otherCharges = value; }
        public float Paid { get => paid; set => paid = value; }
        public float Dues { get => dues; set => dues = value; }
        public string Remarks { get => remarks; set => remarks = value; }
    }
    
    class PrescribedMed
    {

        private int oPDRegId;
        private int visitID;
        private string remarks;
        private float cost;
        private int iD;
        private string medicineName;
        private string power;
        private string noOfTime;
        private string quantity;
        private string description;

        public int ID { get => iD; set => iD = value; }
        public int OPDRegId { get => oPDRegId; set => oPDRegId = value; }
        public int VisitID { get => visitID; set => visitID = value; }
        public string MedicineName { get => medicineName; set => medicineName = value; }
        public string Power { get => power; set => power = value; }
        public string NoOfTime { get => noOfTime; set => noOfTime = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Description { get => description; set => description = value; }
        public string Remarks { get => remarks; set => remarks = value; }
        public float Cost { get => cost; set => cost = value; }
    }
    class AuthUsers
    {
        private int role;
        private string password;
        private int iD;
        private string userName;

        public int ID { get => iD; set => iD = value; }
        public int Role { get => role; set => role = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }

    class Visit
    {

        private int visitNo;
        private DateTime visitDate;
        private int revisit;
        private int billable;
        private string problems;
        private int id;
        private int oPDRegID;
        private DateTime nextVisit;
        private int visitBillable;

        public int Id { get => id; set => id = value; }
        public int OPDRegID { get => oPDRegID; set => oPDRegID = value; }
        public int VisitNo { get => visitNo; set => visitNo = value; }
        public DateTime NextVisit { get => nextVisit; set => nextVisit = value; }
        public DateTime VisitDate { get => visitDate; set => visitDate = value; }
        public int Revisit { get => revisit; set => revisit = value; }
        public int VisitBillable { get => visitBillable; set => visitBillable = value; }
        public int Billable { get => billable; set => billable = value; }
        public string Problems { get => problems; set => problems = value; }
    }
}
