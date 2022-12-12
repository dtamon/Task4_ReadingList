insert into Authors values
('Andrzej', 'Sapkowski'),
('John R.R.', 'Tolkien'),
('George R.R.', 'Martin');

insert into Books values
('Blood of Elves', 1, 1, null),
('Time of Contempt', 1, 0, null),
('Baptism of Fire', 1, 0, 1),
('The Tower of the Swallow', 1, 0, 2),
('The Lady of the Lake', 1, 0, 3),
('Silmarillion', 2, 1, null),
('The Lord of the Rings', 2, 1, null),
('Game of Thrones', 3, 0, 4),
('Fire and Blood', 3, 0, 5);

Select * from Books b inner join Authors a on b.AuthorId = a.Id order by Priority asc


