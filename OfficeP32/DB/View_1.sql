CREATE VIEW View_1 AS SELECT * FROM Employee
inner join dbo.Position P on P.IdPosition = Employee.PositionId
inner join dbo.Skills S on S.IdSkill = Employee.SkillsId