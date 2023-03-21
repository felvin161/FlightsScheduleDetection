CREATE DATABASE [FlightsScheduleDB]
GO

USE [FlightsScheduleDB]
Go

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.routes
	(
	route_id int NOT NULL,
	origin_city_id int NOT NULL,
	destination_city_id int NOT NULL,
	departure_date date NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.routes ADD CONSTRAINT
	PK_routes PRIMARY KEY CLUSTERED 
	(
	route_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_routes_origin_city_id ON dbo.routes
	(
	origin_city_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_routes_destination_city_id ON dbo.routes
	(
	destination_city_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_routes_departure_date ON dbo.routes
	(
	departure_date
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.routes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.routes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.flights
	(
	flight_id int NOT NULL,
	route_id int NOT NULL,
	departure_time datetime NOT NULL,
	arrival_time datetime NOT NULL,
	airline_id int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.flights ADD CONSTRAINT
	PK_flights PRIMARY KEY CLUSTERED 
	(
	flight_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_flights_airline_Id ON dbo.flights
	(
	flight_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.flights ADD CONSTRAINT
	FK_flights_routes FOREIGN KEY
	(
	route_id
	) REFERENCES dbo.routes
	(
	route_id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.flights SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.subscriptions
	(
	agency_id int NOT NULL,
	origin_city_id int NOT NULL,
	destination_city_id int NOT NULL
	)  ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_subscriptions_agency_id ON dbo.subscriptions
	(
	agency_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_subscriptions_origin_city_id ON dbo.subscriptions
	(
	agency_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_subscriptions_destination_city_id ON dbo.subscriptions
	(
	agency_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.subscriptions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT