-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-08-23 15:04:31.339

-- tables
-- Table: Appointment
CREATE TABLE Appointment (
    Person_pesel varchar(11)  NOT NULL,
    Service_id_service int  NOT NULL,
    start timestamp  NOT NULL,
    "end" timestamp  NOT NULL,
    is_cancelled int  NOT NULL,
    CONSTRAINT Appointment_pk PRIMARY KEY (Person_pesel,Service_id_service,start,"end")
);

-- Table: DayOfWork
CREATE TABLE DayOfWork (
    date date  NOT NULL,
    start time  NOT NULL,
    "end" time  NOT NULL,
    pesel varchar(11)  NOT NULL,
    CONSTRAINT DayOfWork_pk PRIMARY KEY (date,pesel)
);

-- Table: EquipmentService
CREATE TABLE EquipmentService (
    Service_id_service int  NOT NULL,
    MedicalEquipment_id int  NOT NULL,
    CONSTRAINT EquipmentService_pk PRIMARY KEY (Service_id_service,MedicalEquipment_id)
);

-- Table: Machine
CREATE TABLE Machine (
    MedicalEquipment_id int  NOT NULL,
    license_is_needed boolean  NOT NULL,
    CONSTRAINT Machine_pk PRIMARY KEY (MedicalEquipment_id)
);

-- Table: MedicalEquipment
CREATE TABLE MedicalEquipment (
    id int  NOT NULL,
    price int  NOT NULL,
    width int  NOT NULL,
    depth int  NOT NULL,
    height int  NOT NULL,
    descript text  NOT NULL,
    room int  NOT NULL,
    CONSTRAINT MedicalEquipment_pk PRIMARY KEY (id)
);

-- Table: NurseInService
CREATE TABLE NurseInService (
    Person_pesel varchar(11)  NOT NULL,
    Service_id_service int  NOT NULL,
    CONSTRAINT NurseInService_pk PRIMARY KEY (Person_pesel,Service_id_service)
);

-- Table: Person
CREATE TABLE Person (
    pesel varchar(11)  NOT NULL,
    name varchar(20)  NOT NULL,
    surname varchar(20)  NOT NULL,
    patient boolean  NOT NULL,
    worker boolean  NOT NULL,
    doctor_spec varchar(15)  NOT NULL,
    nurse_spec varchar(15)  NOT NULL,
    is_admin boolean  NOT NULL,
    CONSTRAINT Person_pk PRIMARY KEY (pesel)
);

-- Table: Service
CREATE TABLE Service (
    id_service int  NOT NULL,
    price int  NOT NULL,
    room int  NOT NULL,
    Doctor_pesel varchar(11)  NOT NULL,
    CONSTRAINT Service_pk PRIMARY KEY (id_service)
);

-- Table: Tool
CREATE TABLE Tool (
    MedicalEquipment_id int  NOT NULL,
    material int  NOT NULL,
    CONSTRAINT Tool_pk PRIMARY KEY (MedicalEquipment_id)
);

-- foreign keys
-- Reference: Appointment_Person (table: Appointment)
ALTER TABLE Appointment ADD CONSTRAINT Appointment_Person
    FOREIGN KEY (Person_pesel)
    REFERENCES Person (pesel)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Appointment_Service (table: Appointment)
ALTER TABLE Appointment ADD CONSTRAINT Appointment_Service
    FOREIGN KEY (Service_id_service)
    REFERENCES Service (id_service)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: NurseInService_Person (table: NurseInService)
ALTER TABLE NurseInService ADD CONSTRAINT NurseInService_Person
    FOREIGN KEY (Person_pesel)
    REFERENCES Person (pesel)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: NurseInService_Service (table: NurseInService)
ALTER TABLE NurseInService ADD CONSTRAINT NurseInService_Service
    FOREIGN KEY (Service_id_service)
    REFERENCES Service (id_service)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Service_Person (table: Service)
ALTER TABLE Service ADD CONSTRAINT Service_Person
    FOREIGN KEY (Doctor_pesel)
    REFERENCES Person (pesel)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Table_6_MedicalEquipment (table: Machine)
ALTER TABLE Machine ADD CONSTRAINT Table_6_MedicalEquipment
    FOREIGN KEY (MedicalEquipment_id)
    REFERENCES MedicalEquipment (id)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Table_7_MedicalEquipment (table: Tool)
ALTER TABLE Tool ADD CONSTRAINT Table_7_MedicalEquipment
    FOREIGN KEY (MedicalEquipment_id)
    REFERENCES MedicalEquipment (id)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Table_8_MedicalEquipment (table: EquipmentService)
ALTER TABLE EquipmentService ADD CONSTRAINT Table_8_MedicalEquipment
    FOREIGN KEY (MedicalEquipment_id)
    REFERENCES MedicalEquipment (id)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Table_8_Service (table: EquipmentService)
ALTER TABLE EquipmentService ADD CONSTRAINT Table_8_Service
    FOREIGN KEY (Service_id_service)
    REFERENCES Service (id_service)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: dayOfWork_Person (table: DayOfWork)
ALTER TABLE DayOfWork ADD CONSTRAINT dayOfWork_Person
    FOREIGN KEY (pesel)
    REFERENCES Person (pesel)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- End of file.

