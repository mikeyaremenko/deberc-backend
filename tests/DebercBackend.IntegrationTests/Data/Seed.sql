
INSERT INTO Players
    (Name, Password, Image, [Index])
VALUES
    ('John', 'John123', NULL, 0),
    ('Matthew', 'Matthew123', NULL, 1),
    ('Tim', 'Tim123', NULL, 2),
    ('Gregor', 'Gregor123', NULL, 3);

INSERT INTO Teams
    (Name, Score, FirstPlayerId, SecondPlayerId)
VALUES
    ('The winners', 0, 1, 2),
    ('The loosers', 0, 3, 4),
    ('The winners', 162, 1, 2),
    ('The loosers', 324, 3, 4),
    ('The winners', 1001, 1, 2),
    ('The loosers', 530, 3, 4);

INSERT INTO Games
    (Name, FirstTeamId, SecondTeamId, DealerId, OpenPoints, Status)
VALUES
    ('Test game1', 1, 2, 2, 1001, 0),
    ('Test game2', 1, 2, 1, 1001, 1),
    ('Test game3', 2, 1, 3, 501, 2),
    ('Test game4', 2, 1, 2, 501, 3),
    ('Test game5', 1, 2, 1, 1001, 1);
