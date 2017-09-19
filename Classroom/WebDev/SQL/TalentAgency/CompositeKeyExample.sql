USE TalentAgency;
GO

create table PerformersTalents
(
	PerformerID int,
	TalentID int,
	
  CONSTRAINT PerformerTalentID PRIMARY KEY (PerformerID, TalentID),
  CONSTRAINT FK_PerformerID 
      FOREIGN KEY (PerformerID) REFERENCES Performers (PerformerID),
  CONSTRAINT FK_TalentID 
      FOREIGN KEY (TalentID) REFERENCES Talents (TalentID)
)
GO