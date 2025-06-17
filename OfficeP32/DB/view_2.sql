CREATE VIEW View_2 AS SELECT Employee.NameEmployee, S.NameSkill, P.NamePosition FROM Employee
inner join dbo.Position P on P.IdPosition = Employee.PositionId
inner join dbo.Skills S on S.IdSkill = Employee.SkillsId;