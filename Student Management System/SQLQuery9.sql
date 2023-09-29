/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [StudentId]
      ,[AssessmentComponentId]
      ,[RubricMeasurementId]
      ,[EvaluationDate]
  FROM [ProjectB].[dbo].[StudentResult]

  Select * from StudentResult where day(EvaluationDate)=8