create database Mazatech;

use Mazatech;

go;

if ((select count(*) from sysobjects where xtype = 'U' and name = 'RabbitMessage') = 0)
begin
	CREATE TABLE RabbitMessage (
		NumeroProtocolo		int				not null
		,NumeroVia			int				null
		,Cpf				varchar(11)		not null
		,Rg					varchar(12)		not null
		,Nome				varchar(200)	not null
		,Pai				varchar(200)	null
		,Mae				varchar(200)	null
		,Foto				image			not null
		,dataHoraEnviada	datetime)

	ALTER TABLE RabbitMessage ADD CONSTRAINT UC_RabbitMessage_Protocolo UNIQUE (NumeroProtocolo);
	ALTER TABLE RabbitMessage ADD CONSTRAINT UC_RabbitMessage_CpfVia UNIQUE (Cpf,NumeroVia);
	ALTER TABLE RabbitMessage ADD CONSTRAINT UC_RabbitMessage_RgVia UNIQUE (Rg,NumeroVia);
end
ELSE
BEGIN
	DROP TABLE RabbitMessage;
	CREATE TABLE RabbitMessage (
		NumeroProtocolo		int				not null
		,NumeroVia			int				null
		,Cpf				varchar(11)		not null
		,Rg					varchar(12)		not null
		,Nome				varchar(200)	not null
		,Pai				varchar(200)	null
		,Mae				varchar(200)	null
		,Foto				image			not null
		,dataHoraEnviada	datetime)

	ALTER TABLE RabbitMessage ADD CONSTRAINT UC_RabbitMessage_Protocolo UNIQUE (NumeroProtocolo);
	ALTER TABLE RabbitMessage ADD CONSTRAINT UC_RabbitMessage_CpfVia UNIQUE (Cpf,NumeroVia);
	ALTER TABLE RabbitMessage ADD CONSTRAINT UC_RabbitMessage_RgVia UNIQUE (Rg,NumeroVia);
END

if ((select count(*) from sysobjects where xtype = 'U' and name = 'RabbitMessageLog') = 0)
begin
	CREATE TABLE RabbitMessageLog (
		RabbitMessageLogId		int				not null identity
		,NumeroProtocolo		int				not null 
		,ErrorDescription		varchar(500)	not	null
		,DataLog				datetime)

	ALTER TABLE RabbitMessageLog ADD CONSTRAINT PK_Person PRIMARY KEY (RabbitMessageLogId);
END
ELSE
BEGIN
	DROP TABLE RabbitMessageLog;
	CREATE TABLE RabbitMessageLog (
		RabbitMessageLogId		int				not null identity
		,NumeroProtocolo		int				not null 
		,ErrorDescription		varchar(500)	not	null
		,DataLog				datetime)

	ALTER TABLE RabbitMessageLog ADD CONSTRAINT PK_Person PRIMARY KEY (RabbitMessageLogId);
END