

create database muhammedkilic
GO
USE muhammedkilic
GO




create table [Apartments] (
[Id] [int] identity,
[UserId] [int],
[BlockNo] [int],
[HouseType] [nvarchar] (max) NULL,
[ApartmentNo] [int],
[Full] [bit],
[HomeOwner] [bit]);



set identity_insert [Apartments] on;


insert [Apartments] ([Id],[UserId],[BlockNo],[HouseType],[ApartmentNo],[Full],[HomeOwner])
select 1,2,1,N'2+1',6,1,1 UNION ALL
select 2002,3,1,N'2+1',1,1,1 UNION ALL
select 2003,2002,1,N'2+1',2,1,1 UNION ALL
select 2004,3002,1,N'2+1',3,1,1 UNION ALL
select 2006,3005,1,N'2+1',5,1,0 UNION ALL
select 2007,3006,1,N'2+1',7,0,1 UNION ALL
select 2008,3003,1,N'2+1',8,1,1 UNION ALL
select 2009,3007,1,N'2+1',9,1,1 UNION ALL
select 2010,3008,1,N'2+1',10,1,0 UNION ALL
select 2011,3011,2,N'2+1',1,1,1;

set identity_insert [Apartments] off;


create table [Bills] (
[Id] [int] identity,
[UserId] [int],
[Type] [int],
[Month] [int],
[Year] [nvarchar] (max) NULL,
[Amount] [decimal] (18,2),
[IsPaid] [bit]);



set identity_insert [Bills] on;


insert [Bills] ([Id],[UserId],[Type],[Month],[Year],[Amount],[IsPaid])
select 1,2,1,1,N'2022',50.00,1 UNION ALL
select 2,2,2,1,N'2022',100.00,1 UNION ALL
select 3,2,2,1,N'2022',250.00,1 UNION ALL
select 4,2,3,1,N'2022',250.00,0 UNION ALL
select 1002,2003,1,1,N'2022',50.00,0 UNION ALL
select 1003,2003,2,1,N'2022',150.00,0 UNION ALL
select 1004,2003,3,1,N'2022',200.00,0 UNION ALL
select 1005,2003,4,1,N'2022',75.00,0 UNION ALL
select 2002,3,1,2,N'2022',50.00,1 UNION ALL
select 2003,3,2,2,N'2022',150.00,1 UNION ALL
select 2004,3,3,2,N'2022',250.00,1 UNION ALL
select 2005,3,4,2,N'2022',200.00,1 UNION ALL
select 2006,3002,4,2,N'2022',200.00,0 UNION ALL
select 2007,3002,3,2,N'2022',250.00,0 UNION ALL
select 2008,3002,2,2,N'2022',200.00,0 UNION ALL
select 2009,3002,1,2,N'2022',50.00,0 UNION ALL
select 2010,3002,2,2,N'2022',150.00,0 UNION ALL
select 2011,3002,3,2,N'2022',200.00,0 UNION ALL
select 2012,3002,4,2,N'2022',170.00,0 UNION ALL
select 2013,3011,1,2,N'2022',50.00,1 UNION ALL
select 2014,3011,2,2,N'2022',250.00,1 UNION ALL
select 2015,3011,3,2,N'2022',350.00,0 UNION ALL
select 2016,3011,4,2,N'2022',175.00,0;

set identity_insert [Bills] off;




create table [Messages] (
[Id] [int] identity,
[UserId] [int],
[ReaderRole] [int],
[Email] [nvarchar] (max) NULL,
[MessageText] [nvarchar] (max) NULL,
[IsRead] [bit],
[Date] [datetime2]);



set identity_insert [Messages] on;


insert [Messages] ([Id],[UserId],[ReaderRole],[Email],[MessageText],[IsRead],[Date])
select 2002,3011,2,N'mehmethnbl@mail.com',N'Merhaba Aidat ve Elektrik faturasını ödedim. Doğalgaz ve Su faturasını yarın ödeyeceğim.',1,'2022-08-12 16:30:01.8707190' UNION ALL
select 2009,1,1,N'efe@mail.com',N'Merhaba değerli apartman sakinler 12 Şubat 2022 tarihinde 10:00''da apartman toplantısı olacaktır.',1,'2022-08-12 16:55:39.8399590';

set identity_insert [Messages] off;



