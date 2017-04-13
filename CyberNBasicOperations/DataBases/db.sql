Drop TABLe Personal;
CREATE TABLE Personal( 
                Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,     
                 OPDRegID INT NOT NULL, FirstName varchar(50) NOT NULL,     
                LastName varchar(50) NOT NULL,    Gender INT NOT NULL,     
                Age INT NOT NULL,     AddressLine1 varchar(50) NOT NULL,     
                AddressLine2 varchar(50) NULL,     City INT NOT NULL,     
                State INT NOT NULL,     Country INT NOT NULL,     MobileNo varchar(50) NOT NULL, 
                Religion varchar(50) NOT NULL,    DateOfRecord varchar(50) NOT NULL,     
                Occupation varchar(50) NOT NULL)

Drop TABLE BloodGroup;
CREATE TABLE bloodgroup (
	 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
 BloodGroup VARCHAR(50) NOT NULL, 
 RHFactor VARCHAR(50) NOT NULL 
)
/*Done*/
CREATE TABLE role (
	 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
 Role VARCHAR(50) NOT NULL, 
 status VARCHAR(50) NULL 
)
/*ADDED*/
CREATE TABLE City (
	 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
 City VARCHAR(50) NOT NULL, 
 state int NOT NULL 
)

/*ADDED*/
CREATE TABLE state
(
	 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
 state VARCHAR(50) NOT NULL, 
 Country int NOT NULL 
)


/*ADDED*/
CREATE TABLE Country 
(
	 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
 Country VARCHAR(50) NOT NULL 
 
)

/*ADDED*/
CREATE TABLE Complaint
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    OPDRegID INT NOT NULL, 
    PresentComplain varchar(50) NULL, 
    HistoryComplain varchar(50) NULL, 
    PastComplain varchar(50) NULL, 
    PaternalSide varchar(50) NULL, 
    MaternalSide varchar(50) NULL, 
    OwnSide varchar(50) NULL
)


/*ADDED*/
CREATE TABLE PatHistory
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    OPDRegId INT NULL, 
    Accomodation varchar(50) NULL, 
    Addications varchar(50) NULL, 
    NoOfChild INT NULL, 
    ChildAges varchar(50) NULL, 
    Diet varchar(50) NULL, 
    Marital varchar(50) NULL, 
    BirthPlace varchar(50) NULL, 
    SexualHistory varchar(50) NULL, 
    AnyMedicine varchar(50) NULL, 
    Obes varchar(50) NULL, 
    Vaccines varchar(50) NULL, 
    Seterilization varchar(50) NULL, 
    Moutox varchar(50) NULL, 
    Relationwithfamily varchar(50) NULL, 
    Habbit varchar(50) NULL, 
    Hobbies varchar(50) NULL
)

/*ADDED*/
CREATE TABLE Gender

(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    Gender varchar(50) NOT NULL
)


/*ADDED*/
CREATE TABLE Generalities
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    OPDRegId INT NOT NULL, 
    sentation varchar(50) NULL, 
    thermalreaction varchar(50) NULL, 
    tendencies varchar(50) NULL, 
    modalities varchar(50) NULL, 
    desire varchar(50) NULL, 
    appitite varchar(50) NULL, 
    urine varchar(50) NULL, 
    aversion varchar(50) NULL, 
    intolerance varchar(50) NULL, 
    sleep varchar(50) NULL, 
    thirst varchar(50) NULL, 
    periperation varchar(50) NULL, 
    taste varchar(50) NULL, 
    discharge varchar(50) NULL, 
    stool varchar(50) NULL, 
    mensutral varchar(50) NULL, 
    salavation varchar(50) NULL, 
    mental varchar(50) NULL
)

/*ADDED*/
CREATE TABLE phycialExam
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    OPDRegId varchar(50) NULL, 
    BP varchar(50) NULL, 
    Temp varchar(50) NULL, 
    lymphnode varchar(50) NULL, 
    built varchar(50) NULL, 
    apperance varchar(50) NULL, 
    nutri varchar(50) NULL, 
    oedema varchar(50) NULL, 
    decubities varchar(50) NULL, 
    facies varchar(50) NULL, 
    anemia varchar(50) NULL, 
    cynosis varchar(50) NULL, 
    jaundance varchar(50) NULL, 
    clubbing varchar(50) NULL, 
    pigmentation varchar(50) NULL, 
    pulse varchar(50) NULL, 
    respiration varchar(50) NULL, 
    neck varchar(50) NULL, 
    reportdetails varchar(50) NULL
)


/*ADDED*/
CREATE TABLE Visit
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    OPDRegID INT NOT NULL, 
    VisitNo INT NOT NULL, 
    NexTVisit DATE NULL, 
    Revisit INT NULL, 
    Problems varchar(50) NULL, 
    VisitBillable INT NULL, 
    Billable INT NULL

)

/*ADDED*/
CREATE TABLE PrescribedMed (
    Id           INT        NOT NULL PRIMARY KEY,
    OPDRegID     INT        NOT NULL,
    VisitID      INT        NOT NULL,
    MedicineName Varchar(50) NULL,
    Power       Varchar(50) NULL,
    NoOfTime    Varchar(50) NULL,
    Quantity    Varchar(50) NULL,
    Description Varchar(50) NULL,
    Remark      Varchar(50) NULL,
    Cost         FLOAT (53) NULL,
    
);



/*ADDED*/
CREATE TABLE Invoice
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    OPDRegID INT NOT NULL, 
    VisitCharge FLOAT NULL, 
    MediceneCharge FLOAT NULL, 
    OtherCharges FLOAT NULL, 
    Remark varchar(50) NULL, 
    Paid FLOAT NULL, 
    due FLOAT NULL
)

CREATE TABLE [dbo].AuthUser
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [username] VARCHAR(20) NOT NULL, 
    [passwd] VARCHAR(10) NOT NULL, 
    [role] INT NOT NULL
)


CREATE TABLE [dbo].[Visit] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [OPDRegID]      INT          NOT NULL,
    [VisitNo]       INT          NOT NULL,
    [NexTVisit]     DATE         NULL,
    [Revisit]       INT          NULL,
    [Problems]      VARCHAR (50) NULL,
    [VisitBillable] INT          NULL,
    [Billable]      INT          NULL,
    [VisitDate] DATE NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

/*ADDED*/
CREATE TABLE [dbo].Medicine
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Medicine] VARCHAR(50) NOT NULL, 
    [Power] VARCHAR(50) NULL, 
    [Type]Varchar(50) NULL
)

CREATE TABLE [dbo].[PrescribedMed] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [OPDRegID]     INT        NOT NULL,
    [VisitID]      INT        NOT NULL,
    [MedicineName] Varchar (50) NULL,
    [Power]        Varchar (50) NULL,
    [NoOfTime]     Varchar (50) NULL,
    [Quantity]     Varchar (50) NULL,
    [Description]  Varchar (50) NULL,
    [Remark]       Varchar (50) NULL,
    [Cost]         FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE Test (id int IDENTITY not null,fname VARCHAR(40));
