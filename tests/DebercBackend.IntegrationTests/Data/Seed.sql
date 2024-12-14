
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
    ('The winners', 0, 0, 1),
    ('The loosers', 0, 2, 3),
    ('The winners', 162, 0, 1),
    ('The loosers', 324, 2, 3),
    ('The winners', 1001, 0, 1),
    ('The loosers', 530, 2, 3);

INSERT INTO Games
    (Name, FirstTeamId, SecondTeamId, DealerId, OpenPoints, Status)
VALUES
    ('Test game1', 0, 1, 2, 1001, 0),
    ('Test game2', 0, 1, 1, 1001, 1),
    ('Test game3', 1, 0, 0, 501, 2),
    ('Test game4', 1, 0, 2, 501, 3),
    ('Test game5', 0, 1, 1, 1001, 1);