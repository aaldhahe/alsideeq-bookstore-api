-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: alsideeq-bookstore-instance.clslxbbfn4dw.us-east-2.rds.amazonaws.com    Database: Alsideeq_BookStore_DB
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED='';

--
-- Table structure for table `Customer`
--

DROP TABLE IF EXISTS `Customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Customer` (
  `customer_id` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `phone` varchar(50) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `pwd` varchar(50) NOT NULL,
  `address_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`customer_id`),
  UNIQUE KEY `username` (`username`),
  KEY `address_id` (`address_id`),
  CONSTRAINT `Customer_ibfk_1` FOREIGN KEY (`address_id`) REFERENCES `Address` (`address_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Customer`
--

LOCK TABLES `Customer` WRITE;
/*!40000 ALTER TABLE `Customer` DISABLE KEYS */;
INSERT INTO `Customer` VALUES ('00516282-2e03-4a07-8c27-4f07f3e750ff','aaldhaher8613','Ali','Eljahmi','231-989-9999','eljahmi@gmail.com','blahblah','66c83240-8d05-444c-9eda-a8bb07f8ab30'),('02ab4b76-18d4-464c-9d27-a4a4d2c71d4d','aaldhaher6862','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','blahblah','6795e82a-e112-4cca-a04f-4ed584d40880'),('13566f1c-6dc0-4bc2-9e73-f94ffd0d83ac','aaldhaher4962','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','YN5Bef24NqRZswSs1tEJqEIB44PtmKbCYUGF3libIQA=','f6b8fb1b-fabb-4453-bd53-2ede8fb7b01a'),('176ed5ed-5362-4577-8cd8-d74ca928255b','test13','test12F','test12L','','testing1234@gmail.com','????\0???	???B~','208316bb-1723-4a82-abdc-7909d99be853'),('18feb37c-0444-4c31-ab84-5d5636b67392','aaldhaher1519','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','rKV129Ese25tKAVBZy04Qq8rCwDocqKcfeYF6saoRyk=','052a4c6d-1329-441d-9de0-a0911a308246'),('1c79cd07-346a-4873-9ee5-b00089631782','aaldhaher5507','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','779184a0-7adc-433b-9889-492458d62617'),('1e778f02-80b9-4d3e-94ec-a7b1e4b259d9','aaldhaher9648','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','660leSUK04h7xMqm2zimSIyFru6ByujddKob40hYnMY=','16086e04-dd03-4f38-9df0-3f5a56bcfd61'),('1f6722ec-6c4d-4042-8977-1db14266ba79','aaldhaher9245','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','39bf1db9-9d50-4804-b88b-e0322bc4d419'),('20764958-ef0c-4a47-afaa-59793b27618b','aaldhaher2419','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','d3320427-e528-4c3e-b95c-1d6cc3e434c5'),('24acba5d-9212-4e62-9769-6a8cf7f9c7a3','aaldhaher5329','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','blahblah','619275e5-0ea1-4b76-88a3-404c586c8030'),('26ecd87d-a831-424d-bb2e-63b3154eb6ad','aaldhaher8287','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','ccb1a934-37fd-4387-98cc-030f9c6fc4d6'),('277c9879-14c1-447a-a7d3-4693bc5b3936','aaldhaher2602','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','blahblah','21916487-a460-4a95-95f9-71089a35dd60'),('2928413a-491b-48a5-a778-5f9f7291d433','aaldhaher5479','Ahmed','Abdofara','313-232-2323','aaabofara@gmail.com','???Dn$??;?0???','eac41a62-c1ab-4983-a30b-163ce462d589'),('2ae874f0-4d4e-4056-a09d-cb9b3b70d549','aaldhaher9435','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','9491215c-5686-45ab-9329-d68dc78daa4f'),('33a17a77-5b91-402c-b964-0f4b58b9e521','aaldhaher2935','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','750c7d17-eed1-4ac2-953b-cbb701ee635e'),('382e7c49-01a2-4486-abfb-f33691107b66','aaldhaher3025','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','3oP8FMm21WrHVG0h0ssJ2Unnp9Po8Z79clToyi48eCc=','3e3e6a2f-8948-462a-8aa9-d02f2eca7328'),('38f6acb7-5f67-45ea-9bc3-22bed1b65714','aaldhaher4357','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','373c3e4f-b8bb-4e30-97a4-78726a584dae'),('40b72a65-6086-49eb-ace2-aefbe66b1338','aaldhaher4610','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','a9affe62-ef0f-4258-a40e-e5d1ad529af5'),('4261c9a7-a010-475c-ad49-f1005a37725b','aaldhaher9645','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','369a1b48-34fc-420f-8b16-a6d4c8208499'),('471638f1-7245-4728-b2c7-8d6507b7e612','anotherTest2345467','test12F','test12L','','testing1234@gmail.com',' ,?b?Y[?K-#Kp','176962bc-53f6-44d8-97ae-cc6da142f2e5'),('47a5fc0d-83bd-42ec-9201-74db8b4ed0f4','aaldhaher1140','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','c781314a-bc4d-4134-a578-4f3fff7d98a9'),('4a148242-154c-4c78-8f44-5943cf6cf462','aaldhaher1725','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','e9d78c25-ca91-4d1d-b676-1104f3e89c11'),('4ac44265-3b7c-4449-a7f5-358a229d3e9f','aaldhaher5741','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','17b9yUVZDkPnNU/F2oRYyHWWazqH+ODGC0u6l1tpl4w=','c70570f8-8492-461f-b225-75adb1b124f9'),('4eef32cc-3255-4dd5-b7b8-a6d0d8048b03','testing234','test234F','test234L','','testing1234@gmail.com',' ,?b?Y[?K-#Kp','f1ddac41-bf80-4313-a111-9e20f842949c'),('50de98c5-37ce-493f-a33f-c6c4aef52560','aaldhaher2375','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','50e0f116-c2e9-4e52-9d0f-8d562f9968c0'),('55d5110d-075e-4a82-9bb8-a1ac7b1869b8','aaldhaher4607','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','86HD1Wo9S5YsG4n0aHDcq+2jqkwD2pOEN5y4H+ilgwk=','aa253ee3-5122-4897-a747-5f92bff7665a'),('55fe2c09-14b6-4a72-8ce4-d566ce273baf','aaldhaher5687','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','blahblah','0ed59162-f7ff-4f23-8a05-3677dbc8d884'),('5992345f-ebcb-4b09-b45b-5044fe08ad22','aaldhaher5508','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','uEj7cL4PwDndNFKG+KSnZdpsUjNZuwtCkPrkGrd9Xeg=','0ec7e390-0946-4b2c-976f-8f8bd681309d'),('5a32a64c-dad1-4623-baff-aecc699101b5','aaldhaher2506','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','iL9SkLnLoFZ+r19vEjsqAwElbUbJokEGmcQNbNCcEOw=','7226bee5-d934-4cdb-8a3d-f3352146e020'),('5ab87e6a-5313-415b-8eb8-160270bc4072','aaldhaher5613','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','blahblah','254da359-74e3-4103-98f7-a5b0a4d96e83'),('5ad336b6-649f-493d-9a09-fd1512c874f3','aaldhaher5005','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','POQW/4rKI2a7FRaa+IAo31WxiR0U+19DcFjYjB5cG90=','e0026593-acfc-4daf-923f-18a0f73f737c'),('63f16f4d-5f70-4388-92c3-f13309a03799','test11','test11F','test11L','','','????R?M?\06??1>?U','4b08fc78-f158-4506-b5c6-7ab1ffa2f9f3'),('66dce603-5968-481f-863a-786d4a698216','anotherTest678','TestingFName','TestingLName','','testing1234@gmail.com','??Y:?3?g??d?\0','a4becf39-9eff-4147-b9a8-c567031a970e'),('7ae6f403-aece-4a47-8e4f-f098f8084c08','test12','test12F','test12L','','testing1234@gmail.com',' ,?b?Y[?K-#Kp','890acadb-d328-4e77-ae3d-98e7faf7f789'),('7f37409e-99f1-46d5-981b-19268dc825fc','another2Test','TestingFName','TestingLName','','testing1234@gmail.com','????\0???	???B~','b4b26c7f-ae8c-4849-8b74-36606bbd8ec2'),('820de135-e8d3-4d60-8e8f-a55da6e760a3','anotherTest11','TestingFName2','TestingLName2','','testing1234@gmail.com','????R?M?\06??1>?U','1db5bc0c-e67e-4978-8761-68971bee2d8d'),('83f029f0-4266-4823-9391-366ec42f08a2','aaldhaher2877','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','bb232f15-dd8f-48b2-a3e4-3d37baff1c60'),('86eea291-5ee6-44f9-bf6a-96fbbb2d5b66','anotherTest123','TestingFName2','TestingLName2','','testing1234@gmail.com',' ,?b?Y[?K-#Kp','5bbced88-6a9f-4600-a718-49b9e5a8f316'),('88283c4d-6213-4def-b324-9a3cd495814e','aaldhaher2541','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','92c26a18-2bfe-4c06-aa7c-00ef90915a7b'),('8b2502b7-6466-445c-8d98-4940ee7e8777','anotherTest','another ','test','212','sjisjidfg@gsg.com','?|???plL4?h??N{','2175206d-fff3-4d88-ba56-2f2bd63fd865'),('929fd9da-8e22-4270-971e-62700aef93e2','aaldhaher6067','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','d547ad34-8822-455a-8151-4662a866172b'),('94116147-fbdd-4bf1-9819-e52fe4d19d9e','','','','1234','','????\0???	???B~','2b9be56f-84ff-42d2-b463-452b99b577db'),('9530315a-9bdb-43de-9742-4169555a2a7c','aaldhaher3067','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','B?????????????','0bad4bb6-a2ee-4512-8c57-8a1e73c6df73'),('9c6246e7-a4d0-468e-81e8-e50b1eef497c','aaldhaher8389','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','b4215c6f-d922-4646-bc92-1f623c611d25'),('9f0004d9-2480-4c80-9ac3-087f40346c2a','aaldhaher3681','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','Wl8xY67zEGNNapY8PxeMpaP8aT1usFCYXbsz/00hsHE=','d78c0857-afe2-4108-9551-54f610ff52fb'),('b5b61f9c-491f-400d-b691-e64edc929990','aaldhaher2272','ahmed','Aldhaheri','123-123-1231','aaldhahe@umich.edu','???Dn$??;?0???','9bb19b10-cbec-41ae-9c52-db0d131ec8db');
/*!40000 ALTER TABLE `Customer` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-05 21:46:18
