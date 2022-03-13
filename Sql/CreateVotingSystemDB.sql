--
-- File generated with SQLiteStudio v3.3.3 on Sat Mar 12 20:11:11 2022
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Candidates
CREATE TABLE [Candidates] (
	[CandidateId]	integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	[VoteEventId]	integer NOT NULL,
	[CandidateName]	varchar(255) NOT NULL COLLATE NOCASE
,
    FOREIGN KEY ([VoteEventId])
        REFERENCES [VoteEvents]([VoteEventId])
);

-- Table: Users
CREATE TABLE [Users] (
	[UserId]	integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	[UserName]	varchar(50) NOT NULL COLLATE NOCASE,
	[PasswordHash]	varchar(255) NOT NULL COLLATE NOCASE,
	[UserRole]	integer NOT NULL,
	[FirstName]	varchar(50) NOT NULL COLLATE NOCASE,
	[LastName]	varchar(50) NOT NULL COLLATE NOCASE,
	[EntryDateTime]	datetime NOT NULL COLLATE NOCASE,
	[UpdateDateTime]	datetime NOT NULL COLLATE NOCASE

);

-- Table: VoteEvents
CREATE TABLE [VoteEvents] (
	[VoteEventId]	integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	[EventName]	varchar(255) NOT NULL COLLATE NOCASE

);

-- Table: Votes
CREATE TABLE [Votes] (
	[VoteId]	integer PRIMARY KEY AUTOINCREMENT NOT NULL,
	[VoteEventId]	integer NOT NULL,
	[UserId]	integer NOT NULL,
	[CandidateId]	integer NOT NULL
,
    FOREIGN KEY ([VoteEventId])
        REFERENCES [VoteEvents]([VoteEventId]),
    FOREIGN KEY ([UserId])
        REFERENCES [Users]([UserId]),
    FOREIGN KEY ([CandidateId])
        REFERENCES [Candidates]([CandidateId])
);

-- Trigger: fkd_Candidates_VoteEventId_VoteEvents_VoteEventId
CREATE TRIGGER [fkd_Candidates_VoteEventId_VoteEvents_VoteEventId] Before Delete ON [VoteEvents] BEGIN SELECT RAISE(ROLLBACK, 'delete on table VoteEvents violates foreign key constraint fkd_Candidates_VoteEventId_VoteEvents_VoteEventId') WHERE (SELECT VoteEventId FROM Candidates WHERE VoteEventId = OLD.VoteEventId) IS NOT NULL;  END;

-- Trigger: fkd_Votes_CandidateId_Candidates_CandidateId
CREATE TRIGGER [fkd_Votes_CandidateId_Candidates_CandidateId] Before Delete ON [Candidates] BEGIN SELECT RAISE(ROLLBACK, 'delete on table Candidates violates foreign key constraint fkd_Votes_CandidateId_Candidates_CandidateId') WHERE (SELECT CandidateId FROM Votes WHERE CandidateId = OLD.CandidateId) IS NOT NULL;  END;

-- Trigger: fkd_Votes_UserId_Users_UserId
CREATE TRIGGER [fkd_Votes_UserId_Users_UserId] Before Delete ON [Users] BEGIN SELECT RAISE(ROLLBACK, 'delete on table Users violates foreign key constraint fkd_Votes_UserId_Users_UserId') WHERE (SELECT UserId FROM Votes WHERE UserId = OLD.UserId) IS NOT NULL;  END;

-- Trigger: fkd_Votes_VoteEventId_VoteEvents_VoteEventId
CREATE TRIGGER [fkd_Votes_VoteEventId_VoteEvents_VoteEventId] Before Delete ON [VoteEvents] BEGIN SELECT RAISE(ROLLBACK, 'delete on table VoteEvents violates foreign key constraint fkd_Votes_VoteEventId_VoteEvents_VoteEventId') WHERE (SELECT VoteEventId FROM Votes WHERE VoteEventId = OLD.VoteEventId) IS NOT NULL;  END;