--create table [UserPasswords] (
--[Id] [int] identity,
--[UserId] [int],
--[PasswordSalt] [varbinary] (max) NULL,
--[PasswordHash] [varbinary] (max) NULL);



set identity_insert [UserPasswords] on;


insert [UserPasswords] ([Id],[UserId],[PasswordSalt],[PasswordHash])
select 1,1,0x3DD4B2784147659C47B55046231AE81960F62C27FA955057690952A06C07C728DFE6C75964AD8F611FC785E03C6FF63A218E8356A9B4C1AA26944B32D9A1FD7E658634FA114C718904358248D59EA055A0C488C85145113AE923D44B5DA39D4C36D9D3D413C83E432A659A2A815C30226334D09703766FC067F4BD76F9909101,0x1C3B62CC85C93E5CD852C18A9218B7E4EBA34E21ECEB52981B9F3C8DD617BE961142894115B25D44F059941FD9352D15BA8922EB1CA8B7895A0ED04120AC98BF UNION ALL
select 2,2,0x8929DB9BA01462FF04602E14D8487CC6835FD09F23844AB5CA13C2A7E70AC7C1821503CFA8CEFDEB2A059641A2DC2ECC7A1743CBEF876BE5723117C2C723A72FED876078DA7AB046595506484E02D65D98968D448115B17C43BA6F9E24DE85AB054D67034AB028C7861406509A6FC9884A9A200000F8283A40D8D8DF7F0FFC74,0x67EB4C38D71682FC1DDDE81DDF1276D386AFB8909C0A806B7CB33F0C9948349E97FDF85A425D403E4A9176A825D8BBFC1C149ACBDC0AECBB7B6987A77EA0E6A4 UNION ALL
select 3,3,0x38B3B2DF1AD4E7D89C15E5420E8A21ED4038D5F02A620C08F72BDA5F743CA6B57DF0CFB3672DF0530A55E264856F2672B3C575E7C8ABF39633AF7A3DADED3F1CDDAE5B89C3D8C47D5CCD66DC437BA22EB71FB784D765A28785116CCEF72B8A1389EEFAF7EEA15831758C7C4134BED1BF9CD04369517E278CEFCC7EC3027CF1B6,0x1E8141989BE89F5CF996C4AD254C269C0A35C6CC9C89B17A1C792C3075B549E1B299F8F8C731402A8E25F13753A77DC088A1B8D62F686316367888E773CFBF69 UNION ALL
select 2002,2002,0x22C7BEB84702C2CE6E7AEABAD3A03B5615358F220AA409E65C236EC478AE088EC9CE3C62A0E74A916404424A7AC0F950D1D4EDED842F433D41FEE1E0F745BC39BD5D472688AB337D4465BE0FE02250CC1D67596F9BBF7A1B9A52DD527D97F7262E1DD515B072F0C08CF11168404645D898D355560BDA59FCF8D6D251F7D265B4,0x103855AC38E3505242C8FDF1E6052BE95A05685FA10698154E0891EDC0B7CBE67BD95D204CDDE15021FEFF789E474A969D2AD2ED0499C86059519C1DC7A12F10 UNION ALL
select 3002,3002,0xD7EB731E187278E9D8078E4B033AFE509D25EDC1F987D122475762C211571E6CD978E7C79E763D196D80E948AD1E9967D0B45AC253696755BA433369FBDC5C95FA192FEF87F7E8F2BCFBCE244A1F2EF43C6D28CDEFFE46FB63317338A9B38670C77AFA454CE470AF919612CB34544512B93C214D605B1AA16833F1BF1B8AB487,0xC0F92B01F99B58308339D017AB3F3E6B4CE7A756479E155CC0A7E5E14E4A3D7E957BB9CDA8E930C3E0640255D7C53B5BDDC6BBE8818320BF064B0C1BAF55E426 UNION ALL
select 3003,3003,0xF5977739E378C1702CFBDA1B0C0D022793BBDC07FC925043354E3E7EDD6B6FDAE1115ECD2E027CAD3EE203AE87BAD1D9EE107AC580ABDA09B10172931E5C852B8A159138434D77331573A734C29A6660B56BF1AE3D4ED1579A9F73395509C9F0F8B746E24EC80A37490581970342EC2F4D85F07F9B2B68C3AD16FADF77A03FF1,0xC95AD86EC8740AFCD37BC78F8EC1BFC5766B0EC5A619F35C5FA04185784970D2B8E2EA2313AD6FB897D5DFC06CE56D8F182DBB81E138110AED474ABE613E0689 UNION ALL
select 3004,3004,0x02B85350CFAEFE180077CDF50D2F6C151251149130336B93C7263D951AD57409B771B8A836B008A9C0F06E15BCD9491630441BCBE88E46C90CB884907E209EEC8B14F443E31D0002603B669F09E10C8AC036DDBBAD43CF0C3190146D6E069BF85537267B29FB9C4DE02E1AF5A1CFE859F69D81340852DAFDFB3E984B74D6079D,0x974D2EED8D64275E1CB17636AAE88039E3B49D1F432208749A92CD076403D2C6AD06EC20F81F588C5EAF8018F8DB244AAD33050C2F5956F260B6BA7607DD8013 UNION ALL
select 3006,3006,0x93C6C37318B93E295D5221882CE590DCA6CE99E3DFB2034BA2CEC18EC799FCD4C54F1C803ED5C789114B0296C8E839064C0AB603E841FD67049E9193357BD47ADBE0897E023E7F4AA532032CB75921EB7450C06C41300EA3F36D3C27327D3463858621E2CBD26854143414E27B1948A48A19196620323B41B40347664CC06B11,0x1F027083CDA99B6CDD37FE72CF4D123CFFF6E87D7729A2CE87C4C24D06D4A3D3E7A3047C8CF3F3080DB682D0A2C16D477DE4CE9E1C5EB6A0C8073800FA86D947 UNION ALL
select 3007,3007,0xC203F2BF15A2E13C8425D8C9FFC5C5396016172241C204BCC160937B8AEE0583FBD6ECF7E76AF3BF69DF4552F89C6D76BCCD67F7C612D2DBC7E27BCFCD07FBE7BA8AC4F103F73FCB19AF07279FF5A9BC3DF93FB98FC8CBDE9B4268CF57A456DBB94DC9B6E1FE2287C1386345C6886956BAA4878C2295104B94B2A009DC86BE81,0x640E36D80EC1D32DE1C6F93B52AB8954FA13E887A1D33BDE5448EB9D626E462D786AD0FA778A6BAEA06C18D4D98BFD0F02BC13C1F9A415E6ED8B79F8DF0C633C UNION ALL
select 3008,3008,0x7E067450B7D2BA82BCF15A68092A38171440A7D77E002678C9E2EC1983CD3E7DFED798829E697BBBA81EF4B297375270B7F0D12747E56DB141941FF8847253BAE7B1A5468130C03B301B9804B31B90C7A5AA256E6A120812B8A16002E84BEF8BD671792B71C9228A9C889F0AFE05A77D5617395B04B06D64BE6BB8ED0D31ADC3,0x5104DF822F78CEE871621629822308A61A89F85E0BA0B0667EF2830FBCBC5276B00D89C0305FADAB61FFC29B562464221BAB2A6A46B279A677B69E8CC16879EE UNION ALL
select 3009,3009,0x3A260D99FB6CC3784B806F15B4D12BDF20123FE7F1BE920104C636EEFB6D550C2E5A90EF82A735B8AA6FFA716E7D11BF0CB591CB510F47B6DDF60A71E6AAFB0CD812782563BEBCC467CF4FDEDF235A84F0702C60B121D20B1367F6570500BD2D40B9172462DD7934906189CE85CDCD4ABAE6BDA6ADF6492164F6F16C9157395C,0xD58B663265A03B1C57B2E94C9DF50A815B1978BBECAB1D221AA8A0238B0DDFC7DFB579987ECC481EC6BC9B88865A79AB8D21D6004118B39C7FE19C44D09D705D UNION ALL
select 3011,3011,0xC56E26116F4322C1699244CDDBBF6A92B5A6746E96926590CF09D5025169CADC3F25C2F53B6EFFB215F422AD098D94D8FDCB3DA6D863D17E10F6B01FD8CDA7B177289C8587C23E6AB194AA98EDE2B377C78A8EC5C5FCBBCA2896B2C17FF65A1E58EDC2F4BC1A38163AF408EBCCA2695318367300B9D40C93075B6B6CEF3ADF30,0xC8684A5404FB904ABA1C06A3ADDB1251F1E7F02A3D0B9EC0181953B8844E9BD1B875B615345FC9BA899F7AF410DD07075249F25EA52354B90F70CB3477987F47;

