INSERT INTO person (pesel,name,surname,patient,worker,doctor_spec,nurse_spec,is_admin)
VALUES (00000000000,'Emil','Bakula',TRUE,FALSE,'NONE','NONE',FALSE);
INSERT INTO person (pesel,name,surname,patient,worker,doctor_spec,nurse_spec,is_admin)
VALUES (00000000001,'Em','Ula',FALSE,TRUE,'PSYCHIATRY','NONE',FALSE);
INSERT INTO person (pesel,name,surname,patient,worker,doctor_spec,nurse_spec,is_admin)
VALUES (00000000002,'Emi','Ulat',FALSE,TRUE,'PSYCHIATRY','NONE',FALSE);

INSERT INTO service(id_service,price,room,doctor_pesel)
VALUES (0,100,1,00000000001);

INSERT INTO appointment(person_pesel,service_id_service,start_appointment,end_appointment,is_cancelled)
VALUES(000000000000,0,to_timestamp('2017-03-31 9:30:20','YYYY-MM-DD HH:MI:SS'),to_timestamp('2017-03-31 10:30:20','YYYY-MM-DD HH:MI:SS'),0);
