/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [StudentId]
      ,[AssessmentComponentId]
      ,[RubricMeasurementId]
      ,[EvaluationDate]
  FROM [ProjectB].[dbo].[StudentResult]



  Select *
  from Clo cl
  join Rubric r
  on cl.id=r.CloId
  join RubricLevel rl
  on r.id=rl.RubricId
  join StudentResult sr
  on rl.id=sr.RubricMeasurementId

   Select *
  from Assessment a
  join AssessmentComponent ac
  on a.id=ac.AssessmentId
  join StudentResult sr
  on ac.id=sr.AssessmentComponentId

  
  Select *
  from Student s
  join StudentAttendance sa
  on s.Id=sa.StudentId
  join ClassAttendance ca
  on sa.AttendanceId=ca.Id
  where s.Status=5