set identity_insert [UserPasswords] off;


--create table [Users] (
--[Id] [int] identity,
--[Name] [nvarchar] (max) NULL,
--[Surname] [nvarchar] (max) NULL,
--[TcNo] [nvarchar] (max) NULL,
--[Email] [nvarchar] (max) NULL,
--[PhoneNumber] [nvarchar] (max) NULL,
--[CarPlate] [nvarchar] (max) NULL,
--[Role] [int]);



set identity_insert [Users] on;


insert [Users] ([Id],[Name],[Surname],[TcNo],[Email],[PhoneNumber],[CarPlate],[Role])
select 1,N'Efe',N'Kılıç',N'11028883214',N'efe@mail.com',N'5559081254',N'34EK1990',2 UNION ALL
select 2,N'Deniz',N'Nehir',N'1103392014',N'deniz@mail.com',N'5550972254',N'32DN1990',1 UNION ALL
select 3,N'Esma',N'Kılıç',N'11032229912',N'esma@mail.com',N'5077249012',N'34ESM1991',1 UNION ALL
select 2002,N'Pelin',N'Demir',N'11043332265',N'pelin@mail.com',N'5053216644',N'33PLN1990',1 UNION ALL
select 3002,N'Erdem',N'Bahçeci',N'11000223454',N'erdem@mail.com',N'5071230055',N'34ERDM34',1 UNION ALL
select 3003,N'Elif',N'Aydın',N'11330227754',N'elif@mail.com',N'5053216655',N'34ELFM34',1 UNION ALL
select 3004,N'Zeki',N'Can',N'10339945321',N'zeki@mail.com',N'5339112400',N'34ZK34',1 UNION ALL
select 3006,N'Sedat',N'Somun',N'44005533992',N'sedat@mail.com',N'5059993421',N'22DGK012',1 UNION ALL
select 3007,N'ebru',N'taşçı',N'119988772210',N'ebru@mail.com',N'5549081133',N'---',1 UNION ALL
select 3008,N'kardelen',N'adalı',N'99887700321',N'kardelen@mail.com',N'5363890011',N'---',1 UNION ALL
select 3009,N'Kaan',N'Atalı',N'11046667832',N'kaan@mail.com',N'5078287321',N'35PLT1912',1 UNION ALL
select 3011,N'Mehmet',N'Hanbal',N'11111111111',N'mehmethnbl@mail.com',N'5078287391',N'34HNB1994',1;