-- Trigger: fki_Candidates_VoteEventId_VoteEvents_VoteEventId
CREATE TRIGGER [fki_Candidates_VoteEventId_VoteEvents_VoteEventId] Before Insert ON [Candidates] BEGIN SELECT RAISE(ROLLBACK, 'insert on table Candidates violates foreign key constraint fki_Candidates_VoteEventId_VoteEvents_VoteEventId') WHERE (SELECT VoteEventId FROM VoteEvents WHERE VoteEventId = NEW.VoteEventId) IS NULL;  END;

-- Trigger: fki_Votes_CandidateId_Candidates_CandidateId
CREATE TRIGGER [fki_Votes_CandidateId_Candidates_CandidateId] Before Insert ON [Votes] BEGIN SELECT RAISE(ROLLBACK, 'insert on table Votes violates foreign key constraint fki_Votes_CandidateId_Candidates_CandidateId') WHERE (SELECT CandidateId FROM Candidates WHERE CandidateId = NEW.CandidateId) IS NULL;  END;

-- Trigger: fki_Votes_UserId_Users_UserId
CREATE TRIGGER [fki_Votes_UserId_Users_UserId] Before Insert ON [Votes] BEGIN SELECT RAISE(ROLLBACK, 'insert on table Votes violates foreign key constraint fki_Votes_UserId_Users_UserId') WHERE (SELECT UserId FROM Users WHERE UserId = NEW.UserId) IS NULL;  END;

-- Trigger: fki_Votes_VoteEventId_VoteEvents_VoteEventId
CREATE TRIGGER [fki_Votes_VoteEventId_VoteEvents_VoteEventId] Before Insert ON [Votes] BEGIN SELECT RAISE(ROLLBACK, 'insert on table Votes violates foreign key constraint fki_Votes_VoteEventId_VoteEvents_VoteEventId') WHERE (SELECT VoteEventId FROM VoteEvents WHERE VoteEventId = NEW.VoteEventId) IS NULL;  END;

-- Trigger: fku_Candidates_VoteEventId_VoteEvents_VoteEventId
CREATE TRIGGER [fku_Candidates_VoteEventId_VoteEvents_VoteEventId] Before Update ON [Candidates] BEGIN SELECT RAISE(ROLLBACK, 'update on table Candidates violates foreign key constraint fku_Candidates_VoteEventId_VoteEvents_VoteEventId') WHERE (SELECT VoteEventId FROM VoteEvents WHERE VoteEventId = NEW.VoteEventId) IS NULL;  END;

-- Trigger: fku_Votes_CandidateId_Candidates_CandidateId
CREATE TRIGGER [fku_Votes_CandidateId_Candidates_CandidateId] Before Update ON [Votes] BEGIN SELECT RAISE(ROLLBACK, 'update on table Votes violates foreign key constraint fku_Votes_CandidateId_Candidates_CandidateId') WHERE (SELECT CandidateId FROM Candidates WHERE CandidateId = NEW.CandidateId) IS NULL;  END;

-- Trigger: fku_Votes_UserId_Users_UserId
CREATE TRIGGER [fku_Votes_UserId_Users_UserId] Before Update ON [Votes] BEGIN SELECT RAISE(ROLLBACK, 'update on table Votes violates foreign key constraint fku_Votes_UserId_Users_UserId') WHERE (SELECT UserId FROM Users WHERE UserId = NEW.UserId) IS NULL;  END;

-- Trigger: fku_Votes_VoteEventId_VoteEvents_VoteEventId
CREATE TRIGGER [fku_Votes_VoteEventId_VoteEvents_VoteEventId] Before Update ON [Votes] BEGIN SELECT RAISE(ROLLBACK, 'update on table Votes violates foreign key constraint fku_Votes_VoteEventId_VoteEvents_VoteEventId') WHERE (SELECT VoteEventId FROM VoteEvents WHERE VoteEventId = NEW.VoteEventId) IS NULL;  END;

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
