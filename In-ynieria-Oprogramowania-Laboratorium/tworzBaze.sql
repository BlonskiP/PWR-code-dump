CREATE TABLE City(
    city_id INTEGER NOT NULL GENERATED always AS IDENTITY,
    name varchar(50) not null,
    country varchar(50) not null,
    CONSTRAINT city_pk PRIMARY key (city_id) 
);

CREATE TABLE Hotel (
    hotel_id INTEGER NOT NULL GENERATED ALWAYS AS IDENTITY,
    city_id integer not null,
    name varchar(50) not null,
    description varchar(255),
    address varchar(255) not null,
    stars integer not null,
    photo varchar(255) not null,
    CONSTRAINT hotel_pk PRIMARY KEY ( hotel_id ),
    FOREIGN KEY (city_id) REFERENCES City (city_id)
);

create table Room (
    room_id integer not null generated always as identity,
    hotel_id integer not null,
    number integer not null,
    size integer not null,
    price integer not null,
    description varchar(255),
    photo varchar(255) not null,
    CONSTRAINT room_pk PRIMARY KEY ( room_id ),
    FOREIGN KEY (hotel_id) REFERENCES Hotel (hotel_id)
);

create table Client (
    client_id integer not null generated always as identity,
    email varchar(50) not null,
    password varchar(50) not null,
    firstName varchar(50) not null,
    lastName varchar(50) not null,   
    phone varchar(50) not null,
    address varchar(50) not null,
    constraint client_pk primary key (client_id)
);

create table Reservation (
    reservation_id integer not null generated always as identity,
    number varchar(50) not null, --robione z diagramu klas, możliwe, że w bazie niepotrzebne pole
    startDate date not null,
    endDate date not null,
    client_id integer not null,
    room_id integer not null,
    FOREIGN KEY (client_id) REFERENCES Client (client_id),
    FOREIGN KEY (room_id) REFERENCES Room (room_id),
    constraint reservation_pk primary key (reservation_id)
);

insert into city (name, country) values ('Wrocław', 'Polska');
insert into city (name, country) values ('Londyn', 'Wielka Brytania');
insert into city (name, country) values ('Kraków', 'Polska');


insert into Hotel (city_id ,name, descritpion, address, stars, photo) values (1, 'Test BnB', 'Najlepszy hotel w mieście', 'ul. Apache Derby 17', 3, 'photo.png');

insert into Hotel (city_id ,name, descritpion, address, stars, photo) values (3, 'Ibis Budget', 'Najtańszy hotel w mieście', 'Downing Street 5', 5, 'screen.png');

insert into room (hotel_id, number, size, price, description, photo) values (1, 1, 3, 300, 'Trzyosobowy pokój z widokiem na rynek', 'room1.png');
insert into room (hotel_id, number, size, price, description, photo) values (2, 21, 2, 150, 'Dwuosobowy pokój z widokiem na morze', 'roomphoto1.png');
insert into room (hotel_id, number, size, price, description, photo) values (2, 22, 1, 76, 'Jednoosobowy pokój z łazienką', 'roomphoto2.png');

insert into client (email, password, firstName, lastName, phone, address) values ('abd@gmail.com', '12345678', 'Jan', 'Kowalski', '999222111', 'pl. Grunwaldzi 2/3 Wrocław');
insert into client (email, password, firstName, lastName, phone, address) values ('xyz@gmail.com', '12222228', 'Adam', 'Nowak', '000222111', 'ul. Czerwona 7 Szczecin');

insert into reservation (number, startDate, endDate, client_id, room_id) values ('1', '2019-03-20','2019-03-22',1,2);
insert into reservation (number, startDate, endDate, client_id, room_id) values ('2', '2019-05-02','2019-05-11',2,3);