set identity_insert [Users] off;



--create table [Logs] (
--[Id] [int] identity,
--[MessageTemplate] [nvarchar] (max) NULL,
--[Level] [nvarchar] (max) NULL,
--[TimeStamp] [datetime] NULL,
--[Exception] [nvarchar] (max) NULL);



set identity_insert [Logs] on;


insert [Logs] ([Id],[MessageTemplate],[Level],[TimeStamp],[Exception])
select 1,N'{ error = A connection was successfully established with the server, but then an error occurred during the pre-login handshake. (provider: TCP Provider, error: 0 - No such file or directory), innerException = System.ComponentModel.Win32Exception (2): No such file or directory, statusCode = InternalServerError }',N'Error','2022-08-10 13:02:54.123',NULL UNION ALL
select 2,N'{ error = Object reference not set to an instance of an object., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 13:03:35.697',NULL UNION ALL
select 3,N'{ error = Database operation expected to affect 1 row(s) but actually affected 0 row(s). Data may have been modified or deleted since entities were loaded. See http://go.microsoft.com/fwlink/?LinkId=527962 for information on understanding and handling optimistic concurrency exceptions., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 13:08:39.473',NULL UNION ALL
select 4,N'{ error = This Id is not valid., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 13:10:41.470',NULL UNION ALL
select 5,N'{ error = This Id is not valid., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 13:13:59.253',NULL UNION ALL
select 6,N'{ error = There is no record in this id in the database., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 13:14:18.547',NULL UNION ALL
select 7,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
Int32 -> Message
System.Int32 -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 21:43:39.883',NULL UNION ALL
select 8,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
Int32 -> Message
System.Int32 -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 21:50:58.770',NULL UNION ALL
select 9,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
Int32 -> Message
System.Int32 -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 21:56:01.620',NULL UNION ALL
select 10,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
UpdateMessageRequest -> Message
DTO.Message.UpdateMessageRequest -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:06:03.123',NULL UNION ALL
select 11,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
UpdateMessageRequest -> Message
DTO.Message.UpdateMessageRequest -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:14:41.293',NULL UNION ALL
select 12,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
UpdateMessageRequest -> Message
DTO.Message.UpdateMessageRequest -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:21:50.990',NULL UNION ALL
select 13,N'{ error = Missing type map configuration or unsupported mapping.

