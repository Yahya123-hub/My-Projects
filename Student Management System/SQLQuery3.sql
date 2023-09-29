/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Contact]
      ,[Email]
      ,[RegistrationNumber]
      ,[Status]
  FROM [ProjectB].[dbo].[Student]