Mapping types:
UpdateMessageRequest -> Message
DTO.Message.UpdateMessageRequest -> Models.Entities.Message, innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:24:35.003',NULL UNION ALL
select 14,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:39:43.070',NULL UNION ALL
select 15,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:41:14.467',NULL UNION ALL
select 16,N'{ error = There is no record in this id in the database., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:41:28.417',NULL UNION ALL
select 17,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:42:39.657',NULL UNION ALL
select 18,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:45:22.537',NULL UNION ALL
select 19,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:45:38.903',NULL UNION ALL
select 20,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:45:56.287',NULL UNION ALL
select 21,N'{ error = The instance of entity type ''Bill'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:48:23.103',NULL UNION ALL
select 22,N'{ error = The instance of entity type ''User'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:52:03.760',NULL UNION ALL
select 23,N'{ error = The instance of entity type ''User'' cannot be tracked because another instance with the key value ''{Id: 1002}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 22:59:14.737',NULL UNION ALL
select 24,N'{ error = This email is not valid., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 23:01:09.493',NULL UNION ALL
select 25,N'{ error = The instance of entity type ''User'' cannot be tracked because another instance with the key value ''{Id: 3}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 23:02:13.837',NULL UNION ALL
select 26,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the key value ''{Id: 2}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-10 23:02:48.810',NULL UNION ALL
select 1002,N'{ error = The instance of entity type ''Bill'' cannot be tracked because another instance with the key value ''{Id: 1005}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-11 14:42:37.403',NULL UNION ALL
select 1003,N'{ error = The instance of entity type ''Bill'' cannot be tracked because another instance with the key value ''{Id: 1005}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-11 14:47:10.163',NULL UNION ALL
select 1004,N'{ error = Database operation expected to affect 1 row(s) but actually affected 0 row(s). Data may have been modified or deleted since entities were loaded. See http://go.microsoft.com/fwlink/?LinkId=527962 for information on understanding and handling optimistic concurrency exceptions., innerException = , statusCode = InternalServerError }',N'Error','2022-08-11 14:48:26.733',NULL UNION ALL
select 1005,N'{ error = The instance of entity type ''User'' cannot be tracked because another instance with the key value ''{Id: 2003}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-11 14:53:38.233',NULL UNION ALL
select 1006,N'{ error = The instance of entity type ''User'' cannot be tracked because another instance with the key value ''{Id: 2002}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-11 15:05:19.057',NULL UNION ALL
select 1007,N'[{"BillId":1,"Amount":50,"CreditCardNumber":"1234123412341234","Cvc":"123"}]',N'Information','2022-08-11 18:55:33.567',NULL UNION ALL
select 1008,N'[{"BillId":1,"Amount":50,"CreditCardNumber":"1234123412341234","Cvc":"123"}]',N'Information','2022-08-11 19:09:50.283',NULL UNION ALL
select 1009,N'[{"BillId":1,"Amount":50,"CreditCardNumber":"12341234341234","Cvc":"123"}]',N'Information','2022-08-11 19:46:12.737',NULL UNION ALL
select 1010,N'[{"BillId":1,"Amount":50,"CreditCardNumber":"12341234341234","Cvc":"123"}]',N'Information','2022-08-11 19:48:14.910',NULL UNION ALL
select 2002,N'[{"BillId":2,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"12"}]',N'Information','2022-08-11 23:45:27.497',NULL UNION ALL
select 2003,N'[{"BillId":2,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"12"}]',N'Information','2022-08-11 23:54:39.863',NULL UNION ALL
select 2004,N'[{"BillId":2,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"12"}]',N'Information','2022-08-11 23:59:16.993',NULL UNION ALL
select 2005,N'[{"BillId":2,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"12"}]',N'Information','2022-08-11 23:59:37.120',NULL UNION ALL
select 3002,N'[{"BillId":3,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"1"}]',N'Information','2022-08-12 12:56:33.397',NULL UNION ALL
select 3003,N'[{"BillId":3,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"1"}]',N'Information','2022-08-12 13:00:06.107',NULL UNION ALL
select 3004,N'[{"BillId":3,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"1"}]',N'Information','2022-08-12 13:00:39.557',NULL UNION ALL
select 3005,N'[{"BillId":3,"Amount":200,"CreditCardNumber":"1234123412341234","Cvc":"1"}]',N'Information','2022-08-12 13:04:22.727',NULL UNION ALL
select 3006,N'{ error = Validation failed: 
 -- Cvc: Cvc must be 3 numbers. Severity: Error, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:11:02.523',NULL UNION ALL
select 3007,N'{ error = Validation failed: 
 -- Cvc: Cvc must be 3 numbers. Severity: Error, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:11:20.937',NULL UNION ALL
select 3008,N'{ error = Object reference not set to an instance of an object., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:26:18.140',NULL UNION ALL
select 3009,N'{ error = Object reference not set to an instance of an object., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:28:00.577',NULL UNION ALL
select 3010,N'{ error = ''User Password'' must be 6 characters in length. You entered 4 characters., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:41:31.087',NULL UNION ALL
select 3011,N'{ error = JobStorage.Current property value has not been initialized. You must set it before using Hangfire Client or Server API., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:41:53.803',NULL UNION ALL
select 3012,N'{ error = This email is already registered., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:42:20.180',NULL UNION ALL
select 3013,N'{ error = JobStorage.Current property value has not been initialized. You must set it before using Hangfire Client or Server API., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 13:47:19.893',NULL UNION ALL
select 3014,N'{ error = Validation failed: 
 -- CreditCardNumber: Credit card must be 16 numbers. Severity: Error
 -- Cvc: Cvc must be 3 numbers. Severity: Error, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 14:22:06.130',NULL UNION ALL
select 3015,N'{ error = Validation failed: 
 -- CreditCardNumber: Credit card must be 16 numbers. Severity: Error
 -- Cvc: Cvc must be 3 numbers. Severity: Error, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 14:39:20.127',NULL UNION ALL
select 3016,N'{ error = There is no record in this id in the database., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:03:21.040',NULL UNION ALL
select 3017,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the key value ''{Id: 2003}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:03:52.430',NULL UNION ALL
select 3018,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the key value ''{Id: 2004}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:04:34.687',NULL UNION ALL
select 3019,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the key value ''{Id: 2004}'' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:05:14.857',NULL UNION ALL
select 3020,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:09:12.827',NULL UNION ALL
select 3021,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:16:43.350',NULL UNION ALL
select 3022,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:19:28.473',NULL UNION ALL
select 3023,N'{ error = The instance of entity type ''Apartment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 15:21:11.293',NULL UNION ALL
select 3024,N'{ error = Object reference not set to an instance of an object., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 16:04:08.243',NULL UNION ALL
select 3025,N'{ error = Validation failed: 
 -- CreditCardNumber: Credit card must be 16 numbers. Severity: Error, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 16:18:49.410',NULL UNION ALL
select 3026,N'{ error = Validation failed: 
 -- CreditCardNumber: Credit card must be 16 numbers. Severity: Error, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 16:20:14.793',NULL UNION ALL
select 3027,N'{ error = This apartment is already registered., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 17:41:22.140',NULL UNION ALL
select 3028,N'{ error = This user already has an apartment., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 17:42:56.877',NULL UNION ALL
select 3029,N'{ error = This apartment is already registered., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 19:32:51.780',NULL UNION ALL
select 3030,N'{ error = This user already has an apartment., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 19:33:28.190',NULL UNION ALL
select 3031,N'{ error = there is already an invoice for this date, innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 19:40:55.860',NULL UNION ALL
select 3032,N'{ error = This email is already registered., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 19:42:15.667',NULL UNION ALL
select 3033,N'{ error = Block no must be between 1 and 5., innerException = , statusCode = InternalServerError }',N'Error','2022-08-12 19:43:16.387',NULL;

set identity_insert [Logs] off;